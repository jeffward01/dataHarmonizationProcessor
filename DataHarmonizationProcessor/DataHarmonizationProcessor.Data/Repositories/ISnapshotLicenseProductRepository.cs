using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotLicenseProductRepository
    {
        Snapshot_LicenseProduct SaveSnapshotLicenseProduct(Snapshot_LicenseProduct licenseProductSnapshot);

        Snapshot_LicenseProduct GetLicenseProductSnapShotById(int id);

        bool DeleteLicenseProductSnapshot(int snapshotLicenseProductId);

        int? GetProductIdFromSnapshotLicenseProductId(int snapshotLicenseProductId);

        List<int> GetLicenseProductIds(int licenseId);

        List<Snapshot_LicenseProduct> GetAllLicenseProductsForLicenseId(int licenseId);

        Snapshot_LicenseProduct SaveMassiveSnapshotLicenseProduct(Snapshot_LicenseProduct licenseProductSnapshot);

        int? GetLicenseProductIdFromSnapshotLicenseProductId(int snapshotLicenseProductId);
    }
}