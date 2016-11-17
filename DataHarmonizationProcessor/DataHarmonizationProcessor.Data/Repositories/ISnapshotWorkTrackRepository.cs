using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotWorkTrackRepository
    {
        Snapshot_WorksTrack GetTrackForCloneTrackId(int cloneTrackId);

        bool DeleteTrackBySnapshotTrackId(int snapshotTrackId);

        Snapshot_WorksTrack SaveWorksTrack(Snapshot_WorksTrack worksTrack);
    }
}