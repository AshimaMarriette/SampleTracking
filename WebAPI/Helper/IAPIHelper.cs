using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public interface IAPIHelper
    {
        List<AirportDetails> FetchCountryList();
        TrackDetails GetFlightDetails(string origin, string dest, string deptDate);
    }
}
