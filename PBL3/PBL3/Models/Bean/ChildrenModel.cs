using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model.Bean
{
    public class ChildrenModel
    {
        public string ChildID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateGetIntoCenter { get; set; }

        public string gender
        {
            get { return Gender ? "Male" : "Female"; }
        }
    }
}
