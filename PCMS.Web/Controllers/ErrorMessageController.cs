using PCMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCMS.Web.Controllers
{
    public class ErrorMessageController : ParentController<PortalErrorMessage,Guid>
    {
        public ErrorMessageController()
            : base()
        {

        }

    }
}
