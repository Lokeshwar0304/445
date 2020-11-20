using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;

namespace TryItWeatherApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tb4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {

            

            String baseURL = "https://localhost:44349/Review/GetReviews/";

          

            using (var httpClient = new HttpClient())
            {
                var zipCodeResponse = httpClient.GetStringAsync(new Uri($"{baseURL}")).Result;

                //validating the input zip code
                List<String> list = JsonConvert.DeserializeObject<List<String>>(zipCodeResponse);


            }
            

        }
    }
}