using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotComposerRepository : ISnapshotComposerRepository
    {
        public Snapshot_Composer SaveComposerSnapshot(Snapshot_Composer composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_Composers.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_Composer> GetAllComposersByRecsCopyrightid(int recsCopyrightId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_Composers.Where(sl => sl.SnapshotRecsCopyrightId == recsCopyrightId).ToList();
            }
        }

        public bool DeleteComposerSnapshotByComposer(Snapshot_Composer composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_Composers
                        .Find(composerToDelete.SnapshotComposerId);

                context.Snapshot_Composers.Attach(composer);
                context.Snapshot_Composers.Remove(composer);
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