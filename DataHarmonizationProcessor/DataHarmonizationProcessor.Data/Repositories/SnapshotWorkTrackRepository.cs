﻿using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotWorkTrackRepository : ISnapshotWorkTrackRepository
    {
        public Snapshot_WorksTrack GetTrackForCloneTrackId(int cloneTrackId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_Tracks.FirstOrDefault(_ => _.CloneWorksTrackId == cloneTrackId);
            }
        }

        public Snapshot_WorksTrack SaveWorksTrack(Snapshot_WorksTrack worksTrack)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_Tracks.Add(worksTrack);
                context.SaveChanges();
                return worksTrack;
            }
        }

        public bool DeleteTrackBySnapshotTrackId(int snapshotTrackId)
        {
            using (var context = new DataContext())
            {
                var address = context.Snapshot_Tracks.Find(snapshotTrackId);
                context.Snapshot_Tracks.Attach(address);
                context.Snapshot_Tracks.Remove(address);
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