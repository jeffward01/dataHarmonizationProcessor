using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotAdminAffiliationBaseRepository : ISnapshotAdminAffiliationBaseRepository
    {
        public Snapshot_AdminAffiliationBase SaveSnapshotAdministrator(Snapshot_AdminAffiliationBase administratorSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_AdminAffiliationBases.Add(administratorSnapshot);
                context.SaveChanges();
                return administratorSnapshot;
            }
        }

        public Snapshot_AdminAffiliationBase GetSnapshotAdministratorByAdminAffiliationBaseId(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AdminAffiliationBases.Find(adminSnapshotId);
            }
        }

        public List<Snapshot_AdminAffiliationBase> GetAllAdminAffiliationBaseForSnapshotAdminId(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AdminAffiliationBases.Where(_ => _.SnapshotAdminAffiliationId == adminSnapshotId).ToList();
            }
        }

        public bool DeleteConfigurationSnapshot(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                var adminSnapshot =
                    context.Snapshot_AdminAffiliationBases.Find(adminSnapshotId);
                if (adminSnapshot == null)
                {
                    return false;
                }
                context.Snapshot_AdminAffiliationBases.Attach(adminSnapshot);
                context.Snapshot_AdminAffiliationBases.Remove(adminSnapshot);
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