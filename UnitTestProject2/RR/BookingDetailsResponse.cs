using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject2
{
    class BookingDetailsResponse
    {
        [JsonProperty(PropertyName = "bookingid")]
        public int bookingid { get; set; }
        [JsonProperty(PropertyName = "booking")]
        public BookingDetails booking { get; set; }

        public void SetBookingiId(int bookingid)
        {
            this.bookingid = bookingid;
        }

        public void SetBooking(BookingDetails booking)
        {
            this.booking = booking;
        }
    }
}
