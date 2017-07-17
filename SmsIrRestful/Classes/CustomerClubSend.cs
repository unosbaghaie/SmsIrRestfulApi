using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
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
