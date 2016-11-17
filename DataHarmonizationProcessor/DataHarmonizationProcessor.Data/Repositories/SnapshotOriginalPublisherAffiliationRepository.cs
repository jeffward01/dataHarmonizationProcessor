using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotOriginalPublisherAffiliationRepository : ISnapshotOriginalPublisherAffiliationRepository
    {
        public List<Snapshot_OriginalPublisherAffiliation> GetAllOriginalPublisherAffiliationsByCaeCode(int caeCode)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_OriginalPublisherAffiliations.Where(_ => _.CloneWriterCaeNumber == caeCode).ToList();
            }
        }

        public List<Snapshot_OriginalPublisherAffiliation> GetAllOriginalPublisherAffiliationsByOriginalBuplisherId(int originalPublisherId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_OriginalPublisherAffiliations.Where(_ => _.SnapshotOriginalPublisherId == originalPublisherId).ToList();
            }
        }

        public bool DeleteOriginalPublisherSnapshotById(int snapshotPhoneId)
        {
            using (var context = new DataContext())
            {
                var address = context.Snapshot_OriginalPublisherAffiliations.Find(snapshotPhoneId);
                context.Snapshot_OriginalPublisherAffiliations.Attach(address);
                context.Snapshot_OriginalPublisherAffiliations.Remove(address);
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

        public Snapshot_OriginalPublisherAffiliation SaveSnapshotOriginalPublisherAffiliation(Snapshot_OriginalPublisherAffiliation snapshotAdminAffiliation)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_OriginalPublisherAffiliations.Add(snapshotAdminAffiliation);
                context.SaveChanges();
                //    int id = snapshotAdminAffiliation.SnapshotAdminAffiliationId;
                return snapshotAdminAffiliation;
            }
        }
    }
}