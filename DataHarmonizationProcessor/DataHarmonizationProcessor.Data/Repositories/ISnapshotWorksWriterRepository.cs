using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotWorksWriterRepository
    {
        List<Snapshot_WorksWriter> GetAllWritersForCloneTrackId(int cloneTrackId);

        bool DeleteWorksWriterSnapshotBySnapshotId(int worksWriterSnapshotId);

        Snapshot_WorksWriter SaveWorksWriter(Snapshot_WorksWriter worksWriter);
    }
}