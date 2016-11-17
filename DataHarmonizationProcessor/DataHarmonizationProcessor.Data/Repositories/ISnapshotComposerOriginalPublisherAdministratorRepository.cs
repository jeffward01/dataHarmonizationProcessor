using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotComposerOriginalPublisherAdministratorRepository
    {
        Snapshot_ComposerOriginalPublisherAdministrator SaveComposerOriginalPublisherAdministrator(Snapshot_ComposerOriginalPublisherAdministrator sampleSnapshot);

        List<Snapshot_ComposerOriginalPublisherAdministrator> GetAllComposerOriginalPublisherAdministratorsForComposerOriginalPublisherId(int snapshotComposerOriginalPublisherId);

        bool DeleteComposerOriginalPublisherAdministrator(Snapshot_ComposerOriginalPublisherAdministrator composerToDelete);
    }
}