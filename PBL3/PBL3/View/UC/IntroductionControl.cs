using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Bo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBL3.View.UC
{
    public partial class IntroductionControl : UserControl
    {
        private readonly Bo_Introduction bo_Introduction;
        public int UserID { get; set; }
        public bool IsOpenedFromCustomerForm { get; set; }

        public IntroductionControl(int userID)
        {
            InitializeComponent();
            IntroducerActivityIDText.Enabled = false;
            dbConnection dbConnection = new dbConnection();
            bo_Introduction = new Bo_Introduction(dbConnection);
            LoadStatusOptions();
            SetSortccb();
            UserID = userID;
        }

        private void IntroductionControl_Load(object sender, EventArgs e)
        {
            LoadData();
            CustomizeDataGridView();
        }

        public void SetButtonVisibility(bool isVisible)
        {
            DELETE.Visible = isVisible;
            UPDATE.Visible = isVisible;
            ComboboxSatatus.Enabled = isVisible;
        }

        public void LoadData()
        {
            if (IsOpenedFromCustomerForm)
            {
                dgv.Columns.Clear();
                LoadIntroductionActivitiesByUserID();
            }
            else
            {
                dgv.Columns.Clear();
                LoadIntroductionActivities();
            }
        }

        public void LoadIntroductionActivities()
        {
            try
            {
                List<IntroductionModel> introductionActivities = bo_Introduction.GetIntroductionActivityList();
                dgv.DataSource = introductionActivities;
                dgv.Columns["Description"].Visible = false;
                dgv.Columns["UserID"].Visible = true;
                dgv.Columns["Gender"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void LoadIntroductionActivitiesByUserID()
        {
            try
            {
                List<IntroductionModel> introductionActivities = bo_Introduction.GetIntroductionByUserID(UserID);
                dgv.DataSource = introductionActivities;
                dgv.Columns["Description"].Visible = false;
                dgv.Columns["UserID"].Visible = true;
                dgv.Columns["Gender"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadStatusOptions()
        {
            List<string> statusOptions = new List<string> { "Waiting", "Completed", "Cancelled", "In Progress", "Postponed" };
            ComboboxSatatus.DataSource = statusOptions;
        }

        private void SetSortccb()
        {
            List<string> statusOptions = new List<string> { "All", "Waiting", "Completed", "Cancelled", "In Progress", "Postponed" };
            SortStatusCombobox.DataSource = statusOptions;
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IntroducerNameText.Text) ||
                    string.IsNullOrEmpty(IntroducerContactInfoText.Text) ||
                    string.IsNullOrEmpty(DescriptionText.Text) ||
                    string.IsNullOrEmpty(ChildNameText.Text) ||
                    string.IsNullOrEmpty(ChildLastNameText.Text))
                {
                    MessageBox.Show("All fields must be filled in.");
                    return;
                }

                var introductionActivity = new IntroductionModel
                {
                    IntroductionActivityID = GenerateIntroductionActivityID(),
                    IntroducerName = IntroducerNameText.Text,
                    IntroducerContactInfo = IntroducerContactInfoText.Text,
                    DateOfIntroduction = DateOfIntroduction.Value,
                    Status = ComboboxSatatus.SelectedItem.ToString(),
                    Description = DescriptionText.Text,
                    ChildrenName = ChildNameText.Text,
                    ChildrenLastName = ChildLastNameText.Text,
                    Gender = GenderCheckBox.Checked,
                    DateOfBirth = DateOfBirthChild.Value,
                    UserID = UserID
                };

                bool isAdded = bo_Introduction.AddIntroductionActivity(introductionActivity);

                if (isAdded)
                {
                    MessageBox.Show("Introduction activity added successfully.");
                    LoadData(); // Refresh the DataGridView
                }
                else
                {
                    MessageBox.Show("Failed to add introduction activity.");
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
            if (dgv.SelectedRows.Count > 0)
            {
                IntroductionModel selectedActivity = dgv.SelectedRows[0].DataBoundItem as IntroductionModel;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this introduction activity?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = bo_Introduction.DeleteIntroductionActivity(selectedActivity.IntroductionActivityID);
                    if (success)
                    {
                        MessageBox.Show("Introduction activity deleted successfully.");
                        LoadData(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete introduction activity.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an introduction activity to delete.");
            }
            CustomizeDataGridView();
        }

        private string GenerateIntroductionActivityID()
        {
            return Guid.NewGuid().ToString();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                IntroductionModel selectedActivity = dgv.SelectedRows[0].DataBoundItem as IntroductionModel;

                selectedActivity.IntroducerName = IntroducerNameText.Text;
                selectedActivity.IntroducerContactInfo = IntroducerContactInfoText.Text;
                selectedActivity.DateOfIntroduction = DateOfIntroduction.Value;
                selectedActivity.Description = DescriptionText.Text;
                selectedActivity.ChildrenName = ChildNameText.Text;
                selectedActivity.ChildrenLastName = ChildLastNameText.Text;
                selectedActivity.Gender = GenderCheckBox.Checked;
                selectedActivity.DateOfBirth = DateOfBirthChild.Value;
                selectedActivity.Status = ComboboxSatatus.SelectedItem.ToString();
                selectedActivity.UserID = UserID;

                bool success = bo_Introduction.UpdateIntroductionActivity(selectedActivity);

                if (success)
                {
                    MessageBox.Show("Introduction activity updated successfully.");
                    LoadData(); // Refresh the DataGridView
                }
                else
                {
                    MessageBox.Show("Failed to update introduction activity.");
                }
            }
            else
            {
                MessageBox.Show("Please select an introduction activity to update.");
            }
            CustomizeDataGridView();
        }

        private void DTGV_INTRODUCTION_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv.SelectedRows.Count > 0)
            {
                IntroductionModel selectedActivity = dgv.SelectedRows[0].DataBoundItem as IntroductionModel;

                IntroducerActivityIDText.Text = selectedActivity.IntroductionActivityID;
                IntroducerNameText.Text = selectedActivity.IntroducerName;
                IntroducerContactInfoText.Text = selectedActivity.IntroducerContactInfo;
                DescriptionText.Text = selectedActivity.Description;
                ChildNameText.Text = selectedActivity.ChildrenName;
                ChildLastNameText.Text = selectedActivity.ChildrenLastName;
                DateOfBirthChild.Value = selectedActivity.DateOfBirth;
                GenderCheckBox.Checked = selectedActivity.Gender;
                DateOfIntroduction.Value = selectedActivity.DateOfIntroduction;

                if (ComboboxSatatus.Items.Contains(selectedActivity.Status))
                {
                    ComboboxSatatus.SelectedItem = selectedActivity.Status;
                }
                else
                {
                    ComboboxSatatus.SelectedIndex = -1;
                }
            }
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            string searchText = SearchText.Text.Trim();
            string selectedStatus = SortStatusCombobox.SelectedItem?.ToString();

            List<IntroductionModel> introductionActivities = bo_Introduction.GetIntroductionActivityList();

            if (!string.IsNullOrEmpty(searchText))
            {
                introductionActivities = introductionActivities.Where(activity =>
                    activity.IntroducerName.Contains(searchText) ||
                    activity.Description.Contains(searchText) ||
                    activity.ChildrenName.Contains(searchText) ||
                    activity.ChildrenLastName.Contains(searchText)
                ).ToList();
            }

            if (!string.IsNullOrEmpty(selectedStatus) && !selectedStatus.Equals("All"))
            {
                introductionActivities = introductionActivities.Where(activity => activity.Status == selectedStatus).ToList();
            }

            dgv.DataSource = introductionActivities;
            CustomizeDataGridView();
        }

        private void SortStatusCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBT_Click(sender, e);
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
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].Width = 150;
                dgv.Columns[2].Width = 200;
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

            if(IsOpenedFromCustomerForm)
            {
                dgv.CellClick -= DTGV_INTRODUCTION_CellClick;
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "DateOfBirth" ||
                dgv.Columns[e.ColumnIndex].Name == "DateOfIntroduction")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    DateTime dateValue = (DateTime)e.Value;
                    e.Value = dateValue.ToString("dd MMM yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
