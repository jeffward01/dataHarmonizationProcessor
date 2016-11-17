using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotComposerOriginalPublisherAdminKnownAsRepository
    {
        Snapshot_ComposerOriginalPublisherAdminKnownAs SaveSnapshotComposerOriginalPublisherAdminKnownAs(Snapshot_ComposerOriginalPublisherAdminKnownAs sampleSnapshot);

        List<Snapshot_ComposerOriginalPublisherAdminKnownAs> GetAllComposerOriginalPublisherAdminKnownAsForAdministratorId(int adminAffiliationId);

        bool DeleteSnapshotComposerOriginalPublisherAdminKnownAs(Snapshot_ComposerOriginalPublisherAdminKnownAs composerToDelete);
    }
}