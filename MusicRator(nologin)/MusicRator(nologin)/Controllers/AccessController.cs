using MusicRator_nologin_.Models;
using MusicRator_nologin_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicRator_nologin_.Controllers
{
    public class AccessController : Controller
    {
        private MusicRatorContext db = new MusicRatorContext();

        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var users = db.Users.Include

                if(model.UserName == model.UserName && model.Password == model.Password)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Deze combinatie is niet bekend");

                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel User)
        {
            //todo : check user data 

            // add to database
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            // redirect..

            // maybe login user ...
            return View();
        }
    }
}