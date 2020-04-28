using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject2
{
       public class BookingDates
        {
        [JsonProperty(PropertyName = "checkin")]
        public DateTime checkin { get; private set; }
        [JsonProperty(PropertyName = "checkout")]
        public DateTime checkout { get; private set; }

        public BookingDates(DateTime checkin, DateTime checkout)
        {
            this.checkin = checkin;
            this.checkout = checkout;
        }
    }
    
}
