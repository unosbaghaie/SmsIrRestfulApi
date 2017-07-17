using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class Token
    {
        #region [Properties]
        private static readonly Lazy<IHttpRequest> CachedClient
           = new Lazy<IHttpRequest>(() => new HttpPostRequest());

        private static readonly Func<IHttpRequest> DefaultFactory
            = () => CachedClient.Value;

        private static Func<IHttpRequest> _httpClientFactory;
        private static readonly object HttpRequestFactoryLock = new object();

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



        /// <summary>
        /// returns token key which is needed for any request to other methods in RESTful APIs
        /// </summary>
        /// <param name="userApiKey"> the userApiKey which will be generated from UI by user in UserApiKey page</param>
        /// <param name="secretKey"> the secretKey which will be provided by user when generating user API key </param>
        /// <returns></returns>
        public string GetToken(string userApiKey, string secretKey)
        {
            try
            {

                TokenRequestObject req = new TokenRequestObject();
                req.UserApiKey = userApiKey;
                req.SecretKey = secretKey;

                var json = req.Serialize();
                string url = "http://ws.sms.ir/api/Token";

                var httpRequest = HttpRequestFactory();
                var tokenResult =  httpRequest.Execute(new HttpObject() { Url = url, Json = json } , null);


              //  HttpExecuter exec = new HttpPost();
              //  var tokenResult = exec.Execute(new HttpObject() { Url = url, Json = json } , null);

                TokenResultObject res = tokenResult.Deserialize<TokenResultObject>();
                if (res != null && res.IsSuccessful == true)
                {
                    return res.TokenKey;
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
