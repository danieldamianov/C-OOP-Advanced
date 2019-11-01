using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == vehicleType);
            IVehicle vehicle = (IVehicle)Activator.CreateInstance(type, model, weight, price, attack, defense, hitPoints,new VehicleAssembler());
            return vehicle;
        }
    }
}
