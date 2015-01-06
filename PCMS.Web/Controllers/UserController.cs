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
        private const string LOGIN_FAIL_PARTIAL_VIEW = "LoginFailPartial";
        private const string LOGIN_SUCCESS_ACTION = "Index";
        private const string LOGIN_SUCCESS_CONTROLLER = "Home";

        private UserService _userService;


        public UserController():base()
        {
            base._service = new UserService(uow);
            this._userService = new UserService(uow);
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string username = formCollection["username"];
            string password = formCollection["password"];

            PortalUser user = _userService.Login(username, password);
            bool loginSuccessful = user != null;

            if (loginSuccessful)
            {
                Session["CurrentUser"] = user;
                Session["CurrentUserName"] = user.Username;
                return JavaScript("window.location.href='" + Url.Action(LOGIN_SUCCESS_ACTION, LOGIN_SUCCESS_CONTROLLER) + "';");
            }
            else
            {
                return PartialView(LOGIN_FAIL_PARTIAL_VIEW);
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
