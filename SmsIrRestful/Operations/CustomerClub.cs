using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
   public  class CustomerClub
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


        
        public CustomerClubSendResponse Send(string tokenKey, CustomerClubSend model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/CustomerClub/Send";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                CustomerClubSendResponse res = rawResponse.Deserialize<CustomerClubSendResponse>();
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

        public CustomerClubSendResponse SendToCategories(string tokenKey, CustomerClubSendToCategories model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/CustomerClub/SendToCategories";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                CustomerClubSendResponse res = rawResponse.Deserialize<CustomerClubSendResponse>();
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

        public CustomerClubSendResponse AddContactAndSend(string tokenKey, CustomerClubInsertAndSendMessage[] model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/CustomerClub/AddContactAndSend";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = json }, parameters);
                 
                CustomerClubSendResponse res = rawResponse.Deserialize<CustomerClubSendResponse>();
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
