﻿using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotAquisitionLocationCodeRepository : ISnapshotAquisitionLocationCodeRepository
    {
        public List<Snapshot_AquisitionLocationCode> GetAllAquisitionLocationCodesForTrackId(int trackId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AquisitionLocationCodes.Where(_ => _.CloneWorksTrackId == trackId).ToList();
            }
        }

        public List<Snapshot_AquisitionLocationCode> GetAllAquisitionLocationCodesForRecsCopyrightId(int recsCopyrightId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AquisitionLocationCodes.Where(_ => _.SnapshotRecsCopyrightId == recsCopyrightId).ToList();
            }
        }

        public bool DeleteAquisitionLocationCodeBySnashotId(int aquisitonLocationCodeSnapshotId)
        {
            using (var context = new DataContext())
            {
                var aquisitonLocationCode = context.Snapshot_AquisitionLocationCodes.Find(aquisitonLocationCodeSnapshotId);
                context.Snapshot_AquisitionLocationCodes.Attach(aquisitonLocationCode);
                context.Snapshot_AquisitionLocationCodes.Remove(aquisitonLocationCode);
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

        public Snapshot_AquisitionLocationCode SaveAquisitionLocationCode(Snapshot_AquisitionLocationCode snapshotLabel)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_AquisitionLocationCodes.Add(snapshotLabel);
                context.SaveChanges();
                return snapshotLabel;
            }
        }
    }
}