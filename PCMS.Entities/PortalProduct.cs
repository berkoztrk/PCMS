//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCMS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PortalProduct
    {
        public PortalProduct()
        {
            this.PortalProvidersProducts = new HashSet<PortalProvidersProduct>();
            this.Id = Guid.NewGuid();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public System.Guid ProductTypeId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public string PictureURL { get; set; }
        public string Description { get; set; }
    
        public virtual PortalProductType PortalProductType { get; set; }
        public virtual ICollection<PortalProvidersProduct> PortalProvidersProducts { get; set; }
    }
}
