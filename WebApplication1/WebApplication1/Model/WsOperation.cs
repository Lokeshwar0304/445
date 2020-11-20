using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace WebApplication1.Model
{
    public class WsOperation
    {
        public string operationName { get; set; }
        public string inputParameter { get; set; }

        public string outputParameter { get; set; }

        public WsOperation(string opName, string inParam, string outParam)
        {
            this.operationName = opName;
            this.inputParameter = inParam;
            this.outputParameter = outParam;
        }
    }
}