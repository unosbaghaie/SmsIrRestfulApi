using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public interface IHttpRequest
    {
        string SendRequest(HttpObject httpObject, IDictionary<string, string> parameters);

    }
}
