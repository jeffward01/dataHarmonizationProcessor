using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ILicenseRepository
    {
        License GetLicenseById(int id);
        License GetLite(int id);
    }
}