import customtkinter as ctk
import tkinter as tk
from tkinter import ttk, messagebox
from tkinter import font as tkFont
from scapy.all import ARP, Ether, srp
import ipaddress
import threading
from queue import Queue
import time
import socket
import struct
import platform
import subprocess
from openpyxl import Workbook
import psutil
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import matplotlib.pyplot as plt

ctk.set_appearance_mode("Light")
ctk.set_default_color_theme("green")

stop_flag = threading.Event()  # Global stop flag

def get_local_ip_range():
    try:
        hostname = socket.gethostname() 
        print(hostname)
        local_ip = socket.gethostbyname(hostname)
        print(local_ip)
        subnet_mask = socket.inet_ntoa(struct.pack('!L', (1 << 32) - (1 << (32 - 24))))
        ip_parts = local_ip.split('.')
        subnet_parts = subnet_mask.split('.')
        network_parts = [str(int(ip_parts[i]) & int(subnet_parts[i])) for i in range(4)]
        network_address = '.'.join(network_parts)
        network = ipaddress.ip_network(f"{network_address}/24", strict=False)
        ip_range = f"{network.network_address}-{network.network_address + (network.num_addresses - 1)}"
        return str(ip_range)
    except Exception as e:
        print(f"Failed to get local IP range: {e}")
        return ""

def expand_ip_range(ip_range):
    ip_list = []
    try:
        for ip_block in map(str.strip, ip_range.split(',')):
            if '-' in ip_block:
                start_ip, end_ip = ip_block.split('-')
                if '.' not in end_ip:
                    base_ip = start_ip.rsplit('.', 1)[0]
                    end_ip = f"{base_ip}.{end_ip}"
                start_ip_int = int(ipaddress.IPv4Address(start_ip))
                end_ip_int = int(ipaddress.IPv4Address(end_ip))
                ip_list.extend(str(ipaddress.IPv4Address(ip_int)) for ip_int in range(start_ip_int, end_ip_int + 1))
            else:
                ip_list.append(ip_block)
        if len(ip_list) == 0:  # Fix condition
            messagebox.showerror(title="Error", message="Please enter a valid address!")
        return ip_list
    except:
        messagebox.showerror(title="Error", message="Please enter a valid address!")

def get_device_name(ip_address):
    try:
        name = socket.getfqdn(ip_address) #Fully Qualified Domain Name
        return name if name else "Unknown"
    except Exception as e:
        return f"Error: {e}"

def scan_network(ip_list, update_progress):
    devices = []
    try:
        queue = Queue()
        for ip in ip_list:
            queue.put(ip)

        def worker():
            while not queue.empty() and not stop_flag.is_set():
                ip = queue.get()
                if stop_flag.is_set():
                    break
                devices.extend(scan_single_ip(ip))
                queue.task_done()
                update_progress()  # Update progress after scanning each IP

        num_threads = 20
        threads = []
        for _ in range(num_threads):
            thread = threading.Thread(target=worker)
            thread.start()
            threads.append(thread)

        for thread in threads:
            thread.join()
    except Exception as e:
        print(f"Failed to scan network: {e}")
    return devices

def scan_single_ip(ip):
    if stop_flag.is_set():  # Early exit if stop flag is set
        return []
    arp = ARP(pdst=ip)
    ether = Ether(dst="ff:ff:ff:ff:ff:ff")
    packet = ether/arp
    result = srp(packet, timeout=1, verbose=0)[0]
    devices = [{'ip': received.psrc, 'mac': received.hwsrc} for sent, received in result]
    return devices

def ping(ip, count=2):
    param = "-n" if platform.system().lower() == "windows" else "-c"
    command = ["ping", param, str(count), ip]
    try:
        ping_times = []
        for i in range(count):
            if stop_flag.is_set():  # Early exit if stop flag is set during ping
                return "Stopped"
            start_time = time.time()
            response = subprocess.run(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
            end_time = time.time()
            if response.returncode == 0:
                ping_time = (end_time - start_time) * 1000  # Convert to milliseconds
                ping_times.append(ping_time)
        if ping_times:
            avg_ping = sum(ping_times) / len(ping_times)
            return f"{avg_ping:.2f} ms"
        else:
            return "Unreachable"
    except Exception as e:
        return f"Error: {str(e)}"

def start_scan():
    if scan_button.cget('text') == "Scan Network":
        stop_flag.clear()
        ip_range = ip_range_entry.get()
        ip_list = expand_ip_range(ip_range)
        total_ips = len(ip_list)
        if total_ips == 0:
            return

        progress_bar.set(0)  # Reset progress bar to 0

        scan_button.configure(text="Stop Scan", command=stop_scan)

        def update_progress():
            nonlocal scanned_ips
            scanned_ips += 1
            progress_value = scanned_ips / total_ips
            root.after(0, progress_bar.set, progress_value)  # Update progress bar

        def scan_thread():
            devices = scan_network(ip_list, update_progress)
            total_device = len(devices)
            root.after(0, clear_results)
            progress_bar.set(0)

            #index store position of the device in the list
            #device store device info exp: ip and mac
            for index, device in enumerate(devices):
                if stop_flag.is_set():
                    break
                device_name = get_device_name(device['ip'])
                ping_time = ping(device['ip'], count=2)

                nonlocal scanned_device
                scanned_device += 1
                progress_value = scanned_device / total_device
                root.after(0, progress_bar.set, progress_value)

                root.after(0, lambda idx=index, dev=device, ping_time=ping_time, device_name=device_name: 
                        tree.insert('', 'end', values=(idx + 1, device_name, dev['mac'], dev['ip'], ping_time)))

            root.after(0, reset_scan_button)

        scanned_ips = 0  # Track the number of scanned IPs
        scanned_device = 0  # Track the number of scanned devices
        t = threading.Thread(target=scan_thread)
        t.daemon = True
        t.start()
    else:
        stop_scan()

def on_tree_select(event):
    selected_item = tree.selection()
    if selected_item:
        # Get selected row's values from the first treeview
        item_values = tree.item(selected_item[0], 'values')
        
        stv.item(0, text=f"Status: Active")
        stv.item(1, text=f"Device Name: {item_values[1]}")
        stv.item(2, text=f"IP Address: {item_values[3]}")
        stv.item(3, text=f"MAC Address: {item_values[2]}")
        stv.item(4, text=f"Ping: {item_values[4]}")

def update_cpu_ram_plot():
    for widget in monitor_tab.winfo_children():
        widget.destroy()

    cpu_data = []
    ram_data = []

    fig, ax = plt.subplots(2, 1, figsize=(5, 3))
    fig.suptitle('CPU and RAM Usage')

    canvas = FigureCanvasTkAgg(fig, master=monitor_tab)
    canvas.get_tk_widget().pack(side=tk.TOP, fill=tk.BOTH, expand=1)

    def animate():
        while True:
            cpu_data.append(psutil.cpu_percent())
            ram_data.append(psutil.virtual_memory().percent)

            if len(cpu_data) > 60:
                cpu_data.pop(0)
                ram_data.pop(0)

            ax[0].clear()
            ax[1].clear()

            ax[0].plot(cpu_data, label=f'CPU %: {cpu_data[-1]:.1f}%' if cpu_data else 'CPU %')
            ax[0].set_ylim(0, 100)
            ax[0].set_ylabel("CPU Usage (%)")
            ax[0].legend()


            ax[1].plot(ram_data, label=f'RAM %: {ram_data[-1]:.1f}%', color='green')
            ax[1].set_ylabel("RAM Usage (%)")
            ax[1].set_ylim(0, 100)
            ax[1].legend()
            canvas.draw()

            time.sleep(1)

    threading.Thread(target=animate, daemon=True).start()

def stop_scan():
    stop_flag.set()
    reset_scan_button()

def reset_scan_button():
    scan_button.configure(text="Scan Network", command=start_scan)
    # progress_bar.configure(value=0)

def clear_results():
    for row in tree.get_children():
        tree.delete(row)
    reset_stv()

def reset_stv():
    stv.item(0, text=f"Status:")
    stv.item(1, text=f"Device Name:")
    stv.item(2, text=f"IP Address:")
    stv.item(3, text=f"MAC Address:")
    stv.item(4, text=f"Ping:")

def put_into_entry():
    selected_class = ip_class.get()
    ip_range_entry.delete(0, tk.END)

    if selected_class == "A":
        ip_range_entry.insert(0, "1.0.0.0/8")
    elif selected_class == "B":
        ip_range_entry.insert(0, "128.0.0.0/16")
    elif selected_class == "C":
        ip_range_entry.insert(0, "192.0.0.0/24")

def export_results_excel():
    if not tree.get_children():
        messagebox.showerror("Export Error", "No data available to export!")
        return

    workbook = Workbook()
    sheet = workbook.active
    sheet.append(["#", "Device Name", "MAC Address", "IP Address", "Ping Status"])

    for row in tree.get_children():
        values = tree.item(row)['values']
        sheet.append(values)

    workbook.save("network_scan_results.xlsx")
    messagebox.showinfo("Export Results", "Results exported successfully as 'network_scan_results.xlsx'.")

# Callback Functions
def on_exit():
    # root.quit()  # Exits the application
    stop_flag.set()  # Stop all background threads
    root.quit()

def show_about():
    messagebox.showinfo("About", "Network Scanner v1.0\nCreated by Xanakone Siphanthong, Đặng Văn Cường")

# Create the main application window
appWidth, appHeight = 800, 700
root = ctk.CTk()
root.title("Network Scanner")
root.geometry(f"{appWidth}x{appHeight}")
root.minsize(appWidth, appHeight)

detected_ip_range = get_local_ip_range()

# Create a style object
style = ttk.Style()

# Customize the tabs in the Notebook
style.configure("TNotebook.Tab", font=('Helvetica', 11, 'bold'), padding=[0, 0], background="lightblue", foreground="gray")
style.map("TNotebook.Tab", background=[("selected", "green")], foreground=[("selected", "black")])

# Create the tab control
tab_control = ttk.Notebook(root, takefocus=False)

# Create tabs
network_tab = ttk.Frame(tab_control)
monitor_tab = ttk.Frame(tab_control)

# Add tabs to the tab control
tab_control.add(network_tab, text="Network Scanner")
tab_control.add(monitor_tab, text="System Monitor")

# Pack the tab control to fill the window
tab_control.pack(expand=True, fill="both")

# Menu bar setup
menu_bar = tk.Menu(root)

# File menu
file_menu = tk.Menu(menu_bar, tearoff=0, font=('Helveti', 11))
file_menu.add_command(label="Exit", command=on_exit)
file_menu.add_command(label="Export", command=export_results_excel)
menu_bar.add_cascade(label="File", menu=file_menu)

# Help menu
help_menu = tk.Menu(menu_bar, tearoff=0, font=('Helvetica', 11))
help_menu.add_command(label="About", command=show_about)
menu_bar.add_cascade(label="Help", menu=help_menu)

# Setting the menu bar
root.config(menu=menu_bar)

# Create frames for better organization
frame_controls = ctk.CTkFrame(network_tab)
frame_controls.pack(pady=(10, 0), padx=10, fill='x')

frame_results = ctk.CTkFrame(network_tab)
frame_results.pack(pady=(5, 10), padx=10, fill='both', expand=True)

# Control Buttons
scan_button = ctk.CTkButton(frame_controls, text="Scan Network", command=start_scan)
scan_button.grid(row=0, column=0, padx=5, pady=5, sticky="w")

clear_button = ctk.CTkButton(frame_controls, text="Clear Results", command=clear_results)
clear_button.grid(row=1, column=0, padx=5, pady=5, sticky="w")

# Select IP Label
Select_IP_LB = ctk.CTkLabel(frame_controls, text="Select IP range class:")
Select_IP_LB.grid(row=2, column=0, padx=5, pady=5, sticky="w")

# Create a shared StringVar to hold the selected IP class
ip_class = tk.StringVar(value="C")
# IP classes Radio Buttons
radio_a = ctk.CTkRadioButton(frame_controls, text="Class A", variable=ip_class, value="A", command=put_into_entry)
radio_a.grid(row=3, column=0, padx=15, pady=5, sticky="w")
radio_b = ctk.CTkRadioButton(frame_controls, text="Class B", variable=ip_class, value="B", command=put_into_entry)
radio_b.grid(row=3, column=0, padx=115, pady=5, sticky="w")

radio_c = ctk.CTkRadioButton(frame_controls, text="Class C", variable=ip_class, value="C", command=put_into_entry)
radio_c.grid(row=3, column=0, padx=210, pady=5, sticky="w")

# Enter IP Label
Enter_ip_LB = ctk.CTkLabel(frame_controls, text="Or Enter IP range:")
Enter_ip_LB.grid(row=4, column=0, padx=5, pady=5, sticky="w")
 
# Entry IP range Field
ip_range_entry = ctk.CTkEntry(frame_controls, placeholder_text="Example: 192.168.0.0-192.168.255.255")
ip_range_entry.grid(row=5, column=0, columnspan=3, padx=5, pady=5, sticky="ew")
ip_range_entry.insert(0, detected_ip_range)

# Progress bar
progress_bar = ctk.CTkProgressBar(master=frame_controls, mode='determinate', height=30, corner_radius=3)
progress_bar.grid(row=6, column=0, columnspan=3, padx=5, pady=5, sticky="ew")
progress_bar.set(0)

# Configure columns in frame_controls to expand
frame_controls.columnconfigure(0, weight=1)
frame_controls.columnconfigure(1, weight=1)
frame_controls.columnconfigure(2, weight=1)

# Create a font object
custom_font = tkFont.Font(family="Times New Roman", size=13)

# Treeview style
style = ttk.Style()
style.configure("Treeview", font=custom_font)
style.configure("Treeview.Heading", font=custom_font)
style_stv = ttk.Style()
style_stv.configure("STV.Treeview", rowheight=30)

# Treeview for results
columns = ("#", "Device Name", "MAC Address", "IP Address", "Ping Status")
tree = ttk.Treeview(frame_results, columns=columns, show='headings')

tree.heading("#", text="#")
tree.column("#", width=50, anchor='center', stretch=False)

tree.heading("Device Name", text="Device Name")
tree.column("Device Name", width=120, anchor='w', stretch=True)

tree.heading("MAC Address", text="MAC Address")
tree.column("MAC Address", width=120, anchor='w', stretch=True)

tree.heading("IP Address", text="IP Address")
tree.column("IP Address", width=120, anchor='w', stretch=True)

tree.heading("Ping Status", text="Ping Status")
tree.column("Ping Status", width=120, anchor='w', stretch=True)

tree.pack(padx=5, pady=5, fill='both', expand=True)

# Additional information treeview
stv = ttk.Treeview(frame_results, style="STV.Treeview")
stv.heading('#0', text='Information', anchor=tk.W)
stv.heading('#0', text='Information', anchor=tk.W)
stv.insert('', tk.END, text='Status:', iid=0, open=False)
stv.insert('', tk.END, text='Device Name:', iid=1, open=False)
stv.insert('', tk.END, text='IP Address:', iid=2, open=False)
stv.insert('', tk.END, text='MAC Address:', iid=3, open=False)
stv.insert('', tk.END, text='Ping:', iid=4, open=False)

# Use the custom font for additional information treeview
stv.pack(padx=5, pady=5, fill='both', expand=False)
stv.configure(height=5)
frame_results.update_idletasks()  # Update the frame before getting the size
stv_height = 165
stv.pack_propagate(0)  # Prevent Treeview from changing the frame's size
frame_results.configure(height=stv_height)
tree.bind("<<TreeviewSelect>>", on_tree_select)

def on_tab_selected(event):
    selected_tab = event.widget.select()
    if selected_tab == str(monitor_tab):
        update_cpu_ram_plot()

# Bind the event when the tab is changed
tab_control.bind("<<NotebookTabChanged>>", on_tab_selected)

# Bind the close window event to the on_exit function
root.protocol("WM_DELETE_WINDOW", on_exit)
# Start the application
root.mainloop()