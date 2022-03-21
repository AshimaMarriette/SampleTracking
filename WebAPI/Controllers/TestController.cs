using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TestController : Controller
    {
        private IAPIHelper _apiHelper;
        // GET: Test
        public TestController(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public ActionResult Index()
        {
            ViewDetails data = new ViewDetails();
            var countryLst = _apiHelper.FetchCountryList();

            ViewBag.FromCountry = new SelectList(countryLst, "FromCountryCode", "FromCountry", 0);
            ViewBag.ToCountry = new SelectList(countryLst, "ToCountryCode", "ToCountry", 0);

            return View(data);
        }
        [HttpPost]
        public ActionResult getFlightData(string from, string to, string date, string fromCountry, string toCountry)
        {
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                var deptDate = getDateFormatForFlight(date);
                if (string.IsNullOrEmpty(deptDate))
                {
                    TempData["error"] = "Please enter Valid Departure Date";
                    return PartialView();
                }
                else
                {
                    List<FlightDetails> flightList = new List<FlightDetails>();
                    var details = _apiHelper.GetFlightDetails(from, to, deptDate);
                    if (details.results != null && details.results.Count > 0)
                    {
                        foreach (var item in details.results)
                        {
                            var route = item.flightRoute[0];
                            var actualArrivalTime = string.Empty;
                            var actualDeptTime = string.Empty;
                            var scheduleArrivalTime = string.Empty;
                            var scheduleDeptTime = string.Empty;

                            if (route.arrivalTime?.schedule != null)
                            {
                                scheduleArrivalTime = route.arrivalTime?.schedule.ToString("HH:mm");
                            }
                            if (route.arrivalTime?.actual != null)
                            {
                                actualArrivalTime = route.arrivalTime?.actual.ToString("HH:mm");
                            }
                            if (route.departureTime?.schedule != null)
                            {
                                scheduleDeptTime = route.departureTime?.schedule.ToString("HH:mm");
                            }
                            if (route.departureTime?.actual != null)
                            {
                                actualDeptTime = route.departureTime?.actual.ToString("HH:mm");
                            }

                            var scheduleArrival = route.arrivalTime.schedule.ToString("ddd, dd MMM");
                            var scheduleDept = route.departureTime.schedule.ToString("ddd, dd MMM");



                            FlightDetails flight = new FlightDetails()
                            {
                                FlightNumber = item.airlineDesignator + " " + item.flightNumber,
                                ScheduledArrival = scheduleArrival,
                                ActualArrival = actualArrivalTime,
                                FromCountry = fromCountry,
                                ScheduleFromTime = scheduleDeptTime,
                                ActualFromTime = actualDeptTime,
                                FromDate = scheduleDept,
                                ScheduledDeparture = scheduleDept,
                                ActualDeparture = actualDeptTime,
                                ToCountry = toCountry,
                                ArrivalToTime = scheduleArrivalTime,
                                ActualToTime = actualArrivalTime,
                                ToDate = scheduleArrival,
                                Status = item.flightRoute[0].statusCode
                            };
                            flightList.Add(flight);
                        }
                    }
                    return PartialView(flightList);
                }
            }
            else
            {
                TempData["error"] = "Please enter Valid details";
                return PartialView();
            }

        }
        private string getDateFormatForFlight(string dateString)
        {
            DateTime dateValue;
            return DateTime.TryParse(dateString, out dateValue) ? dateValue.ToString("yyyy-MM-dd") : dateString;
        }
        private string getFlightDate(string dateString)
        {
            DateTime dateValue;
            return DateTime.TryParse(dateString, out dateValue) ? dateValue.ToString("ddd, dd MMM") : dateString;
        }
    }
}