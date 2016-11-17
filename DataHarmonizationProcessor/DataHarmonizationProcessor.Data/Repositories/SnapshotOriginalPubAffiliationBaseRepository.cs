using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotOriginalPubAffiliationBaseRepository : ISnapshotOriginalPubAffiliationBaseRepository
    {
        public List<Snapshot_OriginalPubAffiliationBase> GetAllOriginalPubAffiliationBasesByAffilationId(int opAffiliationId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_OriginalPublisherAffiliationBases.Where(_ => _.SnapshotOriginalPublisherAffiliationId == opAffiliationId).ToList();
            }
        }

        public bool DeletePhoneBySnapshotPhoneId(int snapshotPhoneId)
        {
            using (var context = new DataContext())
            {
                var address = context.Snapshot_OriginalPublisherAffiliationBases.Find(snapshotPhoneId);
                context.Snapshot_OriginalPublisherAffiliationBases.Attach(address);
                context.Snapshot_OriginalPublisherAffiliationBases.Remove(address);
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

        public Snapshot_OriginalPubAffiliationBase SaveSnapshotAdminAffiliation(Snapshot_OriginalPubAffiliationBase snapshotAdminAffiliation)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_OriginalPublisherAffiliationBases.Add(snapshotAdminAffiliation);
                context.SaveChanges();
                //    int id = snapshotAdminAffiliation.SnapshotAdminAffiliationId;
                return snapshotAdminAffiliation;
            }
        }
    }
}