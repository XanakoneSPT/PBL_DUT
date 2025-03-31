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
    internal class Dao_EquipmentModel
    {
        private dbConnection dbConnection; // Declare an instance of dbConnection

        public Dao_EquipmentModel()
        {
            dbConnection = new dbConnection(); // Initialize dbConnection instance
        }
        // Display Parts
        public List<EquipmentModel> GetEquipmentInfo(string EquipmentID)
        {
            // Open the database connection
            dbConnection.OpenConnection();

            // Get the SqlConnection object from dbConnection
            SqlConnection connection = dbConnection.GetConnection();

            // Perform the query using Dapper
            var equipmentList = connection.Query<EquipmentModel>($"select * from Equipment where EquipmentID = '{EquipmentID}'").ToList();

            // Close the database connection
            dbConnection.CloseConnection();

            // Return the result
            return equipmentList;
        }
        public List<EquipmentModel> GetAllEquipmentInfo()
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();
            var allequipmentList = connection.Query<EquipmentModel>("SELECT * FROM Equipment").ToList();
            dbConnection.CloseConnection();
            return allequipmentList;
        }

        // Insert(Add) Parts
        public void InsertEquipmentInfo(string EquipmentID, string EquipmentName, int Amount)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            string newEquipmentID = GenerateEquipmentID();
            EquipmentID = newEquipmentID;

            try
            {
                // Construct the SQL query with parameters for inserting equipment information
                string sqlQuery = "INSERT INTO Equipment (EquipmentID, EquipmentName, Amount) " +
                                  "VALUES (@EquipmentID, @EquipmentName, @Amount)";

                // Execute the SQL query with parameters
                connection.Execute(sqlQuery, new
                {
                    EquipmentID = EquipmentID,
                    EquipmentName = EquipmentName,
                    Amount = Amount
                });
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred while inserting equipment information: " + ex.Message);
            }

            // Close the database connection
            dbConnection.CloseConnection();
        }
        private string GenerateEquipmentID()
        {
            string newEquipmentID = "";

            try
            {
                // Truy vấn SQL để lấy StaffID cuối cùng trong cơ sở dữ liệu
                string query = "SELECT TOP 1 EquipmentID FROM Equipment ORDER BY EquipmentID DESC";
                dbConnection.OpenConnection();

                // Execute the query using Dapper
                var lastEquipmentID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                // Tạo StaffID mới
                if (!string.IsNullOrEmpty(lastEquipmentID))
                {
                    int lastNumber = int.Parse(lastEquipmentID.Substring(1)); // Remove the 'S' prefix
                    int newNumber = lastNumber + 1;
                    newEquipmentID = "E" + newNumber.ToString("D3"); // D3 để đảm bảo số có ba chữ số
                }
                else
                {
                    newEquipmentID = "E001"; // Nếu không có StaffID nào trong cơ sở dữ liệu, ta bắt đầu từ S001
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

            return newEquipmentID;
        }

        //Delete pearts
        public void DeleteEquipment(string equipmentID)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            // Delete the staff member with the specified ID from the database
            connection.Execute("DELETE FROM Equipment WHERE EquipmentID = @EquipmentID", new { EquipmentID = equipmentID });

            dbConnection.CloseConnection();
        }

        //Update parts
        public void UpdateEquipment(EquipmentModel updatedEquipment)
        {
            dbConnection.OpenConnection();
            SqlConnection connection = dbConnection.GetConnection();

            try
            {
                // Construct the SQL query with parameters for updating equipment information
                string sqlQuery = @"UPDATE Equipment 
                            SET EquipmentName = @EquipmentName,
                                Amount = @Amount
                            WHERE EquipmentID = @EquipmentID";

                // Execute the SQL query with parameters
                connection.Execute(sqlQuery, new
                {
                    EquipmentName = updatedEquipment.EquipmentName,
                    Amount = updatedEquipment.Amount,
                    EquipmentID = updatedEquipment.EquipmentID
                });
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred while updating equipment information: " + ex.Message);
            }

            // Close the database connection
            dbConnection.CloseConnection();
        }
    }
}
