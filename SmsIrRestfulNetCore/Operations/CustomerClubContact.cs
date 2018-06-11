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


        /// <summary>
        /// create a new contact in customer club
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="model">is is an object of <see cref="CustomerClubContactObject "/></param>
        /// <returns>returns an object of <see cref="CustomerClubContactResponse"/></returns>
        public CustomerClubContactResponse Create(string tokenKey, CustomerClubContactObject model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://restfulsms.com/api/CustomerClubContact";

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


        /// <summary>
        /// it updates a contact in customer club using its mobile number
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="model">is is an object of <see cref="CustomerClubContactObject "/></param>
        /// <returns>returns an object of <see cref="CustomerClubContactResponse"/></returns>
        public CustomerClubContactResponse Update(string tokenKey, CustomerClubContactObject model)
        {
            try
            {
                var json = model.Serialize();
                string url = "http://restfulsms.com/api/CustomerClubContact";

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


        /// <summary>
        /// Get customer club contact Categories
        /// </summary>
        /// /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <returns>returns an object of <see cref="CustomerClubContactCategoryResponse"/></returns>
        public CustomerClubContactCategoryResponse GetCategories(string tokenKey)
        {
            try
            {
                string url = "http://restfulsms.com/api/CustomerClubContact/GetCategories";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                HttpRequestFactory = () => new HttpGetRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = null}, parameters);

                CustomerClubContactCategoryResponse res = rawResponse.Deserialize<CustomerClubContactCategoryResponse>();
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
        /// GetContacts By CategoryId and pagination
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="categoryId"> category Id which is got from GetCategories  </param>
        /// <param name="pageNumber"> start from 1 . all your contacts count / 10 equals all page numbers </param>
        /// <returns>returns an object of <see cref="CustomerClubContactsResponse"/></returns>
        public CustomerClubContactsResponse GetContactsByCategoryId(string tokenKey, int categoryId , int pageNumber)
        {
            try
            {
                //var json = model.Serialize();
                string url = $@"http://restfulsms.com/api/CustomerClubContact/GetContactsByCategoryById?categoryId={categoryId}&pageNumber={pageNumber}";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                HttpRequestFactory = () => new HttpGetRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = null }, parameters);

                CustomerClubContactsResponse res = rawResponse.Deserialize<CustomerClubContactsResponse>();
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
        /// Get Contacts by pagination
        /// </summary>
        /// <param name="tokenKey"> see GetToken method in  <see cref="Token"/> class </param>
        /// <param name="pageNumber"> start from 1 . all your contacts count / 10 equals all page numbers </param>
        /// <returns>returns an object of <see cref="CustomerClubContactsResponse"/></returns>
        public CustomerClubContactsResponse GetContacts(string tokenKey, int pageNumber)
        {
            try
            {
                string url = $@"http://restfulsms.com/api/CustomerClubContact/GetContacts?pageNumber={pageNumber}";

                var parameters = new Dictionary<string, string>();
                parameters.Add("x-sms-ir-secure-token", tokenKey);

                HttpRequestFactory = () => new HttpGetRequest();
                var httpRequest = HttpRequestFactory();
                var rawResponse = httpRequest.Execute(new HttpObject() { Url = url, Json = null }, parameters);

                CustomerClubContactsResponse res = rawResponse.Deserialize<CustomerClubContactsResponse>();
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
