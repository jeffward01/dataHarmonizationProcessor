using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class Snapshot_ComposerOriginalPublisherAffiliationRepository : ISnapshot_ComposerOriginalPublisherAffiliationRepository
    {
        public Snapshot_ComposerOriginalPublisherAffiliation SaveComposerOriginalPublisherAffiliation(Snapshot_ComposerOriginalPublisherAffiliation composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_COmposerOriginalPublisherAffiliations.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_ComposerOriginalPublisherAffiliation> GetAllComposerOriginalPublisherAffiliationsForComposerOriginalPublisherId(int composerOrignalPublisherId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_COmposerOriginalPublisherAffiliations.Where(sl => sl.SnapshotComposerOriginalPublisherId == composerOrignalPublisherId).ToList();
            }
        }

        public bool DeleteComposerOriginalPubhliserAffiliation(Snapshot_ComposerOriginalPublisherAffiliation composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_COmposerOriginalPublisherAffiliations
                        .Find(composerToDelete.SnapshotComposerOriginalPublisherAffiliationId);

                context.Snapshot_COmposerOriginalPublisherAffiliations.Attach(composer);
                context.Snapshot_COmposerOriginalPublisherAffiliations.Remove(composer);
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