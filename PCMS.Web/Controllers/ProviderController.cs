using PCMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCMS.Services;

namespace PCMS.Web.Controllers
{
    public class ProviderController : ParentController<PortalProvider,Guid>
    {
        public ProviderController()
            : base()
        {
            base._service = new ProviderService(uow);
        }

        public override JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int count = _service.GetCount();
                var items = _service.GetAllWithPaging(jtStartIndex, jtPageSize, jtSorting)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Name = p.Name
                    });
                return Json(new { Result = "OK", Records = items, TotalRecordCount = count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        //[HttpPost]
        //public JsonResult GetProductsById(Guid providerId)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}
    }
}
