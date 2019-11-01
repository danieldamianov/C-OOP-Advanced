namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Sets;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

		public FestivalController(IStage stage) // CHEKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
		{
			this.stage = stage;// CHEKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
            this.instrumentFactory = new InstrumentFactory();// CHEKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
            this.performerFactory = new PerformerFactory();// CHEKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
            this.setFactory = new SetFactory();// CHEKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
            this.songFactory = new SongFactory();// CHEKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
        }

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));////CHEKKKK
            
            //result += ($"Festival length: {totalFestivalLength.ToString(TimeFormat)}") + "\n";////CHEKKKK
            result += ($"Festival length: {((int)totalFestivalLength.TotalMinutes):D2}:{totalFestivalLength.Seconds:D2}") + "\n";////CHEKKKK
            //TimeSpan timeSpan = new TimeSpan();

            foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({((int)set.ActualDuration.TotalMinutes):D2}:{set.ActualDuration.Seconds:D2}):") + "\n";////CHEKKKK

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

		public string RegisterSet(string[] args)
		{
            ISet concertSet = this.setFactory.CreateSet(args[0], args[1]);
            this.stage.AddSet(concertSet);
            return $"Registered {args[1]} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

            var performer = this.performerFactory.CreatePerformer(name, age);

            var instrumentsAsStrings = args.Skip(2).ToArray();

            if (instrumentsAsStrings.Length != 0)
            {
                IInstrument[] instruments = instrumentsAsStrings
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

                foreach (var instrument in instruments)
                {
                    performer.AddInstrument(instrument);
                }
            }

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            string durationAsString = args[1];

            string[] durationArgs = durationAsString.Split(':');

            TimeSpan timeSpan = new TimeSpan(0, int.Parse(durationArgs[0]), int.Parse(durationArgs[1]));

            ISong song = this.songFactory.CreateSong(name, timeSpan);

            this.stage.AddSong(song);

			return $"Registered song {args[0]} ({timeSpan:mm\\:ss})";
		}

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}

		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}