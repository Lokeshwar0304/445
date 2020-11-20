using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        

        public string[] Weather5day(string zipcode)
        {
            List<string[]> weatherClient = new List<string[]>();
            string baseURL = "https://api.zippopotam.us/us";
            
            string apikey = "deb8c45d999bb4cf6a423be9bb20ed92";
       
            using (var httpClient = new HttpClient())
            {
                var response1 = httpClient.GetStringAsync(new Uri($"{baseURL}/{zipcode}")).Result;

                var obj= JsonConvert.DeserializeObject<ZipCodeJson>(response1);

                baseURL = "http://api.openweathermap.org/data/2.5";
                var response2 = httpClient.GetStringAsync(new Uri($"{baseURL}/forecast?lat={obj.places[0].latitude}&lon={obj.places[0].longitude}&appid={apikey}")).Result;

                var obj1 = JsonConvert.DeserializeObject<Weather>(response2);

                var groups = obj1.weatherInfo.GroupBy(order => order.dateTime.Split()[0]);

                Dictionary<string, List<Weather.WeatherInfo.TemperatureInfo>> dicwinfo = new Dictionary<string, List<Weather.WeatherInfo.TemperatureInfo>>();

                foreach (var group  in groups)
                {
                    List<Weather.WeatherInfo.TemperatureInfo> info = new List<Weather.WeatherInfo.TemperatureInfo>();
                    foreach (var g in group)
                    {
                        info.Add(g.temperatureInfo);
                    }
                    dicwinfo.Add(group.Key, info);
                }


                weatherClient.Add(new string[] { obj1.city.name,obj1.city.country,zipcode, obj.places[0].latitude, obj.places[0].longitude});

                int dateCounter = 0;
                foreach (var day in dicwinfo.Values)
                {
                    
                    var avg_temp = day.Select(x => Convert.ToDouble(x.temperature)).DefaultIfEmpty(0).Average();
                    avg_temp = ((avg_temp - 273.15) * 9 / 5) + 32;
                    var avg_min_temp = day.Select(x => Convert.ToDouble(x.temperature_min)).DefaultIfEmpty(0).Average();
                    avg_min_temp = ((avg_min_temp - 273.15) * 9 / 5) + 32;
                    var avg_max_temp = day.Select(x => Convert.ToDouble(x.temperature_max)).DefaultIfEmpty(0).Average();
                    avg_max_temp = ((avg_max_temp - 273.15) * 9 / 5) + 32;
                    var avg_humidity = day.Select(x => Convert.ToDouble(x.humidity)).DefaultIfEmpty(0).Average();
                    var avg_pressure = day.Select(x => Convert.ToDouble(x.pressure)).DefaultIfEmpty(0).Average();

                    weatherClient.Add(new string[] { dicwinfo.Keys.ToList()[dateCounter], avg_temp.ToString(), avg_min_temp.ToString(), avg_max_temp.ToString(), avg_humidity.ToString(), avg_pressure.ToString() });
                    dateCounter += 1;
                }

            }
            return weatherClient.Select(i => i.ToString()).ToArray();
            
        }
        public string Index()
        {
            return "Lokesh";
        }
    }
}
