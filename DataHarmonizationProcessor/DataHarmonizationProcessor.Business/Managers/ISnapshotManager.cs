using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;
using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Business.Managers
{
    public interface ISnapshotManager
    {
        bool DoesLicenseSnapshotExist(int licenseId);
        Snapshot_License GeLicenseSnapshotByLicenseId(int licenseId);
        bool TakeLicenseSnapshot(License licenseToBeSnapshotted, List<LicenseProduct> licenseProducts);
        bool DeleteLicenseSnapshot(int licenseSnapshotId);
    }
}