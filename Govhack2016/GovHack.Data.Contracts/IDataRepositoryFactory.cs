using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovHack.Data.Contracts.Repository_Interfaces;

namespace GovHack.Data.Contracts
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IBaseRepository;        
    }
}
