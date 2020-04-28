using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Mime;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Gherkin.Ast;

namespace UnitTestProject2
{
    class CommonUtils
    {
        public static HttpClient client;
        public static JObject jObject;
        public static string baseuri;
        public static JObject readJsonFromFile()
        {

            JObject jObject = JObject.Parse(File.ReadAllText(@"..\..\jsconfig1.json"));
            return jObject;
        }

        public static void createUri(string path)
        {
            if (path == "" || path== null)
            {
                baseuri = jObject.GetValue("baseuri").ToString();
            }
            else
            baseuri = jObject.GetValue("baseuri").ToString() + path;
        }

        public static HttpResponseMessage createAuthToken()
        {
            createUri("/auth");
            User user = new User();
            user.SetUsername(jObject.GetValue("username").ToString());
            user.SetPassword(jObject.GetValue("password").ToString());
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(baseuri), Method = HttpMethod.Post })
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = client.SendAsync(request).Result;
                return response;
            }
        }

        public static HttpResponseMessage getRequest()
        {
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(baseuri), Method = HttpMethod.Get })
            {
                request.Headers.Add("Accept","application/json");
                var response = client.SendAsync(request).Result;
                return response;
            }

        }

        public static HttpResponseMessage getRequestWithParams(KeyValuePair<String, String>[] parameters)
        {
            string query;
            using (var parametersAsString = new FormUrlEncodedContent(parameters))
            {
                query = parametersAsString.ReadAsStringAsync().Result;
            }

            var response = client.GetAsync(baseuri + query).Result;
            return response;

        }

        public static HttpResponseMessage postRequest(String payload)
        {
                
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(baseuri), Method = HttpMethod.Post })
                {
                    request.Content = new StringContent(payload, Encoding.UTF8, "application/json");                    
                    request.Headers.Add("Accept", "application/json");                    
                    var response = client.SendAsync(request).Result;
                    return response;
                }
            }
        

    public static HttpResponseMessage deleteRequest()
    {
            
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (client = new HttpClient(handler))
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(baseuri), Method = HttpMethod.Delete })
                {
                    cookieContainer.Add(new Uri(baseuri), new Cookie("token", ScenarioContext.Current.Get<string>("Token")));
                    request.Headers.Add("Accept", "application/json");
                    var response = client.SendAsync(request).Result;
                    return response;
                }
            }
    }

        public static void Initialise()
        {
            client= new HttpClient();
            jObject = readJsonFromFile();
        }

       
    }
}
