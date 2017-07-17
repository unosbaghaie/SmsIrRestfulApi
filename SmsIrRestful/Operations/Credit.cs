using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class Credit
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

        public CreditResponse GetCredit(string tokenKey)
        {
            try
            {
              
                string url = "http://ws.sms.ir/api/credit";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                HttpRequestFactory = () => new HttpGetRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url }, parameters);

                //HttpExecuter exec = new HttpGet();
                //var tokenResult = exec.Execute(new HttpObject() { Url = url }, parameters);

                CreditResponse res = rawResponse.Deserialize<CreditResponse>();
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
