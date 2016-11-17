﻿using DataHarmonizationProcessor.Data.Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotRecsCopyrightRespository : ISnapshotRecsCopyrightRespository
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Snapshot_RecsCopyright SaveSnapshotWorksRecording(Snapshot_RecsCopyright snapshotRecsCopyright)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_RecsCopyrights.Add(snapshotRecsCopyright);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Logger.Debug(e.ToString());
                    throw new Exception(e.ToString());
                }

                return snapshotRecsCopyright;
            }
        }

        public List<Snapshot_RecsCopyright> GetAllRecsCopyrightsForCloneTrackId(int cloneTrackId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_RecsCopyrights.Where(_ => _.CloneWorksTrackId == cloneTrackId).ToList();
            }
        }

        public bool DeleteRecsCopyrightByRecsCopyrightSnapshotId(int recCopyrightSnapshotId)
        {
            using (var context = new DataContext())
            {
                var recording = context.Snapshot_RecsCopyrights.Find(recCopyrightSnapshotId);
                if (recording == null)
                {
                    return false;
                }
                context.Snapshot_RecsCopyrights.Attach(recording);
                context.Snapshot_RecsCopyrights.Remove(recording);
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