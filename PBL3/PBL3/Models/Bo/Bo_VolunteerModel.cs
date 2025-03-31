using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Bean;
using PBL3.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.Models.Bo
{
    internal class Bo_VolunteerModel
    {
        private Dao_VolunteerModel daoVolunteerModel;

        public Bo_VolunteerModel()
        {
            daoVolunteerModel = new Dao_VolunteerModel();
        }
        public List<VolunteerModel> SearchVolunteerInfo(string volunteerID)
        {
            return daoVolunteerModel.GetVolunteerInfo(volunteerID);
        }
        public DataTable DisplayVolunteerInfo()
        {
            DataTable dt = new DataTable();
            var volunteerList = daoVolunteerModel.GetAllVolunteerInfo();

            // Add columns to the DataTable
            dt.Columns.Add("Volunteer ID");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Position");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Age");
            dt.Columns.Add("Date Of Birth");
            dt.Columns.Add("Date Start Volunteer");
            dt.Columns.Add("Phone Number");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");

            // Convert boolean gender values to string representation
            foreach (var volunteer in volunteerList)
            {
                dt.Rows.Add(volunteer.VolunteerID, volunteer.FirstName, volunteer.LastName, volunteer.Position, volunteer.GenderString, volunteer.Age, volunteer.DateOfBirthString, volunteer.DateStartVolunteerString, volunteer.PhoneNumber, volunteer.Address, volunteer.Email);
            }

            return dt;
        }
        public void UpdateVolunteerInfo(VolunteerModel updatedVolunteer)
        {
            daoVolunteerModel.UpdateVolunteer(updatedVolunteer);
            MessageBox.Show("Volunteer information updated.");
        }
        public void DeleteVolunteerInfo(string volunteerID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete Volunteer information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                daoVolunteerModel.DeleteVolunteer(volunteerID);
                MessageBox.Show("Volunteer information deleted.");
            }
            else
            {
                //MessageBox.Show("Deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void SaveVolunteerInfo(VolunteerModel newVolunteer)
        {
            daoVolunteerModel.InsertVolunteerInfo(
                newVolunteer.VolunteerID,
                newVolunteer.FirstName,
                newVolunteer.LastName,
                newVolunteer.Position,
                newVolunteer.Gender,
                newVolunteer.Age,
                newVolunteer.DateOfBirth,
                newVolunteer.DateStartVolunteer,
                newVolunteer.Email,
                newVolunteer.PhoneNumber,
                newVolunteer.Address
            );
            MessageBox.Show("New volunteer information added.");
        }
    }
}
