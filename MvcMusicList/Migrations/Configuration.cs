namespace MvcMusicList.Migrations
{
	using MvcMusicList.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMusicList.Models.MusicListDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMusicList.Models.MusicListDBContext context)
        {
			context.MusicLists.AddOrUpdate(i => i.Artiste,
				new MusicList
				{
					Artiste = "Lil Wayne",
					Album = "Tha Carter III",
					Genre = "Rap",
					Annee = 2008,
					Vues = "100000"
				},

				new MusicList
				{ 
					Artiste = "Justin Bieber",
					Album = "Believe",
					Genre = "R&B",
					Annee = 2012,
					Vues = "100000"
				},

				new MusicList
				{
					Artiste = "Justin Bieber",
					Album = "My World 2.0",
					Genre = "R&B",
					Annee = 2010,
					Vues = "100000"
				},

				new MusicList
				{
					Artiste = "Nicki Minaj",
					Album = "Pink Friday",
					Genre = "Rap",
					Annee = 2010,
					Vues = "100000"
				},

				new MusicList
				{
					Artiste = "Jay Sean",
					Album = "All or Nothing",
					Genre = "Rap",
					Annee = 2009,
					Vues = "100000"
				},

				new MusicList
				{
					Artiste = "Alicia Keys",
					Album = "Girl on fire",
					Genre = "Rap",
					Annee = 2012,
					Vues = "100000"
				},

				new MusicList
				{
					Artiste = "M. Pokora",
					Album = "My Way",
					Genre = "Rap",
					Annee = 2016,
					Vues = "100000"
				},

				new MusicList
				{
					Artiste = "Céline Dion",
					Album = "One Heart",
					Genre = "Rap",
					Annee = 2003,
					Vues = "100000"
				}
				);
		}
    }
}
