using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    internal class TokenResultObject
    {
        public string TokenKey { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
