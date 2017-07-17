using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsIrRestful;

namespace SmsIrRestfulTest
{
    [TestClass]
    public class CustomerClubContactTest
    {
        public string GetToken()
        {
            string userApikey = TokenInformation.UserApikey;
            string secretKey = TokenInformation.SecretKey;

            return new Token().GetToken(userApikey, secretKey);
        }


        [TestMethod]
        public void Create()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            var customerClubContactObject = new CustomerClubContactObject()
            {
                Prefix = "آقای",
                FirstName = "یونس ",
                LastName = "بقائی مقدم",
                Mobile = "09120000001",
                BirthDay = null,
                CategoryId = 44
            };

            CustomerClubContactResponse customerClubContactResponse = new CustomerClubContact().Create(token, customerClubContactObject);

            if (customerClubContactResponse == null)
                throw new Exception($@"{nameof(customerClubContactResponse) } is null");

            if (customerClubContactResponse.IsSuccessful)
            {

            }
            else
            {

            }

        }


        [TestMethod]
        public void Update()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            var customerClubContactObject = new CustomerClubContactObject()
            {
                Prefix = "آقای",
                FirstName = "یونس ",
                LastName = "بقائی مقدم",
                Mobile = "09120000001",
                BirthDay = null,
                CategoryId = 44
            };


            var customerClubContactResponse = new CustomerClubContact().Update(token, customerClubContactObject);

            if (customerClubContactResponse == null)
                throw new Exception($@"{nameof(customerClubContactResponse) } is null");

            if (customerClubContactResponse.IsSuccessful)
            {

            }
            else
            {

            }

        }

    }
}
