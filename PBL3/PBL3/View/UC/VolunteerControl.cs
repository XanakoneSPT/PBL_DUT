using PBL3.Models.Bean;
using PBL3.Models.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.View
{
    public partial class VolunteerControl : UserControl
    {
        private Bo_VolunteerModel boVolunteerModel;
        public VolunteerControl()
        {
            InitializeComponent();
            boVolunteerModel = new Bo_VolunteerModel();
            UpdateDataBindings();
        }
        private void VolunteerControl_Load(object sender, EventArgs e)
        {
            CustomizeDataGridView();
        }
        private void UpdateDataBindings()
        {
            // Refresh the data source of DataGridView to reflect the changes
            VolunteerDataGridView.DataSource = null;
            VolunteerDataGridView.DataSource = boVolunteerModel.DisplayVolunteerInfo();
        }
        private void VolunteerIDSearchBox_TextChanged(object sender, EventArgs e)
        {
            string volunteerID = VolunteerIDSearchBox.Text;
            VolunteerDataGridView.DataSource = boVolunteerModel.SearchVolunteerInfo(volunteerID);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string volunteerID = VolunteerIDSearchBox.Text;
            VolunteerDataGridView.DataSource = boVolunteerModel.SearchVolunteerInfo(volunteerID);
            UpdateDataBindings();
            CustomizeDataGridView();
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
        private void VolunteerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = VolunteerDataGridView.Rows[e.RowIndex];

                // Extract the data from the selected row and populate the input fields
                VolunteerIDInsert.Text = selectedRow.Cells["Volunteer ID"].Value?.ToString() ?? "";
                VolunteerFirstNameInsert.Text = selectedRow.Cells["First Name"].Value?.ToString() ?? "";
                VolunteerLastNameInsert.Text = selectedRow.Cells["Last Name"].Value?.ToString() ?? "";
                VolunteerPositionInsert.Text = selectedRow.Cells["Position"].Value?.ToString() ?? "";
                VolunteerGenderInsertBox.Text = selectedRow.Cells["Gender"].Value?.ToString();
                VolunteerAgeInsert.Text = selectedRow.Cells["Age"].Value?.ToString() ?? "";
                VolunteerDateOfBirthInsert.Text = selectedRow.Cells["Date Of Birth"].Value?.ToString();
                VolunteerDateStartInsert.Text = selectedRow.Cells["Date Start Volunteer"].Value?.ToString();
                VolunteerEmailInsert.Text = selectedRow.Cells["Email"].Value?.ToString() ?? "";
                VolunteerPhoneNumberInsert.Text = selectedRow.Cells["Phone Number"].Value?.ToString() ?? "";
                VolunteerAddressInsert.Text = selectedRow.Cells["Address"].Value?.ToString() ?? "";
            }
        }
        private void VolunteerAddButton_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth = VolunteerDateOfBirthInsert.Value;
            int age = CalculateAge(dateOfBirth);

            VolunteerModel newVolunteer = new VolunteerModel
            {
                VolunteerID = VolunteerIDInsert.Text,
                FirstName = VolunteerFirstNameInsert.Text,
                LastName = VolunteerLastNameInsert.Text,
                Position = VolunteerPositionInsert.Text,
                Gender = VolunteerGenderInsertBox.SelectedItem.ToString() == "Male",
                Age = age,
                DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd"),
                DateStartVolunteer = VolunteerDateStartInsert.Value.ToString("yyyy-MM-dd"),
                Email = VolunteerEmailInsert.Text,
                PhoneNumber = VolunteerPhoneNumberInsert.Text,
                Address = VolunteerAddressInsert.Text,
            };
            boVolunteerModel.SaveVolunteerInfo(newVolunteer);
            UpdateDataBindings();
            VolunteerDataGridView.DataSource = boVolunteerModel.DisplayVolunteerInfo();
            CustomizeDataGridView();
        }
        private void VolunteerDeleteButton_Click(object sender, EventArgs e)
        {
            string volunteerID = VolunteerIDInsert.Text;
            boVolunteerModel.DeleteVolunteerInfo(volunteerID);
            UpdateDataBindings();
            VolunteerDataGridView.DataSource = boVolunteerModel.DisplayVolunteerInfo();
            CustomizeDataGridView();
        }
        private void VolunteerUpdateButton_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth = VolunteerDateOfBirthInsert.Value;
            int age = CalculateAge(dateOfBirth);

            VolunteerModel updatedVolunteer = new VolunteerModel
            {
                VolunteerID = VolunteerIDInsert.Text,
                FirstName = VolunteerFirstNameInsert.Text,
                LastName = VolunteerLastNameInsert.Text,
                Position = VolunteerPositionInsert.Text,
                Gender = VolunteerGenderInsertBox.SelectedItem.ToString() == "Male",
                Age = age,
                DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd"),
                DateStartVolunteer = VolunteerDateStartInsert.Value.ToString("yyyy-MM-dd"),
                Email = VolunteerEmailInsert.Text,
                PhoneNumber = VolunteerPhoneNumberInsert.Text,
                Address = VolunteerAddressInsert.Text,
            };
            boVolunteerModel.UpdateVolunteerInfo(updatedVolunteer);
            UpdateDataBindings();
            VolunteerDataGridView.DataSource = boVolunteerModel.DisplayVolunteerInfo();
            CustomizeDataGridView();
        }
        private void VolunteerResetButton_Click(object sender, EventArgs e)
        {
            VolunteerIDInsert.Text = "";
            VolunteerFirstNameInsert.Text = "";
            VolunteerLastNameInsert.Text = "";
            VolunteerPositionInsert.Text = "";
            VolunteerGenderInsertBox.Text = "";
            VolunteerAgeInsert.Text = "";
            VolunteerDateOfBirthInsert.Value = DateTime.Now;
            VolunteerDateStartInsert.Value = DateTime.Now;
            VolunteerEmailInsert.Text = "";
            VolunteerPhoneNumberInsert.Text = "";
            VolunteerAddressInsert.Text = "";

            UpdateDataBindings();
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            // Set font and header styles
            VolunteerDataGridView.Font = new Font("Times New Roman", 10);
            VolunteerDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            VolunteerDataGridView.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            VolunteerDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row colors
            // VolunteerDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set border styles
            VolunteerDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            VolunteerDataGridView.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            VolunteerDataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ensure header cell styles are not affected by row selection
            VolunteerDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = VolunteerDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            VolunteerDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = VolunteerDataGridView.ColumnHeadersDefaultCellStyle.ForeColor;

            // Auto-size columns, but not the first one
            VolunteerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            VolunteerDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            VolunteerDataGridView.Columns[0].Width = 80;
            VolunteerDataGridView.Columns[3].Width = 150;
            VolunteerDataGridView.Columns[5].Width = 50;
            VolunteerDataGridView.Columns[9].Width = 190;
            VolunteerDataGridView.Columns[10].Width = 200;

            // Set selection mode to full row select
            VolunteerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VolunteerDataGridView.MultiSelect = false;

            // Set row height
            // VolunteerDataGridView.RowTemplate.Height = 70; // Adjust the height as needed

            // Set other properties
            VolunteerDataGridView.EnableHeadersVisualStyles = false;
            VolunteerDataGridView.GridColor = Color.LightGray;
            VolunteerDataGridView.BorderStyle = BorderStyle.None;
            VolunteerDataGridView.RowHeadersVisible = false;
        }
    }
}
