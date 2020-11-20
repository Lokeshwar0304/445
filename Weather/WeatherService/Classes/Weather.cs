using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Classes
{
    public class Weather
    {

        [JsonProperty(PropertyName = "list")]
        public List<WeatherInfo> weatherInfo { get; set; }

        public CityInfo city { get; set; }


        public class CityInfo
        {
            public string name { get; set; }
            public string country { get; set; }

        }

        public class WeatherInfo
        {
            public string dt { get; set; }

            [JsonProperty(PropertyName = "dt_txt")]
            public string dateTime { get; set; }

            [JsonProperty(PropertyName = "main")]
            public TemperatureInfo temperatureInfo { get; set; }

            [JsonProperty(PropertyName = "weather")]
            public List<WeatherDescription> weatherDescription { get; set; }

            public class TemperatureInfo
            {
                [JsonProperty(PropertyName = "temp")]
                public string temperature { get; set; }
                [JsonProperty(PropertyName = "temp_min")]
                public string temperature_min { get; set; }
                [JsonProperty(PropertyName = "temp_max")]
                public string temperature_max { get; set; }
                public string pressure { get; set; }
                public string humidity { get; set; }

            }

            public class WeatherDescription
            {
                public string description { get; set; }
            }



        }
    }

}