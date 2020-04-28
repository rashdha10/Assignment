using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject2
{
    class BookingDetails
    {
        [JsonProperty(PropertyName = "firstname")]
        public string firstname { get; private set; }
        [JsonProperty(PropertyName = "lastname")]
        public string lastname { get; private set; }
        [JsonProperty(PropertyName = "totalprice")]
        public int totalprice { get; private set; }
        [JsonProperty(PropertyName = "depositpaid")]
        public bool depositpaid { get; private set; }
        [JsonProperty(PropertyName = "bookingdates")]
        public BookingDates bookingdates { get; private set; }
        [JsonProperty(PropertyName = "additionalneeds")]
        public string additionalneeds { get; private set; }


        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public void SetLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public void SetTotalPrice(int totalprice)
        {
            this.totalprice = totalprice;
        }

        public void SetDepositPaid(bool depositpaid)
        {
            this.depositpaid = depositpaid;
        }

        public void SetBookingDates(BookingDates bookingdates)
        {
            this.bookingdates = bookingdates;
        }

        public void SetAdditionalNeeds(string additionalneeds)
        {
            this.additionalneeds = additionalneeds;
        }

        private BookingDetails(string firstname, string lastname, int totalprice, bool depositpaid, BookingDates bookingdates, string additionalneeds)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.totalprice = totalprice;
            this.depositpaid = depositpaid;
            this.bookingdates = bookingdates;
            this.additionalneeds = additionalneeds;
        }

        public BookingDetails()
        {
        }
    }

    
}
