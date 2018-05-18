using Autofac;
using Autofac.Extras.DynamicProxy;
using AutofacConfiguration;
using DFC.JobProfile.DataAccess;
namespace DFC.JobProfile.DataImporter
{
    public class RegistrationModuleAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteFinityJobProfileImportData>().AsImplementedInterfaces().SingleInstance()
                .PropertiesAutowired();
            builder.RegisterType<HttpClientService>().AsImplementedInterfaces().SingleInstance()
                .PropertiesAutowired();
            builder.RegisterType<SitefinityODataContext>().As<IOdataContext>().AsImplementedInterfaces().SingleInstance()
                .PropertiesAutowired();
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(LogInterceptor.name, LogInterceptor.name)
                .PropertiesAutowired();
        }
    }
}