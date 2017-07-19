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
    internal static class HttpRequestExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client">it can be any type that implements <see cref="IHttpRequest"/> </param>
        /// <param name="httpObject"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Execute(this IHttpRequest client,HttpObject httpObject, IDictionary<string, string> parameters)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return client.SendRequest(httpObject,  parameters);
        }

      

    }
}
