using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class SentMessageResponseByDate : BaseResponseApiModel
    {
        public int CountOfAll { get; set; }
        public SentMessage[] Messages { get; set; }

    }

    public class SentMessage
    {
        public long ID { get; set; }
        public string LineNumber { get; set; }
        public string SMSMessageBody { get; set; }
        public string MobileNo { get; set; }
        // public string SendDateTime_Persian { get; set; }

        public string SendDateTime { get; set; }
        //{
        //    get {

        //        try
        //        {
        //            return this.SendDateTimeLatin.Value.GetPersianDateWithTime();
        //        }
        //        catch 
        //        {
        //            return null;
        //        }

        //    }
        //}

        public string ToBeSentAt { get; set; }
        public string NativeDeliveryStatus { get; set; }
        public string TypeOfMessage { get; set; }

        public string PersianSendDateTime { get; set; }
    }









































}
