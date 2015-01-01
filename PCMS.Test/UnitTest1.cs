using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCMS.Entities;

namespace PCMS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guids_Are_Not_Empty_Test()
        {
            PortalCustomer pc = new PortalCustomer();
            PortalErrorMessage pem = new PortalErrorMessage();
            PortalPlatformType ppt = new PortalPlatformType();
            PortalProduct pp = new PortalProduct();
            PortalProductType pptype = new PortalProductType();
            PortalUser pu = new PortalUser();

            Assert.AreNotEqual(pc.Id,Guid.Empty);
            Assert.AreNotEqual(pem.Id, Guid.Empty);
            Assert.AreNotEqual(ppt.Id, Guid.Empty);
            Assert.AreNotEqual(pp.Id, Guid.Empty);
            Assert.AreNotEqual(pptype.Id, Guid.Empty);
            Assert.AreNotEqual(pu.Id, Guid.Empty);
        }



    }
}
