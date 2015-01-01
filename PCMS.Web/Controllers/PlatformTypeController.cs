using PCMS.Entities;
using PCMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCMS.Web.Controllers
{
    public class PlatformTypeController : ParentController<PortalPlatformType,Guid>
    {
        private PlatformTypeService _platformTypeService;

        public PlatformTypeController()
            : base()
        {
            base._service = new PlatformTypeService(uow);
            this._platformTypeService = new PlatformTypeService(uow);
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

        [HttpPost]
        public JsonResult GetPlatformOptions()
        {
            try
            {
                return Json(new { Result = "OK", Options = _platformTypeService.GetAll().Select(p => new { DisplayText = p.Name, Value = p.Id }) });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
