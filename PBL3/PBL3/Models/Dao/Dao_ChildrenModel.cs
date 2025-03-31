using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL3.Model.Bean;
using PBL3.Model.Dao;

namespace PBL3.Models.Dao
{
    internal class Dao_ChildrenModel
    {
        private dbConnection dbConnection;

        public Dao_ChildrenModel(dbConnection connection)
        {
            dbConnection = connection;
        }

        // Phương thức lấy danh sách các Children
        public List<ChildrenModel> GetChildrenList()
        {
            List<ChildrenModel> childrenList = new List<ChildrenModel>();
            string query = "SELECT * FROM Children";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChildrenModel child = new ChildrenModel
                            {
                                ChildID = reader.GetString(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Gender = reader.GetBoolean(3),
                                Age = reader.GetInt32(4),
                                DateOfBirth = reader.GetDateTime(5),
                                DateGetIntoCenter = reader.GetDateTime(6),
                            };
                            childrenList.Add(child);
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
                dbConnection.CloseConnection();
            }

            return childrenList;
        }
        private string GenerateChildID()
        {
            string newChildID = "";

            try
            {
                string query = "SELECT TOP 1 ChildID FROM Children ORDER BY ChildID DESC";
                dbConnection.OpenConnection();

                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        // Convert the result to a string
                        newChildID = result.ToString();
                        // Extract numeric part and increment
                        int lastNumber = int.Parse(newChildID.Substring(2));
                        int newNumber = lastNumber + 1;
                        newChildID = "CH" + newNumber.ToString("D3");
                    }
                    else
                    {
                        newChildID = "CH001";
                    }
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

            return newChildID;
        }
        // Phương thức thêm Children
        public bool AddChildren(ChildrenModel child)
        {
            string query = "INSERT INTO Children (ChildID, FirstName, LastName, Gender, Age, DateOfBirth, DateGetIntoCenter) " +
                           "VALUES (@ChildID, @FirstName, @LastName, @Gender, @Age, @DateOfBirth, @DateGetIntoCenter)";

            try
            {
                // Generate a new ChildID
                string newChildID = GenerateChildID();

                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    // Use the generated ChildID
                    command.Parameters.AddWithValue("@ChildID", newChildID);
                    command.Parameters.AddWithValue("@FirstName", child.FirstName);
                    command.Parameters.AddWithValue("@LastName", child.LastName);
                    command.Parameters.AddWithValue("@Gender", child.Gender);
                    command.Parameters.AddWithValue("@Age", child.Age);
                    command.Parameters.AddWithValue("@DateOfBirth", child.DateOfBirth);
                    command.Parameters.AddWithValue("@DateGetIntoCenter", child.DateGetIntoCenter);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // Phương thức xóa Children
        public bool DeleteChildren(string childID)
        {
            string checkAdoptionQuery = "SELECT COUNT(*) FROM Adoption WHERE ChildID = @ChildID";
            string deleteChildQuery = "DELETE FROM Children WHERE ChildID = @ChildID";

            try
            {
                dbConnection.OpenConnection();

                // Check if there are associated records in the Adoption table
                using (SqlCommand checkCommand = new SqlCommand(checkAdoptionQuery, dbConnection.GetConnection()))
                {
                    checkCommand.Parameters.AddWithValue("@ChildID", childID);
                    int adoptionCount = (int)checkCommand.ExecuteScalar();

                    if (adoptionCount > 0)
                    {
                        DialogResult result = MessageBox.Show(
                            $"There are {adoptionCount} adoption records associated with this child.\nDo you still want to delete this child?",
                            "Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result != DialogResult.Yes)
                        {
                            return false; // User chose not to delete
                        }
                    }
                }

                using (SqlTransaction transaction = dbConnection.GetConnection().BeginTransaction())
                {
                    // Delete the Child record
                    using (SqlCommand deleteChildCommand = new SqlCommand(deleteChildQuery, dbConnection.GetConnection(), transaction))
                    {
                        deleteChildCommand.Parameters.AddWithValue("@ChildID", childID);
                        int rowsAffected = deleteChildCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting child: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Logging
                return false;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // Phương thức cập nhật thông tin Children
        public bool UpdateChildren(ChildrenModel child)
        {
            string query = "UPDATE Children SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, " +
                           "Age = @Age, DateOfBirth = @DateOfBirth, DateGetIntoCenter = @DateGetIntoCenter WHERE ChildID = @ChildID";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@FirstName", child.FirstName);
                    command.Parameters.AddWithValue("@LastName", child.LastName);
                    command.Parameters.AddWithValue("@Gender", child.Gender);
                    command.Parameters.AddWithValue("@Age", child.Age);
                    command.Parameters.AddWithValue("@DateOfBirth", child.DateOfBirth);
                    command.Parameters.AddWithValue("@DateGetIntoCenter", child.DateGetIntoCenter);
                    command.Parameters.AddWithValue("@ChildID", child.ChildID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        public int GetTotalChildrenCount()
        {
            int totalCount = 0;
            string query = "SELECT COUNT(*) FROM Children";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    totalCount = (int)command.ExecuteScalar();
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

            return totalCount;
        }

        // Get count of children for each month
        public Dictionary<string, int> GetChildrenCountByMonth()
        {
            Dictionary<string, int> childrenCountByMonth = new Dictionary<string, int>();

            string query = "SELECT FORMAT(DateGetIntoCenter, 'MM-yyyy') AS MonthYear, COUNT(*) AS Count " +
                           "FROM Children " +
                           "GROUP BY FORMAT(DateGetIntoCenter, 'MM-yyyy')";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string monthYear = reader["MonthYear"].ToString();
                            int count = Convert.ToInt32(reader["Count"]);
                            childrenCountByMonth.Add(monthYear, count);
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
                dbConnection.CloseConnection();
            }

            return childrenCountByMonth;
        }
    }
}
