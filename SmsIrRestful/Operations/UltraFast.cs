using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class UltraFast
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


        public UltraFastSendRespone Send(string tokenKey, UltraFastSend model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://ws.sms.ir/api/UltraFastSend";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);


                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url , Json = json}, parameters);


                //HttpExecuter exec = new HttpGet();
                //var rawResponse = exec.Execute(new HttpObject() { Url = url }, parameters);

                UltraFastSendRespone res = rawResponse.Deserialize<UltraFastSendRespone>();
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
