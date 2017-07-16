using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
  
    public class CustomerClubContactObject
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string BirthDay { get; set; }
        public int? CategoryId { get; set; }

    }
    public class CustomerClubInsertAndSendMessage : CustomerClubContactObject
    {
        public string MessageText { get; set; }

    }


    public class CustomerClubContactResponse : BaseResponseApiModel
    {
    }
}
