using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SortStringNumbers
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //This method is used to sort a string of numeric values.
        //Input Parameter: String array of numeric values
        //Output: Sorted array
        public string sort(string s)
        {
            try
            {
                char[] spearator = { ',' };
                string[] split_string = s.Split(spearator);
                int[] array = split_string.Select(int.Parse).ToArray();
                Array.Sort(array);
                return string.Join(",", array);
            }
            catch(Exception ex)
            {               
                return ex.Message; //Returns error message if there is some exception
            }
            
        }
    }
}
