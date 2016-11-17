using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotProductHeaderRepository
    {
        Snapshot_ProductHeader SaveSnapshotProductHeader(Snapshot_ProductHeader snapshotProductHeader);

        Snapshot_ProductHeader GetSnapshotProductHeaderBySnapshotProductHeaderId(int productHeaderId);

        int GetSnapshotProductHeaderBySnapshotLicenseProductId(int snapshotLicenseProductId);

        bool DeleteProductHeaderSnapshotBySnapshotId(int snapshotProductHeaderId);

        Snapshot_ProductHeader GetProductHeaderByProductHeaderId(int productHeaderId);
    }
}