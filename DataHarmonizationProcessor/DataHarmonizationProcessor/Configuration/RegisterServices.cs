using Autofac;
using DataHarmonizationProcessor.Business;
using DataHarmonizationProcessor.Business.Logging;
using DataHarmonizationProcessor.Business.Managers;
using DataHarmonizationProcessor.Business.Services;
using NLog.Internal;
using System.Reflection;
using Module = Autofac.Module;

namespace DataHarmonizationProcessor.Configuration
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Provider"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces();

            builder.RegisterType<TimeSpanUtil>().As<ITimeSpanUtil>();
            builder.RegisterType<ServiceManager>().As<IServiceManager>();

            builder.RegisterType<ConfigurationManager>().As<IConfigurationManager>();
            builder.RegisterType<DataHarmonizationLogManager>().As<IDataHarmonizationLogManager>();
            builder.RegisterType<ServiceManager>().As<IServiceManager>();
            builder.RegisterType<SnapshotLicenseManager>().As<ISnapshotLicenseManager>();
            builder.RegisterType<SnapshotManager>().As<ISnapshotManager>();
            builder.RegisterType<SnapshotLicenseProductManager>().As<ISnapshotLicenseProductManager>();

            builder.RegisterType<DataHarmonizationManager>().As<IDataHarmonizationManager>();
            base.Load(builder);
        }
    }
}