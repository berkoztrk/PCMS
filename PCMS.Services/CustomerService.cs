using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class CustomerService:EntityService<PortalCustomer>
    {
        public CustomerService(UnitOfWork uow)
            : base(uow)
        {

        }
        public override IEnumerable<PortalCustomer> GetAll()
        {
            return this.repository.All();
        }

        public override PortalCustomer GetById(object Id)
        {
            return this.repository.GetById(Id);
        }

        public override PortalCustomer Add(PortalCustomer entity)
        {
            this.repository.Insert(entity);
            this.uow.Save();
            return entity;
        }

        public override void Update(PortalCustomer entity)
        {
            this.repository.Update(entity);
            this.uow.Save();
        }

        public override void Delete(object Id)
        {
            this.repository.Delete(Id);
            this.uow.Save();
        }

        public override int GetCount()
        {
            return this.repository.GetCount();
        }

        public override IEnumerable<PortalCustomer> GetAllWithPaging(int start, int pageSize, string orderBy)
        {
            return this.repository.GetAllWithPaging(start, pageSize, orderBy);
        }
    }
}
