using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class ErrorMessageService : EntityService<PortalErrorMessage>
    {
        public ErrorMessageService(UnitOfWork uow)
            : base(uow)
        {

        }
        public override IEnumerable<PortalErrorMessage> GetAll()
        {
            return this.repository.All();
        }

        public override PortalErrorMessage GetById(object Id)
        {
            return this.repository.GetById(Id);
        }

        public override PortalErrorMessage Add(PortalErrorMessage entity)
        {
            this.repository.Insert(entity);
            this.uow.Save();
            return entity;
        }

        public override void Update(PortalErrorMessage entity)
        {
            this.repository.Update(entity);
            this.uow.Save();
        }

        public override void Delete(object Id)
        {
            this.repository.Delete(Id);
            this.uow.Save();
        }


    }
}
