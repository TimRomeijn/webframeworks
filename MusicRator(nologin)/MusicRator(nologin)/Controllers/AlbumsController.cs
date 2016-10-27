using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicRator_nologin_.Models;

namespace MusicRator_nologin_.Controllers
{
    public class AlbumsController : Controller
    {
        private MusicRatorContext db = new MusicRatorContext();

        // GET: Albums
        public ActionResult Index()
        {
            //int userId = (int)Session["UserId"];

            var albums = db.Albums.Include(a => a.Genre);
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumModel albumModel = db.Albums.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            return View(albumModel);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AlbumModel albumModel)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(albumModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", albumModel.GenreId);
            return View(albumModel);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumModel albumModel = db.Albums.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", albumModel.GenreId);
            return View(albumModel);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GenreId,Title,Artist,ReleaseYear,Description,ImageUrl")] AlbumModel albumModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", albumModel.GenreId);
            return View(albumModel);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumModel albumModel = db.Albums.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            return View(albumModel);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumModel albumModel = db.Albums.Find(id);
            db.Albums.Remove(albumModel);
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
