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
    
    public partial class PortalProvider
    {
        public PortalProvider()
        {
            this.PortalProvidersProducts = new HashSet<PortalProvidersProduct>();
            this.Id = Guid.NewGuid();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<PortalProvidersProduct> PortalProvidersProducts { get; set; }
    }
}
