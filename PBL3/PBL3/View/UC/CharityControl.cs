using PBL3.Model.Bean;
using PBL3.Models.Bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBL3.View
{
    public partial class CharityControl : UserControl
    {
        private Bo_CharityModel boCharityModel;

        public CharityControl()
        {
            InitializeComponent();
            boCharityModel = new Bo_CharityModel();
        }

        public void SetButtonVisibility(bool isVisible)
        {
            CharityAddButton.Visible = isVisible;
            CharityDeleteButton.Visible = isVisible;
            CharityUpdateButton.Visible = isVisible;
            CharityRefreshButton.Visible = isVisible;
        }
        private void CharityControl_Load_1(object sender, EventArgs e)
        {
            UpdateDataBindings();
            CustomizeDataGridView();
        }
        private void UpdateDataBindings()
        {
            dgv.DataSource = null;
            dgv.DataSource = boCharityModel.DisplayCharityInfo();
            if (dgv.Columns.Contains("Description"))
            {
                dgv.Columns["Description"].Visible = false;
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
                dgv.Columns[0].Width = 90;
                dgv.Columns[1].Width = 150;
                dgv.Columns[4].Width = 165;
                dgv.Columns[5].Width = 195;
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
        private void SearchBox_Click(object sender, EventArgs e)
        {
            string charityID = CharityIDSearchBox.Text;
            dgv.DataSource = boCharityModel.SearchCharityInfo(charityID);
            CustomizeDataGridView();
        }

        private void CharityIDSearchBox_TextChanged(object sender, EventArgs e)
        {
            string charityID = CharityIDSearchBox.Text;
            dgv.DataSource = boCharityModel.SearchCharityInfo(charityID);
        }

        private void CharityDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                PopulateInsertFields(selectedRow);
            }
        }

        private void PopulateInsertFields(DataGridViewRow selectedRow)
        {
            CharityIDInsert.Text = selectedRow.Cells["Charity Activity ID"].Value?.ToString() ?? "";
            CharityNameInsert.Text = selectedRow.Cells["Charity Name"].Value?.ToString() ?? "";
            CharityDescriptionrichTextBox.Text = selectedRow.Cells["Description"].Value?.ToString() ?? "";
            string dateTime = selectedRow.Cells["Date Time"].Value?.ToString() ?? "";
            string[] dateTimeParts = dateTime.Split(' ');
            if (dateTimeParts.Length == 2)
            {
                CharityDateInsert.Value = DateTime.Parse(dateTimeParts[0]);
                CharityTimeInsert.Value = DateTime.ParseExact(dateTimeParts[1], "HH:mm", null);
            }
            CharityLocationInsert.Text = selectedRow.Cells["Location"].Value?.ToString() ?? "";
            CharityOrganizerInsert.Text = selectedRow.Cells["Organizer"].Value?.ToString() ?? "";
            MoneyDonateInsert.Text = selectedRow.Cells["Donate"].Value?.ToString() ?? "";
        }

        private void CharityAddButton_Click(object sender, EventArgs e)
        {
            string dateTime = $"{CharityDateInsert.Value:yyyy-MM-dd} {CharityTimeInsert.Value:HH:mm:ss}";
            CharityModel newCharity = new CharityModel
            {
                CharityActivityID = CharityIDInsert.Text,
                CharityName = CharityNameInsert.Text,
                CharityDescription = CharityDescriptionrichTextBox.Text,
                CharityDateTime = dateTime,
                Location = CharityLocationInsert.Text,
                Organizer = CharityOrganizerInsert.Text,
                MoneyDonate = MoneyDonateInsert.Text,
            };

            boCharityModel.SaveCharityInfo(newCharity);
            UpdateDataBindings();
            CustomizeDataGridView();
        }

        private void CharityDeleteButton_Click(object sender, EventArgs e)
        {
            string charityID = CharityIDInsert.Text;
            boCharityModel.DeleteCharityInfo(charityID);
            UpdateDataBindings();
            CustomizeDataGridView();
        }

        private void CharityUpdateButton_Click(object sender, EventArgs e)
        {
            string dateTime = $"{CharityDateInsert.Value:yyyy-MM-dd} {CharityTimeInsert.Value:HH:mm:ss}";
            CharityModel updatedCharity = new CharityModel
            {
                CharityActivityID = CharityIDInsert.Text,
                CharityName = CharityNameInsert.Text,
                CharityDescription = CharityDescriptionrichTextBox.Text,
                CharityDateTime = dateTime,
                Location = CharityLocationInsert.Text,
                Organizer = CharityOrganizerInsert.Text,
                MoneyDonate = MoneyDonateInsert.Text,
            };

            boCharityModel.UpdateCharityInfo(updatedCharity);
            UpdateDataBindings();
            CustomizeDataGridView();
        }

        private void CharityRefreshButton_Click(object sender, EventArgs e)
        {
            ClearInsertFields();
            UpdateDataBindings();
            CustomizeDataGridView();
        }

        private void ClearInsertFields()
        {
            CharityIDInsert.Text = "";
            CharityNameInsert.Text = "";
            CharityDescriptionrichTextBox.Text = "";
            CharityDateInsert.Value = DateTime.Now;
            CharityTimeInsert.Value = DateTime.Now;
            CharityLocationInsert.Text = "";
            CharityOrganizerInsert.Text = "";
            MoneyDonateInsert.Text = "";
        }
    }
}
