using Autofac;
using AutoMapper;
using System.Reflection;

namespace Business.Extensions

{
    public static class AutofacMapperExtension
    {
        public static void AddAutoMapper(this ContainerBuilder builder, Assembly[] assemblies)
        {
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var assembly in assemblies)
                {
                    cfg.AddMaps(assembly);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
