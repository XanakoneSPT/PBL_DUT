using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Windows.Forms;
using PBL3.Models.Dao;
using PBL3.Model.Dao;
using System.Data;
using PBL3.Models.Bean;

namespace PBL3.Models.Bo
{
    public class Bo_CustomerModel
    {
        private Dao_CustomerModel daoCustomer;

        public Bo_CustomerModel()
        {
            daoCustomer = new Dao_CustomerModel();
        }
        public CustomerModel GetCustomerInfoByUserID(int userID)
        {
            return daoCustomer.GetCustomerInfoByUserID(userID);
        }
        public bool AddCustomer(CustomerModel customer)
        {
            return daoCustomer.AddCustomer(customer);
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            return daoCustomer.UpdateCustomer(customer);
        }
        public bool UpdateCustomerContactInfo(CustomerModel customer)
        {
            return daoCustomer.UpdateCustomerContactInfo(customer);
        }

        public bool DeleteCustomer(string customerID)
        {
            return daoCustomer.DeleteCustomer(customerID);
        }
        public bool DeleteCustomerByUserID(int _userID)
        {
            return daoCustomer.DeleteCustomerByUserID(_userID);
        }
        public List<CustomerModel> SearchCustomer(string searchBy, string searchValue)
        {
            return daoCustomer.SearchCustomer(searchBy, searchValue);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return daoCustomer.GetAllCustomers();
        }

    }
}
