using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            partType = partType + "Part";
            Type type = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == partType);
            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price,additionalParameter);
            return part;
        }
    }
}
