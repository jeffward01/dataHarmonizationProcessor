using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotProductHeaderRepository : ISnapshotProductHeaderRepository
    {
        public Snapshot_ProductHeader SaveSnapshotProductHeader(Snapshot_ProductHeader snapshotProductHeader)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_ProductHeaders.Add(snapshotProductHeader);
                context.SaveChanges();
                return snapshotProductHeader;
            }
        }

        public Snapshot_ProductHeader GetSnapshotProductHeaderBySnapshotProductHeaderId(int snapshotProductHeaderId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ProductHeaders.Find(snapshotProductHeaderId);
            }
        }

        public Snapshot_ProductHeader GetProductHeaderByProductHeaderId(int productHeaderId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_ProductHeaders.FirstOrDefault(_ => _.CloneProductHeaderId == productHeaderId);
            }
        }

        public int GetSnapshotProductHeaderBySnapshotLicenseProductId(int snapshotLicenseProductId)
        {
            using (var context = new DataContext())
            {
                var licenseProduct = context.Snapshot_LicenseProducts.Find(snapshotLicenseProductId);
                return licenseProduct.SnapshotLicenseProductId;
            }
        }

        public bool DeleteProductHeaderSnapshotBySnapshotId(int snapshotProductHeaderId)
        {
            using (var context = new DataContext())
            {
                var productHeader =
                    context.Snapshot_ProductHeaders.Find(snapshotProductHeaderId);
                if (productHeader == null)
                {
                    return false;
                }
                context.Snapshot_ProductHeaders.Attach(productHeader);
                context.Snapshot_ProductHeaders.Remove(productHeader);
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