using PBL3.Model.Bean;
using PBL3.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.Model.Bo
{
    internal class Bo_AccountModel
    {
        private Dao_AccountModel daoAccount;

        public Bo_AccountModel(dbConnection connection)
        {
            daoAccount = new Dao_AccountModel(connection);
        }

        // Method to authenticate user login and check role
        // Bo_Account.cs
        public bool AuthenticateUserAndCheckRole(string username, string password, out string userType, out int userID)
        {
            return daoAccount.AuthenticateUserAndCheckRole(username, password, out userType, out userID);
        }

        // Method to get all accounts by user type
        public List<AccountModel> GetAllAccountsByUserType(string userType)
        {
            return daoAccount.GetAllAccountsByUserType(userType);
        }

        // Method to add a staff account
        public bool AddStaffAccount(AccountModel account)
        {
            return daoAccount.AddStaffAccount(account);
        }

        // Method to add a customer account
        public bool AddCustomerAccount(AccountModel account)
        {
            return daoAccount.AddCustomerAccount(account);
        }

        // Method to update an account
        public bool UpdateAccount(AccountModel account)
        {
            return daoAccount.UpdateAccount(account);
        }

        // Method to delete an account by user ID
        public bool DeleteAccount(int userID)
        {
            return daoAccount.DeleteAccount(userID);
        }

        // Method to find accounts by search criteria
        public List<AccountModel> FindAccounts(string searchBy, string searchValue)
        {
            return daoAccount.FindAccounts(searchBy, searchValue);
        }
    }
}
