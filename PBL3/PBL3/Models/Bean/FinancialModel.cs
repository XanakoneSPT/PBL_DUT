using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model.Bean
{
    public class Financial
    {
        // Properties
        public string FinancialID { get; set; }
        public string Description { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal AmountSpend { get; set; }
        public DateTime DataEntryDate { get; set; }
    }

    public class Donate
    {
        // Properties
        public string DonateID { get; set; }
        public string RequestName { get; set; }
        public decimal AmountRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }

    }
}
