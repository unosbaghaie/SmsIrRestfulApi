using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsIrRestful;
using System.Collections.Generic;

namespace SmsIrRestfulTest
{
    [TestClass]
    public class CustomerClubTest
    {
        public string GetToken()
        {
            string userApikey = TokenInformation.UserApikey;
            string secretKey = TokenInformation.SecretKey;

            return new Token().GetToken(userApikey, secretKey);
        }


        [TestMethod]
        public void Send()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            var customerClubSend = new CustomerClubSend()
            {
                Messages = new List<string>() { "تست باشگاه" }.ToArray(),
                MobileNumbers = new List<string>() { "09120000001" }.ToArray(),
                SendDateTime = null,
                CanContinueInCaseOfError = false
            };

            CustomerClubSendResponse customerClubContactResponse = new CustomerClub().Send(token, customerClubSend);

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
        public void SendToCategories()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            var customerClubSendToCategories = new CustomerClubSendToCategories()
            {
                Messages = "ارسال به گروه باشگاه",
                contactsCustomerClubCategoryIds = new List<int>() { 44}.ToArray(),
                SendDateTime = null,
                CanContinueInCaseOfError = false


            };

            CustomerClubSendResponse customerClubContactResponse = new CustomerClub().SendToCategories(token, customerClubSendToCategories);

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
        public void AddContactAndSend()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");


            List<CustomerClubInsertAndSendMessage> customerClubInsertAndSendMessageList = new List<CustomerClubInsertAndSendMessage>();


            customerClubInsertAndSendMessageList.Add(
            new CustomerClubInsertAndSendMessage()
            {
                Prefix = "آقای",
                FirstName = "یونس ",
                LastName = "بقائی مقدم",
                Mobile = "09120000001",
                BirthDay = null,
                CategoryId = 44,
                MessageText = " ثبت مشتری و ارسال"
            });

            CustomerClubSendResponse customerClubContactResponse = new CustomerClub().AddContactAndSend(token, customerClubInsertAndSendMessageList.ToArray());

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
