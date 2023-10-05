using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Extensions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
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

            builder.RegisterType<OperatorIsEmriManager>().As<IOperatorIsEmriService>().SingleInstance();
            builder.RegisterType<EfOperatorIsEmriDal>().As<IOperatorIsEmriDal>().SingleInstance();


            builder.RegisterType<MakineKesizHizTablosuManager>().As<IMakineKesitHizTablosuService>().SingleInstance();
            builder.RegisterType<EfMakineKesitHizTablosuDal>().As<IMakineKesitHizTablosuDal>().SingleInstance();



            builder.RegisterType<GenelDizaynManager>().As<IGenelDizaynService>().SingleInstance();
            builder.RegisterType<EfGenelDizaynDal>().As<IGenelDizaynDal>().SingleInstance();
            builder.RegisterType<DamarDizaynManager>().As<IDamarDizaynService>().SingleInstance();
            builder.RegisterType<EfDamarDizaynDal>().As<IDamarDizaynDal>().SingleInstance();

            builder.RegisterType<IsEmriManager>().As<IIsEmriService>().SingleInstance();
            builder.RegisterType<EfIsEmriDal>().As<IIsEmriDal>().SingleInstance();

            builder.RegisterType<KesitYapisiManager>().As<IKesitYapisiService>().SingleInstance();
            builder.RegisterType<EfKesitYapisiDal>().As<IKesitYapisiDal>().SingleInstance();

            builder.RegisterType<SarfiyatManager>().As<ISarfiyatService>().SingleInstance();
            builder.RegisterType<EfSarfiyatDal>().As<ISarfiyatDal>().SingleInstance();


            builder.RegisterType<ProcessManager>().As<IProcessService>().SingleInstance();
            builder.RegisterType<EfProcessDal>().As<IProcessDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<ExchangeRateManager>().As<IExchangeRateService>().SingleInstance();
            builder.RegisterType<EfExchangeRateDal>().As<IExchangeRateDal>().SingleInstance();



            builder.RegisterType<TokenManager>().As<ITokenService>().InstancePerLifetimeScope();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.AddAutoMapper(new[] { System.Reflection.Assembly.GetExecutingAssembly() });

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
