using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotSampleLocalClientCopyrightRepository : ISnapshotSampleLocalClientCopyrightRepository
    {
        public Snapshot_SampleLocalClientCopyright SaveSampleLocalClientCopyright(Snapshot_SampleLocalClientCopyright composerSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_SampleLocalClientCopyrights.Add(composerSnapshot);
                context.SaveChanges();
                return composerSnapshot;
            }
        }

        public List<Snapshot_SampleLocalClientCopyright> GetAllSampleLocalClientCopyrightsForSampleId(int sampleSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_SampleLocalClientCopyrights.Where(sl => sl.SnapshotSampleId == sampleSnapshotId).ToList();
            }
        }

        public bool DeleteSampleLocalClientCopyright(Snapshot_SampleLocalClientCopyright composerToDelete)
        {
            using (var context = new DataContext())
            {
                var composer =
                    context.Snapshot_SampleLocalClientCopyrights
                        .Find(composerToDelete.SnapshotSampleLocalClientCopyrightId);

                context.Snapshot_SampleLocalClientCopyrights.Attach(composer);
                context.Snapshot_SampleLocalClientCopyrights.Remove(composer);
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