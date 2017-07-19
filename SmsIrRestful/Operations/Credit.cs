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


        /// <summary>
        /// this method get user credit
        /// </summary>
        /// <param name="tokenKey"> <see cref="Token"/> </param>
        /// <returns>returns an object of <see cref="CreditResponse"/></returns>
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
