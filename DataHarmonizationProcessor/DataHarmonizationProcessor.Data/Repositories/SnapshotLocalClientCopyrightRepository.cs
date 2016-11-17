﻿using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotLocalClientCopyrightRepository : ISnapshotLocalClientCopyrightRepository
    {
        public List<Snapshot_LocalClientCopyright> GetAllLocalCopyrightsForTrackId(int trackId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_LocalClientCopyrights.Where(_ => _.CloneWorksTrackId == trackId).ToList();
            }
        }

        public List<Snapshot_LocalClientCopyright> GetAllLocalCopyrightsForRecsCopyrightSnapshotId(int recsCopyrightSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_LocalClientCopyrights.Where(_ => _.SnapshotRecsCopyrightId == recsCopyrightSnapshotId).ToList();
            }
        }

        public bool DeleteLocalClientCopyrightBySnapshotId(int localClientCopyrightSnapshotId)
        {
            using (var context = new DataContext())
            {
                var clientcopyRight = context.Snapshot_LocalClientCopyrights.Find(localClientCopyrightSnapshotId);
                context.Snapshot_LocalClientCopyrights.Attach(clientcopyRight);
                context.Snapshot_LocalClientCopyrights.Remove(clientcopyRight);
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

        public Snapshot_LocalClientCopyright SaveLocalClientCopyright(Snapshot_LocalClientCopyright snapshotLabel)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_LocalClientCopyrights.Add(snapshotLabel);
                context.SaveChanges();
                return snapshotLabel;
            }
        }
    }
}