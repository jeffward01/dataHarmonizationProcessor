using DataHarmonizationProcessor.Data.Infrastructure;
using System.Linq;
using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        public License GetLicenseById(int id)
        {
            using (var context = new DataContext())
            {
                var license = context.Licenses
                    .Include("LicenseType")
                    .Include("LicensePriority")
                    .Include("LicenseStatus")
                    .Include("LicenseMethod")
                    .FirstOrDefault(c => c.LicenseId == id && c.Deleted == null);

                return license;
            }
        }

        public License GetLite(int id)
        {
            using (var context = new DataContext())
            {
                var license = context.Licenses
                    .FirstOrDefault(c => c.LicenseId == id);
                return license;
            }
        }
    }
}