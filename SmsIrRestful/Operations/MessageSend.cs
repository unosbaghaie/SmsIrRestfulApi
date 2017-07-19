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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{

    /// <summary>
    /// Provides static methods for send http request <i>post</i>, <i>get</i>
    /// <i>put</i> , <i>delete</i> , <i>patch</i> to sms.ir RESTful APIs
    /// </summary>
    /// <remarks>
    /// <para>This class is a wrapper for the <see cref="IHttpRequest"/> 
    /// interface and its default implementation, <see cref="HttpPostRequest"/>
    /// class, that was created for the most simple scenarios. Please consider 
    /// using the types above in real world applications.</para>
    /// </remarks>
    /// 
    /// <seealso cref="IHttpRequest"/>
    /// <seealso cref="HttpPostRequest"/>
    /// 
    /// <threadsafety static="true" instance="false" />
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

        /// <summary>
        /// send messages to one or many mobile numbers . mobile numbers and message count should be the same  
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="model">is is an object of <see cref="MessageSendObject "/></param>
        /// <returns>returns an object of <see cref="MessageSendResponseObject"/></returns>
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
        /// <summary>
        /// returns rowsPerPage records of requestedPageNumber page, actually it is a pagination 
        /// on sent messages by date and page by page 
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="shamsi_FromDate"> like "1396/04/01" </param>
        /// <param name="shamsi_ToDate">like "1396/04/31"</param>
        /// <param name="rowsPerPage">10</param>
        /// <param name="requestedPageNumber">1</param>
        /// <returns>returns an object of <see cref="SentMessageResponseByDate"/></returns>
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

        /// <summary>
        /// returns sent message by Id 
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="id"> message id </param>
        /// <returns>returns an object of <see cref="SentMessageResponseById"/></returns>
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
