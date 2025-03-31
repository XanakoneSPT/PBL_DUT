using PBL3.Model.Bean;
using PBL3.Model.Dao;
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
    public partial class ActivityControl : UserControl
    {
        private Bo_ActivityModel boActivity;

        public ActivityControl()
        {
            InitializeComponent();
            dbConnection dbConnection = new dbConnection();
            boActivity = new Bo_ActivityModel(dbConnection);
            LoadDataGrid();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns["Description"].Visible = false;
        }
        private void ActivityControl_Load(object sender, EventArgs e)
        {
            CustomizeDataGridView();
        }
        public void SetButtonVisibility(bool isVisible)
        {
            AddButton.Visible = isVisible;
            DeleteButton.Visible = isVisible;
            UpdateButton.Visible = isVisible;
        }
        private void LoadDataGrid()
        {
            try
            {
                dgv.DataSource = boActivity.GetActivities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshActivityList()
        {
            dgv.DataSource = boActivity.GetActivities();
        }
        private void SearchBox_Click(object sender, EventArgs e)
        {
            // Get the activity ID from the search box
            string searchID = IDSearchBox.Text;

            // Check if the search ID is valid
            if (!string.IsNullOrEmpty(searchID))
            {
                // Try to retrieve the activity information for the given ID
                ActivityModel activity = boActivity.GetActivityByID(searchID);

                if (activity != null)
                {
                    // Activity found, display it in the DataGridView
                    dgv.DataSource = new List<ActivityModel> { activity };
                }
                else
                {
                    // Activity not found
                    MessageBox.Show("Activity not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Invalid search ID
                MessageBox.Show("Please enter a valid ActivityID to search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload all activities in DataGridView
                dgv.DataSource = boActivity.GetActivities();
            }
        }
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgv.SelectedRows.Count > 0)
            {
                // Get the selected activity
                ActivityModel selectedActivity = dgv.SelectedRows[0].DataBoundItem as ActivityModel;

                // Display the description in the RichTextBox
                ActivityDescriptionrichTextBox.Text = selectedActivity.Description;
                ActivityIDInsert.Text = selectedActivity.ActivityID;
                ActivityNameInsert.Text = selectedActivity.Name;
                ActivityDateInsert.Value = selectedActivity.Time;
                ActivityTimeInsert.Value = selectedActivity.Time;
                ActivityLocationInsert.Text = selectedActivity.Location;
            }
        }
        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                // Extract the data from the selected row
                string activityID = selectedRow.Cells["ActivityID"].Value?.ToString() ?? "";
                string activityName = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                string description = selectedRow.Cells["Description"].Value?.ToString() ?? "";
                string dateTime = selectedRow.Cells["Time"].Value?.ToString() ?? "";
                string location = selectedRow.Cells["Location"].Value?.ToString() ?? "";

                // Set the values in the insert boxes
                ActivityIDInsert.Text = activityID;
                ActivityNameInsert.Text = activityName;
                ActivityDescriptionrichTextBox.Text = description;

                // Parse the DateTime value from the concatenated string
                DateTime activityDateTime;
                if (DateTime.TryParse(dateTime, out activityDateTime))
                {
                    ActivityDateInsert.Value = activityDateTime.Date;
                    ActivityTimeInsert.Value = activityDateTime;
                }
                else
                {
                    MessageBox.Show("Error parsing date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ActivityLocationInsert.Text = location;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(ActivityIDInsert.Text) ||
                string.IsNullOrWhiteSpace(ActivityNameInsert.Text) ||
                string.IsNullOrWhiteSpace(ActivityLocationInsert.Text) ||
                string.IsNullOrWhiteSpace(ActivityDescriptionrichTextBox.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the DateTime from the input string
            if (!DateTime.TryParse(ActivityDateInsert.Text + " " + ActivityTimeInsert.Text, out DateTime timeValue))
            {
                MessageBox.Show("Invalid date and time format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new ActivityModel object
            ActivityModel newActivity = new ActivityModel
            {
                ActivityID = ActivityIDInsert.Text,
                Name = ActivityNameInsert.Text,
                Description = ActivityDescriptionrichTextBox.Text,
                Time = timeValue, // Assign the parsed DateTime value
                Location = ActivityLocationInsert.Text,
            };

            // Add the new activity using the Bo_ActivityModel
            boActivity.AddActivity(newActivity);

            // Refresh the activity list after adding
            RefreshActivityList();

            // Clear input fields after adding
            ActivityIDInsert.Text = "";
            ActivityNameInsert.Text = "";
            ActivityDescriptionrichTextBox.Text = "";
            ActivityLocationInsert.Text = "";
            ActivityDateInsert.Value = DateTime.Now.Date;
            ActivityTimeInsert.Value = DateTime.Now;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                // Get the ActivityID of the selected row
                string id = dgv.SelectedRows[0].Cells["ActivityID"].Value.ToString();

                // Ask the user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete this activity?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // User confirmed deletion, proceed with deletion
                    boActivity.DeleteActivity(id);

                    // Refresh the activity list after deletion
                    RefreshActivityList();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgv.SelectedRows.Count > 0)
            {
                // Extract the ActivityID from the selected row (assuming ActivityID cannot be changed)
                string activityID = dgv.SelectedRows[0].Cells["ActivityID"].Value?.ToString() ?? "";

                // Retrieve updated values from the input fields
                string name = ActivityNameInsert.Text;
                string description = ActivityDescriptionrichTextBox.Text;
                string location = ActivityLocationInsert.Text;

                // Parse the DateTime value from the input fields
                if (DateTime.TryParse(ActivityDateInsert.Text + " " + ActivityTimeInsert.Text, out DateTime timeValue))
                {
                    // Create a new ActivityModel object with the updated values
                    ActivityModel updatedActivity = new ActivityModel
                    {
                        ActivityID = activityID,
                        Name = name,
                        Description = description,
                        Time = timeValue,
                        Location = location
                    };

                    // Update the activity using the Bo_ActivityModel
                    boActivity.UpdateActivity(updatedActivity);

                    // Refresh the activity list after updating
                    RefreshActivityList();

                    // Clear input fields after updating
                    ActivityIDInsert.Text = "";
                    ActivityNameInsert.Text = "";
                    ActivityDescriptionrichTextBox.Text = "";
                    ActivityLocationInsert.Text = "";
                    ActivityDateInsert.Value = DateTime.Now.Date;
                    ActivityTimeInsert.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Invalid date and time format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgv.Columns[0].Width = 120;
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
            if (dgv.Columns[e.ColumnIndex].Name == "Time")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    DateTime dateValue = (DateTime)e.Value;
                    e.Value = dateValue.ToString("dd MMM yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
