using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class CustomerClubContact
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



        public CustomerClubContactResponse Create(string tokenKey, CustomerClubContactObject model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/CustomerClubContact";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);


                HttpRequestFactory = () => new HttpPostRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                //HttpExecuter exec = new HttpPost();
                //var rawResponse = exec.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                CustomerClubContactResponse res = rawResponse.Deserialize<CustomerClubContactResponse>();
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


        public CustomerClubContactResponse Update(string tokenKey, CustomerClubContactObject model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/CustomerClubContact";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                HttpRequestFactory = () => new HttpPutRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = json }, parameters);

                CustomerClubContactResponse res = rawResponse.Deserialize<CustomerClubContactResponse>();
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
