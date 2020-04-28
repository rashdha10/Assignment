using System;
using System.Net.Http;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace UnitTestProject2
{
    [Binding]
    public class AuthUtil
    {
        public static HttpResponseMessage response;
        [Given(@"the token ready for use")]
        public void GivenTheTokenReadyForUse()
        {
            response = CommonUtils.createAuthToken();
            AuthResponse token=JsonConvert.DeserializeObject<AuthResponse>(response.Content.ReadAsStringAsync().Result);
            ScenarioContext.Current.Set<string>(token.token, "Token");

        }
    }
}
