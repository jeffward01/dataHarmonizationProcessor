using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotConfigurationRepository
    {
        Snapshot_Configuration SaveSnapshotConfiguration(Snapshot_Configuration snapshotConfiguration);

        Snapshot_Configuration GetSnapshotConfigurationByConfigurationId(int configurationId);

        bool DeleteConfigurationSnapshot(int snapshotLicenseProductId);
    }
}