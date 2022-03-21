using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebAPI.Controllers;
using WebAPI.Helper;
using WebAPI.Models;

namespace WEBAPI_UnitTest
{
    [TestClass]
    public class TestControllerTests
    {
        public TestControllerTests()
        {
        }
        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            List<AirportDetails> mockData = new List<AirportDetails>();
            var details = new AirportDetails()
            {
                FromCountry= "Test1(DXB)",
                ToCountry = "Test2(XYZ)",
                FromCountryCode= "DXB",
                ToCountryCode = "XYZ",
                FromCountryName= "Test1",
                ToCountryName= "Test2"
            };
            mockData.Add(details);
            var serviceMock = new Mock<IAPIHelper>();
            serviceMock.Setup(x => x.FetchCountryList())
                .Returns(mockData)
                .Verifiable();
            
            var controller = new TestController(serviceMock.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert

            serviceMock.Verify(mock => mock.FetchCountryList(), Times.Once());
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestIndexEmptyList()
        {
            //Arrange
            List<AirportDetails> mockData = new List<AirportDetails>();
            
            var serviceMock = new Mock<IAPIHelper>();
            serviceMock.Setup(x => x.FetchCountryList())
                .Returns(mockData)
                .Verifiable();

            var controller = new TestController(serviceMock.Object);

            //Act
            var result = controller.Index();

            //Assert
            serviceMock.Verify(mock => mock.FetchCountryList(), Times.Once());
        }
        [TestMethod]
        public void TestFlightListEmpty()
        {
            //Arrange
            TrackDetails mockData = new TrackDetails();

            var serviceMock = new Mock<IAPIHelper>();
            serviceMock.Setup(x => x.GetFlightDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockData)
                .Verifiable();
            var controller = new TestController(serviceMock.Object);

            //Act
            var result = controller.getFlightData("","","2022-02-02","","");

            //Assert
            serviceMock.Verify(mock => mock.GetFlightDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }
        [TestMethod]
        public void TestFlightList()
        {
            //Arrange
            TrackDetails mockData = new TrackDetails();
            List<fightRouteDetails> lst=new List<fightRouteDetails>();
            List<ResultDetails> set = new List<ResultDetails>();
            var arrival = new arrivalTimeDetails()
            {
                schedule = new DateTime().AddDays(2),
                actual = new DateTime().AddDays(2).AddHours(2)
            };
            var dept = new departureTimeDetails()
            {
                schedule = new DateTime().AddDays(1),
                actual = new DateTime().AddDays(1).AddHours(-1)
            };
            var routeDetails = new fightRouteDetails()
            {
                arrivalTime = arrival,
                arrivalTerminal = "T1",
                departureTime = dept,
                departureTerminal = "D1"
            };
            lst.Add(routeDetails);
            ResultDetails details = new ResultDetails()
            {
                flightNumber = "45122",
                airlineDesignator = "Test",
                flightDate = new DateTime().AddDays(2).ToString(),
                flightRoute = lst
            };
            set.Add(details);
            mockData.results = set;

            var serviceMock = new Mock<IAPIHelper>();
            serviceMock.Setup(x => x.GetFlightDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockData)
                .Verifiable();
            var controller = new TestController(serviceMock.Object);

            //Act
            var result = controller.getFlightData("src", "dest", "2022-02-02", "Test(src)", "Test(dest)");

            //Assert
            serviceMock.Verify(mock => mock.GetFlightDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            Assert.IsNotNull(result);
        }
    }
}
