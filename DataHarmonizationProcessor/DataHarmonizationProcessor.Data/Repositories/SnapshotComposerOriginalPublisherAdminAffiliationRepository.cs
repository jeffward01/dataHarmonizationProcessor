using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotComposerOriginalPublisherAdminAffiliationRepository : ISnapshotComposerOriginalPublisherAdminAffiliationRepository
    {
        public Snapshot_ComposerOriginalPublisherAdminAffiliation SaveComposerOriginalPublisherAdminAffiliation(Snapshot_ComposerOriginalPublisherAdminAffiliation sampleSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_ComposerOriginalPublisherAdminAffiliations.Add(sampleSnapshot);
                context.SaveChanges();
                return sampleSnapshot;
            }
        }

        public List<Snapshot_ComposerOriginalPublisherAdminAffiliation> GetAllComposerOriginalPublisherAdminAffiliationsorAdminId(int composerOpAdminId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ComposerOriginalPublisherAdminAffiliations.Where(sl => sl.SnapshotComposerOriginalPublisherAdministratorId == composerOpAdminId).ToList();
            }
        }

        public bool DeleteComposerOriginalPublisherAdminAffiliation(Snapshot_ComposerOriginalPublisherAdminAffiliation composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_ComposerOriginalPublisherAdminAffiliations
                        .Find(composerToDelete.SnapshotComposerOriginalPublisherAdminAffiliationId);

                context.Snapshot_ComposerOriginalPublisherAdminAffiliations.Attach(composer);
                context.Snapshot_ComposerOriginalPublisherAdminAffiliations.Remove(composer);
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