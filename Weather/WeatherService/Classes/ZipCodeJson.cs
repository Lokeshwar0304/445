using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Classes
{
    public class ZipCodeJson
    {
        [JsonProperty(PropertyName = "post code")]
        public string postCode { get; set; }
        public string country { get; set; }

        [JsonProperty(PropertyName = "country abbreviation")]
        public string countryAbbrevation { get; set; }

        public List<Place> places { get; set; }

        public class Place
        {
            [JsonProperty(PropertyName = "place name")]
            public string placeName { get; set; }
            public string longitude { get; set; }
            public string state { get; set; }

            [JsonProperty(PropertyName = "state abbreviation")]
            public string stateAbbrevation { get; set; }
            public string latitude { get; set; }


        }
    }
}