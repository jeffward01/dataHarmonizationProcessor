using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Business.Managers
{
    public interface ISnapshotLicenseProductManager
    {
        Snapshot_LicenseProduct SaveSnapshotLicenseProduct(Snapshot_LicenseProduct snapshotLicenseProduct);
        Snapshot_LicenseProduct GetSnapshotLicenseProductByLicenseProductId(int snapshotLicenseProductId);
    }
}