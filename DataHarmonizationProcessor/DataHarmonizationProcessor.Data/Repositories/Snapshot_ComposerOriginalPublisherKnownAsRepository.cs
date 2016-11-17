using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class Snapshot_ComposerOriginalPublisherKnownAsRepository : ISnapshot_ComposerOriginalPublisherKnownAsRepository
    {
        public Snapshot_ComposerOriginalPublisherKnownAs SaveComposerOriginalPublisherKnownAs(Snapshot_ComposerOriginalPublisherKnownAs composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_ComposerOriginalPublisherKnownAs.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_ComposerOriginalPublisherKnownAs> GetAllComposerOriginalPublisherKnownAsByComposerOriginalPublisherSnapshotId(int composerOriginalPublisherSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ComposerOriginalPublisherKnownAs.Where(sl => sl.SnapshotComposerOriginalPublisherId == composerOriginalPublisherSnapshotId).ToList();
            }
        }

        public bool DeleteComposerOriginalPublisherKnownAs(Snapshot_ComposerOriginalPublisherKnownAs composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_ComposerOriginalPublisherKnownAs
                        .Find(composerToDelete.SnapshotComposerOriginalPublisherId);

                context.Snapshot_ComposerOriginalPublisherKnownAs.Attach(composer);
                context.Snapshot_ComposerOriginalPublisherKnownAs.Remove(composer);
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