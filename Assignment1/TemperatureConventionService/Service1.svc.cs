using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperatureConventionService
{
     public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        //This method is to convert a Celsius temperature value to Faranheit temperature value
        //Input Parameter: Celsius value
        //Output: Faranheit value
        public int c2f(int c)
        {
            int conv_value = 0;
            try
            {
                double f = (32 + (c * 9d / 5));
                conv_value = Convert.ToInt32(Math.Round(f, MidpointRounding.AwayFromZero));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return conv_value;
        }


        //This method is to convert a Faranheit temperature value to Celsius temperature value
        //Input Parameter: Faranheit value
        //Output: Celsius value
        public int f2c(int f)
        {
            int conv_value = 0;
            try
            {
                double c = ((f - 32) * 5d / 9);
                conv_value= Convert.ToInt32(Math.Round(c, MidpointRounding.AwayFromZero));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return conv_value;
        }
        
    }
}
