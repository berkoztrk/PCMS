using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PCMS.Web.Helpers
{
    public static class UploadHelper
    {
        private const string IMAGE_SAVE_PATH_SERVER = @"~/TestImagePath/";
        private const string IMAGE_SAVE_PATH_URL = "/TestImagePath/";

        public static string SaveFile(HttpPostedFileBase file)
        {
            string imageName = System.IO.Path.GetFileName(file.FileName);
            string filePath = HttpContext.Current.Server.MapPath(IMAGE_SAVE_PATH_SERVER + imageName);
            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

            file.SaveAs(filePath);
            return baseUrl + IMAGE_SAVE_PATH_URL + imageName;
        }
    }
}