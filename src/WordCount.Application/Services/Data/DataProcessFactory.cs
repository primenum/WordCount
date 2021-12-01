using System;
using System.Collections.Generic;
using System.Text;

namespace WordCount.Application.Services.Data
{
    internal class DataProcessFactory : IDataProcessFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DataProcessFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() where T : IDataProcess
        {
            var svc = _serviceProvider.GetService(typeof(T));
            if (svc == null)
                throw new Exception($"The service of type {typeof(T).FullName}, not exists in service collection");
            return (T)svc;
        }
    }
}
