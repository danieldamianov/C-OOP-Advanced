namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type typeOfBlackBoxInteger = typeof(BlackBoxInteger);

            ConstructorInfo blackBoxIntegerConstructor = typeOfBlackBoxInteger.GetConstructor
                (BindingFlags.Instance | BindingFlags.NonPublic,null, new Type[] { typeof(int) },null);

            BlackBoxInteger blackBoxInteger = (BlackBoxInteger)blackBoxIntegerConstructor.Invoke(new object[] { 0});

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandSplit = input.Split('_');

                string methodName = commandSplit[0];
                int methodParameter = int.Parse(commandSplit[1]);

                typeOfBlackBoxInteger.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(blackBoxInteger,new object[] { methodParameter});

                Console.WriteLine(typeOfBlackBoxInteger.GetField("innerValue",BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(blackBoxInteger));
            }

            //Console.WriteLine(typeOfBlackBoxInteger.GetField("innerValue",BindingFlags.Instance | BindingFlags.NonPublic)
            //    .GetValue(blackBoxInteger));
        }
    }
}
