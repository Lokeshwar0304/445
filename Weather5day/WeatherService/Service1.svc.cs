using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeatherService.Models;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] Weather5day(string zipcode)
        {
            try
            {
                List<string> weatherClient = new List<string>();
                string baseURL = "https://api.zippopotam.us/us";

                string apikey = "deb8c45d999bb4cf6a423be9bb20ed92";

                using (var httpClient = new HttpClient())
                {
                    var response1 = httpClient.GetStringAsync(new Uri($"{baseURL}/{zipcode}")).Result;

                    var obj = JsonConvert.DeserializeObject<ZipCodeJson>(response1);

                    baseURL = "http://api.openweathermap.org/data/2.5";
                    var response2 = httpClient.GetStringAsync(new Uri($"{baseURL}/forecast?lat={obj.places[0].latitude}&lon={obj.places[0].longitude}&appid={apikey}")).Result;

                    var obj1 = JsonConvert.DeserializeObject<Weather>(response2);

                    var groups = obj1.weatherInfo.GroupBy(order => order.dateTime.Split()[0]);

                    Dictionary<string, List<Weather.WeatherInfo.TemperatureInfo>> dicwinfo = new Dictionary<string, List<Weather.WeatherInfo.TemperatureInfo>>();

                    foreach (var group in groups)
                    {
                        List<Weather.WeatherInfo.TemperatureInfo> info = new List<Weather.WeatherInfo.TemperatureInfo>();
                        foreach (var g in group)
                        {
                            info.Add(g.temperatureInfo);
                        }
                        dicwinfo.Add(group.Key, info);
                    }


                    weatherClient.Add(obj1.city.name+","+ obj1.city.country + "," + zipcode + "," + obj.places[0].latitude + "," + obj.places[0].longitude );

                    

                    int dateCounter = 0;
                    foreach (var day in dicwinfo.Values)
                    {

                        var avg_temp = day.Select(x => Convert.ToDouble(x.temperature)).DefaultIfEmpty(0).Average();
                        avg_temp = Math.Round(((avg_temp - 273.15) * 9 / 5) + 32, 2);
                        var avg_min_temp = day.Select(x => Convert.ToDouble(x.temperature_min)).DefaultIfEmpty(0).Average();
                        avg_min_temp = Math.Round(((avg_min_temp - 273.15) * 9 / 5) + 32, 2);
                        var avg_max_temp = day.Select(x => Convert.ToDouble(x.temperature_max)).DefaultIfEmpty(0).Average();
                        avg_max_temp = Math.Round(((avg_max_temp - 273.15) * 9 / 5) + 32, 2);
                        var avg_humidity = Math.Round(day.Select(x => Convert.ToDouble(x.humidity)).DefaultIfEmpty(0).Average(),2);
                        var avg_pressure = Math.Round(day.Select(x => Convert.ToDouble(x.pressure)).DefaultIfEmpty(0).Average(),2);

                        weatherClient.Add(dicwinfo.Keys.ToList()[dateCounter] + "," + avg_temp.ToString() + "°F" + "," + avg_min_temp.ToString()+"°F" + "," + avg_max_temp.ToString()+ "°F" + "," + avg_humidity.ToString() + "%"+ "," + avg_pressure.ToString() +"hPa");
                        dateCounter += 1;
                    }

                }
                return weatherClient.ToArray();
                
            }
            catch(Exception ex)
            {
                return new string[] { "ERROR", ex.Message };
            }

        }
    }
}
