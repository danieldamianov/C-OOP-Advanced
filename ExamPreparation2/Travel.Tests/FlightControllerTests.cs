// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void Test2()
        {
            IAirport airport = new Airport();

            Trip trip = new Trip("Sofia", "Honolulu", new LightAirplane());

            Trip trip2 = new Trip("SampleTown", "SampleTown2", new MediumAirplane());
            trip2.Complete();

            Passenger passenger6 = new Passenger("Dani3");
            passenger6.Bags.Add(new Bag(passenger6, new IItem[] {  new CellPhone() }));
            Passenger passenger7 = new Passenger("Dani3");
            passenger7.Bags.Add(new Bag(passenger7, new IItem[] { new CellPhone() }));
            Passenger passenger8 = new Passenger("Dani3");
            passenger8.Bags.Add(new Bag(passenger8, new IItem[] {  new CellPhone() }));
            Passenger passenger9 = new Passenger("Dani3");
            passenger9.Bags.Add(new Bag(passenger9, new IItem[] {  new CellPhone() }));
            Passenger passenger10 = new Passenger("Dani3");
            passenger10.Bags.Add(new Bag(passenger10, new IItem[] {  new CellPhone() }));
            Passenger passenger11 = new Passenger("Dani3");
            passenger11.Bags.Add(new Bag(passenger11, new IItem[] {  new CellPhone() }));

            trip.Airplane.AddPassenger(passenger6);
            trip.Airplane.AddPassenger(passenger7);
            trip.Airplane.AddPassenger(passenger8);
            trip.Airplane.AddPassenger(passenger9);
            trip.Airplane.AddPassenger(passenger10);
            trip.Airplane.AddPassenger(passenger11);

            airport.AddTrip(trip);
            airport.AddTrip(trip2);
            FlightController flightController = new FlightController(airport);

            string actualResult = flightController.TakeOff();
            string expectedResult = "SofiaHonolulu3:\r\nOverbooked! Ejected Dani3\r\nConfiscated 1 bags ($700)\r\nSuccessfully transported 5 passengers from Sofia to Honolulu.\r\nConfiscated bags: 1 (1 items) => $700";
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(trip.Airplane.Passengers.Count, 5);
            Assert.AreEqual(trip.IsCompleted,true);
        }

        [Test]
        public void Test1()
        {
            IAirport airport = new Airport();
            Trip trip = new Trip("Sofia", "Honolulu", new LightAirplane());
            Trip trip2 = new Trip("SampleTown", "SampleTown2", new MediumAirplane());
            trip2.Complete();
            Passenger passenger1 = new Passenger("Dani");
            passenger1.Bags.Add(new Bag(passenger1, new IItem[] { new Toothbrush(), new CellPhone() }));
            trip.Airplane.AddPassenger(passenger1);
            airport.AddTrip(trip);
            airport.AddTrip(trip2);
            FlightController flightController = new FlightController(airport);

            string actualResult = flightController.TakeOff();
            string expectedResult = "SofiaHonolulu1:\r\n" +
                "Successfully transported 1 passengers from Sofia to Honolulu.\r\n" +
                "Confiscated bags: 0 (0 items) => $0";
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(1, airport.Trips.First().Airplane.BaggageCompartment.Count);
        }
    }
}
