using MusicRator_nologin_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicRator_nologin_.Controllers
{
    public class AdminController : Controller
    {
        private MusicRatorContext db = new MusicRatorContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //// GET: Admin
        //[HttpPost]
        //public ActionResult Index(string userId)
        //{
        //    int UserId = Int32.Parse(userId);
        //    User changeUser = db.Users.Find(UserId);
        //    changeUser.Active = !changeUser.Active;
        //    db.Entry(changeUser).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return View(db.Users.ToList());
        //}
    }
}