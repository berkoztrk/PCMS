using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class ProductTypeService : EntityService<PortalProductType>
    {

        public ProductTypeService(UnitOfWork uow)
            : base(uow)
        {

        }

        public override PortalProductType GetById(object Id)
        {
            return this.repository.GetById(Id);
        }

        public override IEnumerable<PortalProductType> GetAll()
        {
            return this.repository.All();
        }

        public override PortalProductType Add(PortalProductType entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public override void Update(PortalProductType entity)
        {
            throw new NotImplementedException();
        }

        public override int GetCount()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PortalProductType> GetAllWithPaging(int start, int pageSize, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
