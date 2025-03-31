using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model.Bean
{
    internal class CharityModel
    {
        public string CharityActivityID { get; set; }
        public string CharityName { get; set; }
        public string CharityDescription { get; set; }
        public string CharityDateTime { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public string MoneyDonate { get; set; }

        public string DateAndTime
        {
            get
            {
                if (DateTime.TryParse(CharityDateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
                {
                    return dob.ToString("dd/MMM/yyyy HH:mm");
                }
                else
                {
                    return CharityDateTime; // Return the original value if it's not in the specified format
                }
            }
        }
    }
}
