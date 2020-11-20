using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Web;
using System.Web.Http;

namespace WebApplication2.Controller
{
    public class HelloController : ApiController
    {

        LatLonListZipCodeService.ndfdXMLPortTypeClient sec = new LatLonListZipCodeService.ndfdXMLPortTypeClient();

        
        public string[] Weather5day()
        {
            string baseURL = "api.openweathermap.org/data/2.5/forecast?";

            var output = sec.LatLonListZipCode("85281");

            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            }

            return null;
        }

    }
}
