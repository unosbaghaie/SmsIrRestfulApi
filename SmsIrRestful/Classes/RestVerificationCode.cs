using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class RestVerificationCode
    {
        public string Code { get; set; }
        public string MobileNumber { get; set; }
    }


    public class RestVerificationCodeRespone : BaseResponseApiModel
    {
        public long VerificationCodeId { get; set; }

    }
}
