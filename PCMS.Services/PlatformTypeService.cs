using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class PlatformTypeService:EntityService<PortalPlatformType>
    {
        public PlatformTypeService(UnitOfWork uow):base(uow)
        {

        }
    }
}
