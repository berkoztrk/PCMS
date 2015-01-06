using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Entities.AnonymousTypes
{
    public class ProviderProduct
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }

        public string ProductPictureURL { get; set; }
        public Guid PlatformTypeId { get; set; }
        public string PlatformTypeName { get; set; }

        public Guid ProviderId { get; set; }

        public string ProviderName { get; set; }

    }
}
