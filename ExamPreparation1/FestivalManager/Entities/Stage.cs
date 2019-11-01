namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return this.performers.FirstOrDefault(p => p.Name == name); //CHECKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!
        }

        public ISet GetSet(string name)
        {
            return this.sets.FirstOrDefault(s => s.Name == name); //CHECKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!
        }

        public ISong GetSong(string name)
        {
            return this.songs.FirstOrDefault(s => s.Name == name); //CHECKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Exists(p => p.Name == name); //CHECKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!
        }

        public bool HasSet(string name)
        {
            return this.sets.Exists(s => s.Name == name); //CHECKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!
        }

        public bool HasSong(string name)
        {
            return this.songs.Exists(s => s.Name == name); //CHECKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}
