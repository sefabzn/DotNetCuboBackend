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

            builder.RegisterType<OperatorIsEmriManager>().As<IOperatorIsEmriService>().SingleInstance();
            builder.RegisterType<EfOperatorIsEmriDal>().As<IOperatorIsEmriDal>().SingleInstance();


            builder.RegisterType<MakineKesizHizTablosuManager>().As<IMakineKesitHizTablosuService>().SingleInstance();
            builder.RegisterType<EfMakineKesitHizTablosuDal>().As<IMakineKesitHizTablosuDal>().SingleInstance();

            builder.RegisterType<CctvGenelDizaynManager>().As<ICctvGenelDizaynService>().SingleInstance();
            builder.RegisterType<EfCctvGenelDizaynDal>().As<ICctvGenelDizaynDal>().SingleInstance();
            builder.RegisterType<CctvDamarDizaynManager>().As<ICctvDamarDizaynService>().SingleInstance();
            builder.RegisterType<EfCctvDamarDizaynDal>().As<ICctvDamarDizaynDal>().SingleInstance();
            builder.RegisterType<CctvIsEmriManager>().As<ICctvIsEmriService>().SingleInstance();
            builder.RegisterType<EfCctvIsEmriDal>().As<ICctvIsEmriDal>().SingleInstance();

            builder.RegisterType<TelefonGenelDizaynManager>().As<ITelefonGenelDizaynService>().SingleInstance();
            builder.RegisterType<EfTelefonGenelDizaynDal>().As<ITelefonGenelDizaynDal>().SingleInstance();
            builder.RegisterType<TelefonDamarDizaynManager>().As<ITelefonDamarDizaynService>().SingleInstance();
            builder.RegisterType<EfTelefonDamarDizaynDal>().As<ITelefonDamarDizaynDal>().SingleInstance();
            builder.RegisterType<TelefonIsEmriManager>().As<ITelefonIsEmriService>().SingleInstance();
            builder.RegisterType<EfTelefonIsEmriDal>().As<ITelefonIsEmriDal>().SingleInstance();

            builder.RegisterType<YanginGenelDizaynManager>().As<IYanginGenelDizaynService>().SingleInstance();
            builder.RegisterType<EfYanginGenelDizaynDal>().As<IYanginGenelDizaynDal>().SingleInstance();
            builder.RegisterType<YanginDamarDizaynManager>().As<IYanginDamarDizaynService>().SingleInstance();
            builder.RegisterType<EfYanginDamarDizaynDal>().As<IYanginDamarDizaynDal>().SingleInstance();
            builder.RegisterType<YanginIsEmriManager>().As<IYanginIsEmriService>().SingleInstance();
            builder.RegisterType<EfYanginIsEmriDal>().As<IYanginIsEmriDal>().SingleInstance();


            builder.RegisterType<KesitYapisiManager>().As<IKesitYapisiService>().SingleInstance();
            builder.RegisterType<EfKesitYapisiDal>().As<IKesitYapisiDal>().SingleInstance();

            builder.RegisterType<SarfiyatManager>().As<ISarfiyatService>().SingleInstance();
            builder.RegisterType<EfSarfiyatDal>().As<ISarfiyatDal>().SingleInstance();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ExchangeRateManager>().As<IExchangeRateService>().SingleInstance();
            builder.RegisterType<EfExchangeRateDal>().As<IExchangeRateDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
