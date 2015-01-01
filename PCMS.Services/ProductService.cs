using PCMS.Entities;
using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class ProductService : EntityService<PortalProduct>
    {
        public ProductService(UnitOfWork uow)
            : base(uow)
        {

        }

        public override IEnumerable<PortalProduct> GetAll()
        {
            return this.repository.All();
        }

        public override PortalProduct GetById(object Id)
        {
            return this.repository.GetById(Id);
        }

        public override PortalProduct Add(PortalProduct entity)
        {
            PortalProduct product = new PortalProduct()
           {
               Id = Guid.NewGuid(),
               Code = entity.Code,
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               Description = entity.Description,
               Name = entity.Name,
               PictureURL = entity.PictureURL,
               ProductTypeId = entity.ProductTypeId
           };

            this.repository.Insert(product);
            this.uow.Save();
            return product;
        }

        public override void Delete(object Id)
        {
            this.repository.Delete(Id);
            this.uow.Save();
        }

        public override void Update(PortalProduct entity)
        {
            PortalProduct pp = new PortalProduct()
            {
                Code = entity.Code,
                DateCreated = entity.DateCreated,
                DateUpdated = DateTime.Now,
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                PictureURL = entity.PictureURL != null ? entity.PictureURL : this.repository.AllReadOnly().Where( p => p.Id == entity.Id).FirstOrDefault().PictureURL,
                ProductTypeId = entity.ProductTypeId
            };
           
            this.repository.Update(pp);
            this.uow.Save();
        }


        public override int GetCount()
        {
            return this.repository.GetCount();
        }

        public override IEnumerable<PortalProduct> GetAllWithPaging(int start, int pageSize,string orderBy)
        {
            return this.repository.GetAllWithPaging(start, pageSize, orderBy);
        }
    }
}
