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

namespace PBL3.View.UC
{
    public partial class DonateControl : UserControl
    {
        private Bo_FinancialModel boFinacial;
        public DonateControl()
        {
            InitializeComponent();
            dbConnection dbConnection = new dbConnection();
            boFinacial = new Bo_FinancialModel(dbConnection);
        }
        private void DonateControl_Load(object sender, EventArgs e)
        {
            LoadData();
            Setcbb();
            SetSortcbb();
            CustomizeDataGridView();
        }
        private void SetSortcbb()
        {
            // Define a list of status options
            List<string> ccb = new List<string> { "All", "Waiting", "Completed", "Cancelled" };
            SortCBB.DataSource = ccb;
        }
        private void Setcbb()
        {
            // Define a list of status options
            List<string> statusOptions = new List<string> { "Waiting", "Completed", "Cancelled" };
            cbbStatus.DataSource = statusOptions;
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.DataSource = boFinacial.GetDonateList();
            if (dgv.Columns.Contains("Description"))
            {
                dgv.Columns["Description"].Visible = false;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Check if any of the required input fields are empty
            if (string.IsNullOrWhiteSpace(DescriptionTxt.Text) ||
                string.IsNullOrWhiteSpace(RequestNameInsert.Text) ||
                string.IsNullOrWhiteSpace(AmountRequestInsert.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            Donate donate = new Donate();
            donate.Description = DescriptionTxt.Text;
            donate.RequestName = RequestNameInsert.Text;
            donate.AmountRequest = decimal.Parse(AmountRequestInsert.Text);
            donate.RequestDate = DateTime.Now;
            donate.Status = cbbStatus.SelectedItem.ToString();

            if (boFinacial.AddDonate(donate))
            {
                MessageBox.Show("Financial record added successfully.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to add financial record.");
            }
            CustomizeDataGridView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string donateID = dgv.SelectedRows[0].Cells["DonateID"].Value.ToString();
                if (boFinacial.DeleteDonate(donateID))
                {
                    MessageBox.Show("Financial record deleted successfully.");
                    LoadData(); // Refresh the DataGridView after deleting the record
                }
                else
                {
                    MessageBox.Show("Failed to delete financial record.");
                }
            }
            else
            {
                MessageBox.Show("Please select a financial record to delete.");
            }
            CustomizeDataGridView();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                // Retrieve the selected financial record from the DataGridView
                Donate donate = dgv.SelectedRows[0].DataBoundItem as Donate;
                if (donate != null)
                {
                    // Check if any of the required input fields are empty
                    if (string.IsNullOrWhiteSpace(DescriptionTxt.Text) ||
                        string.IsNullOrWhiteSpace(RequestNameInsert.Text) ||
                        string.IsNullOrWhiteSpace(AmountRequestInsert.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields.");
                        return;
                    }
                    // Update the financial record properties based on user input or changes
                    // For example:
                    donate.Description = DescriptionTxt.Text;
                    donate.RequestName = RequestNameInsert.Text;
                    donate.AmountRequest = decimal.Parse(AmountRequestInsert.Text);
                    donate.RequestDate = DateTime.Now;
                    donate.Status = cbbStatus.SelectedItem.ToString();

                    if (boFinacial.UpdateDonate(donate))
                    {
                        MessageBox.Show("Financial record updated successfully.");
                        LoadData(); // Refresh the DataGridView after updating the record
                    }
                    else
                    {
                        MessageBox.Show("Failed to update financial record.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a financial record to update.");
            }
            CustomizeDataGridView();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            IDInsert.Text = "";
            DescriptionTxt.Text = "";
            RequestNameInsert.Text = "";
            AmountRequestInsert.Text = "";
            DateInsert.Value = DateTime.Now;
            cbbStatus.SelectedIndex = 0;

            LoadData();
            CustomizeDataGridView();
        }
        private void FinancialBT_Click(object sender, EventArgs e)
        {
            // Get the parent form (MainForm in this case)
            Form mainForm = this.FindForm();

            if (mainForm is Main)
            {
                // Create an instance of DonateControl
                FinancialControl financialControl = new FinancialControl();

                // Call the ShowUserControl method in MainForm to display DonateControl
                ((Main)mainForm).ShowUserControl(financialControl);
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                IDInsert.Text = row.Cells["DonateID"].Value.ToString();
                DescriptionTxt.Text = row.Cells["Description"].Value.ToString();
                RequestNameInsert.Text = row.Cells["RequestName"].Value.ToString();
                AmountRequestInsert.Text = row.Cells["AmountRequest"].Value.ToString();
                DateInsert.Value = Convert.ToDateTime(row.Cells["RequestDate"].Value);
                cbbStatus.SelectedItem= row.Cells["Status"].Value.ToString();
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "RequestDate")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    DateTime dateValue = (DateTime)e.Value;
                    e.Value = dateValue.ToString("dd MMM yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.Trim();
            string selectedSort = SortCBB.SelectedItem?.ToString();
            List<Donate> donates = boFinacial.GetDonateList();

            if (!string.IsNullOrEmpty(searchText))
            {
                donates = donates.Where(d =>
                    d.DonateID.Contains(searchText) ||
                    d.RequestName.Contains(searchText) ||
                    d.AmountRequest.ToString().Contains(searchText)
                ).ToList();
            }

            // Filter by sort if selected
            if (!string.IsNullOrEmpty(selectedSort) && !selectedSort.Equals("All"))
            {
                if (selectedSort.Equals("Waiting"))
                {
                    donates = donates.Where(d => d.Status == "Waiting").ToList();
                }
                else if (selectedSort.Equals("Completed"))
                {
                    donates = donates.Where(d => d.Status == "Completed").ToList();
                }
                else if (selectedSort.Equals("Cancelled"))
                {
                    donates = donates.Where(d => d.Status == "Cancelled").ToList();
                }
            }

            dgv.DataSource = null;
            dgv.DataSource = donates;
            CustomizeDataGridView();
        }
    }
}
