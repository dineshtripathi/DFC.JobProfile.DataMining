namespace DFC.JobProfile.ExportService
{
    using Autofac;
    using Microsoft.Extensions.Configuration;

    public class AutofacModuleLoader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public static void Loader(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder();
            builder.RegisterModule<DataImporter.RegistrationModuleAutofac>();
            builder.RegisterModule<Dapper.RegistrationModuleAutofac>();
        }
    }
}