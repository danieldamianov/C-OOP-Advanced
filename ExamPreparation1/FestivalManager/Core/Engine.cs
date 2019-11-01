
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

		private IFestivalController festivalController;
		private ISetController setController;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.festivalController = festivalController;
            this.setController = setController;
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

		// дайгаз
		public void Run()
		{
			while (true) // for job security
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var chasti = input.Split(" ".ToCharArray().First());

			var purvoto = chasti.First();
			var parametri = chasti.Skip(1).ToArray();

			if (purvoto == "LetsRock")
			{
				var setovete = this.setController.PerformSets();
				return setovete;
			}

			var festivalcontrolfunction = this.festivalController.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == purvoto);

			string a;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
			}
			catch (TargetInvocationException up)
			{
				throw up.InnerException; // ha ha
			}

			return a;
		}

        
    }
}