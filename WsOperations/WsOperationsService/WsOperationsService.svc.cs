using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;
using System.Xml;
using WsOperationsService.Classes;

namespace WsOperationsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IWsOperationsService
    {
        public string[] WsOperations(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return new string[] { "ERROR", "Please enter a valid URL" };
            try
            {

                
                List<WsOperation> wsOperations = new List<WsOperation>();
                XmlTextReader reader = new XmlTextReader(url);
                ServiceDescription wsdl = ServiceDescription.Read(reader);
                
                foreach (PortType pt in wsdl.PortTypes)
                {
                    
                    foreach (Operation op in pt.Operations)
                    {
                        string opName = "", inParam = "", outParam = "";
                        opName = op.Name;
                        foreach (OperationMessage msg in op.Messages)
                        {
                            if (msg is OperationInput)
                            {
                                inParam = inParam + msg.Message.Name; // check for two or more input parameters?
                                OperationInput oi = msg as OperationInput;
                            }
                            else if (msg is OperationOutput)
                                outParam = msg.Message.Name;
                        }

                        wsOperations.Add(new WsOperation(opName, inParam, outParam));
                    }
                }
                if (wsOperations.Count > 0)
                {
                    var outputArray = wsOperations.Select(x => x.operationName + "," + x.inputParameter + "," + x.outputParameter).ToArray();
                    return outputArray;
                }
                else
                {
                    return new string[] { "ERROR", "There are no Operations in the provided URL. Please try with different URL" };
                }


            }
            catch (Exception e)
            {
                return new string[] { "ERROR",e.Message };
            }
            finally
            {

            }
        }
    }
}
