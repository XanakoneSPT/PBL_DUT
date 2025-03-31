using PBL3.Model.Dao;
using PBL3.Models.Bo;
using PBL3.Model.Bean;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.Models.Dao;

namespace PBL3.View
{
    public partial class AdoptionControl : UserControl
    {
        private readonly Bo_AdoptionModel _adoptionActivityBO;
        private Bo_ChildrenModel bo_Children;
        public bool IsOpenedFromCustomerForm { get; set; }
        public int UserID { get; set; }

        public AdoptionControl(int userID)
        {
            InitializeComponent();
            dbConnection dbConnection = new dbConnection();
            _adoptionActivityBO = new Bo_AdoptionModel(dbConnection);
            AdoptionActivityIDText.ReadOnly = true;
            bo_Children = new Bo_ChildrenModel(dbConnection);
            UserID = userID;
        }

        private void AdtoptionControl_Load(object sender, EventArgs e)
        {
            if (IsOpenedFromCustomerForm)
            {
                LoadStatusOptions();
                SetSortccb();
                dgv.Columns.Clear();
                LoadChildrenList();
                SendBT.Visible = true;
                ChildrenListBT.Visible = true;
                AdoptionListBT.Visible = true;
                CustomizeDataGridViewChildren();
                dgv.CellClick -= DTGV_ADOPTION_CellClick; // Disable cell click event
            }
            else
            {
                LoadStatusOptions();
                SetSortccb();
                dgv.Columns.Clear();
                LoadAdoptionActivities();
                dgv.CellClick += DTGV_ADOPTION_CellClick; // Enable cell click event
                CustomizeDataGridView();
            }
        }

        public void SetButtonVisibility(bool isVisible)
        {
            ADD.Visible = isVisible;
            DELETE.Visible = isVisible;
            UPDATE.Visible = isVisible;

            //ADD.Enabled = isVisible;
            //DELETE.Enabled = isVisible;
            //UPDATE.Enabled = isVisible;

            SortLB.Visible = isVisible;
            SortStatusCombobox.Visible = isVisible;
            StatusLB.Visible = isVisible;
            ComboboxSatatus.Visible = isVisible;

            SearchBox.Visible = isVisible;
            SearchText.Visible = isVisible;

            dateTimePicker1.Enabled = isVisible;
        }
        private void LoadStatusOptions()
        {
            // Define a list of status options
            List<string> statusOptions = new List<string> { "Waiting", "Completed", "Cancelled", "In Progress", "Postponed" };

            // Set the DataSource for the ComboBox
            ComboboxSatatus.DataSource = statusOptions;

        }
        private void SetSortccb()
        {
            // Define a list of status options
            List<string> statusOptions = new List<string> { "All", "Waiting", "Completed", "Cancelled", "In Progress", "Postponed" };
            SortStatusCombobox.DataSource = statusOptions;
        }
        public void LoadChildrenList()
        {
            try
            {
                dgv.Columns.Clear();
                var children = bo_Children.GetChildrenList();
                dgv.DataSource = children;
                dgv.Columns["Gender"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            CustomizeDataGridViewChildren();
        }
        public void LoadAdoptionActivities()
        {
            try
            {
                dgv.Columns.Clear();
                var adoptionActivities = _adoptionActivityBO.GetAdoptionActivityList();

                // Bind the adoption activities to the DataGridView
                dgv.DataSource = adoptionActivities;

                // Hide the Description column
                dgv.Columns["Description"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ChildIDText.Text) ||
                    string.IsNullOrEmpty(AdopterNameText.Text) ||
                    string.IsNullOrEmpty(AdopterContactInfoText.Text) ||
                    string.IsNullOrEmpty(DescriptionText.Text))
                {
                    MessageBox.Show("All fields must be filled in.");
                    return;
                }

                var adoptionActivity = new AdoptionModel
                {
                    ChildID = ChildIDText.Text,
                    AdopterName = AdopterNameText.Text,
                    AdopterContactInfo = AdopterContactInfoText.Text,
                    Description = DescriptionText.Text,
                    DateOfAdoption = dateTimePicker1.Value,
                    Status = ComboboxSatatus.SelectedItem.ToString(),
                    UserID = UserID
                };

                bool isAdded = _adoptionActivityBO.AddAdoptionActivity(adoptionActivity);

                if (isAdded)
                {
                    MessageBox.Show("Adoption activity added successfully.");
                    LoadAdoptionActivities();
                }
                else
                {
                    MessageBox.Show("Failed to add adoption activity.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            CustomizeDataGridView();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an adoption activity to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected adoption activity?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string adoptionActivityID = dgv.SelectedRows[0].Cells["AdoptionActivityID"].Value.ToString();
                bool isDeleted = _adoptionActivityBO.DeleteAdoptionActivity(adoptionActivityID);

                if (isDeleted)
                {
                    MessageBox.Show("Adoption activity deleted successfully.");
                    LoadAdoptionActivities();
                }
                else
                {
                    MessageBox.Show("Failed to delete adoption activity.");
                }
            }
            CustomizeDataGridView();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(AdoptionActivityIDText.Text))
                {
                    MessageBox.Show("Please select an adoption activity to update.");
                    return;
                }

                var adoptionActivity = new AdoptionModel
                {
                    AdoptionActivityID = AdoptionActivityIDText.Text,
                    ChildID = ChildIDText.Text,
                    AdopterName = AdopterNameText.Text,
                    AdopterContactInfo = AdopterContactInfoText.Text,
                    Description = DescriptionText.Text,
                    DateOfAdoption = dateTimePicker1.Value,
                    Status = ComboboxSatatus.SelectedItem.ToString()
                };

                bool isUpdated = _adoptionActivityBO.UpdateAdoptionActivity(adoptionActivity);

                if (isUpdated)
                {
                    MessageBox.Show("Adoption activity updated successfully.");
                    LoadAdoptionActivities();
                }
                else
                {
                    MessageBox.Show("Failed to update adoption activity.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            CustomizeDataGridView();
        }

        private void DTGV_ADOPTION_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                AdoptionActivityIDText.Text = row.Cells["AdoptionActivityID"].Value.ToString();
                ChildIDText.Text = row.Cells["ChildID"].Value.ToString();
                AdopterNameText.Text = row.Cells["AdopterName"].Value.ToString();
                AdopterContactInfoText.Text = row.Cells["AdopterContactInfo"].Value.ToString();
                DescriptionText.Text = row.Cells["Description"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["DateOfAdoption"].Value);
                ComboboxSatatus.Enabled = true;
                ComboboxSatatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }

        private void SearchBox_Click(object sender, EventArgs e)
        {
            string searchText = SearchText.Text.Trim();
            string selectedStatus = SortStatusCombobox.SelectedItem?.ToString();

            // Get the list of all introduction activities
            List<AdoptionModel> adopts = _adoptionActivityBO.GetAdoptionActivityListSort();

            // Filter by search text if provided
            if (!string.IsNullOrEmpty(searchText))
            {
                adopts = adopts.Where(adopt =>
                    adopt.AdopterName.Contains(searchText) ||
                    adopt.AdopterContactInfo.Contains(searchText) ||
                    adopt.ChildID.Contains(searchText)
                ).ToList();
            }

            // Filter by status if selected
            if (!string.IsNullOrEmpty(selectedStatus) && !selectedStatus.Equals("All"))
            {
                adopts = adopts.Where(adopt => adopt.Status == selectedStatus).ToList();
            }

            // Update the DataGridView with the filtered activities
            dgv.DataSource = adopts;
            CustomizeDataGridView();
        }
        private void SortStatusCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBox_Click(sender, e);
        }
        private void SendBT_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ChildIDText.Text) ||
                    string.IsNullOrEmpty(AdopterNameText.Text) ||
                    string.IsNullOrEmpty(AdopterContactInfoText.Text) ||
                    string.IsNullOrEmpty(DescriptionText.Text))
                {
                    MessageBox.Show("All fields must be filled in.");
                    return;
                }

                DateTime Datenow = DateTime.Now;

                var adoptionActivity = new AdoptionModel
                {
                    ChildID = ChildIDText.Text,
                    AdopterName = AdopterNameText.Text,
                    AdopterContactInfo = AdopterContactInfoText.Text,
                    Description = DescriptionText.Text,
                    DateOfAdoption = Datenow,
                    Status = "Waiting",
                    UserID = UserID
                };

                bool isAdded = _adoptionActivityBO.AddAdoptionActivity(adoptionActivity);

                if (isAdded)
                {
                    MessageBox.Show("Request for adoption successfully.");
                    AdoptionListBT_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed to request adoption.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ChildrenListBT_Click(object sender, EventArgs e)
        {
            dgv.Columns.Clear();
            LoadChildrenList();
            CustomizeDataGridViewChildren();
        }

        private void AdoptionListBT_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.Columns.Clear();
                var adoptionActivities = _adoptionActivityBO.GetAdoptionActivityByUserID(UserID);

                // Bind the adoption activities to the DataGridView
                dgv.DataSource = adoptionActivities;

                // Hide the Description column
                dgv.Columns["Description"].Visible = false;
                dgv.CellClick += DTGV_ADOPTION_CellClick;

                DELETE.Enabled = true;
                UPDATE.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            // Set font and header styles
            dgv.Font = new Font("Times New Roman", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row colors
            //dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set border styles
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ensure header cell styles are not affected by row selection
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

            // Auto-size columns
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].Width = 80;
                dgv.Columns[3].Width = 250;
                dgv.Columns[4].Width = 150;
                dgv.Columns[5].Width = 100;
                dgv.Columns[6].Width = 80;
            }

            // Set selection mode to full row select
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Set row height
            dgv.RowTemplate.Height = 25; // Adjust the height as needed

            // Set other properties
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
        }
        private void CustomizeDataGridViewChildren()
        {
            // Set font and header styles
            dgv.Font = new Font("Times New Roman", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row colors
            //dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set border styles
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ensure header cell styles are not affected by row selection
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

            // Auto-size columns
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[0].Width = 100;
            }

            // Set selection mode to full row select
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Set row height
            dgv.RowTemplate.Height = 25; // Adjust the height as needed

            // Set other properties
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
        }
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "DateOfAdoption"||
                dgv.Columns[e.ColumnIndex].Name == "DateOfBirth"||
                dgv.Columns[e.ColumnIndex].Name == "DateGetIntoCenter")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    DateTime dateValue = (DateTime)e.Value;
                    e.Value = dateValue.ToString("dd MMM yyyy");
                    e.FormattingApplied = true;
                }
            }
            //if (dgv.Columns[e.ColumnIndex].Name == "gender")
            //{
            //    // Check if the cell value is not null and not DBNull
            //    if (e.Value != null && e.Value != DBNull.Value)
            //    {
            //        // Convert the cell value to a boolean
            //        bool gender = (bool)e.Value;

            //        // Set the displayed value based on the boolean value
            //        e.Value = gender ? "Male" : "Female";

            //        // Set the formatting applied flag to true
            //        e.FormattingApplied = true;
            //    }
            //}
        }
    }
}
