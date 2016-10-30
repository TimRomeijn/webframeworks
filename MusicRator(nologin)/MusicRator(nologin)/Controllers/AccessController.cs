using MusicRator_nologin_.Models;
using MusicRator_nologin_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already loged in or not
            if ((Session["Check"] != null) && (Convert.ToBoolean(Session["Check"]) == true))
            {
                // If User is Authenticated then moved to a main page
                if (User.Identity.IsAuthenticated)
                    Response.Redirect("Index");
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, AuthenticateEventArgs e)
        {
            if (ModelState.IsValid)
            {
                var context = new MusicRatorContext();

                var users = from u in context.Users
                            select u;

                Boolean blnresult;
                blnresult = false;
                //blnresult = users;

                if (blnresult == true)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                    // This is the actual statement which will authenticate the user
                    e.Authenticated = true;
                    // Store your authentication mode in session variable 
                    Session["Check"] = true;

                    return RedirectToAction("Index","Home");

                    
                }
                else
                {
                    ModelState.AddModelError("", "Deze combinatie is niet bekend");

                    e.Authenticated = false;

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

        public ActionResult Logout()
        {

            // remove security cookie
            FormsAuthentication.SignOut();

            //  clear the session 
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}