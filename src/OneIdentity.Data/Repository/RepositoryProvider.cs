using OneIdentity.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Repository
{
    public class RepositoryProvider: IRepositoryProvider
    {
        protected RepositoryFactories RepositoryFactories { get; set; }
        public DbContext DbContext { get; set; }
        private Dictionary<Type, object> Repositories {get; set;}

        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            RepositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public RepositoryProvider(RepositoryFactories repositoryFactories, DbContext dbContext)
            : this(repositoryFactories)
        {
            DbContext = dbContext;
        }

        public virtual IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return MakeRepository<IRepository<T>>(RepositoryFactories.GetFactoryForEntityType<T>(), DbContext);
        }

        public virtual T GetRepositoryForType<T>() where T : class
        {
            return MakeRepository<T>(RepositoryFactories.GetFactoryForType<T>(), DbContext);
        }

        protected T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            object repository;
            if (!Repositories.TryGetValue(typeof(T), out repository))
            {
                repository = factory(dbContext);
                Repositories.Add(typeof(T), repository);
            }
            return (T)repository;
        }
    }
}
