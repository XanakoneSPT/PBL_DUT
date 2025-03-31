using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Models.Bean
{
    internal class VolunteerModel
    {
        public string VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string DateStartVolunteer { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string GenderString
        {
            get { return Gender ? "Male" : "Female"; }
        }
        public string DateOfBirthString
        {
            get
            {
                if (DateTime.TryParse(DateOfBirth, out DateTime dob))
                {
                    return dob.ToString("dd MMM yyyy");
                }
                else
                {
                    return "";
                }
            }
        }
        public string DateStartVolunteerString
        {
            get
            {
                if (DateTime.TryParse(DateStartVolunteer, out DateTime dob))
                {
                    return dob.ToString("dd MMM yyyy");
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
