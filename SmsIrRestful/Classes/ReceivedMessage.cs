using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{

    public class ReceiveMessageRequestObject
    {
        public string Shamsi_FromDate { get; set; }
        public string Shamsi_ToDate { get; set; }
        public int RequestedPageNumber { get; set; }
        public int RowsPerPage { get; set; }
    }

    public class ReceivedMessages
    {
        public long ID { get; set; }
        public string LineNumber { get; set; }
        public string SMSMessageBody { get; set; }
        public string MobileNo { get; set; }
        public string ReceiveDateTime { get; set; }
        public string LatinReceiveDateTime { get; set; }
        public string TypeOfMessage { get; set; }
    }

    public class ReceivedMessageResponseByDate : BaseResponseApiModel
    {
        public int CountOfAll { get; set; }
        public ReceivedMessages[] Messages { get; set; }
    }


    public class ReceiveMessageResponseById : BaseResponseApiModel
    {
        public ReceivedMessages[] Messages { get; set; }
        public int CountOfAll { get; set; }
    }














}
