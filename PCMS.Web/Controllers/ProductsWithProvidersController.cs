using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCMS.Entities;
using PCMS.Services;

namespace PCMS.Web.Controllers
{
    public class ProductsWithProvidersController : ParentController<PortalProvidersProduct,int>
    {
        private ProvidersProductsService _providersProductsService;
        public ProductsWithProvidersController()
            : base()
        {
            base._service = new ProvidersProductsService(uow);
            this._providersProductsService = new ProvidersProductsService(uow);
        }

        public override JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                ProviderService _providerService = new ProviderService(this.uow);
                int count = _providerService.GetCount();
                var items = _providerService.GetAllWithPaging(jtStartIndex, jtPageSize, jtSorting)
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

        public  JsonResult GetProductsByProviderID(Guid ProviderId,int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                ProvidersProductsService _ppService = new ProvidersProductsService(this.uow);
                int count = _ppService.GetCountFilterByProvider(ProviderId);
                var items = _ppService.GetProductsByProviderId(ProviderId, jtStartIndex, jtPageSize, jtSorting);

                
                return Json(new { Result = "OK", Records = items, TotalRecordCount = count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public override JsonResult Update(PortalProvidersProduct entity)
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

                ProvidersProductsService pps = new ProvidersProductsService(uow);
                pps.Update(entity);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public  override JsonResult Create(PortalProvidersProduct entity)
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
                var added = _providersProductsService.Add(entity);
                return Json(new { Result = "OK", Record = added });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
