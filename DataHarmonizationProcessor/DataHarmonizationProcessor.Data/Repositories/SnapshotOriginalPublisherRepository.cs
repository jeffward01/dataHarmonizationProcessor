using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotOriginalPublisherRepository : ISnapshotOriginalPublisherRepository
    {
        public List<Snapshot_OriginalPublisher> GetAllOriginalPublishersForCaeCode(int cloneContactId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_OriginalPublishers.Where(_ => _.CloneWorksWriterCaeNumber == cloneContactId).ToList();
            }
        }

        public List<Snapshot_OriginalPublisher> GetAllOriginalPublishersForSnapshotWriterId(int worksWriterSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_OriginalPublishers.Where(_ => _.SnapshotWorksWriterId == worksWriterSnapshotId).ToList();
            }
        }

        public bool DeleteOriginalPublisherSnapshotBySnapshotId(int snapshotId)
        {
            using (var context = new DataContext())
            {
                var originalPublisher = context.Snapshot_OriginalPublishers.Find(snapshotId);
                context.Snapshot_OriginalPublishers.Attach(originalPublisher);
                context.Snapshot_OriginalPublishers.Remove(originalPublisher);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public Snapshot_OriginalPublisher SaveSnapshotOriginalPublisher(Snapshot_OriginalPublisher originalPublisher)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_OriginalPublishers.Add(originalPublisher);
                context.SaveChanges();
                return originalPublisher;
            }
        }
    }
}