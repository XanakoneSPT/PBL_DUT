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
    public partial class NotifiactionControl : UserControl
    {
        private Bo_ActivityModel boactivityModel;
        //private List<ActivityModel> boactivityList;
        private Bo_CharityModel boCharityModel;
        //private List<CharityModel> bocharityList;
        private Bo_FinancialModel bofinancialModel;

        private string dgvShowAs = "";
        public NotifiactionControl()
        {
            InitializeComponent();
            dbConnection dbConnection = new dbConnection();
            boactivityModel = new Bo_ActivityModel(dbConnection);
            boCharityModel = new Bo_CharityModel();
            bofinancialModel = new Bo_FinancialModel(dbConnection);

        }
        private void NotifiactionControl_Load(object sender, EventArgs e)
        {
            ATbt_Click(sender, e);
            SetSortccb();
        }
        private void SetSortccb()
        {
            // Define a list of status options
            List<string> ccb = new List<string> { "All", "Oldest", "Newest" };
            sortcbb.DataSource = ccb;
        }
        private void CustomizeDataGridView()
        {
            // Set font and header styles
            dgv.Font = new Font("Times New Roman", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row colors
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set border styles
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Auto-size columns, but not the first one
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns[0].Width = 90; // Set the width for the first column

            // Set row height
            dgv.RowTemplate.Height = 50; // Adjust the height as needed
            // Set other properties
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
        }
        private void ATbt_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ATbt.BackColor = Color.WhiteSmoke;

            List<ActivityModel> allActivities = boactivityModel.GetActivities();

            //Display the total activity count
            dgv.DataSource = allActivities;
            dgv.Refresh();

            CustomizeDataGridView();

            dgvShowAs = "activity";

        }

        private void CTbt_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            CTbt.BackColor = Color.WhiteSmoke;

            // Retrieve all activities
            List<CharityModel> allActivities = boCharityModel.GetCharityActivities();

            //Display the total activity count
            dgv.DataSource = allActivities;
            dgv.Refresh();

            CustomizeDataGridView();
            // Hide the Description column
            dgv.Columns["CharityDateTime"].Visible = false;

            dgvShowAs = "charity";
        }

        private void DNbt_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            DNbt.BackColor = Color.WhiteSmoke;

            List<Donate> donates = bofinancialModel.GetDonateList();

            dgv.DataSource = donates;
            dgv.Refresh();

            CustomizeDataGridView();
            dgvShowAs = "donate";
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            List<ActivityModel> activity = boactivityModel.GetActivities().ToList();
            List<CharityModel> charity = boCharityModel.GetCharityActivities().ToList();
            List<Donate> donate = bofinancialModel.GetDonateList().ToList();


            string selectedSort = sortcbb.SelectedItem?.ToString();

            if(dgvShowAs == "activity")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Oldest"))
                    {
                        activity = activity.OrderBy(acti => acti.Time).ToList();
                    }
                    else if (selectedSort.Equals("Newest"))
                    {
                        activity = activity.OrderByDescending(acti => acti.Time).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = activity;
            }else if(dgvShowAs == "charity")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Oldest"))
                    {
                        charity = charity.OrderBy(acti => acti.CharityDateTime).ToList();
                    }
                    else if (selectedSort.Equals("Newest"))
                    {
                        charity = charity.OrderByDescending(acti => acti.CharityDateTime).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = charity;
            }else if(dgvShowAs == "donate")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Oldest"))
                    {
                        donate = donate.OrderBy(acti => acti.RequestDate).ToList();
                    }
                    else if (selectedSort.Equals("Newest"))
                    {
                        donate = donate.OrderByDescending(acti => acti.RequestDate).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = donate;
            }

        }

        private void ResetButtonColors()
        {
            ATbt.BackColor = SystemColors.ButtonHighlight;
            CTbt.BackColor = SystemColors.ButtonHighlight;
            DNbt.BackColor = SystemColors.ButtonHighlight;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "Time" ||
                dgv.Columns[e.ColumnIndex].Name == "RequestDate" )
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
