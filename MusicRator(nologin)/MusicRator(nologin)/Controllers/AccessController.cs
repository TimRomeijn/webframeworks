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
                if(model.UserName == "test" && model.Password == "1234")
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                    return RedirectToAction("Index", "Secure");
                }
                else
                {
                    ModelState.AddModelError("", "Deze combinatie is niet bekend");
                }
            }

            return View();
        }
    }
}