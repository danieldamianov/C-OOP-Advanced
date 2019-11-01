 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            FieldInfo[] fieldInfos = null;
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(field => field.IsPrivate).ToArray();
                        break;
                    case "protected":
                        fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(field => field.IsFamily).ToArray();
                        break;
                    case "public":
                        fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
                        break;
                    case "all":
                        fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public
                            | BindingFlags.NonPublic);
                        break;
                }

                foreach (var field in fieldInfos)
                {
                    Console.WriteLine($"{GetAcessMod(field)} {field.FieldType.Name} {field.Name}");
                }
            }

        }

        private static string GetAcessMod(FieldInfo field)
        {
            if (field.IsAssembly)
            {
                return "internal";
            }
            if (field.IsPublic)
            {
                return "public";
            }
            if (field.IsFamily)
            {
                return "protected";
            }
            if (field.IsPrivate)
            {
                return "private";
            }
            throw new ArgumentException();
        }
    }
}
