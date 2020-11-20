using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    public class ReviewController : Controller
    {
        private static string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", "reviews.json");

        public string Index()
        {
            return "Review Service";
        }

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
                var x = op.ToString();
                return op.ToArray();
            }
            catch(Exception ex)
            {
                return new string[] { "ERROR", ex.Message };
            }
        }

        public bool AddUpdateReview(string review)
        {
            string[] reviewArr = review.Split(',');
            if (reviewArr[0] =="")
            {
               return AddReview(review);
            }
            else
            {
                return UpdateReview(review);
            }
        }
        
        public bool AddReview(string addReview)
        {
            List<Reviews> reviews = Get();
            string[] addReviewarray = addReview.Split(',');
            Reviews clientReview = new Reviews
            {
                hospitalID = reviews.Max(x=>x.hospitalID)+1,
                hospitalName = addReviewarray[1],
                hospitalAddress = addReviewarray[2],
                contact = addReviewarray[3],
                distance = addReviewarray[4],
                rating = addReviewarray[5],
                review = new List<string>(addReviewarray[6].Split()),
                bedsAvailable = addReviewarray[7],
                ventilatorsAvailable = addReviewarray[8],
                testing = addReviewarray[9]
            };
            string output = JsonConvert.SerializeObject(clientReview);
            
            Reviews exisReview = reviews.FirstOrDefault(r => r.hospitalID == clientReview.hospitalID);
            if (exisReview == null)
            {
                reviews.Add(clientReview);
            }
            string jsonString = JsonConvert.SerializeObject(reviews);
            using (StreamWriter streamWriter = new StreamWriter(fLocation))
            {
                streamWriter.Write(jsonString);
                return true;
            }
        }

        public bool UpdateReview(string updateReview)
        {

            string[] updateReviewarray = updateReview.Split(',');
            string comment = updateReviewarray[6];
            Reviews clientReview = new Reviews { 
                hospitalID= Convert.ToInt32(updateReviewarray[0]),
                rating= updateReviewarray[5],
            };

            string output = JsonConvert.SerializeObject(clientReview);
            List<Reviews> reviews = Get();
            Reviews exisReview = reviews.FirstOrDefault(r => r.hospitalID == clientReview.hospitalID);

            
            if (exisReview != null)
            {
                int index = reviews.FindIndex(r => r.hospitalID == clientReview.hospitalID);
                if(clientReview.rating!=null) 
                    reviews[index].rating = Convert.ToString(Convert.ToInt32(reviews[index].rating) + Convert.ToInt32(clientReview.rating));
                if (comment != null) 
                    reviews[index].review.Add(comment);

            }

            string jsonString = JsonConvert.SerializeObject(reviews);
            using (StreamWriter streamWriter = new StreamWriter(fLocation))
            {
                streamWriter.Write(jsonString);
                return true;
            }

        }

        
    }
}
