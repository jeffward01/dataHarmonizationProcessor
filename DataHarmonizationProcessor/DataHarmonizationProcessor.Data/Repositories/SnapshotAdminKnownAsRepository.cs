﻿using DataHarmonizationProcessor.Data.Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotAdminKnownAsRepository : ISnapshotAdminKnownAsRepository
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public List<Snapshot_AdminKnownAs> GetAllAdminKnownAsForAdminSnapshotId(int adminSnapshotId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_AdminKnownAs.Where(_ => _.SnapshotAdministratorId == adminSnapshotId).ToList();
            }
        }

        public bool DeleteKnownasByAdminKnownAsSnapshotId(int adminKnownAsSnapshotId)
        {
            using (var context = new DataContext())
            {
                var knownAs = context.Snapshot_AdminKnownAs.Find(adminKnownAsSnapshotId);
                context.Snapshot_AdminKnownAs.Attach(knownAs);
                context.Snapshot_AdminKnownAs.Remove(knownAs);
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

        public Snapshot_AdminKnownAs SaveSnapshotAdminKnownAs(Snapshot_AdminKnownAs adminKnownAs)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_AdminKnownAs.Add(adminKnownAs);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Logger.Debug(e.ToString());
                    throw new Exception(e.ToString());
                }
                return adminKnownAs;
            }
        }
    }
}