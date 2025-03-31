using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using System.Data.SqlClient;
using PBL3.Model.Bean;
using System.Windows.Forms;

namespace PBL3.Model.Dao
{
    internal class Dao_CharityModel
    {
        private dbConnection dbConnection; // Declare an instance of dbConnection

        public Dao_CharityModel()
        {
            dbConnection = new dbConnection(); // Initialize dbConnection instance
        }
        // Display Parts
        public List<CharityModel> GetCharityInfo(string CharityID)
        {
            // Open the database connection
            dbConnection.OpenConnection();

            // Get the SqlConnection object from dbConnection
            SqlConnection connection = dbConnection.GetConnection();

            // Perform the query using Dapper
            var charityList = connection.Query<CharityModel>($"select * from CharityActivity where CharityActivityID = '{CharityID}'").ToList();

            // Close the database connection
            dbConnection.CloseConnection();

            // Return the result
            return charityList;
        }
        public List<CharityModel> GetAllCharityInfo()
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();
            var allcharityList = connection.Query<CharityModel>("SELECT * FROM CharityActivity").ToList();
            dbConnection.CloseConnection();
            return allcharityList;
        }

        // Insert(Add) Parts
        public void InsertCharityInfo(string CharityActivityID, string CharityName, string CharityDescription, string CharityDateTime, string Location, string Organizer, string MoneyDonate)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            string newCharityID = GenerateCharityID();
            CharityActivityID = newCharityID;

            try
            {
                // Construct the SQL query with parameters
                string sqlQuery = "INSERT INTO CharityActivity (CharityActivityID, CharityName, CharityDescription, CharityDateTime, Location, Organizer, MoneyDonate) " +
                                  "VALUES (@CharityActivityID, @CharityName, @CharityDescription, @CharityDateTime, @Location, @Organizer, @MoneyDonate)";

                // Execute the SQL query with parameters
                connection.Execute(sqlQuery, new
                {
                    CharityActivityID = CharityActivityID,
                    CharityName = CharityName,
                    CharityDescription = CharityDescription,
                    CharityDateTime = CharityDateTime,
                    Location = Location,
                    Organizer = Organizer,
                    MoneyDonate = MoneyDonate
                });
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("A charity with the same ID already exists.");
                }
                else
                {
                    MessageBox.Show("An error occurred while inserting charity information: " + ex.Message);
                }
            }

            // Close the database connection
            dbConnection.CloseConnection();
        }
        private string GenerateCharityID()
        {
            string newCharityID = "";

            try
            {
                // Truy vấn SQL để lấy StaffID cuối cùng trong cơ sở dữ liệu
                string query = "SELECT TOP 1 CharityActivityID FROM CharityActivity ORDER BY CharityActivityID DESC";
                dbConnection.OpenConnection();

                // Execute the query using Dapper
                var lastCharityID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                // Tạo StaffID mới
                if (!string.IsNullOrEmpty(lastCharityID))
                {
                    int lastNumber = int.Parse(lastCharityID.Substring(2)); // Remove the 'S' prefix
                    int newNumber = lastNumber + 1;
                    newCharityID = "CA" + newNumber.ToString("D3"); // D3 để đảm bảo số có ba chữ số
                }
                else
                {
                    newCharityID = "CA001"; // Nếu không có StaffID nào trong cơ sở dữ liệu, ta bắt đầu từ S001
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

            return newCharityID;
        }

        //Delete pearts
        public void DeleteCharity(string charityID)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            // Delete the staff member with the specified ID from the database
            connection.Execute("DELETE FROM CharityActivity WHERE CharityActivityID = @CharityActivityID", new { CharityActivityID = charityID });

            dbConnection.CloseConnection();
        }

        //Update parts
        public void UpdateCharity(CharityModel updatedCharity)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            try
            {
                // Construct the SQL query with parameters for updating charity information
                string sqlQuery = @"UPDATE CharityActivity 
                    SET CharityName = @CharityName,
                        CharityDescription = @CharityDescription,
                        CharityDateTime = @CharityDateTime,
                        Location = @Location,
                        Organizer = @Organizer,
                        MoneyDonate = @MoneyDonate
                    WHERE CharityActivityID = @CharityActivityID";

                // Execute the SQL query with parameters
                connection.Execute(sqlQuery, new
                {
                    CharityName = updatedCharity.CharityName,
                    CharityDescription = updatedCharity.CharityDescription,
                    CharityDateTime = updatedCharity.CharityDateTime,
                    Location = updatedCharity.Location,
                    Organizer = updatedCharity.Organizer,
                    MoneyDonate = updatedCharity.MoneyDonate,
                    CharityActivityID = updatedCharity.CharityActivityID
                });
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred while updating charity information: " + ex.Message);
            }
            // Close the database connection
            dbConnection.CloseConnection();
        }
    }
}
