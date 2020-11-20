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
using System.Web.Mvc;

namespace ElectiveServices.Controllers
{
    public class ReviewController : ApiController
    {
        private static string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", "reviews.json");

        [System.Web.Http.HttpGet]
        public string Index()
        {
            return "Review Service";
        }

        [System.Web.Http.HttpGet]
        public List<Reviews> Get()
        {
            
                string JsonResult = "";
                using (StreamReader streamReader = new StreamReader(fLocation))
                {
                    JsonResult = streamReader.ReadToEnd();
                }

                List<Reviews> reviews = new List<Reviews>();
                reviews = JsonConvert.DeserializeObject<List<Reviews>>(JsonResult);
                return reviews;
           
            
        }

        [System.Web.Http.HttpGet]
        public string[] GetReviews()
        {
            List<string> op = new List<string>();
            try
            {
                List<Reviews> reviews = Get();

                foreach (var review in reviews)
                {

                    string rev = "";
                    rev = review.hospitalID.ToString();
                    rev = rev + "#" + review.hospitalName;
                    rev = rev + "#" + review.hospitalAddress;
                    rev = rev + "#" + review.contact;
                    rev = rev + "#" + review.distance;
                    rev = rev + "#" + review.rating;
                    rev = rev + "#" + string.Join(",", review.review);
                    rev = rev + "#" + review.bedsAvailable;
                    rev = rev + "#" + review.ventilatorsAvailable;
                    rev = rev + "#" + review.testing;
                    op.Add(rev);

                }
               
                return op.ToArray();
            }
            catch (Exception ex)
            {
                return new string[] { "ERROR", ex.Message };
            }
        }

        
        public bool PostReview(string review)
        {
            try
            {
                Reviews clientReview = JsonConvert.DeserializeObject<Reviews>(review);
                if ( clientReview.hospitalID.ToString() == "")
                {
                    return AddReview(clientReview);
                }
                else
                {
                    return UpdateReview(clientReview);
                }
            }
            catch
            {
                return false;
            }
        }

        
        public bool AddReview(Reviews addReview)
        {
            try
            {
                List<Reviews> reviews = Get();

                Reviews exisReview = reviews.FirstOrDefault(r => r.hospitalID == addReview.hospitalID);
                if (exisReview == null)
                {
                    int newID = reviews.Max(x => x.hospitalID) + 1;
                    addReview.hospitalID = newID;
                    reviews.Add(addReview);
                }
                string jsonString = JsonConvert.SerializeObject(reviews);
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

        
        public bool UpdateReview(Reviews updateReview)
        {
            try
            {
                List<Reviews> reviews = Get();
                Reviews exisReview = reviews.FirstOrDefault(r => r.hospitalID == updateReview.hospitalID);
                if (exisReview != null)
                {
                    int index = reviews.FindIndex(r => r.hospitalID == updateReview.hospitalID);
                    if (updateReview.rating != null)
                    {
                        reviews[index].rating = Convert.ToString((Convert.ToInt32(reviews[index].rating) + Convert.ToInt32(updateReview.rating)) / 2);
                    }
                    if (updateReview.review != null)
                    {
                        string newReview = updateReview.review[0];
                        reviews[index].review.Add(newReview);
                    }

                    string jsonString = JsonConvert.SerializeObject(reviews);
                    using (StreamWriter streamWriter = new StreamWriter(fLocation))
                    {
                        streamWriter.Write(jsonString);
                        return true;
                    }
                }
                else
                {
                    return AddReview(updateReview);
                }
            }
            catch(Exception)
            {
                return false;
            }

        }

    }
}
