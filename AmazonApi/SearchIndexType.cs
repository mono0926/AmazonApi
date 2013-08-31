using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mono.Api.AmazonApi
{
    [DataContract]
    public enum SearchIndexType
    {
        [EnumMember]
        All,
        [EnumMember]
        Apparel,
        [EnumMember]
        Appliances,
        [EnumMember]
        ArtsAndCrafts,
        [EnumMember]
        Automotive,
        [EnumMember]
        Baby,
        [EnumMember]
        Beauty,
        [EnumMember]
        Blended,
        [EnumMember]
        Books,
        [EnumMember]
        Classical,
        [EnumMember]
        Collectibles,
        [EnumMember]
        DigitalMusic,
        [EnumMember]
        DVD,
        [EnumMember]
        Electronics,
        [EnumMember]
        ForeignBooks,
        [EnumMember]
        GourmetFood,
        [EnumMember]
        Grocery,
        [EnumMember]
        HealthPersonalCare,
        [EnumMember]
        Hobbies,
        [EnumMember]
        HomeGarden,
        [EnumMember]
        HomeImprovement,
        [EnumMember]
        Industrial,
        [EnumMember]
        Jewelry,
        [EnumMember]
        KindleStore,
        [EnumMember]
        Kitchen,
        [EnumMember]
        LawnGardern,
        [EnumMember]
        Lighting,
        [EnumMember]
        Magazines,
        [EnumMember]
        Merchants,
        [EnumMember]
        Miscellaneous,
        [EnumMember]
        MobileApps,
        [EnumMember]
        MP3Downloads,
        [EnumMember]
        Music,
        [EnumMember]
        MusicalInstruments,
        [EnumMember]
        MusicTracks,
        [EnumMember]
        OfficeProducts,
        [EnumMember]
        OutdoorLiving,
        [EnumMember]
        Outlet,
        [EnumMember]
        PCHardware,
        [EnumMember]
        PetSupplies,
        [EnumMember]
        Photo,
        [EnumMember]
        Shoes,
        [EnumMember]
        SilverMerchant,
        [EnumMember]
        Software,
        [EnumMember]
        SoftwareVideoGames,
        [EnumMember]
        SportingGoods,
        [EnumMember]
        Tools,
        [EnumMember]
        Toys,
        [EnumMember]
        UnboxVideo,
        [EnumMember]
        VHS,
        [EnumMember]
        Video,
        [EnumMember]
        VideoGames,
        [EnumMember]
        Watches,
        [EnumMember]
        Wireless,
        [EnumMember]
        WirelessAccessories,
    }

    public static class SearchIndexTypeExtensions
    {
        public static string ToBrowseNode(this SearchIndexType indexType, CountryType countryType)
        {
            switch (countryType)
            {
                case CountryType.Japan:
                    return ToBrowseNodeJapan(indexType);
                case CountryType.US:
                    return ToBrowseNodeUS(indexType);
                case CountryType.UK:
                    return ToBrowseNodeUK(indexType);
                case CountryType.France:
                    return ToBrowseNodeFrance(indexType);
                case CountryType.Germany:
                    return ToBrowseNodeGermany(indexType);
                case CountryType.Canada:
                    return ToBrowseNodeCanada(indexType);
                default:
                    return null;
            }
        }

        public static string ToBrowseNodeJapan(SearchIndexType indexType)
        {
            switch (indexType)
            {
                case SearchIndexType.Apparel:
                    return "361299011";
                case SearchIndexType.Appliances:
                    return "2277724051";
                case SearchIndexType.Automotive:
                    return "2017305051";
                case SearchIndexType.Baby:
                    return "344845011";//"13331821";
                case SearchIndexType.Beauty:
                    return "52391051";
                case SearchIndexType.Books:
                    return "465610";
                case SearchIndexType.Classical:
                    return "562032";
                case SearchIndexType.DVD:
                    return "562002";
                case SearchIndexType.Electronics:
                    return "3210991";
                case SearchIndexType.ForeignBooks:
                    return "52231011";
                case SearchIndexType.Grocery:
                    return "57239051";
                case SearchIndexType.HealthPersonalCare:
                    return "161669011";
                case SearchIndexType.Hobbies:
                    return "2189355051";//"13331821";
                case SearchIndexType.Jewelry:
                    return "85896051";
                case SearchIndexType.KindleStore:
                    return "2250738051";
                case SearchIndexType.Kitchen:
                    return "3839151";
                case SearchIndexType.MP3Downloads:
                    return "2128134051";
                case SearchIndexType.Music:
                    return "562032";
                case SearchIndexType.MusicalInstruments:
                    return "2123629051";
                case SearchIndexType.Shoes:
                    return "2016926051";
                case SearchIndexType.Software:
                    return "637630";
                case SearchIndexType.SportingGoods:
                    return "14304371";
                case SearchIndexType.Toys:
                    return "13299531";//"13331821";
                case SearchIndexType.VHS:
                    return "2130989051";
                //case SearchIndexType.Video:
                //    return "561972";
                case SearchIndexType.VideoGames:
                    return "637872";
                case SearchIndexType.Watches:
                    return "331952011";//"324025011";
                default:
                    return null;
            }
        }
        private static string ToBrowseNodeUS(SearchIndexType indexType)
        {
            switch (indexType)
            {
                case SearchIndexType.Apparel:
                    return "1036592";
                case SearchIndexType.Appliances:
                    return "2619525011";
                case SearchIndexType.ArtsAndCrafts:
                    return "2617941011";
                case SearchIndexType.Automotive:
                    return "15690151";
                case SearchIndexType.Baby:
                    return "165796011";
                case SearchIndexType.Beauty:
                    return "11055981";
                case SearchIndexType.Books:
                    return "1000";
                case SearchIndexType.Classical:
                    return "301668";
                case SearchIndexType.Collectibles:
                    return "4991425011";
                case SearchIndexType.DigitalMusic:
                    return "195208011";
                case SearchIndexType.DVD:
                    return "2625373011";
                case SearchIndexType.Electronics:
                    return "493964";
                case SearchIndexType.GourmetFood:
                    return "3580501";
                case SearchIndexType.Grocery:
                    return "16310101";
                case SearchIndexType.HealthPersonalCare:
                    return "3760931";
                case SearchIndexType.HomeGarden:
                    return "285080";
                case SearchIndexType.Industrial:
                    return "228239";
                case SearchIndexType.Jewelry:
                    return "3880591";
                case SearchIndexType.KindleStore:
                    return "133141011";
                case SearchIndexType.Kitchen:
                    return "1063498";
                case SearchIndexType.Magazines:
                    return "599872";
                case SearchIndexType.Miscellaneous:
                    return "10304191";
                case SearchIndexType.MobileApps:
                    return "2350149011";
                case SearchIndexType.MP3Downloads:
                    return "195211011";
                case SearchIndexType.Music:
                    return "301668";
                case SearchIndexType.MusicalInstruments:
                    return "11091801";
                case SearchIndexType.OfficeProducts:
                    return "1084128";
                case SearchIndexType.OutdoorLiving:
                    return "1063498";
                case SearchIndexType.PCHardware:
                    return "493964";
                case SearchIndexType.PetSupplies:
                    return "1063498";
                case SearchIndexType.Photo:
                    return "493964";
                case SearchIndexType.Software:
                    return "409488";
                case SearchIndexType.SportingGoods:
                    return "3375251";
                case SearchIndexType.Tools:
                    return "468240";
                case SearchIndexType.Toys:
                    return "493964";
                case SearchIndexType.VHS:
                    return "404272";
                case SearchIndexType.Video:
                    return "130";
                case SearchIndexType.VideoGames:
                    return "493964";
                case SearchIndexType.Watches:
                    return "377110011";
                case SearchIndexType.Wireless:
                    return "508494";
                case SearchIndexType.WirelessAccessories:
                    return "13900851";
                default:
                    return null;
            }
        }

        private static string ToBrowseNodeUK(SearchIndexType indexType)
        {
            switch (indexType)
            {
                case SearchIndexType.Apparel:
                    return "83451031";
                case SearchIndexType.Automotive:
                    return "248877031";
                case SearchIndexType.Baby:
                    return "60032031";
                case SearchIndexType.Beauty:
                    return "66280031";
                case SearchIndexType.Books:
                    return "1025612";
                case SearchIndexType.Classical:
                    return "505510";
                case SearchIndexType.DVD:
                    return "283926";
                case SearchIndexType.Electronics:
                    return "560800";
                case SearchIndexType.Grocery:
                    return "340834031";
                case SearchIndexType.HealthPersonalCare:
                    return "66280031";
                case SearchIndexType.HomeGarden:
                    return "11052591";
                case SearchIndexType.HomeImprovement:
                    return "2016929051";
                case SearchIndexType.Jewelry:
                    return "193717031";
                case SearchIndexType.KindleStore:
                    return "341677031";
                case SearchIndexType.Kitchen:
                    return "11052591";
                case SearchIndexType.Lighting:
                    return "213077031";
                case SearchIndexType.MP3Downloads:
                    return "77198031";
                case SearchIndexType.Music:
                    return "505510";
                case SearchIndexType.MusicalInstruments:
                    return "340837031";
                case SearchIndexType.OfficeProducts:
                    return "560800";
                case SearchIndexType.OutdoorLiving:
                    return "11052591";
                case SearchIndexType.Software:
                    return "1025614";
                case SearchIndexType.SoftwareVideoGames:
                    return "1025616";
                case SearchIndexType.SportingGoods:
                    return "319530011";
                case SearchIndexType.Tools:
                    return "11052591";
                case SearchIndexType.Toys:
                    return "712832";
                case SearchIndexType.VHS:
                    return "283926";
                case SearchIndexType.Video:
                    return "283926";
                case SearchIndexType.VideoGames:
                    return "1025616";
                case SearchIndexType.Watches:
                    return "595312";
                default:
                    return null;
            }
        }


        private static string ToBrowseNodeFrance(SearchIndexType indexType)
        {
            switch (indexType)
            {
                case SearchIndexType.Apparel:
                    return "340855031"; ;
                case SearchIndexType.Automotive:
                    return "1571265031";
                case SearchIndexType.Baby:
                    return "206617031";
                case SearchIndexType.Beauty:
                    return "197858031";
                case SearchIndexType.Books:
                    return "468256";
                case SearchIndexType.Classical:
                    return "537366";
                case SearchIndexType.DVD:
                    return "578608";
                case SearchIndexType.Electronics:
                    return "1058082";
                case SearchIndexType.ForeignBooks:
                    return "69633011";
                case SearchIndexType.HealthPersonalCare:
                    return "197861031";
                case SearchIndexType.HomeImprovement:
                    return "590748031";
                case SearchIndexType.Jewelry:
                    return "193711031";
                case SearchIndexType.KindleStore:
                    return "818936031";
                case SearchIndexType.Kitchen:
                    return "57686031";
                case SearchIndexType.Lighting:
                    return "213080031";
                case SearchIndexType.MP3Downloads:
                    return "206442031";
                case SearchIndexType.Music:
                    return "537366";
                case SearchIndexType.MusicalInstruments:
                    return "340862031";
                case SearchIndexType.OfficeProducts:
                    return "192420031";
                case SearchIndexType.PetSupplies:
                    return "1571268031";
                case SearchIndexType.Shoes:
                    return "215934031";
                case SearchIndexType.Software:
                    return "548012";
                case SearchIndexType.SoftwareVideoGames:
                    return "548014";
                case SearchIndexType.Toys:
                    return "548014";
                case SearchIndexType.VHS:
                    return "578610";
                case SearchIndexType.Video:
                    return "578608";
                case SearchIndexType.VideoGames:
                    return "548014";
                case SearchIndexType.Watches:
                    return "60937031";
                default:
                    return null;
            }
        }

        private static string ToBrowseNodeGermany(SearchIndexType indexType)
        {
            switch (indexType)
            {
                case SearchIndexType.Apparel:
                    return "78689031";
                case SearchIndexType.Automotive:
                    return "78191031";
                case SearchIndexType.Baby:
                    return "357577011";
                case SearchIndexType.Beauty:
                    return "64257031";
                case SearchIndexType.Books:
                    return "541686";
                case SearchIndexType.Classical:
                    return "542676";
                case SearchIndexType.DVD:
                    return "547664";
                case SearchIndexType.Electronics:
                    return "569604";
                case SearchIndexType.ForeignBooks:
                    return "54071011";
                case SearchIndexType.Grocery:
                    return "340846031";
                case SearchIndexType.HealthPersonalCare:
                    return "64257031";
                case SearchIndexType.HomeGarden:
                    return "10925241";
                case SearchIndexType.Jewelry:
                    return "327473011";
                case SearchIndexType.KindleStore:
                    return "530484031";
                case SearchIndexType.Kitchen:
                    return "3169011";
                case SearchIndexType.Lighting:
                    return "213083031";
                case SearchIndexType.Magazines:
                    return "1161658";
                case SearchIndexType.MP3Downloads:
                    return "77195031";
                case SearchIndexType.Music:
                    return "542676";
                case SearchIndexType.MusicalInstruments:
                    return "340849031";
                case SearchIndexType.OfficeProducts:
                    return "192416031";
                case SearchIndexType.OutdoorLiving:
                    return "10925051";
                case SearchIndexType.PCHardware:
                    return "569604";
                case SearchIndexType.Photo:
                    return "569604";
                case SearchIndexType.Software:
                    return "542064";
                case SearchIndexType.SoftwareVideoGames:
                    return "541708";
                case SearchIndexType.SportingGoods:
                    return "16435121";
                case SearchIndexType.Toys:
                    return "12950661";
                case SearchIndexType.VHS:
                    return "547082";
                case SearchIndexType.Video:
                    return "547664";
                case SearchIndexType.VideoGames:
                    return "541708";
                case SearchIndexType.Watches:
                    return "193708031";
                default:
                    return null;
            }
        }

        private static string ToBrowseNodeCanada(SearchIndexType indexType)
        {
            switch (indexType)
            {
                case SearchIndexType.Baby:
                    return "3561346011";
                case SearchIndexType.Beauty:
                    return "6205124011";
                case SearchIndexType.Books:
                    return "927726";
                case SearchIndexType.Classical:
                    return "962454";
                case SearchIndexType.DVD:
                    return "14113311";
                case SearchIndexType.Electronics:
                    return "677211011";
                case SearchIndexType.ForeignBooks:
                    return "927726";
                case SearchIndexType.HealthPersonalCare:
                    return "6205177011";
                case SearchIndexType.KindleStore:
                    return "2972705011";
                case SearchIndexType.Kitchen:
                    return "2206275011";
                case SearchIndexType.LawnGardern:
                    return "6205499011";
                case SearchIndexType.Music:
                    return "962454";
                case SearchIndexType.PetSupplies:
                    return "6205514011";
                case SearchIndexType.Software:
                    return "3234171";
                case SearchIndexType.SoftwareVideoGames:
                    return "3323751";
                case SearchIndexType.VHS:
                    return "962072";
                case SearchIndexType.Video:
                    return "962454";
                case SearchIndexType.VideoGames:
                    return "110218011";
                default:
                    return null;
            }
        }
    }
}
