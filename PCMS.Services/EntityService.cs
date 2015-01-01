using PCMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PCMS.Services
{
    public class EntityService<TEntity> where TEntity : class
    {
        protected UnitOfWork uow;
        protected GenericRepository<TEntity> repository;

        public EntityService(UnitOfWork uow)
        {
            this.uow = uow;
            this.repository = uow.GetRepository<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.repository.All();
        }

        public virtual TEntity GetById(object Id)
        {
            return this.repository.GetById(Id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            this.repository.Insert(entity);
            this.uow.Save();
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            this.repository.Update(entity);
            this.uow.Save();
        }

        public virtual void Delete(object Id)
        {
            this.repository.Delete(Id);
            this.uow.Save();
        }

        public virtual int GetCount()
        {
            return this.repository.GetCount();
        }
        public virtual IEnumerable<TEntity> GetAllWithPaging(int start, int pageSize, string orderBy)
        {
            return this.repository.GetAllWithPaging(start, pageSize, orderBy);
        }

        public virtual IEnumerable<TEntity> OrderBy(string orderBy)
        {
            return this.repository.OrderBy(orderBy);
        }


    }
}
