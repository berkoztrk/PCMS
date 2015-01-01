using PCMS.Entities;
using PCMS.Repositories;
using PCMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCMS.Web.Controllers
{
    public class CustomerController : ParentController<PortalCustomer, Guid>
    {

        public CustomerController()
            : base()
        {
            base._service = new CustomerService(uow);
        }


    }
}
