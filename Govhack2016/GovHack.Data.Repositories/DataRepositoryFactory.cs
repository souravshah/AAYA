using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovHack.Data.Contracts;
using GovHack.Data.Contracts.Repository_Interfaces;
using Microsoft.Practices.Unity;

namespace GovHack.Data.Repositories
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get { return _container ?? (_container = Bootstrapper.Initialise()); }
        }

        public T GetDataRepository<T>() where T : IBaseRepository
        {
            return Container.Resolve<T>();
        }
    }
}
