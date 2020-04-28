using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject2
{
    class BookingResponse
    {
        [JsonProperty(PropertyName = "bookingid")]
        public string bookingid { get; private set; }

        public void SetBookingId(string id)
        {
            this.bookingid = bookingid;
        }

    }
}
