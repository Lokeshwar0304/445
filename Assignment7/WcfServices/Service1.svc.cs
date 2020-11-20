using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;

namespace WcfServices
{
    //This service includes two operations:-
    //1. XML Verficiation
    //2. XPathSearch 

    public class Service1 : IService1
    {

      
        public static StringBuilder strBuilder = new StringBuilder("");


        // This operation takes a URL for a XML document (xmlUrl) and a XML Schema document (xsdUrl), verifies them and returns the output.
        public string verification(String xmlUrl, String xsdUrl)
        {

            strBuilder = new StringBuilder("");
            try
            {
                
                XmlSchemaSet schemaset = new XmlSchemaSet(); //Creating XmlSchemaSet class
                schemaset.Add(null, xsdUrl); //Adding Schema
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaset; 
                settings.ValidationEventHandler += new ValidationEventHandler(CBValidationErrors);
                
                XmlReader reader = XmlReader.Create(xmlUrl, settings); //Creating XmlReader object.
                while (reader.Read()) ; 

                if (strBuilder.Length == 0)
                {
                    strBuilder.Append("NO ERROR");
                }

                
            }
            catch (Exception ex)
            {
                strBuilder.Append("ERROR IN LOADING THE XML / XSD, ERROR:-" + ex.Message);
            }

            return strBuilder.ToString();
        }

        //This Operation takes the URL of an XML (.xml) file and a path expression as input. It returns the path expression value of the given path.
        public string XPathSearch(String xmlUrl, String pathExpression)
        {
            StringBuilder strBuilder = new StringBuilder("");
            try
            {
                XPathDocument xpathDoc = new XPathDocument(xmlUrl);
                XPathNavigator xpathNav = xpathDoc.CreateNavigator();
                XPathNodeIterator xpathIterator = xpathNav.Select(pathExpression);

                foreach (XPathNavigator nav in xpathIterator)
                {
                    strBuilder.Append(nav.OuterXml + "\n\n");
                }
            }
            catch (Exception ex)
            {
                strBuilder.Append("Please enter valid XML URL / path expression" + ex.Message);
            }

            return strBuilder.ToString();
        }

        //This method is to append the validation errors if exists.
        private static void CBValidationErrors(object sender, ValidationEventArgs e)
        {

            strBuilder.Append("VALIDATION ERROR:-" + e.Message + "<br />");
        }
      
        
    }
}
