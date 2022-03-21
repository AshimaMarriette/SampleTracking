using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TrackDetails
    {
        public List<ResultDetails> results { get; set; }
    }
    public class ResultDetails
    {
        public string airlineDesignator { get; set; }
        public string flightNumber { get; set; }
        public string flightId { get; set; }
        public string flightDate { get; set; }
        public List<fightRouteDetails> flightRoute { get; set; }
    }
    public class fightRouteDetails
    {
        public string legNumber { get; set; }
        public string originActualAirportCode { get; set; }
        public string destinationActualAirportCode { get; set; }
        public string originPlannedAirportCode { get; set; }
        public string destinationPlannedAirportCode { get; set; }
        public string statusCode { get; set; }
        public string flightPosition { get; set; }
        public string totalTravelDuration { get; set; }
        public string isIrregular { get; set; }
        public departureTimeDetails departureTime { get; set; }
        public arrivalTimeDetails arrivalTime { get; set; }
        public operationalUpdateDetails operationalUpdate { get; set; }
        public string departureTerminal { get; set; }
        public string arrivalTerminal { get; set; }
        public int flightOutageType { get; set; }
    }
    public class departureTimeDetails
    {
        public DateTime schedule { get; set; }
        public DateTime estimated { get; set; }
        public DateTime actual { get; set; }

    }
    public class arrivalTimeDetails
    {
        public DateTime schedule { get; set; }
        public DateTime estimated { get; set; }
        public DateTime actual { get; set; }

    }
    public class operationalUpdateDetails
    {
        public string lastUpdated { get; set; }

    }
}