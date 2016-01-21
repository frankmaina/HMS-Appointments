using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HMS
{
    class CustomHttp
    {

        //JSON object to parse response from authentication
        public class MyObject
        {
            public string result { get;set;}
            public string first_name { get; set; }
            public string role { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string reason { get; set; }
        }

        //http get simplified
        public static string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            var objText = sr.ReadToEnd().Trim();
            return objText;;
        }

        public static MyObject JsonHttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            var objText = sr.ReadToEnd().Trim();
            MyObject j = Newtonsoft.Json.JsonConvert.DeserializeObject<MyObject>(objText);
            return j;
        }

        //checks for internet connection
        public static Boolean check_connection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
