using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace LibraryManagement.Web.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer Container;

        public UnityDependencyResolver(IUnityContainer Container)
        {
            this.Container = Container;
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            Container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}