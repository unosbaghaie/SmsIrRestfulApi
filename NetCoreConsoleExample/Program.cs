using SmsIrRestfulNetCore;
using System;

namespace NetCoreConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");




            var token = new Token().GetToken("apiKey", "secretKey");

            var restVerificationCode = new RestVerificationCode()
            {
                Code = "1234567890",
                MobileNumber = "09120000001"
            };

            var restVerificationCodeRespone = new VerificationCode().Send(token, restVerificationCode);

            Console.WriteLine(restVerificationCodeRespone.Message);


            if (restVerificationCodeRespone.IsSuccessful)
            {

            }
            else
            {

            }
            Console.ReadLine();

        }
    }
}
