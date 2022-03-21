using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ViewDetails
    {
        public string FromCountryCode { get; set; }
        public string FromCountryName { get; set; }
        public string FromCountry { get; set; }
        public string ToCountryCode { get; set; }
        public string ToCountryName { get; set; }
        public string ToCountry { get; set; }
        public string SelectedTime { get; set; }
    }
}