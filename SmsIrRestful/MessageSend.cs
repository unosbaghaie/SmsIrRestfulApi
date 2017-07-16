using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class MessageSend
    {

        #region [Properties]
        private static Lazy<IHttpRequest> CachedClient = new Lazy<IHttpRequest>(() => new HttpPostRequest());

        private static Func<IHttpRequest> DefaultFactory = () => CachedClient.Value;

        private static Func<IHttpRequest> _httpClientFactory;
        private static object HttpRequestFactoryLock = new object();

        internal static Func<IHttpRequest> HttpRequestFactory
        {
            get
            {
                lock (HttpRequestFactoryLock)
                {
                    return _httpClientFactory ?? DefaultFactory;
                }
            }
            set
            {
                lock (HttpRequestFactoryLock)
                {
                    _httpClientFactory = value;
                }
            }
        }

        #endregion


        public MessageSendResponseObject Send(string tokenKey, MessageSendObject model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/MessageSend";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);


                HttpRequestFactory = () => new HttpPostRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                //HttpExecuter exec = new HttpPost();
                //var rawResponse = exec.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                MessageSendResponseObject res = rawResponse.Deserialize<MessageSendResponseObject>();
                if (res == null)
                    return null;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public SentMessageResponseByDate GetByDate(string tokenKey, string shamsi_FromDate, string shamsi_ToDate, int rowsPerPage, int requestedPageNumber)
        {
            try
            {
                string url = string.Format("http://ws.sms.ir/api/MessageSend?Shamsi_FromDate={0}&Shamsi_ToDate={1}&RowsPerPage={2}&RequestedPageNumber={3}",
                    shamsi_FromDate, shamsi_ToDate, rowsPerPage, requestedPageNumber);

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                HttpRequestFactory = () => new HttpGetRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url}, parameters);


                //HttpExecuter exec = new HttpGet();
                //var rawResponse = exec.Execute(new HttpObject() { Url = url }, parameters);

                SentMessageResponseByDate res = rawResponse.Deserialize<SentMessageResponseByDate>();

                if (res == null)
                    return null;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public SentMessageResponseById GetById(string tokenKey, int id)
        {
            try
            {
                string url = string.Format("http://ws.sms.ir/api/MessageSend?id={0}", id);

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);


                HttpRequestFactory = () => new HttpGetRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url }, parameters);


                //HttpExecuter exec = new HttpGet();
                //var rawResponse = exec.Execute(new HttpObject() { Url = url }, parameters);

                SentMessageResponseById res = rawResponse.Deserialize<SentMessageResponseById>();
                if (res == null)
                    return null;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

       
    }
}
