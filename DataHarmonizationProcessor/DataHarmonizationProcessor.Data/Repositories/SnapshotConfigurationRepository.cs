using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotConfigurationRepository : ISnapshotConfigurationRepository
    {
        public Snapshot_Configuration SaveSnapshotConfiguration(Snapshot_Configuration snapshotConfiguration)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_Configurations.Add(snapshotConfiguration);
                context.SaveChanges();
                return snapshotConfiguration;
            }
        }

        public Snapshot_Configuration GetSnapshotConfigurationByConfigurationId(int configurationId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_Configurations.FirstOrDefault(_ => _.CloneConfigId == configurationId);
            }
        }

        public bool DeleteConfigurationSnapshot(int snapshotLicenseProductId)
        {
            using (var context = new DataContext())
            {
                var configs =
                    context.Snapshot_Configurations.Where(_ => _.SnapshotConfigId == snapshotLicenseProductId);
                if (configs == null)
                {
                    return false;
                }
                foreach (var config in configs)
                {
                    
              
                context.Snapshot_Configurations.Attach(config);
                context.Snapshot_Configurations.Remove(config);
                }
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