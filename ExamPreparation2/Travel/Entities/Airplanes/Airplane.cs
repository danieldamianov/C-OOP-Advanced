namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        public Airplane(int seats, int baggageCompartments)
        {
            this.passengers = new List<IPassenger>();
            this.baggageCompartment = new List<IBag>();
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
        }
        public int Seats { get; }
        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment;
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger) => this.passengers.Add(passenger);

        public IPassenger RemovePassenger(int index)
        {
            var passenger = this.passengers[index];
            this.passengers.RemoveAt(index);
            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;//CHECK FOR >=!!!!!!!
            if (isBaggageCompartmentFull)
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");

            this.baggageCompartment.Add(bag);
        }
    }
}