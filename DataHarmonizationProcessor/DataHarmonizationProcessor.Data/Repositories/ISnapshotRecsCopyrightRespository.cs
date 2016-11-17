using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotRecsCopyrightRespository
    {
        Snapshot_RecsCopyright SaveSnapshotWorksRecording(Snapshot_RecsCopyright snapshotRecsCopyright);

        List<Snapshot_RecsCopyright> GetAllRecsCopyrightsForCloneTrackId(int cloneTrackId);

        bool DeleteRecsCopyrightByRecsCopyrightSnapshotId(int recCopyrightSnapshotId);
    }
}