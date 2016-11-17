using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotLicenseRepository
    {
        Snapshot_License SaveSnapshotLicense(Snapshot_License licenseSnapshot);

        Snapshot_License GetLicenseSnapShotById(int id);

        Snapshot_License GetSnapshotLicenseByCloneLicenseId(int licenseId);

        bool DoesLicenseSnapshotExist(int licenseId);

        bool DeleteSnapshotLicense(Snapshot_License licenseId);
    }
}