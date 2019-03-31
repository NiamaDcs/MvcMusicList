using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MvcMusicList.Models;
using MvcMusicList.Controllers;
using System.Linq;

namespace Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMvc()
		{
			List<MusicList> actual = new List<MusicList>();
			MusicList m = new MusicList() {Artiste="AB", Album="cd", Genre="nd", Annee= 2013, Vues="10000"};
			actual.Add(m);

			MusicListsController ctrl = new MusicListsController();
			// variable 
			var expected = "rap";
			List<MusicList> ystyle = new List<MusicList>();
			MusicList y = new MusicList() { Artiste = "AB", Album = "cd", Genre = "Rap", Annee = 2013, Vues = "10000" };
			ystyle.Add(y);

			List<MusicList> rstyle = new List<MusicList>();
			MusicList r = new MusicList() { Artiste = "AB", Album = "cd", Genre = "R&B", Annee = 2013, Vues = "10000" };
			rstyle.Add(r);

			List<MusicList> pstyle = new List<MusicList>();
			MusicList p = new MusicList() { Artiste = "AB", Album = "cd", Genre = "Rap", Annee = 2013, Vues = "10000" };
			pstyle.Add(p);

			var result = ctrl.GetMusicListsByGenre("rap", actual.Where(s=> s.Genre));

			Assert.AreEqual(expected, result);


		}
	}
}
