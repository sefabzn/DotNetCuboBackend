using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutoFacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KullaniciManager>().As<IKullaniciService>().SingleInstance();
            builder.RegisterType<EfKullaniciDal>().As<IKullaniciDal>().SingleInstance();

            builder.RegisterType<MakineManager>().As<IMakineService>().SingleInstance();
            builder.RegisterType<EfMakineDal>().As<IMakineDal>().SingleInstance();

            builder.RegisterType<KabloUretimManager>().As<IKabloUretimService>().SingleInstance();
            builder.RegisterType<EfKabloUretimDal>().As<IKabloUretimDal>().SingleInstance();

            builder.RegisterType<CctvGenelDizaynManager>().As<ICctvGenelDizaynService>().SingleInstance();
            builder.RegisterType<EfCctvGenelDizaynDal>().As<ICctvGenelDizaynDal>().SingleInstance();

            builder.RegisterType<CctvDamarDizaynManager>().As<ICctvDamarDizaynService>().SingleInstance();
            builder.RegisterType<EfCctvDamarDizaynDal>().As<ICctvDamarDizaynDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
