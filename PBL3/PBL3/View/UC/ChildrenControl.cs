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
using PBL3.Model.Dao;
using PBL3.Models.Dao;

namespace PBL3.View
{
    public partial class ChildrenControl : UserControl
    {
        private Bo_ChildrenModel boChildren;
        private List<ChildrenModel> childrenList;
        private ChildrenModel selectedChild;
        public ChildrenControl()
        {
            InitializeComponent();
            boChildren = new Bo_ChildrenModel(new dbConnection());

        }
        public void SetButtonVisibility(bool isVisible)
        {
            btnAdd.Visible = isVisible;
            btnDelete.Visible = isVisible;
            btnSave.Visible = isVisible;
        }
        private void ChildrenControl_Load(object sender, EventArgs e)
        {
            LoadChildrenData();
            CustomizeDataGridView();
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
        private void LoadChildrenData()
        {
            //childrenList = boChildren.GetChildrenList();
            //dataGridViewChildren.DataSource = childrenList;

            childrenList = boChildren.GetChildrenList();

            // Clear existing columns
            dgv.Columns.Clear();

            // Add columns
            dgv.Columns.Add("ChildID", "Child ID");
            dgv.Columns.Add("Name", "Name");
            dgv.Columns.Add("LastName", "Last Name");
            dgv.Columns.Add("Age", "Age");
            dgv.Columns.Add("DateOfBirth", "Date of Birth");
            dgv.Columns.Add("DateGetIntoCenter", "Date Get Into Center");
            dgv.Columns.Add("Gender", "Gender");

            // Populate data
            foreach (var child in childrenList)
            {
                string genderString = child.Gender ? "Male" : "Female";
                dgv.Rows.Add(child.ChildID, child.FirstName, child.LastName, child.Age, child.DateOfBirth, child.DateGetIntoCenter, genderString);
            }
        }
        private void dataGridViewChildren_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < childrenList.Count)
            {
                selectedChild = childrenList[e.RowIndex];

                textBoxChildID.Text = selectedChild.ChildID;
                textBoxName.Text = selectedChild.FirstName;
                textBoxLastName.Text = selectedChild.LastName;
                numericUpDownAge.Value = selectedChild.Age;
                dateTimePickerDateOfBirth.Value = selectedChild.DateOfBirth;
                dateTimePickerDateGetIntoCenter.Value = selectedChild.DateGetIntoCenter;

                if (selectedChild.Gender)
                {
                    checkBoxGender.Checked = true;
                }
                else
                {
                    checkBoxGender.Checked = false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth = dateTimePickerDateOfBirth.Value;
            int age = CalculateAge(dateOfBirth);

            ChildrenModel newChild = new ChildrenModel
            {
                ChildID = textBoxChildID.Text,
                FirstName = textBoxName.Text,
                LastName = textBoxLastName.Text,
                Age = age,
                DateOfBirth = dateOfBirth,
                DateGetIntoCenter = dateTimePickerDateGetIntoCenter.Value,
                Gender = checkBoxGender.Checked
            };

            if (boChildren.AddChildren(newChild))
            {
                MessageBox.Show("Child added successfully.");
                LoadChildrenData();
            }
            else
            {
                MessageBox.Show("Failed to add child.");
            }
            CustomizeDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedChild != null)
            {
                DateTime dateOfBirth = dateTimePickerDateOfBirth.Value;
                int age = CalculateAge(dateOfBirth);

                selectedChild.FirstName = textBoxName.Text;
                selectedChild.LastName = textBoxLastName.Text;
                selectedChild.Age = age;
                selectedChild.DateOfBirth = dateOfBirth;
                selectedChild.DateGetIntoCenter = dateTimePickerDateGetIntoCenter.Value;
                selectedChild.Gender = checkBoxGender.Checked;

                if (boChildren.UpdateChildren(selectedChild))
                {
                    MessageBox.Show("Child information updated successfully.");
                    LoadChildrenData();
                }
                else
                {
                    MessageBox.Show("Failed to update child information.");
                }
            }
            CustomizeDataGridView();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv.SelectedRows[0];

                // Retrieve values from cells of the selected row
                string childID = selectedRow.Cells["ChildID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this child?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (boChildren.DeleteChildren(childID))
                    {
                        MessageBox.Show("Child deleted successfully.");
                        LoadChildrenData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete child.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a child to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CustomizeDataGridView();
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            string SearchTxt = SearchTxtBox.Text.Trim();

            // Get the list of all introduction activities
            List<ChildrenModel> children = boChildren.GetChildrenList();

            // Filter by search text if provided
            if (!string.IsNullOrEmpty(SearchTxt))
            {
                children = children.Where(child =>
                    child.FirstName.Contains(SearchTxt) ||
                    child.LastName.Contains(SearchTxt) ||
                    child.ChildID.Contains(SearchTxt)
                ).ToList();
            }
            dgv.Columns.Clear();
            dgv.DataSource = children;
            CustomizeDataGridView();
        }

        private void dataGridViewChildren_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "DateOfBirth" ||
            dgv.Columns[e.ColumnIndex].Name == "DateGetIntoCenter")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    DateTime dateValue = (DateTime)e.Value;
                    e.Value = dateValue.ToString("dd MMM yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void CustomizeDataGridView()
        {
            // Set font and header styles
            dgv.Font = new Font("Times New Roman", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row colors
            // VolunteerDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set border styles
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ensure header cell styles are not affected by row selection
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

            // Auto-size columns, but not the first one
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns[0].Width = 100;
            dgv.Columns[3].Width = 50;

            // Set selection mode to full row select
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Set row height
            // VolunteerDataGridView.RowTemplate.Height = 70; // Adjust the height as needed

            // Set other properties
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
        }
    }
}
