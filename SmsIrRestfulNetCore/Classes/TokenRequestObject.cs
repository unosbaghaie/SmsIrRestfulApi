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
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestfulNetCore
{

    /*Type 'SmsIrRestful.TokenRequestObject' cannot be serialized. Consider marking it with the DataContractAttribute attribute,
     *  and marking all of its members you want serialized with the DataMemberAttribute attribute.  If the type is a collection,
     *   consider marking it with the CollectionDataContractAttribute.  See the Microsoft .NET Framework documentation for other supported types.*/
    public class TokenRequestObject
    {
        public string UserApiKey { get; set; }
        public string SecretKey { get; set; }
    }



}
