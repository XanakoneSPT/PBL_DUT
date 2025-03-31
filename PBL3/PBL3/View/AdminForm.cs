using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.Model.Bean;
using PBL3.Model.Bo;
using PBL3.Model.Dao;
using PBL3.Models.Bo;


namespace PBL3.View
{
    public partial class AdminForm : Form
    {
        private Bo_AccountModel boAccount;
        private Bo_StaffModel boStaff;
        private Bo_CustomerModel boCustomer;
        private List<AccountModel> searchResult;
        public AdminForm()
        {
            InitializeComponent();
            dbConnection connection = new dbConnection();
            boAccount = new Bo_AccountModel(connection);
            boStaff = new Bo_StaffModel();
            boCustomer = new Bo_CustomerModel();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            cmbSearchBy.Items.AddRange(new string[] { "UserID", "Username", "Password", "UserType" });

            // Chọn mặc định trường tìm kiếm là "UserID"
            cmbSearchBy.SelectedIndex = 0;

            LoadAccounts();
        }
        private void LoadAccounts()
        {
            searchResult = new List<AccountModel>();

            // Tìm kiếm các tài khoản có UserType là "Staff" và "Customer"
            List<AccountModel> staffAccounts = boAccount.GetAllAccountsByUserType("Staff");
            List<AccountModel> customerAccounts = boAccount.GetAllAccountsByUserType("Customer");

            // Kết hợp kết quả từ hai danh sách tài khoản vào một danh sách duy nhất
            searchResult.AddRange(staffAccounts);
            searchResult.AddRange(customerAccounts);

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dataGridView.DataSource = searchResult;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Lấy giá trị trường tìm kiếm và giá trị tìm kiếm từ ComboBox và TextBox
            string searchBy = cmbSearchBy.SelectedItem.ToString();
            string searchValue = txtSearchValue.Text;

            // Gọi phương thức tìm kiếm từ lớp Bo_Account
            List<AccountModel> searchResult = boAccount.FindAccounts(searchBy, searchValue);

            // Hiển thị kết quả tìm kiếm, ví dụ: trong một DataGridView
            dataGridView.DataSource = searchResult;
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {

                // Lấy thông tin tài khoản từ dòng được chọn
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Tạo một đối tượng Bean_Account và đưa thông tin vào
                AccountModel selectedAccount = new AccountModel();
                selectedAccount.UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value.ToString());
                selectedAccount.Username = selectedRow.Cells["Username"].Value.ToString();
                selectedAccount.Password = selectedRow.Cells["Password"].Value.ToString();
                selectedAccount.UserType = selectedRow.Cells["UserType"].Value.ToString();

                // Hiển thị thông tin tài khoản lên các TextBox
                txtUsername.Text = selectedAccount.Username;
                txtPassword.Text = selectedAccount.Password;

            }
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchBy = cmbSearchBy.SelectedItem.ToString();
            string searchValue = txtSearchValue.Text;

            // Gọi phương thức tìm kiếm từ lớp Bo_Account
            searchResult = boAccount.FindAccounts(searchBy, searchValue);

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dataGridView.DataSource = searchResult;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                AccountModel newStaffAccount = new AccountModel();
                newStaffAccount.Username = username;
                newStaffAccount.Password = password;

                bool success = boAccount.AddStaffAccount(newStaffAccount);

                if (success)
                {
                    MessageBox.Show("Staff account added successfully.");
                    // Gọi các hàm cần thiết sau khi thêm tài khoản thành công
                }
                else
                {
                    MessageBox.Show("Failed to add staff account. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }

            // Sau khi thêm thành công, làm mới dữ liệu và hiển thị lại danh sách tài khoản
            LoadAccounts();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                AccountModel newCustomerAccount = new AccountModel();
                newCustomerAccount.Username = username;
                newCustomerAccount.Password = password;

                bool success = boAccount.AddCustomerAccount(newCustomerAccount);

                if (success)
                {
                    MessageBox.Show("Customer account added successfully.");
                    // Gọi các hàm cần thiết sau khi thêm tài khoản thành công
                }
                else
                {
                    MessageBox.Show("Failed to add customer account. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
            LoadAccounts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dòng được chọn trong DataGridView
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            // Lấy thông tin tài khoản từ dòng được chọn
            string userID = selectedRow.Cells["UserID"].Value.ToString();
            string currentUsername = selectedRow.Cells["Username"].Value.ToString();
            string currentPassword = selectedRow.Cells["Password"].Value.ToString();
            string currentUserType = selectedRow.Cells["UserType"].Value.ToString();
            // Lấy thông tin mới từ TextBox
            string newUsername = txtUsername.Text;
            string newPassword = txtPassword.Text;

            // Kiểm tra xem đã nhập đủ thông tin mới hay chưa
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem thông tin mới có thay đổi không
            if (newUsername == currentUsername && newPassword == currentPassword)
            {
                MessageBox.Show("Thông tin không có sự thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo một đối tượng Bean_Account mới để cập nhật thông tin
            AccountModel updatedAccount = new AccountModel();
            updatedAccount.UserID = Convert.ToInt32(userID);
            updatedAccount.Username = newUsername;
            updatedAccount.Password = newPassword;
            updatedAccount.UserType = currentUserType;

            bool success = boAccount.UpdateAccount(updatedAccount);

            if (success)
            {
                MessageBox.Show("Account updated successfully.");
                // Cập nhật lại DataGridView hoặc các điều khiển hiển thị dữ liệu
            }
            else
            {
                MessageBox.Show("Failed to update account. Please try again.");
            }
            LoadAccounts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = boAccount.DeleteAccount(userID);
                    string type = selectedRow.Cells["UserType"].ToString();

                    if (type == "Staff")
                    {
                        if (boStaff.DeleteStaffByUserID(userID))
                        {

                           if (success)
                            {
                                MessageBox.Show("Account deleted successfully.");
                                // Cập nhật lại DataGridView hoặc các điều khiển hiển thị dữ liệu
                            }
                           else
                            {
                                MessageBox.Show("Failed to delete account. Please try again.");
                            }
                        }
                    }
                    else if (type == "Customer")
                    {
                        if (boCustomer.DeleteCustomerByUserID(userID))
                         {

                           if (success)
                            {
                                MessageBox.Show("Account deleted successfully.");
                                // Cập nhật lại DataGridView hoặc các điều khiển hiển thị dữ liệu
                            }
                           else
                            {
                                MessageBox.Show("Failed to delete account. Please try again.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
            LoadAccounts();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại và mở lại form đăng nhập
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void AddInfoBT_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản.");
                return;
            }

            // Lấy thông tin của tài khoản được chọn
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            AccountModel selectedAccount = (AccountModel)selectedRow.DataBoundItem;

            if (selectedAccount == null)
            {
                MessageBox.Show("Không thể tìm thấy thông tin của tài khoản được chọn.");
                return;
            }

            // Kiểm tra UserType của tài khoản và mở form tương ứng
            if (selectedAccount.UserType.Equals("Staff", StringComparison.OrdinalIgnoreCase))
            {
                AddStaffForm addstaffForm = new AddStaffForm();
                addstaffForm.UserIDValue = selectedAccount.UserID.ToString();
                addstaffForm.Show();
                this.Hide();
            }
            else if (selectedAccount.UserType.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                AddCustomerForm addcustomerForm = new AddCustomerForm();
                addcustomerForm.UserIDValue = selectedAccount.UserID.ToString();
                addcustomerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản không hợp lệ.");
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
