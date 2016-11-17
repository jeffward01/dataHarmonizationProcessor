using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotWorksRecordingRepository
    {
        Snapshot_WorksRecording SaveSnapshotWorksRecording(Snapshot_WorksRecording snapshotWorksRecording);

        Snapshot_WorksRecording GetSnapshotWorksRecordingByWorksRecordingId(int? worksRecordingId);

        bool DeleteWorkRecordingByRecordignSnapshotId(int recordingSnapshotIdea);

        List<Snapshot_WorksRecording> GetAllWorksRecordingsForLicenseProductId(int? productId);

        List<Snapshot_WorksRecording> GetAllWorksRecordingsForProductId(int? productId);
    }
}