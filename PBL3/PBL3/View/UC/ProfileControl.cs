using PBL3.Models.Bean;
using PBL3.Models.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.View
{
    public partial class ProfileControl : UserControl
    {
        public int UserID { get; set; }
        private Bo_CustomerModel boCustomerModel;
        private CustomerModel customer;

        public ProfileControl()
        {
            InitializeComponent();
            boCustomerModel = new Bo_CustomerModel(); // Initialize the Bo_CustomerModel
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            DisplayProfileInfo();
        }

        public void DisplayProfileInfo()
        {
            customer = boCustomerModel.GetCustomerInfoByUserID(UserID); // Get customer info

            // Populate UI controls with customer information
            CustomerIDInsert.Text = customer.CustomerID;
            CustomerFirstNameInsert.Text = customer.FirstName;
            CustomerLastNameInsert.Text = customer.LastName;
            CustomerGenderInsertBox.Text = customer.Gender ? "Male" : "Female";
            CustomerAgeInsert.Text = customer.Age.ToString();
            CustomerDateOfBirthInsert.Value = customer.DateOfBirth;
            CustomerPhoneNumberInsert.Text = customer.PhoneNumber;
            AddressInsert.Text = customer.Address;
            CustomerEmailInsert.Text = customer.Email;

            welcome.Text = "Welcome " + customer.FirstName.ToString() + " " + customer.LastName.ToString();
        }

        private void StaffUpdateButton_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                customer.Email = CustomerEmailInsert.Text;
                customer.PhoneNumber = CustomerPhoneNumberInsert.Text;
                customer.Address = AddressInsert.Text;

                bool success = boCustomerModel.UpdateCustomerContactInfo(customer);

                if (success)
                {
                    MessageBox.Show("Information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No information to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
