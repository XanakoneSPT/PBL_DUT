using PBL3.Model.Bean;
using PBL3.Models.Bo;
using PBL3.Models.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.View.UC
{
    public partial class FeedblackControl : UserControl
    {
        public int UserID { get; set; }
        public bool IsOpenedFromCustomerForm { get; set; }
        private Bo_FeedbackModel feedbackBo;
        private FeedbackModel currentFeedback;
        private List<FeedbackModel> feedbackList;

        public FeedblackControl(int userid)
        {
            InitializeComponent();
            UserID = userid;
            feedbackBo = new Bo_FeedbackModel();
            feedbackList = new List<FeedbackModel>();
        }
        private void FeedblackControl1_Load(object sender, EventArgs e)
        {
            LoadData();
            SetSortccb();
            ClearFields();
            CustomizeDataGridView();
        }
        private void SetSortccb()
        {
            // Define a list of status options
            List<string> ccb = new List<string> { "All", "Oldest", "Newest"};
            sortccb.DataSource = ccb;
        }
        public void SetButtonVisibility(bool isVisible)
        {
            //DELETE.Visible = isVisible;
            UPDATE.Visible = isVisible;

            UserIDTxt.Visible = isVisible;
            UserIDLB.Visible = isVisible;
        }
        private void LoadData()
        {
            if (IsOpenedFromCustomerForm)
            {
                LoadFeedbackDataByUserID();
            }
            else
            {
                LoadFeedbackData();
            }
            dgv.DataSource = feedbackList;
        }
        private void LoadFeedbackData()
        {
            // Load all feedback data (this could be filtered by user or other criteria)
            feedbackList = new List<FeedbackModel>(feedbackBo.GetFeedbackList());
            dgv.DataSource = feedbackList;
            //if (feedbackList.Count > 0)
            //{
            //    currentFeedback = feedbackList[0];
            //    PopulateFields(currentFeedback);
            //}
        }
        private void LoadFeedbackDataByUserID()
        {
            // Load all feedback data (this could be filtered by user or other criteria)
            feedbackList = new List<FeedbackModel>(feedbackBo.GetFeedbackByUserId(UserID));
            if (feedbackList.Count > 0)
            {
                currentFeedback = feedbackList[0];
                PopulateFields(currentFeedback);
            }
        }
        private void PopulateFields(FeedbackModel feedback)
        {
            IDText.Text = feedback.FeedbackID;
            TopicTxt.Text = feedback.Topic;
            ContactInfoTxt.Text = feedback.ContactInfo;
            FeedbackDate.Value = feedback.FeedbackDate;
            FeedbackTime.Value = feedback.FeedbackDate;

            if (feedback.Messages.Count > 0)
            {
                DescriptionText.Text = feedback.Messages[0].MessageText;
            }
        }
        private void SendBT_Click(object sender, EventArgs e)
        {
            //// Get the current date
            //DateTime feedbackDate = DateTime.Today; // Today's date

            //// Set the desired time
            //DateTime feedbackTime = new DateTime(feedbackDate.Year, feedbackDate.Month, feedbackDate.Day, 9, 0, 0); // 9:00 AM

            //// Combine date and time
            //DateTime combinedDateTime = feedbackDate.Add(feedbackTime.TimeOfDay);

            try
            {
                if (IsOpenedFromCustomerForm)
                {
                    // Create a new feedback entry
                    FeedbackModel newFeedback = new FeedbackModel
                    {
                        UserId = UserID,
                        Topic = TopicTxt.Text,
                        ContactInfo = ContactInfoTxt.Text,
                        FeedbackDate = DateTime.Now,
                    };

                    // Add the new feedback entry
                    feedbackBo.AddFeedback(newFeedback);

                    // Create new feedback message
                    FeedbackMessage newMessage = new FeedbackMessage
                    {
                        FeedbackID = newFeedback.FeedbackID,
                        UserId = UserID,
                        MessageText = DescriptionText.Text,
                        MessageDate = DateTime.Now,
                    };

                    // Add the new message to the feedback
                    feedbackBo.AddFeedbackMessage(newMessage);

                    MessageBox.Show("Feedback sent!");
                    LoadData();
                }
                else
                {
                    // Create a new feedback entry
                    FeedbackModel newFeedback = new FeedbackModel
                    {
                        UserId = Convert.ToInt32(UserIDTxt.Text),
                        Topic = TopicTxt.Text,
                        ContactInfo = ContactInfoTxt.Text,
                        FeedbackDate = DateTime.Now,
                    };

                    // Add the new feedback entry
                    feedbackBo.AddFeedback(newFeedback);

                    // Create new feedback message
                    FeedbackMessage newMessage = new FeedbackMessage
                    {
                        FeedbackID = newFeedback.FeedbackID,
                        UserId = Convert.ToInt32(UserIDTxt.Text),
                        MessageText = DescriptionText.Text,
                        MessageDate = DateTime.Now,
                    };

                    // Add the new message to the feedback
                    feedbackBo.AddFeedbackMessage(newMessage);

                    MessageBox.Show("Feedback sent!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending feedback: {ex.Message}");
            }
            CustomizeDataGridView();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = IDText.Text;

                if (!string.IsNullOrEmpty(ID))
                {
                    feedbackBo.DeleteFeedback(ID);
                    LoadData();
                    MessageBox.Show("Feedback deleted!");
                }
                else
                {
                    MessageBox.Show("Please select a feedback to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting feedback: {ex.Message}");
            }
            CustomizeDataGridView();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFeedback != null)
                {
                    // Update the current feedback object with the new values
                    currentFeedback.Topic = TopicTxt.Text;
                    currentFeedback.ContactInfo = ContactInfoTxt.Text;
                    currentFeedback.FeedbackDate = FeedbackDate.Value;

                    // Update the message associated with the current feedback
                    if (currentFeedback.Messages.Count > 0)
                    {
                        currentFeedback.Messages[0].MessageText = DescriptionText.Text;
                    }

                    // Update the feedback record in the database
                    feedbackBo.UpdateFeedback(currentFeedback);

                    // Reload the data to reflect the changes
                    LoadData();

                    MessageBox.Show("Feedback updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a feedback to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating feedback: {ex.Message}");
            }
            CustomizeDataGridView();
        }
        private void ClearFields()
        {
            IDText.Clear();
            TopicTxt.Clear();
            ContactInfoTxt.Clear();
            DescriptionText.Clear();
            FeedbackDate.Value = DateTime.Now;
            FeedbackTime.Value = DateTime.Now;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                // Extract the feedback ID from the selected row
                string feedbackID = selectedRow.Cells["FeedbackID"].Value?.ToString() ?? "";

                // Check if the feedback ID is not empty
                if (!string.IsNullOrEmpty(feedbackID))
                {
                    // Call the Bo_FeedbackModel's GetFeedbackById method to retrieve the feedback by its ID
                    FeedbackModel feedback = feedbackBo.GetFeedbackById(feedbackID);

                    // Populate the fields with the selected feedback data
                    if (feedback != null)
                    {
                        // Output debug information
                        Console.WriteLine("Selected Feedback ID: " + feedbackID);

                        // Set the currentFeedback
                        currentFeedback = feedback;

                        IDText.Text = feedback.FeedbackID;
                        TopicTxt.Text = feedback.Topic;
                        UserIDTxt.Text = feedback.UserId.ToString();
                        ContactInfoTxt.Text = feedback.ContactInfo;
                        FeedbackDate.Value = feedback.FeedbackDate;
                        FeedbackTime.Value = feedback.FeedbackDate;

                        // If there are messages associated with the feedback, populate the description field
                        if (feedback.Messages.Count > 0)
                        {
                            DescriptionText.Text = feedback.Messages[0].MessageText;
                        }
                        else
                        {
                            DescriptionText.Clear();
                        }

                        // Optionally, you can populate other fields with feedback data if needed
                    }
                    else
                    {
                        // Handle the case where feedback with the specified ID was not found
                        MessageBox.Show("Feedback not found!");
                    }
                }
                else
                {
                    // Handle the case where feedback ID is empty
                    MessageBox.Show("Feedback ID is empty!");
                }
            }
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            string searchText = SearchText.Text.Trim();
            string selectedSort = sortccb.SelectedItem?.ToString();

            if (IsOpenedFromCustomerForm)
            {
                // Get the list of all feedback entries
                List<FeedbackModel> feedbacks = feedbackBo.GetFeedbackByUserId(UserID).ToList();

                // Filter by search text if provided
                if (!string.IsNullOrEmpty(searchText))
                {
                    feedbacks = feedbacks.Where(feedback =>
                        feedback.FeedbackID.Contains(searchText) ||
                        feedback.Topic.Contains(searchText) ||
                        feedback.ContactInfo.Contains(searchText)
                    ).ToList();
                }

                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Oldest"))
                    {
                        feedbacks = feedbacks.OrderBy(feedback => feedback.FeedbackDate).ToList();
                    }
                    else if (selectedSort.Equals("Newest"))
                    {
                        feedbacks = feedbacks.OrderByDescending(feedback => feedback.FeedbackDate).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = feedbacks;
            }
            else
            {
                // Get the list of all feedback entries
                List<FeedbackModel> feedbacks = feedbackBo.GetFeedbackList();

                // Filter by search text if provided
                if (!string.IsNullOrEmpty(searchText))
                {
                    feedbacks = feedbacks.Where(feedback =>
                        feedback.FeedbackID.Contains(searchText) ||
                        feedback.Topic.Contains(searchText) ||
                        feedback.ContactInfo.Contains(searchText)
                    ).ToList();
                }

                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Oldest"))
                    {
                        feedbacks = feedbacks.OrderBy(feedback => feedback.FeedbackDate).ToList();
                    }
                    else if (selectedSort.Equals("Newest"))
                    {
                        feedbacks = feedbacks.OrderByDescending(feedback => feedback.FeedbackDate).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = feedbacks;
            }
            CustomizeDataGridView();
        }

        private void sortccb_SelectedIndexChanged(object sender, EventArgs e)
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
            if (dgv.Columns[e.ColumnIndex].Name == "FeedbackDate")
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
