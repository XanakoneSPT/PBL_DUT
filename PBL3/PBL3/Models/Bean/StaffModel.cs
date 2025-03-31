using System;
using System.Globalization;

namespace PBL3.Model.Bean
{
    public class StaffModel
    {
        public string StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public int UserID { get; set; }
        public DateTime StartWorkDate { get; set; }

        public string gender
        {
            get { return Gender ? "Male" : "Female"; }
        }
    }

}
