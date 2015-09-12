using OneIdentity.Data.Contracts;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace OneIdentity.Data.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public DbContext DbContext { get; set; }
        public DbSet<T> DbSet { get; set; }

        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("dbContext");
            }
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetByKey(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public virtual async Task<T> GetByKeyAsync(params object[] keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {

            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(params object[] keyValues)
        {
            T entity = GetByKey(keyValues);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            T entity = await GetByKeyAsync(keyValues);
            if (entity != null)
            {
                Delete(entity);
            }
        }
    }
}
