using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class BaseResponseApiModel
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
