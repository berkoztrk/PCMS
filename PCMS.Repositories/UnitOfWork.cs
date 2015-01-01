using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCMS.Entities;

namespace PCMS.Repositories
{
    public class UnitOfWork : IDisposable
    {

        private  CMSEntities context = new CMSEntities();


        private bool disposed = false;

        public  GenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
