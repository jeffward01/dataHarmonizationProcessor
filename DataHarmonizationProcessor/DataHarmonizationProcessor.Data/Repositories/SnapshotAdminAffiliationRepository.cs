using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotAdminAffiliationRepository : ISnapshotAdminAffiliationRepository
    {
        public List<Snapshot_AdminAffiliation> GetAllAdminAffiliationsForSnapshotAdminId(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AdminAffiliations.Where(_ => _.SnapshotAdministratorId == adminSnapshotId).ToList();
            }
        }

        public bool DeletePhoneBySnapshotPhoneId(int snapshotPhoneId)
        {
            using (var context = new DataContext())
            {
                var address = context.Snapshot_AdminAffiliations.Find(snapshotPhoneId);
                context.Snapshot_AdminAffiliations.Attach(address);
                context.Snapshot_AdminAffiliations.Remove(address);
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

        public Snapshot_AdminAffiliation SaveSnapshotAdminAffiliation(Snapshot_AdminAffiliation snapshotAdminAffiliation)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_AdminAffiliations.Add(snapshotAdminAffiliation);
                context.SaveChanges();
                //    int id = snapshotAdminAffiliation.SnapshotAdminAffiliationId;
                return snapshotAdminAffiliation;
            }
        }
    }
}