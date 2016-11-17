using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class Snapshot_ComposerKnownAsRepository : ISnapshot_ComposerKnownAsRepository
    {
        public Snapshot_ComposerKnownAs SaveComposerKnownAs(Snapshot_ComposerKnownAs composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_ComposerKnownAs.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_ComposerKnownAs> GetAllComposerKnownAsByComposerSnapshotId(int composerAffiliationSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ComposerKnownAs.Where(sl => sl.SnapshotComposerId == composerAffiliationSnapshotId).ToList();
            }
        }

        public bool DeleteComposerKnownAs(Snapshot_ComposerKnownAs composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_ComposerKnownAs
                        .Find(composerToDelete.SnapshotComposerKnownAsId);

                context.Snapshot_ComposerKnownAs.Attach(composer);
                context.Snapshot_ComposerKnownAs.Remove(composer);
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