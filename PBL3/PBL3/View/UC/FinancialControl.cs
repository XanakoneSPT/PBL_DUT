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
    public partial class FinancialControl : UserControl
    {
        private Bo_FinancialModel boFinancial;
        public FinancialControl()
        {
            InitializeComponent();
            dbConnection dbConnection = new dbConnection();
            boFinancial = new Bo_FinancialModel(dbConnection);
        }
        private void FinancialControl_Load(object sender, EventArgs e)
        {
            LoadData();
            CustomizeDataGridView();
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.DataSource = boFinancial.GetFinancialList();
            if (dgv.Columns.Contains("Description"))
            {
                dgv.Columns["Description"].Visible = false;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Check if any of the required input fields are empty
            if (string.IsNullOrWhiteSpace(DescriptionrichTextBox.Text) ||
                string.IsNullOrWhiteSpace(TotalMoneyInsert.Text) ||
                string.IsNullOrWhiteSpace(SpendingInsert.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            Financial financial = new Financial();
            financial.Description = DescriptionrichTextBox.Text;
            financial.TotalMoney = decimal.Parse(TotalMoneyInsert.Text);
            financial.AmountSpend = decimal.Parse(SpendingInsert.Text);
            financial.DataEntryDate = DateTime.Now;

            if (boFinancial.AddFinancial(financial))
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
                string financialID = dgv.SelectedRows[0].Cells["FinancialID"].Value.ToString();
                if (boFinancial.DeleteFinancial(financialID))
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
                Financial financial = dgv.SelectedRows[0].DataBoundItem as Financial;
                if (financial != null)
                {
                    // Check if any of the required input fields are empty
                    if (string.IsNullOrWhiteSpace(DescriptionrichTextBox.Text) ||
                        string.IsNullOrWhiteSpace(TotalMoneyInsert.Text) ||
                        string.IsNullOrWhiteSpace(SpendingInsert.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields.");
                        return;
                    }
                    // Update the financial record properties based on user input or changes
                    // For example:
                    financial.Description = DescriptionrichTextBox.Text;
                    financial.TotalMoney = decimal.Parse(TotalMoneyInsert.Text);
                    financial.AmountSpend = decimal.Parse(SpendingInsert.Text);
                    financial.DataEntryDate = DateTime.Now;

                    if (boFinancial.UpdateFinancial(financial))
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
            DescriptionrichTextBox.Text = "";
            TotalMoneyInsert.Text = "";
            SpendingInsert.Text = "";
            DateInsert.Value = DateTime.Now;

            LoadData();
            CustomizeDataGridView();
        }
        private void DonateBT_Click(object sender, EventArgs e)
        {
            //open DonateControl to show in panel1 in Main form
            // Get the parent form (MainForm in this case)
            Form mainForm = this.FindForm();

            if (mainForm is Main)
            {
                // Create an instance of DonateControl
                DonateControl donateControl = new DonateControl();

                // Call the ShowUserControl method in MainForm to display DonateControl
                ((Main)mainForm).ShowUserControl(donateControl);
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
                IDInsert.Text = row.Cells["FinancialID"].Value.ToString();
                DescriptionrichTextBox.Text = row.Cells["Description"].Value.ToString();
                TotalMoneyInsert.Text = row.Cells["TotalMoney"].Value.ToString();
                SpendingInsert.Text = row.Cells["AmountSpend"].Value.ToString();
                DateInsert.Value = Convert.ToDateTime(row.Cells["DataEntryDate"].Value);
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "DataEntryDate")
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
            List<Financial> financials = boFinancial.GetFinancialList();

            if (!string.IsNullOrEmpty(searchText))
            {
                financials = financials.Where(f =>
                    f.FinancialID.Contains(searchText) ||
                    f.Description.Contains(searchText) ||
                    f.TotalMoney.ToString().Contains(searchText) ||
                    f.AmountSpend.ToString().Contains(searchText)
                ).ToList();
            }

            dgv.DataSource = null;
            dgv.DataSource = financials;
            CustomizeDataGridView();
        }
    }
}
