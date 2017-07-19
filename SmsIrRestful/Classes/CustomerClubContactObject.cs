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
