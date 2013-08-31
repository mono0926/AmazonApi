using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mono.Api.AmazonApi.Model
{
    public class ItemAttributes
    {

        
        public string Author { get; set; }
        
        public string Format { get; set; }
        
        public string Binding { get; set; }
        
        public bool IsAdultProduct { get; set; }
        
        public string ISBN { get; set; }
        
        public string Label { get; set; }
        
        public int Amount { get; set; }
        
        public string FormattedPrice { get; set; }
        
        public string Manufacturer { get; set; }
        
        public int NumberOfPages { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public string Publisher { get; set; }
        
        public string Title { get; set; }
    }
}
