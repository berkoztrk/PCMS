using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PCMS.Web.Helpers
{
    public static class UploadHelper
    {
        private const string BEGIN_PATH = @"..\..\";
        public static string SaveFile(HttpPostedFileBase file, string savePath)
        {
            string rootPath = BEGIN_PATH + savePath.Remove(0, 2);
            string fileName = System.IO.Path.GetFileName(file.FileName);
            string serverPath = HttpContext.Current.Server.MapPath(savePath);
            string path = System.IO.Path.Combine(serverPath, fileName);
            file.SaveAs(path);
            return rootPath + fileName;
        }
    }
}