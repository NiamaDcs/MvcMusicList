using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using PagedList;
using System.Web.Mvc;
using MvcMusicList.Models;

namespace MvcMusicList.Controllers
{
    public class MusicListsController : Controller
    {
        private MusicListDBContext db = new MusicListDBContext();

		// GET: MusicLists
		public ViewResult Index(string musicListGenre, string searchString, int? anneeSorties, string sortOrder)
        {
			ViewBag.CurrentSort = sortOrder;
			ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "ariste_desc" : "";
			ViewBag.AnneeSortParam = sortOrder == "Annee" ? "annee_desc" : "Annee"; 
		
			var GenreLst = new List<string>();

			var GenreQry = from d in db.MusicLists
						   orderby d.Genre
						   select d.Genre;

			GenreLst.AddRange(GenreQry.Distinct());
			ViewBag.musicListGenre = new SelectList(GenreLst);

			var AnneeLst = new List<int>();

			var AnneeQry = from a in db.MusicLists
						   orderby a.Annee
						   select a.Annee;

			AnneeLst.AddRange(AnneeLst.Distinct());
			ViewBag.anneeSorties = new SelectList(AnneeLst); 

			var musicLists = from m in db.MusicLists
							 select m;
		

			musicLists = this.GetListsMusicsByArtistName(searchString, musicLists);

			musicLists = this.GetMusicListsByGenre(musicListGenre, musicLists);

			musicLists = this.GetMusicListsByAnnee(anneeSorties, musicLists);

			musicLists = this.MakeSortOrder(sortOrder, musicLists);

			
			
			return View(musicLists);
        }

		public IQueryable<MusicList> GetListsMusicsByArtistName (string searchString, IQueryable<MusicList> musicLists)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				return musicLists.Where(s => s.Artiste.Contains(searchString));
			}
			return musicLists;
		}

		public IQueryable<MusicList> GetMusicListsByGenre (string musicListGenre, IQueryable<MusicList> musicLists)
		{
			if (!string.IsNullOrEmpty(musicListGenre))
			{
				return musicLists.Where(x => x.Genre == musicListGenre);
			}
			return musicLists;
		}

		public IQueryable<MusicList> GetMusicListsByAnnee (int? anneeSorties, IQueryable<MusicList> musicLists)
		{
			if (anneeSorties != 0 && anneeSorties.HasValue)
			{
				return musicLists.Where(y => y.Annee == anneeSorties.Value);
			}
			return musicLists;
		}

		public IQueryable<MusicList> MakeSortOrder(string sortOrder, IQueryable<MusicList> musicLists)
		{
			switch(sortOrder)
			{
				case "ariste_desc":
					musicLists = musicLists.OrderBy(s => s.Artiste);
					break;
				case "Annee":
					musicLists = musicLists.OrderBy(s => s.Annee);
					break;
				case "annee_desc":
					musicLists = musicLists.OrderByDescending(s => s.Annee);
					break;
				default:
					musicLists = musicLists.OrderByDescending(s => s.Artiste);
					break;
			}

			return musicLists; 
		}

        // GET: MusicLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicList musicList = db.MusicLists.Find(id);
            if (musicList == null)
            {
                return HttpNotFound();
            }
            return View(musicList);
        }

        // GET: MusicLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicLists/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Artiste,Album,Genre,Annee,Vues")] MusicList musicList)
        {
            if (ModelState.IsValid)
            {
                db.MusicLists.Add(musicList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicList);
        }

        // GET: MusicLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicList musicList = db.MusicLists.Find(id);
            if (musicList == null)
            {
                return HttpNotFound();
            }
            return View(musicList);
        }

        // POST: MusicLists/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Artiste,Album,Genre,Annee,Vues")] MusicList musicList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicList);
        }

        // GET: MusicLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicList musicList = db.MusicLists.Find(id);
            if (musicList == null)
            {
                return HttpNotFound();
            }
            return View(musicList);
        }

        // POST: MusicLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicList musicList = db.MusicLists.Find(id);
            db.MusicLists.Remove(musicList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
