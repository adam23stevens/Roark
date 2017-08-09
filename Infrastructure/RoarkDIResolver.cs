using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;
using Abstract;
using Concrete;
using RepositoryContract;
using Repository;
using Access;

namespace Roark.Contract.Infrastructure
{
    public class RoarkDIResolver : IDependencyResolver
    {
        private IKernel kernel;

        public RoarkDIResolver(IKernel _kernel)
        {
            kernel = _kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IRoarkService>().To<RoarkService>();
            kernel.Bind<IRepository>().To<RoarkRepository>();
            kernel.Bind<IRoarkContext>().To<RoarkContext>();
            kernel.Bind<IUserHelper>().To<UserHelper>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
