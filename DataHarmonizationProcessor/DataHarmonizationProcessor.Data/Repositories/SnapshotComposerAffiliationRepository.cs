using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotComposerAffiliationRepository : ISnapshotComposerAffiliationRepository
    {
        public Snapshot_ComposerAffiliation SaveComposerAffiliationSnapshot(Snapshot_ComposerAffiliation composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_ComposerAffiliations.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_ComposerAffiliation> GetAllComposersAffiliationsByComposerSnapshotId(int composerSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ComposerAffiliations.Where(sl => sl.SnapshotComposerId == composerSnapshotId).ToList();
            }
        }

        public bool DeleteComposerAffiliationSnapshotByComposer(Snapshot_ComposerAffiliation composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_ComposerAffiliations
                        .Find(composerToDelete.SnapshotComposerAffiliationId);

                context.Snapshot_ComposerAffiliations.Attach(composer);
                context.Snapshot_ComposerAffiliations.Remove(composer);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}