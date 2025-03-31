using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Dao;
using System;
using System.Collections.Generic;

namespace PBL3.Models.Bo
{
    internal class Bo_FinancialModel
    {
        private readonly Dao_FinancialModel daoFinancialModel;

        public Bo_FinancialModel(dbConnection connection)
        {
            daoFinancialModel = new Dao_FinancialModel(connection);
        }

        // Methods to interact with Financial data
        public List<Financial> GetFinancialList()
        {
            try
            {
                return daoFinancialModel.GetFinancialList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to retrieve financial list.", ex);
            }
        }

        public bool AddFinancial(Financial financial)
        {
            try
            {
                return daoFinancialModel.AddFinancial(financial);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to add financial record.", ex);
            }
        }

        public bool UpdateFinancial(Financial financial)
        {
            try
            {
                return daoFinancialModel.UpdateFinancial(financial);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to update financial record.", ex);
            }
        }

        public bool DeleteFinancial(string financialID)
        {
            try
            {
                return daoFinancialModel.DeleteFinancial(financialID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to delete financial record.", ex);
            }
        }

        // Methods to interact with Donate data
        public List<Donate> GetDonateList()
        {
            try
            {
                return daoFinancialModel.GetDonateList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to retrieve donate list.", ex);
            }
        }

        public bool AddDonate(Donate donate)
        {
            try
            {
                return daoFinancialModel.AddDonate(donate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to add donate record.", ex);
            }
        }

        public bool UpdateDonate(Donate donate)
        {
            try
            {
                return daoFinancialModel.UpdateDonate(donate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to update donate record.", ex);
            }
        }

        public bool DeleteDonate(string donateID)
        {
            try
            {
                return daoFinancialModel.DeleteDonate(donateID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to delete donate record.", ex);
            }
        }

        // Method to retrieve total money from Financial and Donate tables
        public decimal GetTotalMoney()
        {
            try
            {
                return daoFinancialModel.GetTotalMoney();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to retrieve total money.", ex);
            }
        }

        public decimal GetTotalDonateMoney()
        {
            try
            {
                return daoFinancialModel.GetTotalDonateMoney();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Failed to retrieve total donate money.", ex);
            }
        }
    }
}
