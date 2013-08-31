using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;
using Mono.Api.AmazonApi.Model;

namespace Mono.Api.AmazonApi
{
    public class AmazonClient
    {
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIL6VG4JT4IYYAJQA";
        private const string MY_AWS_SECRET_KEY = "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";
        //private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2009-03-31";
        public static readonly XNamespace ns;

        private SignedRequestHelper _helper;
        private CountryType _countryType;
        private string _associateTag;

        static AmazonClient()
        {
            ns = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";
        }

        public AmazonClient(CountryType countryType)
        {
            var destination = string.Empty;
            _countryType = countryType;
            switch (countryType)
            {
                case CountryType.Canada:
                    destination = "ecs.amazonaws.ca";
                    _associateTag = "monstecblo-20";
                    break;
                case CountryType.France:
                    destination = "ecs.amazonaws.fr";
                    _associateTag = "monstecblo02-21";
                    break;
                case CountryType.Germany:
                    destination = "ecs.amazonaws.de";
                    _associateTag = "monstecblo03-21";
                    break;
                case CountryType.Japan:
                    destination = "ecs.amazonaws.jp";
                    _associateTag = "mono0926-22";
                    break;
                case CountryType.US:
                    destination = "ecs.amazonaws.com";
                    _associateTag = "mono0926-20";
                    break;
                case CountryType.UK:
                    destination = "ecs.amazonaws.co.uk";
                    _associateTag = "monstecblo-21";
                    break;
            }
            _helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, destination);
        }

        public string ItemLookup(string itemId, ResponseGroupType responseType = ResponseGroupType.Medium)
        {
            var request = CreateCommonRequest(OperationType.ItemLookup);
            request["ItemId"] = itemId;
            request["ResponseGroup"] = Convert.ToString(responseType);
            request["AssociateTag"] = "_associateTag";
            //request["AnUrl"] = "http://www.amazon.com/books";
            //request["AUnicodeString"] = "αβγδεٵٶٷٸٹٺチャーハン叉焼";
            //request["Latin1Chars"] = "ĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳ";

            return GetResponse(request);
        }

        public string CartCreate()
        {
            var request = CreateCommonRequest(OperationType.CartCreate);
            request["Item.1.OfferListingId"] = "Ho46Hryi78b4j6Qa4HdSDD0Jhan4MILFeRSa9mK+6ZTpeCBiw0mqMjOG7ZsrzvjqUdVqvwVp237ZWaoLqzY11w==";
            request["Item.1.Quantity"] = "1";

            return GetResponse(request);
        }

        public string ItemSearch(SearchIndexType indexType, ResponseGroupType responseType = ResponseGroupType.Medium | ResponseGroupType.EditorialReview, string keyword = null, SortType sortType = SortType.salesrank, int itemPage = 1)
        {
            var request = CreateCommonRequest(OperationType.ItemSearch);
            request["SearchIndex"] = Convert.ToString(indexType);
            request["ResponseGroup"] = Convert.ToString(responseType);
            request["BrowseNode"] = indexType.ToBrowseNode(_countryType);
            request["Sort"] = Convert.ToString(sortType);
            request["ItemPage"] = itemPage.ToString();
            //request["MerchantId"] = "All";
            if (keyword != null)
            {
                request["Keywords"] = keyword;
            }

            return GetResponse(request);
        }



        private string GetResponse(IDictionary<string, string> request)
        {
            var requestUrl = _helper.Sign(request);
            using (var client = new WebClient { Encoding = Encoding.UTF8 })
            {
                return client.DownloadString(requestUrl);
            }
        }

        private IDictionary<string, string> CreateCommonRequest(OperationType operationType)
        {
            var operation = Convert.ToString(operationType);
            return new Dictionary<string, String>()
                {
                    { "Service", "AWSECommerceService"},
                    { "Version", "2009-03-31"},
                    { "Operation", operation},
                    { "AssociateTag", _associateTag},
                };
        }

        public Ranking GetRanking(SearchIndexType indexType)
        {
            var response = ItemSearch(indexType);
            var doc = XDocument.Parse(response);
            var items = doc.Descendants(ns + "Item")
                //.Select(x => x.Element(ns + "ItemAttributes"))
                .Select(x => new Item
                {
                    ASIN = x.GetValue("ASIN"),
                    DetailPageURL = x.GetValue("DetailPageURL"),
                    ItemLinks = x.Descendants(ns + "ItemLink")
                                    .Select(y => new ItemLink { URL = y.GetValue("URL"), Description = y.GetValue("Description") }),
                    SmallImageURL = x.GetAttributesValue("SmallImage", "URL"),
                    MediumImageURL = x.GetAttributesValue("MediumImage", "URL"),
                    LargeImageURL = x.GetAttributesValue("LargeImage", "URL"),
                    Attributes = new ItemAttributes
                    {
                        Author = x.GetAttributesValue("ItemAttributes", "Author"),
                        Format = x.GetAttributesValue("ItemAttributes", "Format"),
                        Binding = x.GetAttributesValue("ItemAttributes", "Binding"),
                        IsAdultProduct = x.GetAttributesValue<bool>("ItemAttributes", "IsAdultProduct"),
                        ISBN = x.GetAttributesValue("ItemAttributes", "ISBN"),
                        Label = x.GetAttributesValue("ItemAttributes", "Label"),
                        Amount = x.GetListPrice<int>("Amount"),
                        FormattedPrice = x.GetListPrice<string>("FormattedPrice"),
                        Manufacturer = x.GetAttributesValue("ItemAttributes", "Manufacturer"),
                        NumberOfPages = x.GetAttributesValue<int>("ItemAttributes", "NumberOfPages"),
                        PublicationDate = x.GetAttributesValue<DateTime>("ItemAttributes", "PublicationDate"),
                        ReleaseDate = x.GetAttributesValue<DateTime>("ItemAttributes", "ReleaseDate"),
                        Publisher = x.GetAttributesValue("ItemAttributes", "Publisher"),
                        Title = x.GetAttributesValue("ItemAttributes", "Title"),
                    }
                });//.ToArray();
            return new Ranking { IndexType = SearchIndexType.Books, Items = items };
        }

        public void GetItemDetail(string itemId)
        {
            var response = ItemLookup(itemId);
            var doc = XDocument.Parse(response);
            XNamespace ns = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";
        }
    }

    static class Extensions
    {
        public static T GetAttributesValue<T>(this XElement element, string parentElem, string name)
        {
            var r = GetValue<T>(element.Element(AmazonClient.ns + parentElem).Element(AmazonClient.ns + name));
            return r;
        }
        public static T GetListPrice<T>(this XElement element, string name)
        {
            var attr = element.Element(AmazonClient.ns + "ItemAttributes").Element(AmazonClient.ns + "ListPrice");
            if (attr == null)
            {
                return default(T);
            }
            var r = GetValue<T>(attr.Element(AmazonClient.ns + name));
            return r;
        }
        public static string GetAttributesValue(this XElement element, string parentElem, string name)
        {
            return element.GetAttributesValue<string>(parentElem, name);
        }

        public static T GetValue<T>(this XElement element)
        {
            if (typeof(T) ==  typeof(bool) && element != null && (element.Value == "0" || element.Value == "1"))
            {
                element.Value = element.Value == "0" ? "false" : "true";
            }
            return element == null ? default(T) : (T)Convert.ChangeType(element.Value, typeof(T));
        }
        public static string GetValue(this XElement element, string elementName)
        {
            return element.GetValue<string>(elementName);   
        }

        public static T GetValue<T>(this XElement element, string elementName)
        {
            if (element == null)
            {
                return default(T);
            }
            var e = element.Element(AmazonClient.ns + elementName);
            return e == null ? default(T) : (T)Convert.ChangeType(e.Value, typeof(T));
        }

        private static string GetValue(this XElement element)
        {
            return GetValue<string>(element);
        }
    }
}
