using PBL3.Model.Bean;
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
    public partial class EquipmentControl : UserControl
    {
        private Bo_EquipmentModel boEquipmentModel;
        public EquipmentControl()
        {
            InitializeComponent();
            boEquipmentModel = new Bo_EquipmentModel();
            if (EquipmentIDSearchBox == null)
            {
                EquipmentRefreshButton.Visible = false;
            }
            UpdateDataBindings();
        }
        private void EquipmentControl_Load(object sender, EventArgs e)
        {
            CustomizeDataGridView();
        }
        private void UpdateDataBindings()
        {
            // Refresh the data source of DataGridView to reflect the changes
            dgv.DataSource = null;
            dgv.DataSource = boEquipmentModel.DisplayEquipmentInfo();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string equipmentID = EquipmentIDSearchBox.Text;
            dgv.DataSource = boEquipmentModel.SearchEquipmentInfo(equipmentID);
            UpdateDataBindings();
            CustomizeDataGridView();
        }

        private void EquipmentIDSearchBox_TextChanged(object sender, EventArgs e)
        {
            string equipmentID = EquipmentIDSearchBox.Text;
            dgv.DataSource = boEquipmentModel.SearchEquipmentInfo(equipmentID);
        }

        private void EquipmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                // Extract the data from the selected row and populate the input fields
                EquipmentIDInsert.Text = selectedRow.Cells["Equipment ID"].Value?.ToString() ?? "";
                EquipmentNameInsert.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                EquipmentAmountInsert.Text = selectedRow.Cells["Amount"].Value?.ToString() ?? "";
            }
        }

        private void EquipmentAddButton_Click(object sender, EventArgs e)
        {
            EquipmentModel newEquipment = new EquipmentModel
            {
                EquipmentID = EquipmentIDInsert.Text,
                EquipmentName = EquipmentNameInsert.Text,
                Amount = Convert.ToInt32(EquipmentAmountInsert.Text)
            };
            boEquipmentModel.SaveEquipmentInfo(newEquipment);
            UpdateDataBindings();
            dgv.DataSource = boEquipmentModel.DisplayEquipmentInfo();
            CustomizeDataGridView();
        }

        private void EquipmentDeleteButton_Click(object sender, EventArgs e)
        {
            string equipmentID = EquipmentIDInsert.Text;
            boEquipmentModel.DeleteEquipmentInfo(equipmentID);
            UpdateDataBindings();
            dgv.DataSource = boEquipmentModel.DisplayEquipmentInfo();
            CustomizeDataGridView();
        }

        private void EquipmentUpdateButton_Click(object sender, EventArgs e)
        {
            EquipmentModel updatedEquipment = new EquipmentModel
            {
                EquipmentID = EquipmentIDInsert.Text,
                EquipmentName = EquipmentNameInsert.Text,
                Amount = Convert.ToInt32(EquipmentAmountInsert.Text)
            };
            boEquipmentModel.UpdateEquipmentInfo(updatedEquipment);
            UpdateDataBindings();
            dgv.DataSource = boEquipmentModel.DisplayEquipmentInfo();
            CustomizeDataGridView();
        }

        private void EquipmentRefreshButton_Click(object sender, EventArgs e)
        {
            EquipmentIDInsert.Text = "";
            EquipmentNameInsert.Text = "";
            EquipmentAmountInsert.Text = "";

            UpdateDataBindings();
            CustomizeDataGridView();
        }

        private void EquipmentDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Select the cell.
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Get the position of the mouse relative to the DataGridView.
                var relativeMousePosition = dgv.PointToClient(Cursor.Position);

                // Show the context menu strip at the mouse position.
                contextMenuStrip1.Show(dgv, relativeMousePosition);
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
