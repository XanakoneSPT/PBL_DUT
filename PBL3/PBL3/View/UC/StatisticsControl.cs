using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Bo;
using PBL3.Models.Dao;

namespace PBL3.View
{
    public partial class StatisticsControl : UserControl
    {
        private readonly Bo_ChildrenModel boChildrenModel;
        private readonly Bo_StaffModel boStaffModel;
        private readonly Bo_FinancialModel boFinancialModel;

        private string dgvShowAs = "";

        public StatisticsControl()
        {
            InitializeComponent();
            dbConnection connection = new dbConnection();
            boStaffModel = new Bo_StaffModel();
            boChildrenModel = new Bo_ChildrenModel(connection);
            boFinancialModel = new Bo_FinancialModel(connection);
        }
        private void StatisticsControl_Load(object sender, EventArgs e)
        {
            try
            {
                ChildrenBT_Click(sender, e);
                RefreshStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CustomizeDataGridView();
        }
        private void RefreshStatistics()
        {
            TotalChildren();
            TotalStaff();
            TotalMoney();
            TotalDonate();
        }
        public void AddBorderToPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                BackColor = panel.BackColor;
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle, Color.Gray, ButtonBorderStyle.Outset);

                int shadowWidth = 2;
                Color shadowColor = Color.FromArgb(100, Color.Gray);
                using (SolidBrush shadowBrush = new SolidBrush(shadowColor))
                {
                    e.Graphics.FillRectangle(shadowBrush, panel.Right, panel.Top + shadowWidth, shadowWidth, panel.Height);
                    e.Graphics.FillRectangle(shadowBrush, panel.Left + shadowWidth, panel.Bottom, panel.Width, shadowWidth);
                }
            }
        }
        public void TotalChildren()
        {
            int totalChildrenCount = boChildrenModel.GetTotalChildrenCount();
            childrenTotalLB.Text = $"{totalChildrenCount} Children";
        }
        public void TotalStaff()
        {
            int totalStaffCount = boStaffModel.GetTotalStaffCount();
            stafftotalLB.Text = $"{totalStaffCount} Staffs";
        }
        public void TotalMoney()
        {
            decimal totalMoney = boFinancialModel.GetTotalMoney();
            moneytotalLB.Text = $"{totalMoney:C}";
        }
        public void TotalDonate()
        {
            decimal totalDonate = boFinancialModel.GetTotalDonateMoney();
            donatetotalLB.Text = $"{totalDonate:C}";
        }

        private void ChildrenBT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            childrenTotalLB.BackColor = Color.WhiteSmoke;

            List<ChildrenModel> children = boChildrenModel.GetChildrenList().ToList();
            dgv.DataSource = null;
            dgv.DataSource = children;

            // Define a list of status options
            List<string> ccb = new List<string> { "All", "Age", "Year get into center" };
            sortcbb.DataSource = ccb;

            dgvShowAs = "children";
            dgv.Columns["Gender"].Visible = false;
            CustomizeDataGridView();
        }
        private void StaffBT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            StaffBT.BackColor = Color.WhiteSmoke;

            List<StaffModel> staff = boStaffModel.GetAllStaff().ToList();
            dgv.DataSource = null;
            dgv.DataSource = staff;

            // Define a list of status options
            List<string> ccb = new List<string> { "All", "Age", "Start Work", "Position"};
            sortcbb.DataSource = ccb;

            dgvShowAs = "staff";
            dgv.Columns["Gender"].Visible = false;
            dgv.Columns["UserID"].Visible = false;

            CustomizeDataGridViewStaff();
        }

        private void MoneyBT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            MoneyBT.BackColor = Color.WhiteSmoke;

            List<Financial> financial = boFinancialModel.GetFinancialList().ToList();
            dgv.DataSource = null;
            dgv.DataSource = financial;

            List<string> ccb = new List<string> { "All", "Amount", "Spending" };
            sortcbb.DataSource = ccb;

            dgvShowAs = "money";

            CustomizeDataGridView();
        }

        private void DonateBT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            donatetotalLB.BackColor = Color.WhiteSmoke;

            List<Donate> donate = boFinancialModel.GetDonateList().ToList();
            dgv.DataSource = null;
            dgv.DataSource = donate;

            List<string> ccb = new List<string> { "All", "Amount", "Waiting", "Completed", "Cancelled"};
            sortcbb.DataSource = ccb;

            dgvShowAs = "donate";
            CustomizeDataGridView() ;
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            List<ChildrenModel> children = boChildrenModel.GetChildrenList().ToList();
            List<StaffModel> staff = boStaffModel.GetAllStaff().ToList();
            List<Financial> money = boFinancialModel.GetFinancialList().ToList();
            List<Donate> donate = boFinancialModel.GetDonateList().ToList();

            string selectedSort = sortcbb.SelectedItem?.ToString();

            if(dgvShowAs == "children")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Age"))
                    {
                        children = children.OrderBy(acti => acti.Age).ToList();
                    }
                    else if (selectedSort.Equals("Date get into center"))
                    {
                        children = children.OrderByDescending(acti => acti.DateGetIntoCenter).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = children;
            }
            if(dgvShowAs == "staff")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Age"))
                    {
                        staff = staff.OrderBy(acti => acti.Age).ToList();
                    }
                    else if (selectedSort.Equals("start Work"))
                    {
                        staff = staff.OrderByDescending(acti => acti.StartWorkDate).ToList();
                    }
                    else if (selectedSort.Equals("Position"))
                    {
                        staff = staff.OrderByDescending(acti => acti.Position).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = staff;
            }
            if(dgvShowAs == "money")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Amount"))
                    {
                        money = money.OrderBy(acti => acti.TotalMoney).ToList();
                    }
                    else if (selectedSort.Equals("Spending"))
                    {
                        money = money.OrderByDescending(acti => acti.AmountSpend).ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = money;
            }
            if(dgvShowAs == "donate")
            {
                // Filter by sort if selected
                if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
                {
                    if (selectedSort.Equals("Amount"))
                    {
                        donate = donate.OrderBy(acti => acti.AmountRequest).ToList();
                    }
                    else if (selectedSort.Equals("Waiting"))
                    {
                        donate = donate.OrderByDescending(acti => acti.Status == "Waiting").ToList();
                    }
                    else if (selectedSort.Equals("Completed"))
                    {
                        donate = donate.OrderByDescending(acti => acti.Status == "Completed").ToList();
                    }
                    else if (selectedSort.Equals("Cancelled"))
                    {
                        donate = donate.OrderByDescending(acti => acti.Status == "Cancelled").ToList();
                    }
                }

                // Update the DataGridView with the filtered feedback entries
                dgv.DataSource = donate;
            }
        }
        private void ResetButtonColors()
        {
            childrenTotalLB.BackColor = SystemColors.ButtonHighlight;
            stafftotalLB.BackColor = SystemColors.ButtonHighlight;
            moneytotalLB.BackColor = SystemColors.ButtonHighlight;
            donatetotalLB.BackColor = SystemColors.ButtonHighlight;
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
        private void CustomizeDataGridViewStaff()
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
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns[0].Width = 80;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 120;
            dgv.Columns[3].Width = 80;
            dgv.Columns[4].Width = 80;
            dgv.Columns[5].Width = 120;
            dgv.Columns[6].Width = 180;
            dgv.Columns[7].Width = 180;
            dgv.Columns[8].Width = 120;
            dgv.Columns[9].Width = 120;
            dgv.Columns[10].Width = 120;
            dgv.Columns[11].Width = 120;
            dgv.Columns[12].Width = 120;

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

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "DateOfBirth" ||
            dgv.Columns[e.ColumnIndex].Name == "DateGetIntoCenter" ||
            dgv.Columns[e.ColumnIndex].Name == "StartWorkDate" ||
            dgv.Columns[e.ColumnIndex].Name == "DataEntryDate" ||
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
