using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotSampleAquisitionLocationCodeRepository
    {
        Snapshot_SampleAquisitionLocationCode SaveSampleAquisitionLocationCode(Snapshot_SampleAquisitionLocationCode composerSnapshot);

        List<Snapshot_SampleAquisitionLocationCode> GetAllSampleLocationCodesForSampleId(int sampleSnapshotId);

        bool DeleteSampleLocationCode(Snapshot_SampleAquisitionLocationCode composerToDelete);
    }
}