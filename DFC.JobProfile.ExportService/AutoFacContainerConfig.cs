namespace DFC.JobProfile.ExportService
{
    using System;
    using Autofac;
    using AutofacConfiguration;
    using Castle.DynamicProxy;

    public static class AutoFacContainerConfig
    {
        public static ILifetimeScope RegisterLifetimeScope()
        {
            var builder = new ContainerBuilder();
            RegisterTypeWithContrainer(builder);
            ILifetimeScope containerLifetimeScope = builder.Build();
            return containerLifetimeScope;
        }

        private static void RegisterTypeWithContrainer(ContainerBuilder builder)
        {
            //Register the Log Interceptor, which will log out to the console of the application. Anything registered with 'log-calls' will be intercepted
            builder.Register(c => new LogInterceptor(Console.Out)).AsSelf().Named<IInterceptor>(LogInterceptor.name);

            //Register the repository, make sure 'EnableInterfaceInterceptors' is called, this is important in letting Castle know it has Interceptors
            AutofacModuleLoader.Loader(builder);
        }
    }
}