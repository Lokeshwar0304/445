using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartService.Models
{
    public class Cart
    {

        public string userName { get; set; }
        public string cartName { get; set; }
        public List<ProductDetails> products { get; set; }
        public string contactNumber { get; set; }
        public string address { get; set; }
    }
    public class ProductDetails
    {
        public string productName { get; set; }
        public string productQuantity { get; set; }
    }
}