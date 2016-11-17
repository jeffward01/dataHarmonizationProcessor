using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Business.Managers
{
    public interface IDataHarmonizationManager
    {
        bool CreateLicenseSnapshot(int licenseId, DataHarmonizationQueue queueItem);
        bool DeleteLicenseSnapshot(int licenseId, DataHarmonizationQueue queueItem);
    }
}