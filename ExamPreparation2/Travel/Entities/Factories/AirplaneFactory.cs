namespace Travel.Entities.Factories
{
    using System;
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string typeAsString)
		{
            Type type = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == typeAsString);
            return (IAirplane)Activator.CreateInstance(type);
			//switch (type)
			//{
			//	//case "LightAirplane":
			//	//	return new LightAirplane();
			//	//case "MediumAirplane":
			//	//	return new MediumAirplane();
			//	//default:
			//	//	return new Airplane();

   //             Type
			//}
		}
	}
}