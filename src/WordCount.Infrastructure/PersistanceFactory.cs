using System;
using System.Collections.Generic;
using System.Text;
using WordCount.Infrastructure.PersistanceImplementaton;

namespace WordCount.Infrastructure
{
    internal class PersistanceFactory : IPersistanceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PersistanceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T GetService<T>() where T : IPersistanceImplemenation
        {
            var svc = _serviceProvider.GetService(typeof(T));
            if (svc == null)
                throw new Exception($"The service of type {typeof(T).FullName}, not exists in service collection");
            return (T)svc;
        }
    }
}
