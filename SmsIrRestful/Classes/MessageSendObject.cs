using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class MessageSendObject
    {
        public string[] Messages { get; set; }
        public string[] MobileNumbers { get; set; }
        public string LineNumber { get; set; }
        public DateTime? SendDateTime { get; set; }
        public bool? CanContinueInCaseOfError { get; set; }
    }



    public class MessageSendResponseObject : BaseResponseApiModel
    {
        public SentSMSLog2[] Ids { get; set; }
        public string BatchKey { get; set; }


    }
}
