using Dapper;
using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Bean;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.Models.Dao
{
    internal class Dao_VolunteerModel
    {
        private dbConnection dbConnection; // Declare an instance of dbConnection

        public Dao_VolunteerModel()
        {
            dbConnection = new dbConnection(); // Initialize dbConnection instance
        }

        // Display Parts
        public List<VolunteerModel> GetVolunteerInfo(string VolunteerID)
        {
            // Open the database connection
            dbConnection.OpenConnection();

            // Get the SqlConnection object from dbConnection
            SqlConnection connection = dbConnection.GetConnection();

            // Perform the query using Dapper
            var volunteerList = connection.Query<VolunteerModel>($"select * from Volunteer where VolunteerID = '{VolunteerID}'").ToList();

            // Close the database connection
            dbConnection.CloseConnection();

            // Return the result
            return volunteerList;
        }
        public List<VolunteerModel> GetAllVolunteerInfo()
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();
            var allvolunteerList = connection.Query<VolunteerModel>("SELECT VolunteerID, FirstName, LastName, Position, Gender, Age, CONVERT(varchar, DateOfBirth, 106) AS DateOfBirth, CONVERT(varchar, DateStartVolunteer, 106) AS DateStartVolunteer, Email, PhoneNumber, Address FROM Volunteer").ToList();
            dbConnection.CloseConnection();
            return allvolunteerList;
        }

        // Insert(Add) Parts
        public void InsertVolunteerInfo(string VolunteerID, string VolunteerFirstName, string VolunteerLastName, string Position,
            bool VolunteerGender, int VolunteerAge, string dateOfBirth, string DateStartVolunteer, string VolunteerEmail, string VolunteerPhoneNumber,
            string VolunteerAddress)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            string newVolunteerID = GenerateVolunteerID();
            VolunteerID = newVolunteerID;

            try
            {
                // Construct the SQL query with parameters
                string sqlQuery = "INSERT INTO Volunteer (VolunteerID, FirstName, LastName, Position, Gender, Age, DateOfBirth, DateStartVolunteer, Email, PhoneNumber, Address) " +
                                  "VALUES (@VolunteerID, @FirstName, @LastName, @Position, @Gender, @Age, @DateOfBirth, @DateStartVolunteer, @Email, @PhoneNumber, @Address)";

                // Execute the SQL query with parameters
                connection.Execute(sqlQuery, new
                {
                    VolunteerID = VolunteerID,
                    FirstName = VolunteerFirstName,
                    LastName = VolunteerLastName,
                    Position = Position,
                    Gender = VolunteerGender,
                    Age = VolunteerAge,
                    DateOfBirth = dateOfBirth,
                    DateStartVolunteer = DateStartVolunteer,
                    Email = VolunteerEmail,
                    PhoneNumber = VolunteerPhoneNumber,
                    Address = VolunteerAddress
                });
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("A Volunteer member with the same ID already exists.");
                }
                else
                {
                    MessageBox.Show("An error occurred while inserting the Volunteer member: " + ex.Message);
                }
            }

            // Close the database connection
            dbConnection.CloseConnection();
        }
        private string GenerateVolunteerID()
        {
            string newVolunteerID = "";

            try
            {
                // Truy vấn SQL để lấy VolunteerID cuối cùng trong cơ sở dữ liệu
                string query = "SELECT TOP 1 VolunteerID FROM Volunteer ORDER BY VolunteerID DESC";
                dbConnection.OpenConnection();

                // Execute the query using Dapper
                var lastVolunteerID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                // Tạo StaffID mới
                if (!string.IsNullOrEmpty(lastVolunteerID))
                {
                    int lastNumber = int.Parse(lastVolunteerID.Substring(1)); // Remove the 'S' prefix
                    int newNumber = lastNumber + 1;
                    newVolunteerID = "V" + newNumber.ToString("D3"); // D3 để đảm bảo số có ba chữ số
                }
                else
                {
                    newVolunteerID = "V001"; // Nếu không có StaffID nào trong cơ sở dữ liệu, ta bắt đầu từ S001
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return newVolunteerID;
        }

        //Delete pearts
        public void DeleteVolunteer(string volunteerID)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            // Delete the staff member with the specified ID from the database
            connection.Execute("DELETE FROM Volunteer WHERE VolunteerID = @VolunteerID", new { VolunteerID = volunteerID });

            dbConnection.CloseConnection();
        }

        //Update parts
        public void UpdateVolunteer(VolunteerModel updatedVolunteer)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            try
            {
                // Construct the SQL query with parameters for updating staff information
                string sqlQuery = @"UPDATE Volunteer 
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                Position = @Position,
                                Gender = @Gender,
                                Age = @Age,
                                DateOfBirth = @DateOfBirth,
                                DateStartVolunteer = @DateStartVolunteer,
                                Email = @Email,
                                PhoneNumber = @PhoneNumber,
                                Address = @Address
                            WHERE VolunteerID = @VolunteerID";

                // Execute the SQL query with parameters
                connection.Execute(sqlQuery, updatedVolunteer);
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred while updating the Volunteer member: " + ex.Message);
            }

            // Close the database connection
            dbConnection.CloseConnection();
        }
    }
}
