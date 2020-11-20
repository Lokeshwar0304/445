using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WindIntensityWebAPI.Controllers
{
    public class HomeController : Controller
    {
        //[Route("api/Home/WindIntensity/{latitude:decimal,longitude:decimal}/")]
        public decimal WindIntensity(decimal latitude, decimal longitude)
        {

            string apikey = "11998e7539db55182f98f31ba79cd02f";
            string baseURL = "http://history.openweathermap.org/data/2.5";

            using (var httpClient = new HttpClient())
            {

                var response2 = httpClient.GetStringAsync(new Uri($"{baseURL}/aggregated/year?lat={latitude}&lon={longitude}&appid={apikey}")).Result;

                //var obj1 = JsonConvert.DeserializeObject<Weather>(response2);
            }

            return 0;
        }


        public string Index()
        {
            return "Lokesh";
        }
    }
}
