namespace DFC.JobProfile.DataExporter
{
    using Autofac;

    public class RegistrationModuleAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces().SingleInstance()
                .PropertiesAutowired();
        }
    }
}