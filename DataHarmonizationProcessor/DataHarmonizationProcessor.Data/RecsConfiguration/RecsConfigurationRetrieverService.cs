using UMPG.USL.Common;

namespace DataHarmonizationProcessor.Data.RecsConfiguration
{
    public class RecsConfigurationRetrieverService : IRecsConfigurationRetrieverService
    {
        public RecsConfiguration RecsConfiguration { get; }

        public RecsConfigurationRetrieverService()
        {
            RecsConfiguration = new RecsConfiguration
            {
                SecureUrl = ConfigHelper.GetAppSettingValue("RecsSecureUrl", true),
                UnSecureUrl = ConfigHelper.GetAppSettingValue("RecsUnSecureUrl", true),
                WorksUnSecureUrl = ConfigHelper.GetAppSettingValue("QualifyingWorksUnSecureUrl", true)
            };
        }
    }
}