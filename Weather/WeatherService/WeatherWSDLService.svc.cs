using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeatherService.Classes;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WeatherWSDLService : IWeatherWSDLService
    {
        

        public string Weather5day(string zipcode)
        {
            string baseURL = "https://api.zippopotam.us/us";

            string apikey = "deb8c45d999bb4cf6a423be9bb20ed92";

            using (var httpClient = new HttpClient())
            { 
                var response1 = httpClient.GetStringAsync(new Uri($"{baseURL}/{zipcode}")).Result;

                var obj = JsonConvert.DeserializeObject<ZipCodeJson>(response1);

                baseURL = "http://api.openweathermap.org/data/2.5";
                var response2 = httpClient.GetStringAsync(new Uri($"{baseURL}/forecast?lat={obj.places[0].latitude}&lon={obj.places[0].longitude}&appid={apikey}")).Result;

                var obj1 = JsonConvert.DeserializeObject<Weather>(response2);
            }

            return zipcode;
        }
    }
}
