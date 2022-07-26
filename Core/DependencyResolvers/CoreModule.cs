using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddMemoryCache();

            services.AddSingleton<Stopwatch>();

        }
    }
}
