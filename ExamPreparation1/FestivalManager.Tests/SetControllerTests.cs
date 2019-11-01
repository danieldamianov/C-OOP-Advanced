// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void Test()
	    {
            IStage stage = new Stage();

            ISong song1 = new Song("Song1", new System.TimeSpan(0, 50, 0));
            ISong song2 = new Song("Song2", new System.TimeSpan(0, 5, 0));

            ISet set = new Long("LongSet1");
            set.AddSong(song1);
            set.AddSong(song2);

            IPerformer performer = new Performer("Performer1", 10);
            performer.AddInstrument(new Guitar());

            set.AddPerformer(performer);

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();

            string expectedResult = "1. LongSet1:" + System.Environment.NewLine +
                "-- 1. Song1 (50:00)" + System.Environment.NewLine +
                "-- 2. Song2 (05:00)" + System.Environment.NewLine +
                "-- Set Successful";


            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void Test3()
        {
            IStage stage = new Stage();

            ISong song1 = new Song("Song1", new System.TimeSpan(0, 50, 0));
            ISong song2 = new Song("Song2", new System.TimeSpan(0, 5, 0));

            ISet set = new Long("LongSet1");
            set.AddSong(song1);
            set.AddSong(song2);

            IPerformer performer = new Performer("Performer1", 10);
            performer.AddInstrument(new Guitar());

            set.AddPerformer(performer);

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();

            string expectedResult = "1. LongSet1:" + System.Environment.NewLine +
                "-- 1. Song1 (50:00)" + System.Environment.NewLine +
                "-- 2. Song2 (05:00)" + System.Environment.NewLine +
                "-- Set Successful";


            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, performer.Instruments.First().Wear);
        }

        [Test]
        public void Test2()
        {
            IStage stage = new Stage();

            ISong song1 = new Song("Song1", new System.TimeSpan(0, 50, 0));
            ISong song2 = new Song("Song2", new System.TimeSpan(0, 5, 0));

            ISet set = new Long("LongSet1");
            set.AddSong(song1);
            set.AddSong(song2);

            IPerformer performer = new Performer("Performer1", 10);
            //performer.AddInstrument(new Guitar());

            set.AddPerformer(performer);

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();

            string expectedResult = "1. LongSet1:" + System.Environment.NewLine +
                "-- Did not perform";

            Assert.AreEqual(expectedResult, actualResult);
        }
	}
}