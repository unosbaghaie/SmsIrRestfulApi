using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsIrRestful;
using System.Collections.Generic;

namespace SmsIrRestfulTest
{
    [TestClass]
    public class ReceivedMessageTest
    {

        public string GetToken()
        {
            string userApikey = TokenInformation.UserApikey;
            string secretKey = TokenInformation.SecretKey;

            return new Token().GetToken(userApikey, secretKey);
        }


        
        [TestMethod]
        public void GetSentMessageByDate()
        {

            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");

            ReceivedMessageResponseByDate receivedMessageResponseByDate = new ReceiveMessage().GetByDate(token, "1396/04/01", "1396/04/31", 10, 1);
            if (receivedMessageResponseByDate == null)
                throw new Exception($@"{nameof(receivedMessageResponseByDate) } is null");

            if (receivedMessageResponseByDate.IsSuccessful)
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

            ReceiveMessageResponseById messageSendResponseById = new ReceiveMessage().GetById(token, 5643981);

            if (messageSendResponseById.IsSuccessful)
            {

            }
            else
            {

            }
        }
    }
}
