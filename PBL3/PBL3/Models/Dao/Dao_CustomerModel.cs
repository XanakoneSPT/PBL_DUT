using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.Models.Dao;
using Dapper;
using System.Data.SqlClient;
using PBL3.Model.Dao;
using PBL3.Models.Bean;
using PBL3.Model.Bean;

namespace PBL3.Models.Dao
{
    public class Dao_CustomerModel
    {
        private dbConnection dbConnection; // Declare an instance of dbConnection

        public Dao_CustomerModel()
        {
            dbConnection = new dbConnection(); // Initialize dbConnection instance
        }

        // Method to retrieve all customers

        public CustomerModel GetCustomerInfoByUserID(int userID)
        {
            CustomerModel customer = new CustomerModel();
            string query = "SELECT * FROM Customers WHERE UserID = @UserID";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID); // Add parameter for UserID
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Populate customer object
                        customer.CustomerID = reader["CustomerID"].ToString();
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Gender = (bool)reader["Gender"];
                        customer.Age = (int)reader["Age"];
                        customer.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        customer.Email = reader["Email"].ToString();
                        customer.PhoneNumber = reader["PhoneNumber"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.UserID = (int)reader["UserID"];
                    }
                    reader.Close();
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
            return customer;
        }
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            string query = "SELECT * FROM Customers";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerModel customer = new CustomerModel();
                        customer.CustomerID = reader["CustomerID"].ToString();
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Gender = (bool)reader["Gender"];
                        customer.Age = (int)reader["Age"];
                        customer.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        customer.Email = reader["Email"].ToString();
                        customer.PhoneNumber = reader["PhoneNumber"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.UserID = (int)reader["UserID"];

                        customerList.Add(customer);
                    }
                    reader.Close();
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
            return customerList;
        }

        public bool AddCustomer(CustomerModel customer)
        {
            bool success = false;
            string cus = GenerateCustomerID();
            string query = "INSERT INTO Customers (CustomerID, FirstName, LastName, Gender, Age, DateOfBirth, Email, PhoneNumber, Address, UserID) VALUES (@CustomerID, @FirstName, @LastName, @Gender, @Age, @DateOfBirth, @Email, @PhoneNumber, @Address, @UserID)";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", cus);
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@Age", customer.Age);
                    cmd.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@UserID", customer.UserID);

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
                dbConnection.CloseConnection();
            }
            return success;
        }

        private string GenerateCustomerID()
        {
            string lastUserID = ""; // Biến để lưu UserID cuối cùng trong cơ sở dữ liệu
            string newUserID = ""; // Biến để lưu UserID mới được tạo ra

            try
            {
                // Truy vấn SQL để lấy UserID cuối cùng trong cơ sở dữ liệu
                string query = "SELECT TOP 1 CustomerID FROM Customers ORDER BY CustomerID DESC";
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastUserID = reader.GetString(0);
                        }
                    }
                }

                // Tạo UserID mới
                if (!string.IsNullOrEmpty(lastUserID))
                {
                    int lastNumber = int.Parse(lastUserID.Substring(1));
                    int newNumber = lastNumber + 1;
                    newUserID = "C" + newNumber.ToString("D3"); // D2 để đảm bảo số có hai chữ số
                }
                else
                {
                    newUserID = "C001"; // Nếu không có UserID nào trong cơ sở dữ liệu, ta bắt đầu từ User01
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

            return newUserID;
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            bool success = false;
            string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, Age = @Age, DateOfBirth = @DateOfBirth, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, UserID = @UserID WHERE CustomerID = @CustomerID";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@Age", customer.Age);
                    cmd.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@UserID", customer.UserID);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

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
                dbConnection.CloseConnection();
            }
            return success;
        }
        public bool UpdateCustomerContactInfo(CustomerModel customer)
        {
            bool success = false;
            string query = "UPDATE Customers SET Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address WHERE CustomerID = @CustomerID";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

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
                dbConnection.CloseConnection();
            }
            return success;
        }

        public bool DeleteCustomer(string customerID)
        {
            bool success = false;
            string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);

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
                dbConnection.CloseConnection();
            }
            return success;
        }
        public bool DeleteCustomerByUserID(int _userID)
        {
            bool success = false;
            string query = "DELETE FROM Customers WHERE UserID = @UserID";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userID);

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
                dbConnection.CloseConnection();
            }
            return success;
        }
        public List<CustomerModel> SearchCustomer(string searchBy, string searchValue)
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            string query = "";
            try
            {
                dbConnection.OpenConnection();

                switch (searchBy.ToLower())
                {
                    case "customerid":
                        query = "SELECT * FROM Customers WHERE CustomerID = @Value";
                        break;
                    case "firstname":
                        query = "SELECT * FROM Customers WHERE FirstName = @Value";
                        break;
                    case "lastname":
                        query = "SELECT * FROM Customers WHERE LastName = @Value";
                        break;
                    case "email":
                        query = "SELECT * FROM Customers WHERE Email = @Value";
                        break;
                    default:
                        Console.WriteLine("Invalid search criteria.");
                        return customerList;
                }

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Value", searchValue);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CustomerModel customer = new CustomerModel();
                        customer.CustomerID = reader["CustomerID"].ToString();
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Gender = (bool)reader["Gender"];
                        customer.Age = (int)reader["Age"];
                        customer.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        customer.Email = reader["Email"].ToString();
                        customer.PhoneNumber = reader["PhoneNumber"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.UserID = (int)reader["UserID"];

                        customerList.Add(customer);
                    }

                    reader.Close();
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

            return customerList;
        }

    }
}
