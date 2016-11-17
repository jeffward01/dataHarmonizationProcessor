using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotComposerAffiliationBaseRepository
    {
        Snapshot_ComposerAffiliationBase SaveComposerAffiliatioBasenSnapshot(Snapshot_ComposerAffiliationBase composerSnapshot);

        List<Snapshot_ComposerAffiliationBase> GetAllComposersAffiliationBasesByComposerAffiliationSnapshotId(int composerAffiliationSnapshotId);

        bool DeleteComposerAffiliationBaseSnapshotByComposer(Snapshot_ComposerAffiliationBase composerToDelete);
    }
}