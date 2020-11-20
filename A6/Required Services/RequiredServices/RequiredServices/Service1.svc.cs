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
using RequiredServices.Models;
using System.Xml;
using System.Web.Services.Description;

namespace RequiredServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1, IService2
    {
        //This method takes zipcode as input and returns the weather data for next 5 days
        public string[] Weather5day(string zipcode)
        {
            try
            {
                List<string> weatherClient = new List<string>();
                string baseURL = "https://api.zippopotam.us/us";

                string apikey = "deb8c45d999bb4cf6a423be9bb20ed92"; // API Key

                using (var httpClient = new HttpClient())
                {
                    var response1 = httpClient.GetStringAsync(new Uri($"{baseURL}/{zipcode}")).Result; // fetching latitude and longitude of the given zip code

                    var obj = JsonConvert.DeserializeObject<ZipCodeJson>(response1); // converting the response to JSON

                    baseURL = "http://api.openweathermap.org/data/2.5";

                    var response2 = httpClient.GetStringAsync(new Uri($"{baseURL}/forecast?lat={obj.places[0].latitude}&lon={obj.places[0].longitude}&appid={apikey}")).Result; // fetching 5 day weather information of a particular location from the above third party openweathermap API

                    var obj1 = JsonConvert.DeserializeObject<Weather>(response2); // converting the response to JSON

                    var groups = obj1.weatherInfo.GroupBy(order => order.dateTime.Split()[0]); // data grouped by date

                    Dictionary<string, List<Weather.WeatherInfo.TemperatureInfo>> dicwinfo = new Dictionary<string, List<Weather.WeatherInfo.TemperatureInfo>>();

                    foreach (var group in groups)
                    {
                        List<Weather.WeatherInfo.TemperatureInfo> info = new List<Weather.WeatherInfo.TemperatureInfo>();
                        foreach (var g in group)
                        {
                            info.Add(g.temperatureInfo); //creating temperature information object
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
                return weatherClient.ToArray(); // returing the 5-day weather forecast information
                
            }
            catch(Exception ex)
            {
                return new string[] { "ERROR", ex.Message };
            }

        }

        public string[] WsOperations(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return new string[] { "ERROR", "Please enter a valid URL" };
            try
            {


                List<WsOperation> wsOperations = new List<WsOperation>();
                XmlTextReader reader = new XmlTextReader(url); //Fetching the WSDL XML content from the input url 
                ServiceDescription wsdl = ServiceDescription.Read(reader);

                foreach (PortType pt in wsdl.PortTypes)
                {

                    foreach (Operation op in pt.Operations)
                    {
                        string opName = "", inParam = "", outParam = "";
                        opName = op.Name; //method name
                        foreach (OperationMessage msg in op.Messages)
                        {
                            if (msg is OperationInput)
                            {
                                inParam = inParam + msg.Message.Name; //input parameters
                                OperationInput oi = msg as OperationInput;
                            }
                            else if (msg is OperationOutput)
                                outParam = msg.Message.Name; //return types
                        }

                        wsOperations.Add(new WsOperation(opName, inParam, outParam)); //making operation name, input params, return type tuples
                    }
                }
                if (wsOperations.Count > 0)
                {
                    var outputArray = wsOperations.Select(x => x.operationName + "," + x.inputParameter + "," + x.outputParameter).ToArray(); //converting tuples to string array
                    return outputArray;
                }
                else
                {
                    return new string[] { "ERROR", "There are no Operations in the provided URL. Please try with different URL" };
                }


            }
            catch (Exception e)
            {
                return new string[] { "ERROR", e.Message };
            }
            finally
            {

            }
        }
    }
}
