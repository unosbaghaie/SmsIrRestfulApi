using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
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
