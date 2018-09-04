using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVC.Manager;
using ASPMVC.Models;

namespace ASPMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [Route("User/List")]
        public ActionResult List(int? id, string action)
        {
            ViewBag.UserList = UserManager.Instance.GetAllUsers();
            return View();
        }

        [Route("User/View/{id}")]
        public ActionResult View(int id)
        {
                User user = UserManager.Instance.GetUserById(id);
                return View(user);
        }

        [Route("User/Update/{id}")]
        public ActionResult Update(int id, string UserName, string FullName, string Mobile, string Email)
        {
            if (String.IsNullOrEmpty(UserName) && String.IsNullOrEmpty(FullName) && 
                String.IsNullOrEmpty(Mobile) && String.IsNullOrEmpty(Email))
            {
                User user = UserManager.Instance.GetUserById(id);
                return View(user);
            }
            else
            {
                User user = new Models.User();
                user.Id = id;
                user.UserName = UserName;
                user.FullName = FullName;
                user.Mobile = Convert.ToInt64(Mobile);
                user.Email = Email;
                UserManager.Instance.UpdateOrCreateUser(user);
                return RedirectToAction("List");
            }
        }

        [Route("User/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            UserManager.Instance.DeleteUserById(id);
            return RedirectToAction("List");
        }

        [Route("User/Create")]
        public ActionResult Create(string username, string fullname, string mobile, string email)
        {
            if(!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(fullname) && 
                !String.IsNullOrEmpty(mobile) && !String.IsNullOrEmpty(email))
            {
                User user = new Models.User();
                user.Id = 0;
                user.UserName = username;
                user.FullName = fullname;
                user.Mobile = Convert.ToInt64(mobile);
                user.Email = email;

                UserManager.Instance.UpdateOrCreateUser(user);
                return RedirectToAction("List");
            }


            return View();
        }
    }
}