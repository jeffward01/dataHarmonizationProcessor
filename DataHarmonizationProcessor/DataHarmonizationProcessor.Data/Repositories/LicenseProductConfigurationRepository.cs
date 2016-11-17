using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHarmonizationProcessor.Data.Infrastructure;
using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class LicenseProductConfigurationRepository : ILicenseProductConfigurationRepository
    {

        public LicenseProductConfiguration GetLicenseProductConfigurationByProductIdAndLicenseProductConfigurationId(int licenseproductId, int product_configuration_id)
        {
            using (var context = new DataContext())
            {
                return context.LicenseProductConfigurations.Where(x => x.LicenseProductId == licenseproductId && x.LicenseProductConfigurationId == product_configuration_id && !x.Deleted.HasValue).FirstOrDefault();
            }
        }
    }
}
