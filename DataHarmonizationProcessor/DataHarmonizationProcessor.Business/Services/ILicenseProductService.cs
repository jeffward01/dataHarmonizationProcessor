using System.Collections.Generic;
using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Business.Services
{
    public interface ILicenseProductService
    {
        List<LicenseProduct> GetProductsNew(int licenseId);
    }
}