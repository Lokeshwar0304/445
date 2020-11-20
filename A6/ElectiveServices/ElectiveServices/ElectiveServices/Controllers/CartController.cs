using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ElectiveServices.Models;

namespace ElectiveServices.Controllers
{
    public class CartController : ApiController
    {
        private static string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", "cart.json");



        public Dictionary<string, string> GetCartDetails(string name)
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

                if (cart != null)
                {
                    op.Add("CartName", cart.cartName);
                    op.Add("UserName", cart.userName);
                    op.Add("ContactNumber", cart.contactNumber);
                    op.Add("Address", cart.address);

                    for (int i = 0; i < cart.products.Count; i++)
                    {
                        op.Add("Product" + i.ToString(), cart.products[i].productName + "X" + cart.products[i].productQuantity);
                    }
                }
                else
                {
                    op.Add("ERROR", "Please enter valid user name/ cart name");
                }


                return op;
            }
            catch (Exception ex)
            {
                return new Dictionary<string, string>() { { "ERROR", ex.Message } };
            }

        }

        public bool PostCartDetails(string cartItems)
        {
            try
            {
               var deserObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(cartItems);
                Cart cartDetails = new Cart();
                List<ProductDetails> prd = new List<ProductDetails>();
                cartDetails.userName = deserObj["userName"];
                cartDetails.cartName = deserObj["cartName"];
                var x = deserObj["products"].ToString().Split('X');
                foreach(var item in x)
                {
                    var m = JsonConvert.DeserializeObject<ProductDetails>(item);
                    prd.Add(m);
                }
                cartDetails.products = prd;
                cartDetails.contactNumber = deserObj["contactNumber"];
                cartDetails.address = deserObj["address"];


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
                else
                {
                    prd = new List<ProductDetails>();
                    foreach(var item in exisUserCart.products)
                    {
                        prd.Add(item);
                    }
                    foreach(var item in cartDetails.products)
                    {
                        prd.Add(item);
                    }
                    exisUserCart.products = prd;
                    var index = cart.IndexOf(exisUserCart);
                    if (index>-1)
                    {
                        cart[index].products = prd;
                        cart[index].contactNumber = cartDetails.contactNumber;
                        cart[index].address = cartDetails.address;
                        cart[index].cartName = cartDetails.cartName;
                        cart[index].userName = cartDetails.userName;

                    }
                }
                string jsonString = JsonConvert.SerializeObject(cart);
                using (StreamWriter streamWriter = new StreamWriter(fLocation))
                {
                    streamWriter.Write(jsonString);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
