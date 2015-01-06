using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCMS.Services;

namespace PCMS.Web.Controllers
{
    public class ParentController<TEntity, TKey> : Controller, IPCMSController<TEntity, TKey> where TEntity : class
    {
        protected UnitOfWork uow;
        protected EntityService<TEntity> _service { get; set; }

        protected ParentController()
        {
            this.uow = new UnitOfWork();
            _service = new EntityService<TEntity>(this.uow);
        }

        [HttpGet]
        [ActionName("List")]
        public virtual ActionResult GetList()
        {
            return View();
        }

        [HttpPost]
        public virtual JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int count = _service.GetCount();
                var records = _service.GetAllWithPaging(jtStartIndex, jtPageSize, jtSorting);
                return Json(new { Result = "OK", Records = records, TotalRecordCount = count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult Update(TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                          "Please correct it and try again."
                    });
                }

                _service.Update(entity);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult Delete(TKey id)
        {
            try
            {
                _service.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult Create(TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                        "Please correct it and try again."
                    });
                }
                var added = _service.Add(entity);
                return Json(new { Result = "OK", Record = added });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}