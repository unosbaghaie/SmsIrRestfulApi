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
    public class CustomerClubSend
    {
        public string[] Messages { get; set; }
        public string[] MobileNumbers { get; set; }
        public DateTime? SendDateTime { get; set; }
        public bool? CanContinueInCaseOfError { get; set; }

    }
    public class CustomerClubSendToCategories
    {
        public string Messages { get; set; }
        public int[] contactsCustomerClubCategoryIds { get; set; }
        public DateTime? SendDateTime { get; set; }
        public bool? CanContinueInCaseOfError { get; set; }

    }
    public class CustomerClubSendResponse : BaseResponseApiModel
    {
        public string BatchKey { get; set; }
        public SentSMSLog2[] Ids { get; set; }

    }
    public class CustomerClubLogginResponse : BaseResponseApiModel
    {
        public int Id
        {
            get;
            set;
        }
        public string ContactCount
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
        public string AccountCharge
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }
        public string Result
        {
            get;
            set;
        }

    }
}
