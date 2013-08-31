using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mono.Api.AmazonApi.Model
{
    public class Item
    {
        public string ASIN { get; set; }
        public string DetailPageURL { get; set; }
        public IEnumerable<ItemLink> ItemLinks { get; set; }
        public string SmallImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string LargeImageURL { get; set; }
        public ItemAttributes Attributes { get; set; }
    }
}
