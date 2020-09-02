﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public int c2f(int c)
        {
            double f = (32 + (c * 9d / 5));
            return Convert.ToInt32(Math.Round(f, MidpointRounding.AwayFromZero)); 
        }

        public int f2c(int f)
        {
            double c = ((f - 32) * 5d / 9);
            return Convert.ToInt32(Math.Round(c, MidpointRounding.AwayFromZero)); 
        }
        
    }
}
