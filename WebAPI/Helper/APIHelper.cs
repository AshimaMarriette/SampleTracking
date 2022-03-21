using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public class APIHelper: IAPIHelper
    {
        public string BaseUrl;
        public APIHelper()
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString().Trim();
        }
        public List<AirportDetails> FetchCountryList()
        {
            List<AirportDetails> countryList = new List<AirportDetails>();
            try
            {
                
                HttpClient client = new HttpClient();
                string ReqUrl = BaseUrl + "airports?lang=en";

                var countryResponse = client.GetAsync(ReqUrl).Result;
                var responseString = countryResponse.Content.ReadAsStringAsync().Result;

                JObject json = JObject.Parse(responseString);

                foreach (JProperty item in json["results"])
                {
                    foreach (JProperty property in (item.Value as JObject).Properties())
                    {
                        var code = item.Name;
                        var pname = property.Name;
                        if (pname == "shortName")
                        {
                            var name = (string)property.Value;
                            AirportDetails data = new AirportDetails()
                            {
                                FromCountryCode = item.Name,
                                FromCountryName = name,
                                FromCountry = name + " (" + item.Name + ")",
                                ToCountry = name + " (" + item.Name + ")",
                                ToCountryCode = item.Name,
                                ToCountryName = name,
                            };
                            countryList.Add(data);
                            break;
                        }
                    }
                }
                return countryList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public TrackDetails GetFlightDetails(string origin, string dest, string deptDate )
        {
            try
            {
                HttpClient client = new HttpClient();
                string ReqUrl = BaseUrl + "flight-status?departureDate=" + deptDate + "&origin=" + origin + "&destination=" +dest;
                var response = client.GetAsync(ReqUrl).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                TrackDetails flightDetails = JsonConvert.DeserializeObject<TrackDetails>(responseString);
                return flightDetails != null ? flightDetails : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}