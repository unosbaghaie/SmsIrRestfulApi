using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    internal class HttpGet : HttpExecuter
    {
        public override string Execute(HttpObject http)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(http.Url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = EnumHttpMethod.Get.ToString();

            string result = null;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(http.Json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                using (var streamReader = new StreamReader(wex.Response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            return result;
        }


    }
}
