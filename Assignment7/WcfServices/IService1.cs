using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string verification(string xmlUrl, string xslUrl); //takes a URL of xml and xsd for xml validation

        [OperationContract]
        string XPathSearch(string xmlUrl, string pathExpression); //takes the URL of an XML (.xml) file and a path expression as input. It returns the path expression value of the given path.

    }

   


}
