using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject2
{
    class AuthResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string token { get; set; }

        public void SetToken(string token)
        {
            this.token = token;
        }
    }
}
