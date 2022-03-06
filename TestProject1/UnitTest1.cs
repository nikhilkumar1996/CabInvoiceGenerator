using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// UC1-Return the total fare for normal ride
        [TestMethod]
        [TestCategory("CalculatingFare")]

        public void Return_TotalFare_ForNormalRide()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            double distance = 5.0;
            int time = 10;

            double fare = invoice.CalculateFare(distance, time);
            double expected = 60.0;
            Assert.AreEqual(expected, fare);

        }
        /// UC5-Return the total fare for premium ride
        [TestMethod]
        [TestCategory("CalculatingFare")]
        public void Return_TotalFare_ForPremiumRide()
        {

            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM_RIDE);
            double distance = 15.0;
            int time = 12;

            double fare = invoice.CalculateFare(distance, time);
            double expected = 237.0;
            Assert.AreEqual(expected, fare);

        }
        /// UC2-Returns the totlfare for multiple rides
        [TestMethod]
        public void Return_Multiple_Rides_TotalFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = invoice.CalculateFare(rides);
            Assert.AreEqual(summary.totalFare, expected.totalFare);
        }
        /// UC3-Returns the average ride
        [TestMethod]
        public void Return_Multiple_Rides_AverageFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = invoice.CalculateFare(rides);
            Assert.AreEqual(summary.avgFare, expected.avgFare);
        }
        /// UC3-returns the number of rides
        [TestMethod]
        public void Return_Multiple_Rides_NumofRides()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = invoice.CalculateFare(rides);
            Assert.AreEqual(summary.numOfRides, expected.numOfRides);
        }
        /// UC4-Adding the data in the list correponding userid and rides
        [TestMethod]
        public void Given_UserId_Return_Fare()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(1, rides);
            rideRepository.AddRide(2, rides);
            var rideArray = rideRepository.GetRides(1);
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);

            InvoiceSummary summary = new InvoiceSummary(2, 30.0);
            InvoiceSummary expected = invoice.CalculateFare(rideArray);
            Assert.AreEqual(summary.totalFare, expected.totalFare);
        }

    }
}