using System.Linq;
using System.Threading.Tasks;

namespace OneIdentity.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetByKey(params object[] keyValues);
        Task<T> GetByKeyAsync(params object[] keyValues);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(params object[] keyValues);
        Task DeleteAsync(params object[] keyValues);
    }
}
