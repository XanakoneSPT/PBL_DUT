using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model.Bean
{
    internal class IntroductionModel
    {
        public string IntroductionActivityID { get; set; }
        public string IntroducerName { get; set; }
        public string IntroducerContactInfo { get; set; }
        public DateTime DateOfIntroduction { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ChildrenName { get; set; }
        public string ChildrenLastName { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserID { get; set; }

        public string Child_Gender
        {
            get { return Gender ? "Male" : "Female"; }
        }
    }
}
