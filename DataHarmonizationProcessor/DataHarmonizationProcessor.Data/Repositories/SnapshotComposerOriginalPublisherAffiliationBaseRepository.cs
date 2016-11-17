using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotComposerOriginalPublisherAffiliationBaseRepository : ISnapshotComposerOriginalPublisherAffiliationBaseRepository
    {
        public Snapshot_ComposerOriginalPublisherAffiliationBase SaveComposerOriginalPublisherAffiliationBase(Snapshot_ComposerOriginalPublisherAffiliationBase composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_ComposerOriginalPublisherAffiliationBases.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_ComposerOriginalPublisherAffiliationBase> GetComposerOriginalPublisherAffiliationBasesFComposerOriginalPublisherAffiliationId(int composerOrignalPublisherAffiliationId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ComposerOriginalPublisherAffiliationBases.Where(sl => sl.SnapshotComposerOriginalPublisherAffiliationId == composerOrignalPublisherAffiliationId).ToList();
            }
        }

        public bool DeleteComposerOriginalPublisherAffiliationBase(Snapshot_ComposerOriginalPublisherAffiliationBase composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_ComposerOriginalPublisherAffiliationBases
                        .Find(composerToDelete.SnapshotComposerOriginalPubAffiliationBaseId);

                context.Snapshot_ComposerOriginalPublisherAffiliationBases.Attach(composer);
                context.Snapshot_ComposerOriginalPublisherAffiliationBases.Remove(composer);
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