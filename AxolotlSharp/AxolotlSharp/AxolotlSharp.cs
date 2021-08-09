using AxolotlSharp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AxolotlSharp
{
    public class AxolotlSharp
    {
        private static string BASE_URL = "https://axoltlapi.herokuapp.com/";

        public bool CheckAvailability()
        {
            return false;
        }

        public AxolotlResponse GetResponse()
        {
            AxolotlResponse ar = null;

            ar = CallAPI(GetJson(""));

            return ar;
        }

        internal string GetJson(string apiRoute)
        {
            string json = "";
            using(WebClient wc = new WebClient())
            {
                json = wc.DownloadString(BASE_URL + apiRoute);
            }

            return json;
        }

        internal AxolotlResponse CallAPI(string json)
        {
            return JsonConvert.DeserializeObject<AxolotlResponse>(json);
        }
    }
}
