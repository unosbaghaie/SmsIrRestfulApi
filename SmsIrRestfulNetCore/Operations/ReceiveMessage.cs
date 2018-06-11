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

namespace SmsIrRestfulNetCore
{
    public class ReceiveMessage
    {
        #region [Properties]
        private static Lazy<IHttpRequest> CachedClient = new Lazy<IHttpRequest>(() => new HttpGetRequest());

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
        /// returns rowsPerPage records of requestedPageNumber page of received messages, actually it is a pagination 
        /// on received messages by date and page by page 
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="shamsi_FromDate"> like "1396/04/01" </param>
        /// <param name="shamsi_ToDate">like "1396/04/31"</param>
        /// <param name="rowsPerPage">10</param>
        /// <param name="requestedPageNumber">1</param>
        /// <returns>returns an object of <see cref="ReceivedMessageResponseByDate"/></returns>
        public ReceivedMessageResponseByDate GetByDate(string tokenKey, string shamsi_FromDate, string shamsi_ToDate, int rowsPerPage, int requestedPageNumber)
        {
            try
            {
                string url = string.Format("http://restfulsms.com/api/ReceiveMessage?Shamsi_FromDate={0}&Shamsi_ToDate={1}&RowsPerPage={2}&RequestedPageNumber={3}",
                    shamsi_FromDate, shamsi_ToDate, rowsPerPage, requestedPageNumber);

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url }, parameters);

                
                ReceivedMessageResponseByDate res = rawResponse.Deserialize<ReceivedMessageResponseByDate>();

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

        /// <summary>
        /// returns received message by Id 
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="id"></param>
        /// <returns>returns an object of <see cref="ReceiveMessageResponseById"/></returns>
        public ReceiveMessageResponseById GetByLastMessageID(string tokenKey, int id)
        {
            try
            {
                string url = string.Format("http://restfulsms.com/api/ReceiveMessage?id={0}", id);

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);


                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url }, parameters);


                //HttpExecuter exec = new HttpGet();
                //var rawResponse = exec.Execute(new HttpObject() { Url = url }, parameters);

                ReceiveMessageResponseById res = rawResponse.Deserialize<ReceiveMessageResponseById>();
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
