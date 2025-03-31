using PBL3.Model.Bean;
using PBL3.Model.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBL3.Models.Bo
{
    internal class Bo_EquipmentModel
    {
        private Dao_EquipmentModel daoEquipmentModel;

        public Bo_EquipmentModel()
        {
            daoEquipmentModel = new Dao_EquipmentModel();
        }
        public List<EquipmentModel> SearchEquipmentInfo(string equipmentID)
        {
            return daoEquipmentModel.GetEquipmentInfo(equipmentID);
        }

        public DataTable DisplayEquipmentInfo()
        {
            DataTable dt = new DataTable();
            var equipmentList = daoEquipmentModel.GetAllEquipmentInfo();

            // Add columns to the DataTable
            dt.Columns.Add("Equipment ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Amount");

            // Convert boolean gender values to string representation
            foreach (var equipment in equipmentList)
            {
                dt.Rows.Add(equipment.EquipmentID, equipment.EquipmentName, equipment.Amount);
            }

            return dt;
        }

        public void UpdateEquipmentInfo(EquipmentModel updatedEquipment)
        {
            daoEquipmentModel.UpdateEquipment(updatedEquipment);
            MessageBox.Show("Equipment information updated.");
        }

        public void DeleteEquipmentInfo(string equipmentID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete equipment information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                daoEquipmentModel.DeleteEquipment(equipmentID);
                MessageBox.Show("Equipment information deleted.");
            }
            else
            {
                //MessageBox.Show("Deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void SaveEquipmentInfo(EquipmentModel newEquipment)
        {
            daoEquipmentModel.InsertEquipmentInfo(
                newEquipment.EquipmentID,
                newEquipment.EquipmentName,
                newEquipment.Amount
            );
            MessageBox.Show("New Equipment added.");
        }
    }
}
