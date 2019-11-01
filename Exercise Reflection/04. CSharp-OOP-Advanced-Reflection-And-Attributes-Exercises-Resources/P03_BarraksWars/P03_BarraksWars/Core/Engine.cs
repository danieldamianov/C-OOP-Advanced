namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core;
    using P03_BarraksWars.Models.Units;

    class Engine : IRunnable
    {
        private Provider serviceProvider;

        public Engine(Provider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private string InterpredCommand(string[] data, string commandName)
        {
            commandName = MakeFirstLetterToUpper(commandName);
            Type type = Type.GetType($"_03BarracksFactory.Core.Commands.{commandName}Command");

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] paramatersData = new object[] { data };
            //object[] injectParamaters = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            object[] injectParamaters = fieldsToInject.Select(f => this.serviceProvider.ReturnInstance(f.FieldType)).ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(type,paramatersData.Concat(injectParamaters).ToArray());
            string result = command.Execute();
            
            return result;
        }

        private static string MakeFirstLetterToUpper(string commandName)
        {
            char letter = char.ToUpper(commandName[0]);
            commandName = commandName.Remove(0, 1);
            commandName = commandName.Insert(0, letter.ToString());
            return commandName;
        }
    }
}
