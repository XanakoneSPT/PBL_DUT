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

namespace PBL3.Models.Dao
{
    internal class Dao_ActivityModel
    {
        private dbConnection dbConnection;

        public Dao_ActivityModel(dbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public ActivityModel GetActivityByID(string activityID)
        {
            dbConnection dbConnection = new dbConnection();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Activity WHERE ActivityID = @ActivityID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ActivityID", activityID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapActivityFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<ActivityModel> GetActivities()
        {
            dbConnection dbConnection = new dbConnection();
            List<ActivityModel> activities = new List<ActivityModel>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Activity";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            activities.Add(MapActivityFromReader(reader));
                        }
                    }
                }
            }

            return activities;
        }

        public void AddActivity(ActivityModel activity)
        {
            // Generate a new activity ID
            activity.ActivityID = GenerateActivityID();

            dbConnection dbConnection = new dbConnection();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "INSERT INTO Activity (ActivityID, Time, Location, Description, Name) " +
                               "VALUES (@ActivityID, @Time, @Location, @Description, @Name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ActivityID", activity.ActivityID);
                    command.Parameters.AddWithValue("@Time", activity.Time);
                    command.Parameters.AddWithValue("@Location", activity.Location);
                    command.Parameters.AddWithValue("@Description", activity.Description);
                    command.Parameters.AddWithValue("@Name", activity.Name);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public string GenerateActivityID()
        {
            string newActivityID = "";

            try
            {
                // Truy vấn SQL để lấy StaffID cuối cùng trong cơ sở dữ liệu
                string query = "SELECT TOP 1 ActivityID FROM Activity ORDER BY ActivityID DESC";
                dbConnection.OpenConnection();

                // Execute the query using Dapper
                var lastActivityID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                // Tạo StaffID mới
                if (!string.IsNullOrEmpty(lastActivityID))
                {
                    int lastNumber = int.Parse(lastActivityID.Substring(2)); // Remove the 'S' prefix
                    int newNumber = lastNumber + 1;
                    newActivityID = "A" + newNumber.ToString("D3"); // D3 để đảm bảo số có ba chữ số
                }
                else
                {
                    newActivityID = "A001"; // Nếu không có StaffID nào trong cơ sở dữ liệu, ta bắt đầu từ S001
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

            return newActivityID;
        }
        public void DeleteActivity(string id)   
        {
            dbConnection dbConnection = new dbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "DELETE FROM Activity WHERE ActivityID = @ActivityID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ActivityID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateActivity(ActivityModel activity)
        {
            dbConnection dbConnection = new dbConnection();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "UPDATE Activity SET Time = @Time, Location = @Location, Description = @Description, Name = @Name WHERE ActivityID = @ActivityID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Time", activity.Time);
                    command.Parameters.AddWithValue("@Location", activity.Location);
                    command.Parameters.AddWithValue("@Description", activity.Description);
                    command.Parameters.AddWithValue("@Name", activity.Name);
                    command.Parameters.AddWithValue("@ActivityID", activity.ActivityID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private ActivityModel MapActivityFromReader(SqlDataReader reader)
        {
            return new ActivityModel
            {
                ActivityID = reader["ActivityID"].ToString(),
                Time = Convert.ToDateTime(reader["Time"]),
                Location = reader["Location"].ToString(),
                Description = reader["Description"].ToString(),
                Name = reader["Name"].ToString()
            };
        }
    }
}
