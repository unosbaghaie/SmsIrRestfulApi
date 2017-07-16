using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsIrRestful;
using System.Collections.Generic;

namespace SmsIrRestfulTest
{
    [TestClass]
    public class MessageSendTest
    {

        public string GetToken()
        {
            string userApikey = TokenInformation.UserApikey;
            string secretKey = TokenInformation.SecretKey;

            return new Token().GetToken(userApikey, secretKey);
        }


        [TestMethod]
        public void MessageSend()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            var messageSendObject = new MessageSendObject()
            {
                Messages = new List<string> { "تست" }.ToArray(),
                MobileNumbers = new List<string> { "09353429089" }.ToArray(),
                LineNumber = "30003472012345",
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };

            MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

            if (messageSendResponseObject == null)
                throw new Exception($@"{nameof(messageSendResponseObject) } is null");



            if (messageSendResponseObject.IsSuccessful)
            {


            }
            else
            {

            }

        }

        [TestMethod]
        public void GetSentMessageByDate()
        {

            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            SentMessageResponseByDate sentMessageResponseByDate = new MessageSend().GetByDate(token, "1396/04/01", "1396/04/31", 10, 1);
            if (sentMessageResponseByDate == null)
                throw new Exception($@"{nameof(sentMessageResponseByDate) } is null");

            if (sentMessageResponseByDate.IsSuccessful)
            {


            }
            else
            {

            }

        }

        [TestMethod]
        public void GetSentMessageById()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");
            

            SentMessageResponseById messageSendResponseById = new MessageSend().GetById(token, 5643981);

            if (messageSendResponseById.IsSuccessful)
            {


            }
            else
            {

            }
        }
    }
}
