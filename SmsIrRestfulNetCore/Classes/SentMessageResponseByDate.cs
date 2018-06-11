// This file is part of SmsIrRestful.
// Copyright © 2017 Younos Baghaee Moghaddam.
// 
// SmsIrRestful is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3
// of the License, or any later version.
// 
// SmsIrRestful is distributed in the hope that it will be useful
// for sms.ir customers, but WITHOUT ANY WARRANTY; without even the
// implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with SmsIrRestful. If not, see <http://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestfulNetCore
{
    public class SentMessageResponseByDate : BaseResponseApiModel
    {
        public int CountOfAll { get; set; }
        public SentMessage[] Messages { get; set; }

    }

    public class SentMessage
    {
        public long ID { get; set; }
        public string LineNumber { get; set; }
        public string SMSMessageBody { get; set; }
        public string MobileNo { get; set; }
        // public string SendDateTime_Persian { get; set; }

        public string SendDateTime { get; set; }
        //{
        //    get {

        //        try
        //        {
        //            return this.SendDateTimeLatin.Value.GetPersianDateWithTime();
        //        }
        //        catch 
        //        {
        //            return null;
        //        }

        //    }
        //}

        public string ToBeSentAt { get; set; }
        public string NativeDeliveryStatus { get; set; }
        public string TypeOfMessage { get; set; }

        public string PersianSendDateTime { get; set; }
    }









































}
