using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCMS.Entities;
using PCMS.Repositories;
using System.Linq.Dynamic;
using PCMS.Entities.AnonymousTypes;
namespace PCMS.Services
{
    public class ProvidersProductsService : EntityService<PortalProvidersProduct>
    {
        public ProvidersProductsService(UnitOfWork uow)
            : base(uow)
        {
        }

        public override PortalProvidersProduct Add(PortalProvidersProduct entity)
        {
            PortalProvidersProduct ppp = new PortalProvidersProduct()
            {
                PlatformTypeId = entity.PlatformTypeId,
                Price = entity.Price,
                ProductId = entity.ProductId,
                ProviderId = entity.ProviderId
            };
            this.repository.Insert(ppp);
            this.uow.Save();
            return ppp;
        }

        public override void Update(PortalProvidersProduct entity)
        {

            PortalProvidersProduct ppp = this.repository.GetById(entity.Id);
            ppp.Price = entity.Price;
            ppp.PlatformTypeId = entity.PlatformTypeId;
            ppp.ProductId = entity.ProductId;

            this.repository.Update(ppp, p => p.Price, p => p.PlatformTypeId, p => p.ProductId);
            this.uow.Save();
        }

        public int GetCountFilterByProvider(Guid ProviderId)
        {
            return GetAll().Where(p => p.ProviderId == ProviderId).Select(p => p.ProductId).Count();
        }

        public IEnumerable<ProviderProduct> GetProductsByProviderId(Guid ProviderId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            return GetAll().Where(p => p.ProviderId == ProviderId)
                .Select(p => new ProviderProduct
                {
                    Id = p.Id,
                    Price = p.Price,
                    ProductId = p.ProductId,
                    ProductCode = p.PortalProduct.Code,
                    ProductName = p.PortalProduct.Name,
                    PlatformTypeId = p.PlatformTypeId
                }).AsQueryable()
                .OrderBy(jtSorting)
                .Take(jtPageSize)
                .Skip(jtStartIndex)
                .ToList();
        }

        public IEnumerable<PortalProvidersProduct> GetByProviderId(Guid ProviderId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            return GetAll().Where(p => p.ProviderId == ProviderId).AsQueryable<PortalProvidersProduct>().OrderBy(jtSorting).Take(jtPageSize).Skip(jtStartIndex);
        }
    }
}
