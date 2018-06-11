using System;
namespace SmsIrRestfulNetCore.ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            

            var token = new Token().GetToken("userApikey", "secretKey");

            var restVerificationCode = new RestVerificationCode()
            {
                Code = "1234567890",
                MobileNumber = "09120000001"
            };

            var restVerificationCodeRespone = new VerificationCode().Send(token, restVerificationCode);

            if (restVerificationCodeRespone.IsSuccessful)
            {

            }
            else
            {

            }











        }
    }
}
