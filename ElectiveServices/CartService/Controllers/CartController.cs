using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartService.Models;
using Newtonsoft.Json;

namespace CartService.Controllers
{
    public class CartController : Controller
    {
        private static string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", "cart.json");



        public Dictionary<string,string> printCartDetails(string name)
        {
            string JsonResult = "";
            Dictionary<string, string> op = new Dictionary<string, string>();
            try
            {
                using (StreamReader streamReader = new StreamReader(fLocation))
                {
                    JsonResult = streamReader.ReadToEnd();
                }

                List<Cart> cartDetails = new List<Cart>();
                cartDetails = JsonConvert.DeserializeObject<List<Cart>>(JsonResult);

                Cart cart = cartDetails.FirstOrDefault(r => r.cartName.ToLower() == name.ToLower() || r.userName.ToLower() == name.ToLower());

                op.Add("CartName", cart.cartName);
                op.Add("UserName", cart.userName);
                op.Add("ContactNumber", cart.contactNumber);
                op.Add("Address", cart.address);

                for (int i = 0; i < cart.products.Count; i++)
                {
                    op.Add("Product" + i.ToString(), cart.products[i].productName + "," + cart.products[i].productQuantity);
                }


                return op;
            }
            catch(Exception ex)
            {
                return new Dictionary<string, string>() { { "ERROR", ex.Message } };
            }

        }
        public bool AddCartDetails(string cartItems)
        {
            try
            {
                var cartDetails = JsonConvert.DeserializeObject<Cart>(cartItems);

                string JsonResult = "";
                using (StreamReader streamReader = new StreamReader(fLocation))
                {
                    JsonResult = streamReader.ReadToEnd();
                }

                List<Cart> cart = new List<Cart>();
                cart = JsonConvert.DeserializeObject<List<Cart>>(JsonResult);

                Cart exisUserCart = cart.FirstOrDefault(r => r.cartName.ToLower() == cartDetails.cartName.ToLower());
                if (exisUserCart == null)
                {
                    cart.Add(cartDetails);
                }
                string jsonString = JsonConvert.SerializeObject(cart);
                using (StreamWriter streamWriter = new StreamWriter(fLocation))
                {
                    streamWriter.Write(jsonString);
                    return true;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        //public bool UpdateCartDetails()
        //{
        //    return false;
        //}
    }
}