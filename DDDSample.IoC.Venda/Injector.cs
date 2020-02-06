using DDDSample.Domain.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DDDSample.IoC
{
    public class Injector: IInjector
    {
        private ServiceProvider _serviceProvider;
        public Injector(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Get<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
