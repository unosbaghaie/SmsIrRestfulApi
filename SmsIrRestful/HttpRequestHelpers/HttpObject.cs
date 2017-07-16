using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class HttpObject 
    {
        public string Url { get; set; }
        public EnumHttpMethod Method { get; set; }
        public string Json { get; set; }

       
    }
}
