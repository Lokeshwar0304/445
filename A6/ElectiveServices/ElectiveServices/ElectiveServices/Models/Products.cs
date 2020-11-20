using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectiveServices.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    //Primary Class
    public class Products
    {
        public List<FindItemsByKeywordsResponse> findItemsByKeywordsResponse { get; set; }
    }

    public class PrimaryCategory
    {
        public List<string> categoryId { get; set; }
        public List<string> categoryName { get; set; }
    }

    public class ShippingServiceCost
    {
        [JsonProperty("@currencyId")]
        public string CurrencyId { get; set; }
        public string __value__ { get; set; }
    }

    public class ShippingInfo
    {
        public List<ShippingServiceCost> shippingServiceCost { get; set; }
        public List<string> shipToLocations { get; set; }
        public List<string> oneDayShippingAvailable { get; set; }
    }

    public class CurrentPrice
    {
        [JsonProperty("@currencyId")]
        public string CurrencyId { get; set; }
        public string __value__ { get; set; }
    }

    public class ConvertedCurrentPrice
    {
        [JsonProperty("@currencyId")]
        public string CurrencyId { get; set; }
        public string __value__ { get; set; }
    }

    public class SellingStatus
    {
        public List<CurrentPrice> currentPrice { get; set; }
        public List<ConvertedCurrentPrice> convertedCurrentPrice { get; set; }

    }


    public class Item
    {
        public List<string> itemId { get; set; }
        public List<string> title { get; set; }
        public List<PrimaryCategory> primaryCategory { get; set; }
        public List<string> postalCode { get; set; }
        public List<string> location { get; set; }
        public List<string> country { get; set; }
        public List<ShippingInfo> shippingInfo { get; set; }
        public List<SellingStatus> sellingStatus { get; set; }
        public List<string> returnsAccepted { get; set; }
        public List<string> paymentMethod { get; set; }
    }

    public class SearchResult
    {
        [JsonProperty("@count")]
        public string Count { get; set; }
        public List<Item> item { get; set; }
    }


    public class FindItemsByKeywordsResponse
    {
        public List<SearchResult> searchResult { get; set; }
    }


}