using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GovHack.Data.Contracts.Repository_Interfaces
{
    public interface IBaseRepository
    {

    }
    public interface IBaseRepository<T> : IBaseRepository where T : class
    {
        void Remove(T enitity);

        void Remove(string id);

        T Update(T entity);

        bool UpdateAll(IEnumerable<T> entities);

        IEnumerable<T> Get();

        T Get(string id);
    }
}