using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Repository
{
    public class RepositoryFactories
    {
        public Dictionary<Type, Func<DbContext, object>> Factories { get; set; }

        public RepositoryFactories()
        {
            Factories = GetFactories();
        }

        private Dictionary<Type, Func<DbContext, object>> GetFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {

            };
        }

        public RepositoryFactories(Dictionary<Type, Func<DbContext, object>> factories)
        {
            Factories = factories;
        }

        public Func<DbContext, object> GetFactoryForEntityType<T>() where T : class
        {
            return dbContext => new EFRepository<T>(dbContext);
        }

        public Func<DbContext, object> GetFactoryForType<T>() where T : class
        {
            Func<DbContext, object> factory;
            Factories.TryGetValue(typeof(T), out factory);
            return factory;
        }
    }
}
