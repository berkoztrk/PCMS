using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCMS.Entities;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;

namespace PCMS.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal CMSEntities context;
        internal DbSet<TEntity> dbSet;


        public GenericRepository(CMSEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> All()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> AllReadOnly()
        {
            return dbSet.AsNoTracking();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Insert(TEntity Entity)
        {
            if (Entity == null) throw new ArgumentNullException("Entity");
            dbSet.Add(Entity);
        }

        public virtual void Delete(object Id)
        {
            TEntity entity = dbSet.Find(Id);
            Delete(entity);
        }

        public virtual void Delete(TEntity Entity)
        {
            if (Entity == null) throw new ArgumentNullException("Entity");
            if (context.Entry(Entity).State == EntityState.Detached)
            {
                dbSet.Attach(Entity);
            }
            dbSet.Remove(Entity);
        }

        public virtual void Update(TEntity Entity)
        {
            if (Entity == null) throw new ArgumentNullException("Entity");
            dbSet.Attach(Entity);
            context.Entry(Entity).State = EntityState.Modified;
        }

        public virtual void Update(TEntity Entity, params string[] changedPropertyNames)
        {
            dbSet.Attach(Entity);

            foreach (string property in changedPropertyNames)
            {
                context.Entry(Entity).Property(property).IsModified = true;
            }

        }

        public void Update(TEntity Entity, params Expression<Func<TEntity, object>>[] properties)
        {
            dbSet.Attach(Entity);
            DbEntityEntry<TEntity> entry = context.Entry(Entity);
            foreach (var selector in properties)
            {
                entry.Property(selector).IsModified = true;
            }
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).SingleOrDefault();
        }

        public virtual int GetCount()
        {
            return dbSet.Count();
        }

        public virtual IEnumerable<TEntity> GetAllWithPaging(int start, int pageSize, string orderBy)
        {
            return dbSet.OrderBy(orderBy).Skip(start).Take(pageSize).ToList();
        }

        public virtual IEnumerable<TEntity> OrderBy(string orderBy)
        {
            return GetAllWithPaging(0, GetCount(), orderBy);
        }


    }
}

