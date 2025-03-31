using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.Models.Bean;
using PBL3.Models.Bo;

namespace PBL3.View
{
    public partial class AddCustomerForm : Form
    {
        private Bo_CustomerModel boCustomer;
        private CustomerModel selectedCustomer;

        public string UserIDValue
        {
            get { return txtUserID.Text; }
            set { txtUserID.Text = value; }
        }
        public AddCustomerForm()
        {
            InitializeComponent();
            boCustomer = new Bo_CustomerModel();
            selectedCustomer = null;
        }

        private void LoadCustomerData()
        {
            dataGridView1.DataSource = boCustomer.GetAllCustomers();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["DateOfBirth"].Value != null)
                {
                    DateTime dateOfBirth = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                    row.Cells["Age"].Value = CalculateAge(dateOfBirth);
                }
            }
        }

        private void PopulateSearchComboBox()
        {
            // Thêm các trường của Customer vào ComboBox
            List<string> searchFields = new List<string> { "CustomerID", "FirstName", "LastName", "Email", "PhoneNumber", "UserID", "Address" };
            cboSearchField.DataSource = searchFields;
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void DisplaySelectedCustomer()
        {
            if (selectedCustomer != null)
            {
                txtCustomerID.Text = selectedCustomer.CustomerID;
                txtFirstName.Text = selectedCustomer.FirstName;
                txtLastName.Text = selectedCustomer.LastName;
                txtEmail.Text = selectedCustomer.Email;
                txtPhoneNumber.Text = selectedCustomer.PhoneNumber;
                txtUserID.Text = selectedCustomer.UserID.ToString();
                txtAddress.Text = selectedCustomer.Address;
                chkGender.Checked = selectedCustomer.Gender;
                numAge.Value = selectedCustomer.Age;
                dateTimePickerDOB.Value = selectedCustomer.DateOfBirth;
            }
        }

        private void dataGridViewCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedCustomer = new CustomerModel
                {
                    CustomerID = row.Cells["CustomerID"].Value.ToString(),
                    FirstName = row.Cells["FirstName"].Value.ToString(),
                    LastName = row.Cells["LastName"].Value.ToString(),
                    Email = row.Cells["Email"].Value.ToString(),
                    PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                    UserID = (int)row.Cells["UserID"].Value,
                    Address = row.Cells["Address"].Value.ToString(),
                    Gender = Convert.ToBoolean(row.Cells["Gender"].Value),
                    Age = Convert.ToInt32(row.Cells["Age"].Value),
                    DateOfBirth = Convert.ToDateTime(row.Cells["DateOfBirth"].Value)
                };

                DisplaySelectedCustomer();
            }
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
            PopulateSearchComboBox();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Calculate age
            DateTime dateOfBirth = dateTimePickerDOB.Value;
            int age = CalculateAge(dateOfBirth);

            // Create new customer
            CustomerModel newCustomer = new CustomerModel
            {
                CustomerID = txtCustomerID.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                UserID = int.Parse(txtUserID.Text), // Convert from string to int
                Address = txtAddress.Text,
                Gender = chkGender.Checked,
                Age = age,
                DateOfBirth = dateOfBirth
            };

            // Add new customer to the database
            if (boCustomer.AddCustomer(newCustomer))
            {
                MessageBox.Show("Customer added successfully.");
            }
            else
            {
                MessageBox.Show("An error occurred while adding the customer.");
            }
            LoadCustomerData(); // Refresh DataGridView
            ClearFields();      // Clear input fields
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtUserID.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            chkGender.Checked = false;
            numAge.Value = 0;
            dateTimePickerDOB.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Calculate age
            DateTime dateOfBirth = dateTimePickerDOB.Value;
            int age = CalculateAge(dateOfBirth);

            // Update selected customer
            selectedCustomer.CustomerID = txtCustomerID.Text;
            selectedCustomer.FirstName = txtFirstName.Text;
            selectedCustomer.LastName = txtLastName.Text;
            selectedCustomer.Email = txtEmail.Text;
            selectedCustomer.PhoneNumber = txtPhoneNumber.Text;
            selectedCustomer.UserID = int.Parse(txtUserID.Text); // Convert from string to int
            selectedCustomer.Address = txtAddress.Text;
            selectedCustomer.Gender = chkGender.Checked;
            selectedCustomer.Age = age;
            selectedCustomer.DateOfBirth = dateOfBirth;

            // Update customer in the database
            if (boCustomer.UpdateCustomer(selectedCustomer))
            {
                MessageBox.Show("Customer information updated successfully.");
                LoadCustomerData(); // Refresh DataGridView
                ClearFields();      // Clear input fields
            }
            else
            {
                MessageBox.Show("An error occurred while updating customer information.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Thực hiện xóa khách hàng được chọn
                if (boCustomer.DeleteCustomer(selectedCustomer.CustomerID))
                {
                    MessageBox.Show("Xóa khách hàng thành công.");
                    LoadCustomerData(); // Load lại dữ liệu để cập nhật DataGridView
                    ClearFields();   // Xóa trắng các trường nhập liệu
                    selectedCustomer = null; // Đặt lại selectedCustomer về null sau khi xóa
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa khách hàng.");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchField = cboSearchField.SelectedItem.ToString();
            string searchValue = txtSearchValue.Text;

            // Kiểm tra nếu trường tìm kiếm không được chọn hoặc giá trị tìm kiếm rỗng
            if (string.IsNullOrEmpty(searchField) || string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng chọn trường tìm kiếm và nhập giá trị cần tìm.");
                return;
            }

            // Tìm kiếm theo giá trị được chọn trong ComboBox và giá trị trong TextBox
            List<CustomerModel> searchResult = boCustomer.SearchCustomer(searchField, searchValue);
            dataGridView1.DataSource = searchResult;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại và mở lại form đăng nhập
                this.Close();
                AdminForm form = new AdminForm();
                form.Show();
            }
        }

        //private void AddCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    AdminForm adminForm = new AdminForm();
        //    adminForm.Show();
        //}
    }
}