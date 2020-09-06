using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperatureConventionService
{
    [ServiceContract] //This will turn the interface into a WCF Service
    public interface IService1
    {

        [OperationContract] // This will make the method available as part of the service to the consumer client
        string GetData(int value);


        //This method is to convert a Celsius temperature value to Faranheit temperature value
        [OperationContract]
        int c2f(int c);


        //This method is to convert a Faranheit temperature value to Celsius temperature value
        [OperationContract]
        int f2c(int f);

        
    }


   
}
