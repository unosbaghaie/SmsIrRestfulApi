using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class SentMessageResponseById : BaseResponseApiModel
    {
        public SentSmsDetails Messages { get; set; }
    }

    public class SentSmsDetails
    {
        public long ID { get; set; }
        public string MobileNo { get; set; }
        public string SendDateTime { get; set; }
        public string DeliveryStatus { get; set; }
        public string SMSMessageBody { get; set; }

        public bool SendIsErronous { get; set; }

        public string DeliveryStatusFetchError { get; set; }

        public bool NeedsReCheck { get; set; }

        public int? DeliveryStateID { get; set; }
    }
}
