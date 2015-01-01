using PCMS.Entities;
using PCMS.Repositories;
using PCMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCMS.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Web.Controllers
{
    public class ProductController : ParentController<PortalProduct,Guid>
    {
        private const string IMAGE_SAVE_PATH = @"~\TestImagePath\";
        private ProductTypeService _productTypeService;
        private ProductService _productService;

        public ProductController():base()
        {
            base._service = new ProductService(uow);
            _productTypeService = new ProductTypeService(uow);
            _productService = new ProductService(uow);
        }


        [HttpPost]
        public override JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int count = _service.GetCount();
                var products = _service.GetAllWithPaging(jtStartIndex, jtPageSize, jtSorting).Select(p => new { 
                    Id=p.Id,
                    Name=p.Name,
                    DateUpdated=p.DateUpdated,
                    DateCreated=p.DateCreated,
                    Code = p.Code,
                    ProductTypeId = p.ProductTypeId,
                    PictureURL = p.PictureURL,
                    Description = p.Description
                });
                return Json(new { Result = "OK", Records = products, TotalRecordCount = count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public  JsonResult CreateWithFile(PortalProduct entity,HttpPostedFileBase file)
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

                if (file != null)
                {
                    string filePath = UploadHelper.SaveFile(file, IMAGE_SAVE_PATH);
                    entity.PictureURL = filePath;
                }
                var added = _service.Add(entity);
                return Json(new { Result = "OK", Record = added },"text/html", System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateWithFile(PortalProduct entity,HttpPostedFileBase file)
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
                if (file != null)
                {
                    string filePath = UploadHelper.SaveFile(file, IMAGE_SAVE_PATH);
                    entity.PictureURL = filePath;
                }
                _productService.Update(entity);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetTypeOptions()
        {
            try
            {
                return Json(new { Result = "OK", Options = _productTypeService.GetAll().Select(p => new { DisplayText = p.Name, Value = p.Id }) });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
            
        }


        [HttpPost]
        public JsonResult GetProductOptions()
        {
            try
            {
                return Json(new { Result = "OK", Options = _productService.GetAll().Select(p => new { DisplayText = p.Name, Value = p.Id }).OrderBy(p=>p.DisplayText) });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


    }
}
