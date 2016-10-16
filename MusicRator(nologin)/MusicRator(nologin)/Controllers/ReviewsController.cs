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
    public class ReviewsController : Controller
    {
        private MusicRatorContext db = new MusicRatorContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Album).Include(r => r.User);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModel reviewModel = db.Reviews.Find(id);
            if (reviewModel == null)
            {
                return HttpNotFound();
            }
            return View(reviewModel);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReviewText,Rating,Date,UserId,AlbumId")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(reviewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title", reviewModel.AlbumId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", reviewModel.UserId);
            return View(reviewModel);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModel reviewModel = db.Reviews.Find(id);
            if (reviewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title", reviewModel.AlbumId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", reviewModel.UserId);
            return View(reviewModel);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReviewText,Rating,Date,UserId,AlbumId")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title", reviewModel.AlbumId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", reviewModel.UserId);
            return View(reviewModel);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModel reviewModel = db.Reviews.Find(id);
            if (reviewModel == null)
            {
                return HttpNotFound();
            }
            return View(reviewModel);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewModel reviewModel = db.Reviews.Find(id);
            db.Reviews.Remove(reviewModel);
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
