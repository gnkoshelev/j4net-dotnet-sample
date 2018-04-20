using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HashHttpJsonClient
{
    [DataContract]
    public class HashRequest
    {
        [DataMember]
        private byte[] bytes;

        public HashRequest(byte[] bytes)
        {
            this.bytes = bytes;
        }
    }
}
