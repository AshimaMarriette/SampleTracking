using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CountryList
    {
        public CountryCode results {get;set;}
    }
    public class CountryCode
    {
        public CountryData countryCode { get; set; }
    }
    public class CountryData
    {
        public string iataCode { get; set; }
        public bool showAsOrigin { get; set; }
        public string sellingPOS { get; set; }
        public string stationType { get; set; }
        public bool isInterlineOperated { get; set; }
        public bool isGBE { get; set; }
        public bool isOFW { get; set; }
        public string isEK { get; set; }
        public Coordinates geoCoordinates { get; set; }

        public string shortName { get; set; }
        public string longName { get; set; }
        public List<string> nearbyAirports { get; set; }

        public regionDetails region { get; set; }

        public CountryDetails country {get;set;}

        public cityDetails city { get;set;}


    }
    public class Coordinates
    {
        public double latitude { get;set;}
        public double longitude { get;set;}
    }

    public class regionDetails
    {
        public string shortName { get;set;} 
        public string longName { get;set;} 
        public string code { get;set;} 
    }

    public class CountryDetails
    {
        public string a3code { get;set;}
        public string code { get;set;}
        public string shortName { get;set;}
        public string longName { get;set;}
        public otherRegionDetails otherRegion { get;set;}


    }
    public class otherRegionDetails
    {
        public string shortName { get;set;}
        public string longName { get;set;}
       
    }
    public class cityDetails
    {
        public string code { get;set;}
        public string shortName { get; set; }
        public string longName { get; set; }
    }
    public class AirportDetails
    {
        public string FromCountryCode { get; set; }
        public string FromCountryName { get; set; }
        public string FromCountry { get; set; }
        public string ToCountryCode { get; set; }
        public string ToCountryName { get; set; }
        public string ToCountry { get; set; }
    }
}