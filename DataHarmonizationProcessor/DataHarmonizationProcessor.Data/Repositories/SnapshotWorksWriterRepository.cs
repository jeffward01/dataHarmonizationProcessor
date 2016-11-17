﻿using DataHarmonizationProcessor.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotWorksWriterRepository : ISnapshotWorksWriterRepository
    {
        public List<Snapshot_WorksWriter> GetAllWritersForCloneTrackId(int cloneTrackId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_WorksWriters.Where(_ => _.CloneWorksTrackId == cloneTrackId).ToList();
            }
        }

        public bool DeleteWorksWriterSnapshotBySnapshotId(int worksWriterSnapshotId)
        {
            using (var context = new DataContext())
            {
                var worksWriter = context.Snapshot_WorksWriters.Find(worksWriterSnapshotId);
                context.Snapshot_WorksWriters.Attach(worksWriter);
                context.Snapshot_WorksWriters.Remove(worksWriter);
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

        public Snapshot_WorksWriter SaveWorksWriter(Snapshot_WorksWriter worksWriter)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_WorksWriters.Add(worksWriter);
                context.SaveChanges();
                return worksWriter;
            }
        }
    }
}