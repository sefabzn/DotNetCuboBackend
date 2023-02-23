using Core.CrossCuttingConcern.Logging;
using Core.CrossCuttingConcern.Logging.Nlog;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, params ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services); // bu sayede ICoreModule den inherit eden farklı modellerin farklı içerikli loadlarının hepsini teker teker kullanabiliyoruz
            }
            return ServiceTool.Create(services);
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {

            services.AddSingleton<ILoggerService, LoggerManager>();
        }


    }
}
