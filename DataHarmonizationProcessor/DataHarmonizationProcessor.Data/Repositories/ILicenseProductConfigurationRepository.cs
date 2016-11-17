using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ILicenseProductConfigurationRepository
    {
        LicenseProductConfiguration GetLicenseProductConfigurationByProductIdAndLicenseProductConfigurationId(int licenseproductId, int product_configuration_id);
    }
}