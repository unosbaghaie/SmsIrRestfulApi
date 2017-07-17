using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsIrRestful;
using System.Collections.Generic;

namespace SmsIrRestfulTest
{
    [TestClass]
    public class SmsLineTest
    {

        public string GetToken()
        {
            string userApikey = TokenInformation.UserApikey;
            string secretKey = TokenInformation.SecretKey;


            return new Token().GetToken(userApikey, secretKey);
        }



        [TestMethod]
        public void GetSmsLine()
        {
            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($@"{nameof(token) } is null");


            SmsLineNumber credit = new SmsLine().GetSmsLines(token);

            if (credit == null)
                throw new Exception($@"{nameof(credit) } is null");

            if (credit.IsSuccessful)
            {


            }
            else
            {

            }
        }
    }
}
