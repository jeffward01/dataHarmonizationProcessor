using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotAdministratorRepository : ISnapshotAdministratorRepository
    {
        public Snapshot_Administrator SaveSnapshotAdministrator(Snapshot_Administrator administratorSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_Administrators.Add(administratorSnapshot);
                context.SaveChanges();
                return administratorSnapshot;
            }
        }

        public List<Snapshot_Administrator> GetAllAdministratorsForOriginalPublisherId(int id)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_Administrators.Where(_ => _.SnapshotOriginalPublisherId == id).ToList();
            }
        }

        public Snapshot_Administrator GetSnapshotAdministratorByAdministratorId(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_Administrators.Find(adminSnapshotId);
            }
        }

        public bool DeleteConfigurationSnapshot(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                var adminSnapshot =
                    context.Snapshot_Administrators.Find(adminSnapshotId);
                if (adminSnapshot == null)
                {
                    return false;
                }
                context.Snapshot_Administrators.Attach(adminSnapshot);
                context.Snapshot_Administrators.Remove(adminSnapshot);
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