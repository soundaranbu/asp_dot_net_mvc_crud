using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVC.Models;

namespace ASPMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [Route("account/")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("account/login/{id}/{username}")]
        public ActionResult LogIn(int id, string username)
        {
            var user = new User(){ FullName = "Soundar"};
            // return View(user);
            //return Content("hello");
            //return RedirectToAction("Index", "Home", new {page = 1, xxx = "stri"});
           // return HttpNotFound();
            return Content(String.Format("{0} -id {1} -name", id, username));
        }

        public ActionResult LogOut()
        {
            return View();
        }
    }
}