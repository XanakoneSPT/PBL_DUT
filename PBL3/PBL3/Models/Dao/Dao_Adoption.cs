using PBL3.Model.Dao;
using PBL3.Model.Bean;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PBL3.Models.Dao
{
    internal class Dao_Adoption
    {
        private readonly dbConnection _dbconnection;

        public Dao_Adoption(dbConnection connection)
        {
            _dbconnection = connection;
        }
        public List<AdoptionModel> GetAdoptionActivityList(string status)
        {
            var adoptionActivities = new List<AdoptionModel>();
            string query = "SELECT * FROM Adoption";

            try
            {
                _dbconnection.OpenConnection();

                if (status != "All")
                {
                    query += " WHERE Status = @Status";
                }

                SqlCommand cmd = new SqlCommand(query, _dbconnection.GetConnection());

                if (status != "All")
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AdoptionModel adoptionActivity = new AdoptionModel();
                    adoptionActivity.AdoptionActivityID = reader["AdoptionActivityID"].ToString();
                    adoptionActivity.ChildID = reader["ChildID"].ToString();
                    adoptionActivity.AdopterName = reader["AdopterName"].ToString();
                    adoptionActivity.AdopterContactInfo = reader["AdopterContactInfo"].ToString();
                    adoptionActivity.DateOfAdoption = Convert.ToDateTime(reader["DateOfAdoption"]);
                    adoptionActivity.Status = reader["Status"].ToString();
                    adoptionActivity.Description = reader["Description"].ToString();
                    adoptionActivity.UserID = Convert.ToInt32(reader["UserID"]);

                    adoptionActivities.Add(adoptionActivity);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbconnection.CloseConnection();
            }

            return adoptionActivities;
        }

        public List<AdoptionModel> GetAdoptionActivityList()
        {
            var adoptionActivities = new List<AdoptionModel>();
            const string query = "SELECT * FROM Adoption";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var adoptionActivity = new AdoptionModel
                            {
                                AdoptionActivityID = reader.GetString(0),
                                ChildID = reader.GetString(1),
                                AdopterName = reader.GetString(2),
                                AdopterContactInfo = reader.GetString(3),
                                DateOfAdoption = reader.GetDateTime(4),
                                Status = reader.GetString(5),
                                Description = reader.GetString(6),
                                UserID = reader.GetInt32(7)
                            };
                            adoptionActivities.Add(adoptionActivity);
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
                _dbconnection.CloseConnection();
            }

            return adoptionActivities;
        }

        public AdoptionModel GetAdoptionActivityByID(string adoptionActivityID)
        {
            AdoptionModel adoptionActivity = null;
            const string query = "SELECT * FROM Adoption WHERE AdoptionActivityID = @AdoptionActivityID";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@AdoptionActivityID", adoptionActivityID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adoptionActivity = new AdoptionModel
                            {
                                AdoptionActivityID = reader.GetString(0),
                                ChildID = reader.GetString(1),
                                AdopterName = reader.GetString(2),
                                AdopterContactInfo = reader.GetString(3),
                                DateOfAdoption = reader.GetDateTime(4),
                                Status = reader.GetString(5),
                                Description = reader.GetString(6),
                                UserID = reader.GetInt32(7)
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
                _dbconnection.CloseConnection();
            }

            return adoptionActivity;
        }
        public List<AdoptionModel> GetAdoptionActivityByUserID(int userID)
        {
            var adoptionActivities = new List<AdoptionModel>();
            const string query = "SELECT * FROM Adoption WHERE UserID = @UserID";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var adoptionActivity = new AdoptionModel
                            {
                                AdoptionActivityID = reader.GetString(0),
                                ChildID = reader.GetString(1),
                                AdopterName = reader.GetString(2),
                                AdopterContactInfo = reader.GetString(3),
                                DateOfAdoption = reader.GetDateTime(4),
                                Status = reader.GetString(5),
                                Description = reader.GetString(6),
                                UserID = reader.GetInt32(7)
                            };
                            adoptionActivities.Add(adoptionActivity);
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
                _dbconnection.CloseConnection();
            }

            return adoptionActivities;
        }

        public bool UpdateAdoptionActivity(AdoptionModel adoptionActivity)
        {
            const string query = "UPDATE Adoption SET ChildID = @ChildID, AdopterName = @AdopterName, AdopterContactInfo = @AdopterContactInfo, " +
                                 "DateOfAdoption = @DateOfAdoption, Status = @Status,Description = @Description WHERE AdoptionActivityID = @AdoptionActivityID";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@AdoptionActivityID", adoptionActivity.AdoptionActivityID);
                    command.Parameters.AddWithValue("@ChildID", adoptionActivity.ChildID);
                    command.Parameters.AddWithValue("@AdopterName", adoptionActivity.AdopterName);
                    command.Parameters.AddWithValue("@AdopterContactInfo", adoptionActivity.AdopterContactInfo);
                    command.Parameters.AddWithValue("@DateOfAdoption", adoptionActivity.DateOfAdoption);
                    command.Parameters.AddWithValue("@Status", adoptionActivity.Status);
                    command.Parameters.AddWithValue("@Description", adoptionActivity.Description);

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
                _dbconnection.CloseConnection();
            }
        }

        public bool DeleteAdoptionActivity(string adoptionActivityID)
        {
            const string query = "DELETE FROM Adoption WHERE AdoptionActivityID = @AdoptionActivityID";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@AdoptionActivityID", adoptionActivityID);
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
                _dbconnection.CloseConnection();
            }
        }

        public bool AddAdoptionActivity(AdoptionModel adoptionActivity)
        {
            adoptionActivity.AdoptionActivityID = GenerateAdoptionActivityID();
            const string query = "INSERT INTO Adoption (AdoptionActivityID, ChildID, AdopterName, AdopterContactInfo, DateOfAdoption, Status,Description, UserID) " +
                                 "VALUES (@AdoptionActivityID, @ChildID, @AdopterName, @AdopterContactInfo, @DateOfAdoption, @Status,@Description, @UserID)";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@AdoptionActivityID", adoptionActivity.AdoptionActivityID);
                    command.Parameters.AddWithValue("@ChildID", adoptionActivity.ChildID);
                    command.Parameters.AddWithValue("@AdopterName", adoptionActivity.AdopterName);
                    command.Parameters.AddWithValue("@AdopterContactInfo", adoptionActivity.AdopterContactInfo);
                    command.Parameters.AddWithValue("@DateOfAdoption", adoptionActivity.DateOfAdoption);
                    command.Parameters.AddWithValue("@Status", adoptionActivity.Status);
                    command.Parameters.AddWithValue("@Description", adoptionActivity.Description);
                    command.Parameters.AddWithValue("UserID", adoptionActivity.UserID);

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
                _dbconnection.CloseConnection();
            }
        }

        public string GenerateAdoptionActivityID()
        {
            string newActivityID = "";

            try
            {
                // Query to get the last AdoptionActivityID from the Adoption table
                string query = "SELECT TOP 1 AdoptionActivityID FROM Adoption ORDER BY AdoptionActivityID DESC";
                _dbconnection.OpenConnection();

                // Execute the query using Dapper
                var lastActivityID = _dbconnection.GetConnection().Query<string>(query).FirstOrDefault();

                // Generate a new AdoptionActivityID
                if (!string.IsNullOrEmpty(lastActivityID))
                {
                    int lastNumber = int.Parse(lastActivityID.Substring(3)); // Remove the 'A' prefix
                    int newNumber = lastNumber + 1;
                    newActivityID = "AD" + newNumber.ToString("D3"); // D3 to ensure three digits
                }
                else
                {
                    newActivityID = "AD001"; // If no AdoptionActivityID exists in the database, start from A001
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbconnection.CloseConnection();
            }

            return newActivityID;
        }

        public List<AdoptionModel> GetAdoptionActivityListSort()
        {
            var adoptions = new List<AdoptionModel>();
            const string query = "SELECT * FROM Adoption";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Adoptions = new AdoptionModel
                            {
                                AdoptionActivityID = reader.GetString(0),
                                ChildID = reader.GetString(1),
                                AdopterName = reader.GetString(2),
                                AdopterContactInfo = reader.GetString(3),
                                DateOfAdoption = reader.GetDateTime(4),
                                Status = reader.GetString(5),
                                Description = reader.GetString(6),
                                UserID = reader.GetInt32(7)
                            };
                            adoptions.Add(Adoptions);
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
                _dbconnection.CloseConnection();
            }

            return adoptions;
        }
    }
}
