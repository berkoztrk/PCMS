using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCMS.Services;
using PCMS.Repositories;

namespace PCMS.Web.Controllers
{
    public class HomeController : Controller
    {

        private SiteMenuService _service;

        public HomeController()
        {
            UnitOfWork uow = new UnitOfWork();
            this._service = new SiteMenuService(uow);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Menu()
        {
            var model = this._service.OrderBy("SortingOrder ASC");
            return View(model);
        }

        

    }
}
