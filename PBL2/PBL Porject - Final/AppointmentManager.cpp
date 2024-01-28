#include "AppointmentManager.h"
#include "Service.h"
#include "Customer.h"
#include "Bill.h"
#include <iostream>
#include <fstream>
#include <iomanip>
#include <cstring>
#include <limits>
#include <algorithm>
#include <set>

using namespace std;

void AppointmentManager::loadServices() {
    ifstream file("services.txt");

    if (file.is_open()) {
        int value;
        char ServiceName[50];

        while (file >> value >> ServiceName) {
            Service service(value, ServiceName);
            availableServices.push_back(service);
        }

        file.close();
        cout << endl;
        cout << "Services loaded from file." << endl;
    } else {
        cout << "No previous services found." << endl;
    }
}

void AppointmentManager::loadAppointments() {
    appointments.clear();  // Clear existing appointments before loading

    ifstream file("appointments.txt");

    if (!file.is_open()) {
        cout << "Error: Unable to open 'appointments.txt'." << endl;
        return;
    }

    string line;
    while (getline(file, line)) {
        stringstream ss(line);
        string customerName, appointmentTime, date, IDcardnumber, completedStr, servicesStr;

        if (getline(ss, customerName, ',') &&
            getline(ss, appointmentTime, ',') &&
            getline(ss, date, ',') &&
            getline(ss, IDcardnumber, ',') &&
            getline(ss, completedStr, ',') &&
            getline(ss, servicesStr)) {

            // Convert completedStr to a boolean
            bool completed = (completedStr == "1");

            // Parse services and create Appointment object
            list<Service> services;
            istringstream servicesStream(servicesStr);
            int serviceValue;

            while (servicesStream >> serviceValue) {
                services.push_back(Service(serviceValue, ""));
            }

            // Create and add the appointment
            Appointment appointment(customerName.c_str(), appointmentTime.c_str(), date.c_str(), services, IDcardnumber.c_str());
            appointment.setIDnumber(IDcardnumber.c_str());
            appointment.setCompleted(completed);
            appointments.push_back(appointment);
        } else {
            cerr << "Error: Unable to parse line from 'appointments.txt'." << endl;
        }
    }

    file.close();
    cout << "Appointments loaded from file." << endl;
}

void AppointmentManager::displayAppointments() const {
    if (appointments.empty()) {
        cout << "No appointments to display." << endl;
    } else {
        cout << endl;
        cout << "Check the schedule below for the right decision." << endl;
        cout << "Appointments:" << endl;
        cout << "------------------------------------------------------------------------------------------------------------------------------------------------------" << endl;
        cout << setw(7) << left << "No." << setw(15) << "Customer ID" << setw(17) << "Status" << setw(20) << "Customer Name" << setw(15) << "Time" << setw(15) << "Date" << setw(60) << "Services" << endl;
        cout << "------------------------------------------------------------------------------------------------------------------------------------------------------" << endl;

        int appointmentNo = 1;  // Initialize the appointment number

        for (const Appointment& appointment : appointments) {
            cout << setw(7) << left << appointmentNo++
                 << setw(15) << left << appointment.getIDcardNum()
                 << setw(17) << (appointment.isCompleted() ? "Completed" : "Not Complete") 
                 << setw(20) << left << appointment.getCustomerName()
                 << setw(15) << appointment.getAppointmentTime()
                 << setw(15) << appointment.getDate()
                 << " ";

            const list<Service>& services = appointment.getServices();
            if (services.empty()) {
                cout << "No services selected";
            } else {
                bool firstService = true;
                for (const Service& service : services) {
                    if (!firstService) {
                        cout << ", ";
                    }
                    cout << ServiceToString(service);
                    firstService = false;
                }
            }

            cout << endl;
        }
        cout << "------------------------------------------------------------------------------------------------------------------------------------------------------" << endl;
    }
}

void AppointmentManager::bookAppointment(const char* customerName, int customerAge, const char* appointmentTime, const char* date, const char* phoneNumber, const char* IDcardnumber) {
    for (const Appointment& appointment : appointments) {
        if (strcmp(appointment.getAppointmentTime(), appointmentTime) == 0 &&
            strcmp(appointment.getDate(), date) == 0) {
            cout << "An appointment for this time and date has been booked. Please choose another time or date."<< endl;
            return;
        }
    }

    // Display available services
    cout << "Choose services (enter 0 to finish):" << endl;
    for (const Service& service : availableServices) {
        cout << service.getValue() << ". " << service.getName() << endl;
    }

    set<int> selectedServiceValues;  // Use a set to store selected service values
    list<Service> selectedServices;
    int serviceChoice;

    do {
        cout << "Enter your choice (0 to finish): ";
        cin >> serviceChoice;

        // Check if the input is a valid integer
        if (cin.fail()) {
            cin.clear();  // Clear the error flag
            cin.ignore(numeric_limits<streamsize>::max(), '\n');  // Discard invalid input
            cout << "Invalid input. Please enter a valid integer choice." << endl;
        } else {
            cin.ignore(numeric_limits<streamsize>::max(), '\n');  // Discard newline character
            if (serviceChoice >= 1 && serviceChoice <= availableServices.size()) {
                // Check if the service has already been selected
                if (selectedServiceValues.find(serviceChoice) == selectedServiceValues.end()) {
                    auto it = next(availableServices.begin(), serviceChoice - 1);
                    selectedServices.push_back(*it);
                    selectedServiceValues.insert(serviceChoice);  // Add the service to the set
                } else {
                    cout << "You have already selected this service. Choose another service." << endl;
                }
            } else if (serviceChoice != 0) {
                cout << "Invalid service choice." << endl;
            }
        }
    } while (serviceChoice != 0);

    // Check if no services were selected
    if (selectedServices.empty()) {
        cout << "No services selected. Appointment not booked." << endl;
        return;
    }

        // Get customer name
    char customerNameCopy[256];
    strcpy(customerNameCopy, customerName);

    // Get appointment date
    char dateCopy[20];
    strcpy(dateCopy, date);

    // Create a Customer object
    Customer customer(customerNameCopy, customerAge, phoneNumber, IDcardnumber); // Include the 'IDcardnumber' parameter


    // Continue with the appointment booking
    Appointment newAppointment(customerNameCopy, appointmentTime, dateCopy, selectedServices, IDcardnumber);
    newAppointment.setIDnumber(IDcardnumber);  // Set the IC number
    appointments.push_back(newAppointment);

    cout << "Appointment booked successfully! " << endl;
    // Save customer information
    saveAppointments();
    customer.saveCustomerInfo();
}

void AppointmentManager::cancelAppointment(const char* IDcardnumber) {
    for (auto it = appointments.begin(); it != appointments.end(); ++it) {
        if (strcmp(it->getIDcardNum(), IDcardnumber) == 0) {
            appointments.erase(it);
            cout << "Appointment with ID " << IDcardnumber << " has been canceled." << endl;
            saveAppointments();
            return;
        }
    }
    cout << "Appointment with ID " << IDcardnumber << " not found." << endl;
}

void AppointmentManager::saveAppointments() const {
    ofstream file("appointments.txt");

    if (file.is_open()) {
        for (const Appointment& appointment : appointments) {
            const char* serializedData = appointment.serialize();
            file << serializedData << endl;
            delete[] serializedData; // Remember to free memory
        }
        file.close();
        cout << "Appointments saved to file." << endl;
    } else {
        cout << "Unable to open the file for saving appointments." << endl;
    }
}

bool AppointmentManager::generateBillAndMarkAsCompleted(const char* IDcardnumber) {
    for (Appointment& appointment : appointments) {
        if (strcmp(appointment.getIDcardNum(), IDcardnumber) == 0) {
            // Mark the appointment as completed
            appointment.setCompleted(true);

            // Create an instance of the Bill class
            Bill bill(appointment.getCustomerName(), appointment.getAppointmentTime(), 0.0, appointment.getServices());

            // Generate the bill
            bill.generateBillForCustomer(IDcardnumber, appointments);

            // Save the updated appointments to file
            saveAppointments();

            return true;
        }
    }

    cout << "No appointment found for ID: " << IDcardnumber << endl;
    return false;
}

void AppointmentManager::exportAppointmentsByDate(const char* date) const {
    cout << endl;
    cout << "Exported Appointments on " << date << endl;
    cout << "Appointments:" << endl;
    cout << "------------------------------------------------------------------------------------------------------------------------------------------------------" << endl;
    cout << setw(10) << left << "No." << setw(15) << "Customer ID" << setw(17) << "Status" << setw(20) << "Customer Name" << setw(15) << "Time" << setw(15) << "Date" << setw(60) << "Services" << endl;
    cout << "------------------------------------------------------------------------------------------------------------------------------------------------------" << endl;

    int appointmentNo = 1;  // Initialize the appointment number
    int appointmentNoInFile = 1;  // Initialize the appointment number

    for (const Appointment& appointment : appointments) {
        if (strcmp(date, "all") == 0 || strcmp(appointment.getDate(), date) == 0) {
            cout << setw(10) << left << appointmentNo++
                 << setw(15) << left << appointment.getIDcardNum()
                 << setw(17) << (appointment.isCompleted() ? "Completed" : "Not Complete") 
                 << setw(20) << left << appointment.getCustomerName()
                 << setw(15) << appointment.getAppointmentTime()
                 << setw(15) << appointment.getDate()
                 << " ";

            const list<Service>& services = appointment.getServices();
            if (services.empty()) {
                cout << "No services selected";
            } else {
                bool firstService = true;
                for (const Service& service : services) {
                    if (!firstService) {
                        cout << ", ";
                    }
                    cout << ServiceToString(service);
                    firstService = false;
                }
            }

            cout << endl;
        }
    }
    cout << "------------------------------------------------------------------------------------------------------------------------------------------------------" << endl;

    string filename = "exported_appointments_" + string(date);
    replace(filename.begin(), filename.end(), '/', '_');
    filename += ".txt";

    ofstream file(filename);

    if (file.is_open()) {
        file << "Exported Appointments on " << date << endl;
        file << "------------------------------------------------------------------------------------------------------------------------------------------------" << endl;
        file << setw(10) << left << "No." << setw(15) << "Customer ID" << setw(17) << "Status" << setw(15) << "Customer Name" << setw(10) << "Time" << setw(15) << "Date" << setw(60) << "Services" << endl;
        file << "------------------------------------------------------------------------------------------------------------------------------------------------" << endl;

        for (const Appointment& appointment : appointments) {
            if (strcmp(date, "all") == 0 || strcmp(appointment.getDate(), date) == 0) {
                file << setw(10) << left << appointmentNoInFile++
                     << setw(15) << left << appointment.getIDcardNum()
                     << setw(17) << (appointment.isCompleted() ? "Completed" : "Not Complete") 
                     << setw(15) << left << appointment.getCustomerName()
                     << setw(10) << appointment.getAppointmentTime()
                     << setw(15) << appointment.getDate()
                     << " ";

                const list<Service>& services = appointment.getServices();
                if (services.empty()) {
                    file << "No services selected";
                } else {
                    bool firstService = true;
                    for (const Service& service : services) {
                        if (!firstService) {
                            file << ", ";
                        }
                        file << ServiceToString(service);
                        firstService = false;
                    }
                }

                file << endl;
            }
        }
        file << "------------------------------------------------------------------------------------------------------------------------------------------------" << endl;

        cout << "Appointments exported to '" << filename << "' for date " << date << "." << endl;
    } else {
        cout << "Unable to open the file '" << filename << "' for exporting appointments." << endl;
    }
}