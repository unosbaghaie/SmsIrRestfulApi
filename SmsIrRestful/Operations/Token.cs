// This file is part of SmsIrRestful.
// Copyright © 2017 Younos Baghaee Moghaddam.
// 
// SmsIrRestful is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3
// of the License, or any later version.
// 
// SmsIrRestful is distributed in the hope that it will be useful
// for sms.ir customers, but WITHOUT ANY WARRANTY; without even the
// implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with SmsIrRestful. If not, see <http://www.gnu.org/licenses/>.

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
        /// <returns> token key as string </returns>
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
