using OneIdentity.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Repository
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;
        T GetRepositoryForType<T>() where T : class;
    }
}
