using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectiveServices.Models;

namespace ElectiveServices.Controllers
{
    public class ProductsController : ApiController
    {
        private static string apiKey = ConfigurationManager.AppSettings.Get("ebayAPIKey");
        private static string defaultURL = ConfigurationManager.AppSettings.Get("ebayDefaultURL");
        private static string format = "JSON";
        private static string version = "1.0.0";
        private static string pages = "4";



        public string[] GetProducts(String searchword)
        {
            List<string> outputList = null;
            searchword = System.Net.WebUtility.UrlEncode(searchword);
            string httpUrl = defaultURL + "&SERVICE-VERSION=" + version +
                                "&SECURITY-APPNAME=" + apiKey +
                                "&RESPONSE-DATA-FORMAT=" + format +
                                "&REST-PAYLOAD&keywords=" + searchword +
                                "&paginationInput.entriesPerPage=" + pages;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(new Uri($"{httpUrl}")).Result;
                    outputList = new List<string>();
                    Products products = JsonConvert.DeserializeObject<Products>(response);
                    List<SearchResult> searchResults = products.findItemsByKeywordsResponse[0].searchResult;
                    List<Item> items = searchResults[0].item; //handle null

                    foreach (var item in items) //handle null in for loop
                    {
                        string cItem = "";
                        //id,title,categoryname *,location,value *,shiptoLocations *,onedayavailable *,currentprice *,returnsaccepted,paymentmethod
                        cItem = item.itemId[0];
                        cItem = cItem + "#" + item.title[0];
                        cItem = cItem + "#" + item.primaryCategory[0].categoryName[0];
                        cItem = cItem + "#" + item.location[0];
                        cItem = cItem + "#" + item.shippingInfo[0].shippingServiceCost[0].__value__;
                        cItem = cItem + "#" + item.shippingInfo[0].shipToLocations[0];
                        cItem = cItem + "#" + item.shippingInfo[0].oneDayShippingAvailable[0];
                        cItem = cItem + "#" + item.sellingStatus[0].currentPrice[0].__value__;
                        cItem = cItem + "#" + item.returnsAccepted[0];
                        //cItem = cItem + "," + item.paymentMethod!=null? item.paymentMethod[0]:"";
                        outputList.Add(cItem);
                    }
                }
                return outputList.ToArray();
            }
            catch (Exception ex)
            {
                return new string[] { "ERROR", ex.Message };
            }

        }

    }
}
