using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mono.Api.AmazonApi
{
    class ParamComparer : IComparer<string>
    {
        public int Compare(string p1, string p2)
        {
            return string.CompareOrdinal(p1, p2);
        }
    }
}
