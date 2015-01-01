using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PCMS.Web.Controllers
{
    interface IPCMSController<TEntity,TKey> where TEntity : class
    {
        ActionResult GetList();
        JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null);
        JsonResult Update(TEntity entity);
        JsonResult Delete(TKey id);
        JsonResult Create(TEntity entity);
    }
}
