using PBL3.Model.Bean;
using PBL3.Model.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.Models.Bo
{
    internal class Bo_CharityModel
    {
        private Dao_CharityModel daoCharityModel;

        public Bo_CharityModel()
        {
            daoCharityModel = new Dao_CharityModel();
        }

        public List<CharityModel> SearchCharityInfo(string charityID)
        {
            return daoCharityModel.GetCharityInfo(charityID);
        }

        public DataTable DisplayCharityInfo()
        {
            DataTable dt = new DataTable();
            var charityList = daoCharityModel.GetAllCharityInfo();

            // Add columns to the DataTable
            dt.Columns.Add("Charity Activity ID");
            dt.Columns.Add("Charity Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Date Time");
            dt.Columns.Add("Location");
            dt.Columns.Add("Organizer");
            dt.Columns.Add("Donate");

            // Add rows to the DataTable
            foreach (var charity in charityList)
            {
                dt.Rows.Add(charity.CharityActivityID, charity.CharityName, charity.CharityDescription, charity.DateAndTime, charity.Location, charity.Organizer, charity.MoneyDonate);
            }

            return dt;

        }

        public void UpdateCharityInfo(CharityModel updatedCharity)
        {
            daoCharityModel.UpdateCharity(updatedCharity);
            MessageBox.Show("Charity information updated.");
        }

        public void DeleteCharityInfo(string charityID)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete equipment information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                daoCharityModel.DeleteCharity(charityID);
                MessageBox.Show("Charity information deleted.");
            }
            else
            {
                //MessageBox.Show("Deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SaveCharityInfo(CharityModel newCharity)
        {
            daoCharityModel.InsertCharityInfo(
                newCharity.CharityActivityID,
                newCharity.CharityName,
                newCharity.CharityDescription,
                newCharity.CharityDateTime,
                newCharity.Location,
                newCharity.Organizer,
                newCharity.MoneyDonate
            );
            MessageBox.Show("New Charity activity added.");
        }
        public List<CharityModel> GetCharityActivities()
        {
            return daoCharityModel.GetAllCharityInfo();
        }
    }
}
