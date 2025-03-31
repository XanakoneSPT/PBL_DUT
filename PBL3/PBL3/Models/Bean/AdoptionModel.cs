using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model.Bean
{
    public class AdoptionModel
    {
        public string AdoptionActivityID { get; set; }
        public string ChildID { get; set; }
        public string AdopterName { get; set; }
        public string AdopterContactInfo { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
    }
}
