using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SortStringNumbers
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        // Method to sort a string of numbers, separated by commas
        [OperationContract]
        string sort(string s);
        
    }


}
