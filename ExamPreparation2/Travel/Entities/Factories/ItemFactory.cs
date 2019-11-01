namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string typeAsString)
		{
            Type type = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == typeAsString);
            return (IItem)Activator.CreateInstance(type);
            //switch (type)
            //{
            //	case "Item":
            //		return new Item();
            //	case "CellPhone":
            //		return new Colombian();
            //	case "Colombian":
            //		return new Colombian();
            //	case "Jewelery":
            //		return new Jewelery();
            //	case "Laptop":
            //		return new Laptop();
            //	case "toothbrush":
            //		return new Toothbrush();
            //	case "TravelKit":
            //		return new TravelKit();
            //	default:
            //		return new Soap();
            //}
        }
	}
}
