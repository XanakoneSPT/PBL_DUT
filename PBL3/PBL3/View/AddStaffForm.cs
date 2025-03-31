using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.Models.Bo;
using PBL3.Model.Bean;

namespace PBL3.View
{
    public partial class AddStaffForm : Form
    {
        private Bo_StaffModel boStaff;
        private StaffModel selectedStaff;
        public string UserIDValue
        {
            get { return txtUserID.Text; }
            set { txtUserID.Text = value; }
        }

        public AddStaffForm()
        {
            InitializeComponent();
            boStaff = new Bo_StaffModel();
            selectedStaff = null;
        }


        private void AddStaffForm_Load(object sender, EventArgs e)
        {
            LoadStaffData();
            PopulateSearchComboBox();
        }

        private void LoadStaffData()
        {
            dataGridView1.DataSource = boStaff.GetAllStaff();
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
            // Thêm các trường của Staff vào ComboBox
            List<string> searchFields = new List<string> { "StaffID", "FirstName", "LastName", "Email", "PhoneNumber", "UserID", "Address", "Position", "Salary" , "StartWorkDate"};
            cboSearchField.DataSource = searchFields;
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void DisplaySelectedStaff()
        {
            if (selectedStaff != null)
            {
                txtStaffID.Text = selectedStaff.StaffID;
                txtFirstName.Text = selectedStaff.FirstName;
                txtLastName.Text = selectedStaff.LastName;
                txtEmail.Text = selectedStaff.Email;
                txtPhoneNumber.Text = selectedStaff.PhoneNumber;
                txtUserID.Text = selectedStaff.UserID.ToString();
                txtAddress.Text = selectedStaff.Address;
                txtPosition.Text = selectedStaff.Position;
                txtSalary.Text = selectedStaff.Salary.ToString();
                chkGender.Checked = selectedStaff.Gender;
                numAge.Value = selectedStaff.Age;
                dateTimePickerDOB.Value = selectedStaff.DateOfBirth;
                dateTimePickerStartWork.Value = selectedStaff.StartWorkDate;
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
            List<StaffModel> searchResult = boStaff.SearchStaff(searchField, searchValue);
            dataGridView1.DataSource = searchResult;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Calculate age
            DateTime dateOfBirth = dateTimePickerDOB.Value;
            int age = CalculateAge(dateOfBirth);

            // Create new staff
            StaffModel newStaff = new StaffModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                UserID = int.Parse(txtUserID.Text), // Convert from string to int
                Address = txtAddress.Text,
                Position = txtPosition.Text,
                Salary = Convert.ToDecimal(txtSalary.Text), // Convert to decimal
                Gender = chkGender.Checked,
                Age = age,
                DateOfBirth = dateOfBirth,
                StartWorkDate = dateTimePickerStartWork.Value
            };

            // Add new staff to the database
            if (boStaff.AddStaffWithAutoGeneratedID(newStaff))
            {
                MessageBox.Show("Staff added successfully.");
            }
            else
            {
                MessageBox.Show("An error occurred while adding the staff.");
            }
            LoadStaffData(); // Refresh DataGridView
            ClearFields();   // Clear input fields
        }

        private void ClearFields()
        {
            txtStaffID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtUserID.Clear();
            txtAddress.Clear();
            txtPosition.Clear();
            txtSalary.Clear();
            chkGender.Checked = false;
            numAge.Value = 0;
            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerStartWork.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedStaff == null)
            {
                MessageBox.Show("Please select a staff to update.");
                return;
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtStaffID.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Calculate age
            DateTime dateOfBirth = dateTimePickerDOB.Value;
            int age = CalculateAge(dateOfBirth);

            // Update selected staff
            selectedStaff.StaffID = txtStaffID.Text;
            selectedStaff.FirstName = txtFirstName.Text;
            selectedStaff.LastName = txtLastName.Text;
            selectedStaff.Email = txtEmail.Text;
            selectedStaff.PhoneNumber = txtPhoneNumber.Text;
            selectedStaff.UserID = int.Parse(txtUserID.Text); // Convert from string to int
            selectedStaff.Address = txtAddress.Text;
            selectedStaff.Position = txtPosition.Text;
            selectedStaff.Salary = Convert.ToDecimal(txtSalary.Text); // Convert to decimal
            selectedStaff.Gender = chkGender.Checked;
            selectedStaff.Age = age;
            selectedStaff.DateOfBirth = dateOfBirth;
            selectedStaff.StartWorkDate = dateTimePickerStartWork.Value;

            // Update staff in the database
            if (boStaff.UpdateStaff(selectedStaff))
            {
                MessageBox.Show("Staff information updated successfully.");
                LoadStaffData(); // Refresh DataGridView
                ClearFields();   // Clear input fields
            }
            else
            {
                MessageBox.Show("An error occurred while updating staff information.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStaff == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Thực hiện xóa nhân viên được chọn
                if (boStaff.DeleteStaff(selectedStaff.StaffID))
                {
                    MessageBox.Show("Xóa nhân viên thành công.");
                    LoadStaffData(); // Load lại dữ liệu để cập nhật DataGridView
                    ClearFields();   // Xóa trắng các trường nhập liệu
                    selectedStaff = null; // Đặt lại selectedStaff về null sau khi xóa
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên.");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedStaff = new StaffModel
                {
                    StaffID = row.Cells["StaffID"].Value.ToString(),
                    FirstName = row.Cells["FirstName"].Value.ToString(),
                    LastName = row.Cells["LastName"].Value.ToString(),
                    Email = row.Cells["Email"].Value.ToString(),
                    PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                    UserID = (int)row.Cells["UserID"].Value,
                    Address = row.Cells["Address"].Value.ToString(),
                    Position = row.Cells["Position"].Value.ToString(),
                    Salary = Convert.ToDecimal(row.Cells["Salary"].Value),
                    Gender = Convert.ToBoolean(row.Cells["Gender"].Value),
                    Age = Convert.ToInt32(row.Cells["Age"].Value),
                    DateOfBirth = Convert.ToDateTime(row.Cells["DateOfBirth"].Value),
                    StartWorkDate = Convert.ToDateTime(row.Cells["StartWorkDate"].Value)
                };

                DisplaySelectedStaff();
            }
        }

    }
}
