using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class Token
    {
        public string GetToken(string userApiKey, string secretKey)
        {
            try
            {
                TokenRequestObject req = new TokenRequestObject();
                req.UserApiKey = userApiKey;
                req.SecretKey = secretKey;
                var json = req.Serialize();

                string url = "http://ws.sms.ir/api/Token";
                var method = "POST";
                var tokenResult = new HttpHelper().Execute(url, method, json);
                TokenResultObject res = tokenResult.Deserialize<TokenResultObject>();
                if (res != null && res.IsSuccessful == true)
                {
                    return res.TokenKey;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
