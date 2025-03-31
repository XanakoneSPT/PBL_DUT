using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Bean;
using Dapper;
using System.Windows.Forms;

namespace PBL3.Models.Dao
{
    internal class Dao_Introduction
    {
        private readonly dbConnection _dbConnection;

        public Dao_Introduction(dbConnection connection)
        {
            _dbConnection = connection;
        }

        public List<IntroductionModel> GetIntroductionActivityListByStatus(string status)
        {
            var introductionActivities = new List<IntroductionModel>();
            string query = "SELECT * FROM IntroductionActivity";

            try
            {
                _dbConnection.OpenConnection();

                if (status != "All")
                {
                    query += " WHERE Status = @Status";
                }

                SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection());

                if (status != "All")
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    IntroductionModel introductionActivity = new IntroductionModel();
                    introductionActivity.IntroductionActivityID = reader["IntroductionActivityID"].ToString();
                    introductionActivity.IntroducerName = reader["IntroducerName"].ToString();
                    introductionActivity.IntroducerContactInfo = reader["IntroducerContactInfo"].ToString();
                    introductionActivity.DateOfIntroduction = Convert.ToDateTime(reader["DateOfIntroduction"]);
                    introductionActivity.Status = reader["Status"].ToString();
                    introductionActivity.Description = reader["Description"].ToString();
                    introductionActivity.ChildrenName = reader["ChildrenName"].ToString();
                    introductionActivity.ChildrenLastName = reader["ChildrenLastName"].ToString();
                    introductionActivity.Gender = Convert.ToBoolean(reader["Gender"]);
                    introductionActivity.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    introductionActivity.UserID = Convert.ToInt32(reader["UserID"]);

                    introductionActivities.Add(introductionActivity);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return introductionActivities;
        }


        public List<IntroductionModel> GetIntroductionActivityList()
        {
            var introductionActivities = new List<IntroductionModel>();
            const string query = "SELECT * FROM IntroductionActivity";

            try
            {
                _dbConnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var introductionActivity = new IntroductionModel
                            {
                                IntroductionActivityID = reader.GetString(0),
                                IntroducerName = reader.GetString(1),
                                IntroducerContactInfo = reader.GetString(2),
                                DateOfIntroduction = reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                Description = reader.GetString(5),
                                ChildrenName = reader.GetString(6),
                                ChildrenLastName = reader.GetString(7),
                                Gender = reader.GetBoolean(8),
                                DateOfBirth = reader.GetDateTime(9),
                                UserID = reader.GetInt32(10)
                            };
                            introductionActivities.Add(introductionActivity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return introductionActivities;
        }

        public IntroductionModel GetIntroductionActivityByID(string introductionActivityID)
        {
            IntroductionModel introductionActivity = null;
            const string query = "SELECT * FROM IntroductionActivity WHERE IntroductionActivityID = @IntroductionActivityID";

            try
            {
                _dbConnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@IntroductionActivityID", introductionActivityID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            introductionActivity = new IntroductionModel
                            {
                                IntroductionActivityID = reader.GetString(0),
                                IntroducerName = reader.GetString(1),
                                IntroducerContactInfo = reader.GetString(2),
                                DateOfIntroduction = reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                Description = reader.GetString(5),
                                ChildrenName = reader.GetString(6),
                                ChildrenLastName = reader.GetString(7),
                                Gender = reader.GetBoolean(8),
                                DateOfBirth = reader.GetDateTime(9),
                                UserID = reader.GetInt32(10)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return introductionActivity;
        }
        public List<IntroductionModel> GetIntroductionByUserID(int userID)
        {
            var introductions = new List<IntroductionModel>();
            const string query = "SELECT * FROM IntroductionActivity WHERE UserID = @UserID";

            try
            {
                _dbConnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var introduction = new IntroductionModel
                            {
                                IntroductionActivityID = reader.GetString(0),
                                IntroducerName = reader.GetString(1),
                                IntroducerContactInfo = reader.GetString(2),
                                DateOfIntroduction = reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                Description = reader.GetString(5),
                                ChildrenName = reader.GetString(6),
                                ChildrenLastName = reader.GetString(7),
                                Gender = reader.GetBoolean(8),
                                DateOfBirth = reader.GetDateTime(9),
                                UserID = reader.GetInt32(10)
                            };
                            introductions.Add(introduction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return introductions;
        }
        public bool UpdateIntroductionActivity(IntroductionModel introductionActivity)
        {
            const string query = "UPDATE IntroductionActivity SET IntroducerName = @IntroducerName, " +
                                 "IntroducerContactInfo = @IntroducerContactInfo, " +
                                 "DateOfIntroduction = @DateOfIntroduction, " +
                                 "Status = @Status, " +
                                 "Description = @Description, " +
                                 "ChildrendName = @ChildrendName, " +
                                 "ChildrendLastName = @ChildrendLastName, " +
                                 "Gender = @Gender, " +
                                 "DateOfBirth = @DateOfBirth " +
                                 "WHERE IntroductionActivityID = @IntroductionActivityID";

            try
            {
                _dbConnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@IntroductionActivityID", introductionActivity.IntroductionActivityID);
                    command.Parameters.AddWithValue("@IntroducerName", introductionActivity.IntroducerName);
                    command.Parameters.AddWithValue("@IntroducerContactInfo", introductionActivity.IntroducerContactInfo);
                    command.Parameters.AddWithValue("@DateOfIntroduction", introductionActivity.DateOfIntroduction);
                    command.Parameters.AddWithValue("@Status", introductionActivity.Status);
                    command.Parameters.AddWithValue("@Description", introductionActivity.Description);
                    command.Parameters.AddWithValue("@ChildrendName", introductionActivity.ChildrenName);
                    command.Parameters.AddWithValue("@ChildrendLastName", introductionActivity.ChildrenLastName);
                    command.Parameters.AddWithValue("@Gender", introductionActivity.Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", introductionActivity.DateOfBirth);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }

        public bool DeleteIntroductionActivity(string introductionActivityID)
        {
            const string query = "DELETE FROM IntroductionActivity WHERE IntroductionActivityID = @IntroductionActivityID";

            try
            {
                _dbConnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@IntroductionActivityID", introductionActivityID);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }

        public bool AddIntroductionActivity(IntroductionModel introductionActivity)
        {
            introductionActivity.IntroductionActivityID = GenerateIntroductionActivityID();
            const string query = "INSERT INTO IntroductionActivity (IntroductionActivityID, IntroducerName, IntroducerContactInfo, DateOfIntroduction, " +
                                 "Status, Description, ChildrendName, ChildrendLastName, Gender, DateOfBirth, UserID) " +
                                 "VALUES (@IntroductionActivityID, @IntroducerName, @IntroducerContactInfo, @DateOfIntroduction, " +
                                 "@Status, @Description, @ChildrendName, @ChildrendLastName, @Gender, @DateOfBirth, @UserID)";

            try
            {
                _dbConnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@IntroductionActivityID", introductionActivity.IntroductionActivityID);
                    command.Parameters.AddWithValue("@IntroducerName", introductionActivity.IntroducerName);
                    command.Parameters.AddWithValue("@IntroducerContactInfo", introductionActivity.IntroducerContactInfo);
                    command.Parameters.AddWithValue("@DateOfIntroduction", introductionActivity.DateOfIntroduction);
                    command.Parameters.AddWithValue("@Status", introductionActivity.Status);
                    command.Parameters.AddWithValue("@Description", introductionActivity.Description);
                    command.Parameters.AddWithValue("@ChildrendName", introductionActivity.ChildrenName);
                    command.Parameters.AddWithValue("@ChildrendLastName", introductionActivity.ChildrenLastName);
                    command.Parameters.AddWithValue("@Gender", introductionActivity.Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", introductionActivity.DateOfBirth);
                    command.Parameters.AddWithValue("@UserID", introductionActivity.UserID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }


        public string GenerateIntroductionActivityID()
        {
            string newActivityID = "";

            try
            {
                // Query to get the last IntroductionActivityID from the IntroductionActivity table
                string query = "SELECT TOP 1 IntroductionActivityID FROM IntroductionActivity ORDER BY IntroductionActivityID DESC";
                _dbConnection.OpenConnection();

                // Execute the query using Dapper
                var lastActivityID = _dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                // Generate a new IntroductionActivityID
                if (!string.IsNullOrEmpty(lastActivityID))
                {
                    int lastNumber = int.Parse(lastActivityID.Substring(2)); // Remove the 'I' prefix
                    int newNumber = lastNumber + 1;
                    newActivityID = "IA" + newNumber.ToString("D3"); // D3 to ensure three digits
                }
                else
                {
                    newActivityID = "IA001"; // If no IntroductionActivityID exists in the database, start from I001
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return newActivityID;
        }

        public List<IntroductionModel> SearchIntroductionActivities(string searchText)
        {
            List<IntroductionModel> introductionActivities = new List<IntroductionModel>();

            try
            {
                _dbConnection.OpenConnection();

                // Define the SQL query for searching introduction activities based on the search text
                string query = "SELECT * FROM IntroductionActivity WHERE IntroductionActivityID LIKE @SearchText OR IntroducerName LIKE @SearchText OR Description LIKE @SearchText OR ChildrenName LIKE @SearchText OR ChildrenLastName LIKE @SearchText";

                // Create a SqlCommand object with the query and connection
                using (var command = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    // Add parameter for search text
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    // Execute the query
                    using (var reader = command.ExecuteReader())
                    {
                        // Read the results and populate introductionActivities list
                        while (reader.Read())
                        {
                            IntroductionModel introductionActivity = new IntroductionModel
                            {
                                IntroductionActivityID = reader["IntroductionActivityID"].ToString(),
                                IntroducerName = reader["IntroducerName"].ToString(),
                                IntroducerContactInfo = reader["IntroducerContactInfo"].ToString(),
                                DateOfIntroduction = Convert.ToDateTime(reader["DateOfIntroduction"]),
                                Status = reader["Status"].ToString(),
                                Description = reader["Description"].ToString(),
                                ChildrenName = reader["ChildrenName"].ToString(),
                                ChildrenLastName = reader["ChildrenLastName"].ToString(),
                                Gender = Convert.ToBoolean(reader["Gender"]),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"])
                            };

                            introductionActivities.Add(introductionActivity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            MessageBox.Show(introductionActivities.ToString());
            return introductionActivities;
        }

    }
}
