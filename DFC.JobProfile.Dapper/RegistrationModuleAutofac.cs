namespace DFC.JobProfile.Dapper
{
    using Autofac;
    using Autofac.Extras.DynamicProxy;
    using AutofacConfiguration;

    public class RegistrationModuleAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(LogInterceptor.name, LogInterceptor.name)
                .PropertiesAutowired();
        }
    }
}
