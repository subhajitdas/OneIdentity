using OneIdentity.Data.Contracts;
using System.Data.Entity;

namespace OneIdentity.Data.Repository
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;
        T GetRepositoryForType<T>() where T : class;
    }
}
