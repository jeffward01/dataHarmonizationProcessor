using DataHarmonizationProcessor.Application;
using Topshelf;

namespace DataHarmonizationProcessor
{
    internal class ServiceInit
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(dataHarmonizationService =>
            {
                dataHarmonizationService.SetServiceName("DataHarmonizationProcessor");
                dataHarmonizationService.SetDisplayName("DataHarmonizationProcessor");
                dataHarmonizationService.Service<DataHarmonizationService>();
                dataHarmonizationService.StartAutomatically();
                dataHarmonizationService.RunAsLocalSystem();
                dataHarmonizationService.EnableShutdown();
                dataHarmonizationService.EnableServiceRecovery(recovery =>
                    recovery.RestartService(1));
                dataHarmonizationService.UseNLog();
                dataHarmonizationService.DependsOnEventLog();
            });
        }
    }
}