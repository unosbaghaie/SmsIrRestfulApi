using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class HttpPutRequest : IHttpRequest
    {
        public string SendRequest(HttpObject httpObject, IDictionary<string, string> parameters)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(httpObject.Url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = EnumHttpMethod.Put.ToString();

            if (parameters != null)
                foreach (var p in parameters)
                {
                    httpWebRequest.Headers.Add(p.Key, p.Value);
                }


            string result = null;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(httpObject.Json);
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
