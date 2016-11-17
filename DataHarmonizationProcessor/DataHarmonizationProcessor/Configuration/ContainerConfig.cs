using Autofac;

namespace DataHarmonizationProcessor.Configuration
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(ContainerConfig).Assembly);
            return builder.Build();
        }
    }
}