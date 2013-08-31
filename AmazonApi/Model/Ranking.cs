using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mono.Api.AmazonApi;

namespace Mono.Api.AmazonApi.Model
{
    public class Ranking
    {
        
        public IEnumerable<Item> Items { get; set; }
        
        public SearchIndexType IndexType { get; set; }

    }
}
