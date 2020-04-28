using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject2
{
    public class User
    {
        [JsonProperty(PropertyName = "username")]
        public string username { get; private set; }

        [JsonProperty(PropertyName = "password")]
        public string password { get; private set; }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public User() { }


    


}
}
