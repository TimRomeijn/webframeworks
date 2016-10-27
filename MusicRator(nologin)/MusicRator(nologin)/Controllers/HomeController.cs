using MusicRator_nologin_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MusicRator_nologin_.Controllers
{
    public class HomeController : Controller
    {
        private MusicRatorContext db = new MusicRatorContext();

        public ActionResult Index()
        {

            ViewBag.Message = "These are the albums ready for reviewing!";

            AlbumModel viewData = new AlbumModel();
            viewData.Albums = db.Albums.
                Include(m => m.Genre).
                //Where(t => t.UserAccountId == userId).
                OrderByDescending(t => t.Id).
                Take(5).ToList();

            return View(viewData);
        }


      
        public ActionResult Album()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

    }
}