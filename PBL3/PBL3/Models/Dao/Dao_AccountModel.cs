using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PBL3.Model.Bean;

namespace PBL3.Model.Dao
{
    internal class Dao_AccountModel
    {
        private dbConnection _dbConnection;

        public Dao_AccountModel(dbConnection connection)
        {
            _dbConnection = connection;
        }

        // Dao_Account.cs
        public bool AuthenticateUserAndCheckRole(string username, string password, out string userType, out int userID)
        {
            userType = null; // Initialize userType to null
            userID = -1; // Initialize userID to -1 (invalid)
            string query = "SELECT UserID, UserType FROM Account WHERE Username = @Username AND Password = @Password;";
            using (SqlConnection connection = _dbConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = Convert.ToInt32(reader["UserID"]);
                            userType = reader["UserType"].ToString();
                            return true; // Authentication successful
                        }
                    }
                }
            }
            return false; // Authentication failed
        }

        // Lấy tất cả các Account theo UserType
        public List<AccountModel> GetAllAccountsByUserType(string userType)
        {
            List<AccountModel> accounts = new List<AccountModel>();

            try
            {
                _dbConnection.OpenConnection();

                string query = "SELECT * FROM Account WHERE UserType = @UserType";
                SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@UserType", userType);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AccountModel account = new AccountModel();
                    account.UserID = Convert.ToInt32(reader["UserID"]);
                    account.Username = reader["Username"].ToString();
                    account.Password = reader["Password"].ToString();
                    account.UserType = reader["UserType"].ToString();

                    accounts.Add(account);
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

            return accounts;
        }

        // Thêm Account với UserType mặc định bằng Staff
        public bool AddStaffAccount(AccountModel account)
        {
            string newUserID = GenerateNewUserID();
            string userType = "Staff";

            bool success = false;

            string query = "INSERT INTO Account (UserID, Username, Password, UserType) VALUES (@UserID, @Username, @Password, @UserType)";
            try
            {
                _dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {

                    cmd.Parameters.AddWithValue("@UserID", newUserID);
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        success = true;
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
            return success;
        }

        public bool AddCustomerAccount(AccountModel account)
        {
            string newUserID = GenerateNewUserID();
            string userType = "Customer";

            bool success = false;

            string query = "INSERT INTO Account (UserID, Username, Password, UserType) VALUES (@UserID, @Username, @Password, @UserType)";
            try
            {
                _dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {

                    cmd.Parameters.AddWithValue("@UserID", newUserID);
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        success = true;
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
            return success;
        }

        public bool UpdateAccount(AccountModel account)
        {
            string query = "UPDATE Account SET Username = @Username, Password = @Password, UserType = @UserType WHERE UserID = @UserID";
            try
            {
                _dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@UserType", account.UserType);
                    cmd.Parameters.AddWithValue("@UserID", account.UserID);

                    int rowsAffected = cmd.ExecuteNonQuery();

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
                _dbConnection.CloseConnection();
            }
        }

        public bool DeleteAccount(int userID)
        {
            try
            {
                _dbConnection.OpenConnection();

                string query = "DELETE FROM Account WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@UserID", userID);
                Console.WriteLine("dad");
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
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

        public List<AccountModel> FindAccounts(string searchBy, string searchValue)
        {
            List<AccountModel> accounts = new List<AccountModel>();

            try
            {
                _dbConnection.OpenConnection();

                string query = "";

                switch (searchBy.ToLower())
                {
                    case "userid":
                        query = "SELECT * FROM Account WHERE UserID = @Value";
                        break;
                    case "username":
                        query = "SELECT * FROM Account WHERE Username = @Value";
                        break;
                    case "password":
                        query = "SELECT * FROM Account WHERE Password = @Value";
                        break;
                    case "usertype":
                        query = "SELECT * FROM Account WHERE UserType = @Value";
                        break;
                    default:
                        Console.WriteLine("Invalid search criteria.");
                        return accounts;
                }

                SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@Value", searchValue);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AccountModel account = new AccountModel();
                    account.UserID = Convert.ToInt32(reader["UserID"]);
                    account.Username = reader["Username"].ToString();
                    account.Password = reader["Password"].ToString();
                    account.UserType = reader["UserType"].ToString();

                    accounts.Add(account);
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

            return accounts;
        }

        public string GenerateNewUserID()
        {
            string maxUserID = "";
            try
            {
                _dbConnection.OpenConnection();

                string query = "SELECT MAX(UserID) FROM Account";
                SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection());
                maxUserID = cmd.ExecuteScalar()?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            int newUserID;
            if (string.IsNullOrEmpty(maxUserID))
                newUserID = 1000; // Nếu không có bất kỳ UserID nào trong cơ sở dữ liệu, bạn có thể bắt đầu từ "1000" hoặc bất kỳ giá trị nào khác.
            else
                newUserID = Convert.ToInt32(maxUserID) + 1;

            return newUserID.ToString();
        }
    }
}
