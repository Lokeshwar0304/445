using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectiveServices.Models
{
    public class Reviews
    {
        public int hospitalID { get; set; }
        public string hospitalName { get; set; }
        public string hospitalAddress { get; set; }
        public string contact { get; set; }
        public string distance { get; set; }
        public string rating { get; set; }
        public List<string> review { get; set; }
        public string bedsAvailable { get; set; }
        public string ventilatorsAvailable { get; set; }
        public string testing { get; set; }

        public Reviews()
        {
            //4,Manasa,Atp,44777,100,2,Best,10,7,Yes
        }
    }
}