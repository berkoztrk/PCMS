using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class ProviderService:EntityService<PortalProvider>
    {
        public ProviderService(UnitOfWork uow)
            : base(uow)
        {

        }
    }
}
