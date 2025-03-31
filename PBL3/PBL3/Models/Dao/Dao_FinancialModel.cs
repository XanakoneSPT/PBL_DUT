using Dapper;
using PBL3.Model.Bean;
using PBL3.Model.Dao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PBL3.Models.Dao
{
    internal class Dao_FinancialModel
    {
        private readonly dbConnection dbConnection;

        public Dao_FinancialModel(dbConnection connection)
        {
            dbConnection = connection;
        }

        // Get Financial list
        public List<Financial> GetFinancialList()
        {
            List<Financial> financialList = new List<Financial>();

            string query = "SELECT * FROM Financial";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Financial financial = new Financial
                            {
                                FinancialID = reader["FinancialID"].ToString(),
                                Description = reader["Description"].ToString(),
                                TotalMoney = reader.GetDecimal(reader.GetOrdinal("TotalMoney")),
                                AmountSpend = reader.GetDecimal(reader.GetOrdinal("AmountSpend")),
                                DataEntryDate = reader.GetDateTime(reader.GetOrdinal("DataEntryDate"))
                            };
                            financialList.Add(financial);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, throw exception)
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return financialList;
        }

        // Get Donate list
        public List<Donate> GetDonateList()
        {
            List<Donate> donateList = new List<Donate>();
            string query = "SELECT * FROM Donate";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Donate donate = new Donate
                            {
                                DonateID = reader.GetString(reader.GetOrdinal("DonateID")),
                                RequestName = reader.GetString(reader.GetOrdinal("RequestName")),
                                AmountRequest = reader.GetDecimal(reader.GetOrdinal("AmountRequest")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                RequestDate = reader.GetDateTime(reader.GetOrdinal("RequestDate")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };
                            donateList.Add(donate);
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

            return donateList;
        }

        // Get total money from Financial and Donate tables
        public decimal GetTotalMoney()
        {
            decimal totalMoney = 0;
            decimal totalSpendMoney = 0;

            try
            {
                dbConnection.OpenConnection();

                // Query to get total money from Finance table
                string queryTotalMoney = "SELECT SUM(TotalMoney) FROM Financial";
                using (SqlCommand cmdTotalMoney = new SqlCommand(queryTotalMoney, dbConnection.GetConnection()))
                {
                    totalMoney = Convert.ToDecimal(cmdTotalMoney.ExecuteScalar());
                }

                // Query to get total spend from Finance table
                string querySpending = "SELECT SUM(AmountSpend) FROM Financial";
                using (SqlCommand cmdSpending = new SqlCommand(querySpending, dbConnection.GetConnection()))
                {
                    totalSpendMoney = Convert.ToDecimal(cmdSpending.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, throw exception)
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            // Calculate total money
            decimal TotalMoney = totalMoney - totalSpendMoney;

            return TotalMoney;
        }
        // Get total money from Charity and Donate tables
        public decimal GetTotalDonateMoney()
        {
            decimal totalMoneyFromCharityActivity = 0;
            decimal totalAmountRequestedFromDonate = 0;

            try
            {
                dbConnection.OpenConnection();

                // Query to get total money from CharityActivity table
                string queryCharityActivity = "SELECT SUM(MoneyDonate) FROM CharityActivity";
                using (SqlCommand cmdCharityActivity = new SqlCommand(queryCharityActivity, dbConnection.GetConnection()))
                {
                    totalMoneyFromCharityActivity = Convert.ToDecimal(cmdCharityActivity.ExecuteScalar());
                }

                // Query to get total amount requested from Donate table
                string queryDonate = "SELECT SUM(AmountRequest) FROM Donate  WHERE Status = 'Completed'";
                using (SqlCommand cmdDonate = new SqlCommand(queryDonate, dbConnection.GetConnection()))
                {
                    totalAmountRequestedFromDonate = Convert.ToDecimal(cmdDonate.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, throw exception)
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            // Calculate total money
            decimal totalDonateMoney = totalMoneyFromCharityActivity + totalAmountRequestedFromDonate;

            //MessageBox.Show("C: " + totalMoneyFromCharityActivity + "D: " + totalAmountRequestedFromDonate + "T: " + totalDonateMoney);

            return totalDonateMoney;
        }

        // Auto Generate ID
        private string GenerateFinancialID()
        {
            string newFinancialID = "";

            try
            {
                string query = "SELECT TOP 1 FinancialID FROM Financial ORDER BY FinancialID DESC";
                dbConnection.OpenConnection();

                var lastFinancialID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                if (!string.IsNullOrEmpty(lastFinancialID))
                {
                    int lastNumber = int.Parse(lastFinancialID.Substring(1));
                    int newNumber = lastNumber + 1;
                    newFinancialID = "F" + newNumber.ToString("D3");
                }
                else
                {
                    newFinancialID = "F001";
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

            return newFinancialID;
        }
        private string GenerateDonateID()
        {
            string newDonateID = "";

            try
            {
                string query = "SELECT TOP 1 DonateID FROM Donate ORDER BY DonateID DESC";
                dbConnection.OpenConnection();

                var lastDonateID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                if (!string.IsNullOrEmpty(lastDonateID))
                {
                    int lastNumber = int.Parse(lastDonateID.Substring(2));
                    int newNumber = lastNumber + 1;
                    newDonateID = "DN" + newNumber.ToString("D3");
                }
                else
                {
                    newDonateID = "DN001";
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

            return newDonateID;
        }

        //Financial
        public bool AddFinancial(Financial financial)
        {
            string financialID = GenerateFinancialID();

            string query = "INSERT INTO Financial (FinancialID, Description, TotalMoney, AmountSpend, DataEntryDate) VALUES (@FinancialID, @Description, @TotalMoney, @AmountSpend, @DataEntryDate)";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new
                {
                    FinancialID = financialID,
                    Description = financial.Description,
                    TotalMoney = financial.TotalMoney,
                    AmountSpend = financial.AmountSpend,
                    DataEntryDate = financial.DataEntryDate
                });

                financial.FinancialID = financialID; // Set the generated ID back to the model
                return true;
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
        public bool UpdateFinancial(Financial financial)
        {
            string query = "UPDATE Financial SET Description = @Description, TotalMoney = @TotalMoney, AmountSpend = @AmountSpend, DataEntryDate = @DataEntryDate WHERE FinancialID = @FinancialID";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, financial);
                return true;
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
        public bool DeleteFinancial(string financialID)
        {
            string query = "DELETE FROM Financial WHERE FinancialID = @FinancialID";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new { FinancialID = financialID });
                return true;
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

        //Donate
        public bool AddDonate(Donate donate)
        {
            string donateID = GenerateDonateID();

            string query = "INSERT INTO Donate (DonateID, RequestName, AmountRequest, Description, RequestDate, Status) VALUES (@DonateID, @RequestName, @AmountRequest, @Description, @RequestDate, @Status)";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new
                {
                    DonateID = donateID,
                    RequestName = donate.RequestName,
                    AmountRequest = donate.AmountRequest,
                    Description = donate.Description,
                    RequestDate = donate.RequestDate,
                    Status = donate.Status
                });

                donate.DonateID = donateID; // Set the generated ID back to the model
                return true;
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
        public bool UpdateDonate(Donate donate)
        {
            string query = "UPDATE Donate SET RequestName = @RequestName, AmountRequest = @AmountRequest, Description = @Description, RequestDate = @RequestDate, Status = @Status WHERE DonateID = @DonateID";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new
                {
                    RequestName = donate.RequestName,
                    AmountRequest = donate.AmountRequest,
                    Description = donate.Description,
                    RequestDate = donate.RequestDate,
                    Status = donate.Status,
                    DonateID = donate.DonateID
                });
                return true;
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
        public bool DeleteDonate(string donateID)
        {
            string query = "DELETE FROM Donate WHERE DonateID = @DonateID";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new { DonateID = donateID });
                return true;
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

    }
}
