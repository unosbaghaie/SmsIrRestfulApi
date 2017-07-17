using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsIrRestful;
using System.Collections.Generic;

namespace SmsIrRestfulTest
{
    [TestClass]
    public class UltraFastTest
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

            var ultraFastSend = new UltraFastSend()
            {
                Mobile = 09120000001,
                TemplateId = 26,
                ParameterArray = new List<UltraFastParameters>()
                {
                    new UltraFastParameters()
                    {
                        Parameter = "VerificationCode" , ParameterValue = "123321"
                    }
                }.ToArray()

            };

            UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

            if (ultraFastSendRespone == null)
                throw new Exception($@"{nameof(ultraFastSendRespone) } is null");

            if (ultraFastSendRespone.IsSuccessful)
            {

            }
            else
            {

            }

        }


    }
}
