using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class MessageSend
    {
        public MessageSendResponseObject Send(MessageSendObject model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/MessageSend";

                HttpExecuter exec = new HttpPost();
                var rawResponse= exec.Execute(new HttpObject() { Url = url, Json = json });

                MessageSendResponseObject res = rawResponse.Deserialize<MessageSendResponseObject>();
                if (res != null && res.IsSuccessful == true)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public MessageSendResponseObject GetByDate(string shamsi_FromDate, string shamsi_ToDate, int rowsPerPage, int requestedPageNumber)
        {
            try
            {
                string url = string.Format("http://ws.sms.ir/api/MessageSend?Shamsi_FromDate={0}&Shamsi_ToDate={1}&RowsPerPage={2}&RequestedPageNumber={3}",
                    shamsi_FromDate, shamsi_ToDate, rowsPerPage, requestedPageNumber);

                HttpExecuter exec = new HttpGet();
                var rawResponse = exec.Execute(new HttpObject() { Url = url });

                MessageSendResponseObject res = rawResponse.Deserialize<MessageSendResponseObject>();
                if (res != null && res.IsSuccessful == true)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }


    }
}
