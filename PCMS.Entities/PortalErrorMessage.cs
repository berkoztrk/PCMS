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
    
    public partial class PortalErrorMessage
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public PortalErrorMessage()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
