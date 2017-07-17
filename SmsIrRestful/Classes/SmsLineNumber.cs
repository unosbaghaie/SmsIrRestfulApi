using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class SmsLineNumber : BaseResponseApiModel
    {
        public SMSLines[] SMSLines { get; set; }
    }

    public class SMSLines
    {
        public int ID { get; set; }
        public long LineNumber { get; set; }
    }
}
