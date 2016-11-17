using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotAffiliationBaseRepository : ISnapshotAffiliationBaseRepository
    {
        public List<Snapshot_AffiliationBase> GetAllAffiliationBasesForAffilationId(int affiliationId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AffiliationBases.Where(_ => _.SnapshotAffiliationId == affiliationId).ToList();
            }
        }

        public Snapshot_AffiliationBase SaveSnapshotAffiliationBase(Snapshot_AffiliationBase snapshotAffiliation)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_AffiliationBases.Add(snapshotAffiliation);
                context.SaveChanges();
                return snapshotAffiliation;
            }
        }

        public bool DeleteAffilationByAffiliationBaseSnapshotId(int affiliationSnapshotId)
        {
            using (var context = new DataContext())
            {
                var affilation = context.Snapshot_AffiliationBases.Find(affiliationSnapshotId);
                context.Snapshot_AffiliationBases.Attach(affilation);
                context.Snapshot_AffiliationBases.Remove(affilation);
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
    }
}