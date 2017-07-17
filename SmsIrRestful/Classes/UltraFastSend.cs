using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public class UltraFastSend
    {
        public UltraFastParameters[] ParameterArray { get; set; }
        public long Mobile { get; set; }
        public int TemplateId { get; set; }
    }
    public class UltraFastParameters
    {
        public string Parameter { get; set; }
        public string ParameterValue { get; set; }
    }
    public class UltraFastSendRespone : BaseResponseApiModel
    {
        public long VerificationCodeId { get; set; }
    }
}
