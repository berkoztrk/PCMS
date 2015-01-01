using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCMS.Repositories;
using PCMS.Services;
using PCMS.Entities;
using System.ComponentModel;
using PCMS.Web.Helpers;

namespace PCMS.Web.Controllers
{
    public class UserController : ParentController<PortalUser,Guid>
    {
        private const string LOGIN_FAIL_PARTIAL = "LoginFailPartial";
        private const string LOGIN_SUCCESS_ACTION = "Index";
        private const string LOGIN_SUCCESS_CONTROLLER = "Home";


        public UserController():base()
        {
            base._service = new UserService(uow);
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string username = formCollection["username"];
            string password = formCollection["password"];

            UserService userService = new UserService(uow);
          
            PortalUser user = userService.Login(username, password);
            if (user != null)
            {
                Session["CurrentUser"] = user;
                Session["CurrentUserName"] = user.Username;
                return JavaScript("window.location.href='" + Url.Action(LOGIN_SUCCESS_ACTION, LOGIN_SUCCESS_CONTROLLER) + "';");
            }
            else
            {
                return PartialView(LOGIN_FAIL_PARTIAL);
            }
        }

        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            Session["CurrentUserName"] = null;

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
