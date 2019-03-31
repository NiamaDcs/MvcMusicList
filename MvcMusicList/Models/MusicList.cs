using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMusicList.Models
{
	public class MusicList
	{
		public int ID { get; set; }

		[Required, StringLength(60, MinimumLength = 3)]
		public string Artiste { get; set; }
		[Required]
		public string Album { get; set; }
		[Required]
		public string Genre { get; set; }
		[Required]
		public int Annee { get; set; }
		public string Vues { get; set; }
	
	}

	public class MusicListDBContext : DbContext
	{
		public DbSet<MusicList> MusicLists { get; set; }
	}
}