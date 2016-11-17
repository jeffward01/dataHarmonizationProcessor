using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotAdminAffiliationRepository
    {
        List<Snapshot_AdminAffiliation> GetAllAdminAffiliationsForSnapshotAdminId(int adminSnapshotId);

        bool DeletePhoneBySnapshotPhoneId(int snapshotPhoneId);

        Snapshot_AdminAffiliation SaveSnapshotAdminAffiliation(Snapshot_AdminAffiliation snapshotAdminAffiliation);
    }
}