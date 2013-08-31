using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mono.Api.AmazonApi
{
    [Flags]
    public enum ResponseGroupType : long
    {
        None = 0x0,
        Accessories = 0x1,
        AlternateVersions = 0x2,
        BrowseNodes = 0x4,
        Collections = 0x8,
        EditorialReview = 0x10,
        Images = 0x20,
        ItemAttributes = 0x40,
        ItemIds = 0x80,
        Large = 0x100,
        ListmaniaLists = 0x200,
        Medium = 0x400,
        MerchantItemAttributes = 0x800,
        OfferFull = 0x1000,
        OfferListings = 0x2000,
        OfferSummary = 0x4000,
        Offers = 0x8000,
        PromotionDetails = 0x10000,
        PromotionSummary = 0x20000,
        PromotionalTag = 0x40000,
        RelatedItems = 0x80000,
        Request = 0x100000,
        Reviews = 0x200000,
        SalesRank = 0x400000,
        SearchBins = 0x800000,
        SearchInside = 0x1000000,
        ShippingCharges = 0x2000000,
        Similarities = 0x4000000,
        Small = 0x8000000,
        Subjects = 0x10000000,
        Tags = 0x20000000,
        TagsSummary = 0x40000000,
        Tracks = 0x80000000,
        VariationImages = 0x100000000,
        VariationMatrix = 0x200000000,
        VariationMinimum = 0x400000000,
        VariationOffers = 0x800000000,
        VariationSummary = 0x1000000000,
        Variations = 0x2000000000,
    }
}
