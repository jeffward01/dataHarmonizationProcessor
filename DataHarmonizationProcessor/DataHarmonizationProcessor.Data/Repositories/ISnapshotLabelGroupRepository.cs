using System.Collections.Generic;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public interface ISnapshotLabelGroupRepository
    {
        Snapshot_LabelGroup SaveSnapshotLabelGroup(Snapshot_LabelGroup snapshotLabelGroup);

        Snapshot_LabelGroup GetSaSnapshotLabelGroupByLabelGroupId(int labelGroupId);

        List<Snapshot_LabelGroup> GetAllLabelGroupsForProductHeaderSnapshotId(int productHeaderSnapshotId);

        List<Snapshot_LabelGroup> GetAllALabelGroupsForLabelId(int labelId);

        bool DeleteLabelGroupByLabelGroupSnapshotId(int labelGroupSnapshotId);
    }
}