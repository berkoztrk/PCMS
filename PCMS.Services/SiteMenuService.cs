using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class SiteMenuService:EntityService<PortalSiteMenu>
    {
        public SiteMenuService(UnitOfWork uow)
            : base(uow)
        {

        }

    }
}
