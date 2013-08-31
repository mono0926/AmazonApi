using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mono.Api.AmazonApi
{
    [DataContract]
    public enum CountryType
    {
        [EnumMember]
        US,
        [EnumMember]
        Japan,
        [EnumMember]
        Germany,
        [EnumMember]
        France,
        [EnumMember]
        Canada,
        [EnumMember]
        UK,
    }
}
