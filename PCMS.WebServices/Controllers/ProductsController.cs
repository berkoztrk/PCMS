using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCMS.Entities;
using PCMS.Services;
using PCMS.Repositories;
using PCMS.Entities.AnonymousTypes;
using System.Web.Http.Cors;

namespace PCMS.WebServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController 
    {
        private ProvidersProductsService _providersProductsService;
        private UnitOfWork unitOfWork;
        public ProductsController()
        {
            this.unitOfWork = new UnitOfWork();
            this._providersProductsService = new ProvidersProductsService(unitOfWork);
        }

        public IEnumerable<ProviderProduct> GetAllProducts()
        {
            return this._providersProductsService.GetAll()
                .Select(p => new ProviderProduct
                {
                    Id = p.Id,
                    ProductId = p.PortalProduct.Id,
                    ProductName = p.PortalProduct.Name,
                    ProductPictureURL = p.PortalProduct.PictureURL,
                    Price = p.Price,
                    ProviderName = p.PortalProvider.Name,
                    ProviderId = p.ProviderId,
                    PlatformTypeId = p.PlatformTypeId,
                    PlatformTypeName = p.PortalPlatformType.Name,
                    ProductCode = p.PortalProduct.Code
                });
        }
    }
}
