using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WsOperationsService.Classes
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