using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public static class HttpRequestExtensions
    {

        public static string Execute(this IHttpRequest client,HttpObject httpObject, IDictionary<string, string> parameters)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return client.SendRequest(httpObject,  parameters);
        }

      

    }
}
