using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Business.Managers
{
    public interface ISnapshotLicenseManager
    {
        bool DoesSnapshotExists(int licenseId);
        Snapshot_License SaveSnapshotLicense(Snapshot_License snapshotLicense);
        Snapshot_License GetSnapshotLicenseBySnapshotLicenseId(int snapshotLicenseId);
        bool DeleteLicenseSnapshotAndAllChildren(int licenseId);
    }
}