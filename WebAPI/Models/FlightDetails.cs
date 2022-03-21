using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class FlightDetails
    {
        public string FromCountry { get; set; }
        public string ScheduleFromTime { get; set; }
        public string ActualFromTime { get; set; }  

        public string FromDate { get; set; }
        public string ScheduledDeparture { get; set; }
        public string ActualDeparture { get; set; }

        public string ToCountry { get; set; }
        public string ArrivalToTime { get; set; }
        public string ActualToTime { get; set; }
        public string ToDate { get; set; }
        public string ScheduledArrival { get; set; }
        public string ActualArrival { get; set; }
        public string Status { get; set; }
        public string FlightNumber { get; set; }

    }
    public class FlightInput
    {
        public string from { get; set; }
        public string to { get; set; }
        public string date { get; set; }
        public string fromCountry { get; set; }
        public string toCountry { get; set; }
    }
}