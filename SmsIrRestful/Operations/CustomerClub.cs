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


        /// <summary>
        /// send message to cusomer clubs
        /// </summary>
        /// <param name="tokenKey"> <see cref="Token"/>  </param>
        /// <param name="model">it is an object of <see cref="CustomerClubSend"/></param>
        /// <returns>returns an object of <see cref="CustomerClubSendResponse"/></returns>
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

        /// <summary>
        /// send message to any cusomer club categories
        /// </summary>
        /// <param name="tokenKey"><see cref="Token"/> </param>
        /// <param name="model">it is an object of <see cref="CustomerClubSendToCategories "/></param>
        /// <returns>returns an object of <see cref="CustomerClubSendResponse"/></returns>
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

        /// <summary>
        /// insert a new contact and send a message
        /// </summary>
        /// <param name="tokenKey"><see cref="Token"/> </param>
        /// <param name="model">it is an array of <see cref="CustomerClubInsertAndSendMessage"/></param>
        /// <returns>returns an object of <see cref="CustomerClubSendResponse"/></returns>
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
