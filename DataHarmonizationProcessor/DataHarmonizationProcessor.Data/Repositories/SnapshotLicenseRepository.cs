﻿using DataHarmonizationProcessor.Data.Infrastructure;
using NLog;
using System;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class SnapshotLicenseRepository : ISnapshotLicenseRepository
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Snapshot_License SaveSnapshotLicense(Snapshot_License licenseSnapshot)
        {
            using (var context = new DataContext())
            {
                context.Snapshot_Licenses.Add(licenseSnapshot);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Logger.Debug(e.ToString);
                    throw new Exception("Error saving snapshot_licnese:     " + e.ToString());
                }
                return licenseSnapshot;
            }
        }

        public bool DoesLicenseSnapshotExist(int licenseId)
        {
            using (var context = new DataContext())
            {
                var exist = context.Snapshot_Licenses.FirstOrDefault(_ => _.CloneLicenseId == licenseId);
                if (exist != null)
                {
                    return true;
                }
            }
            return false;
        }

        public Snapshot_License GetSnapshotLicenseByCloneLicenseId(int licenseId)
        {
            using (var context = new DataContext())
            {
                return context.Snapshot_Licenses.FirstOrDefault(_ => _.CloneLicenseId == licenseId);
            }
        }

        public Snapshot_License GetLicenseSnapShotById(int id)
        {
            using (var context = new DataContext())
            {
                //License Details
                var response = context.Snapshot_Licenses
                    .Include("LicenseType")
                    .Include("LicensePriority")
                    .Include("LicenseStatus")
                    .Include("LicenseMethod")
                    .Include("LicenseProducts")
                    .Include("LicenseMethod")

                    .FirstOrDefault(sl => sl.CloneLicenseId == id);

                //LicenseProduct and Product header
                //    var licenseProduct = context.Snapshot_LicenseProducts
                //        .Include("ProductHeader")
                //      .Include("ProductHeader.Artist")
                //      .Include("ProductHeader.Label")
                //                  .Include("ProductHeader.Configurations") //TEST
                //       .Include("ProductHeader.Configurations.Configuration") // Error here, not showing yet
                //   .Include("ProductHeader.Configurations.LicenseProductConfiguration")
                //  .Include("ProductHeader.Label.RecordLabelGroups")
                //   .Include("ProductConfigurations") //comes back null, i think in the test license case its supposed
                //       .Include("Schedule")
                //         .Include("Recordings")
                //        .Include("Recordings.Writers")  //Add to database
                //       .Include("Recordings.Track")  //Add to database  || works
                //       .Include("Recordings.Track.Copyrights")
                //       .Include("Recordings.Track.Copyrights.Composers")
                //       .Include("Recordings.Track.Copyrights.Samples")
                //       .Include("Recordings.Track.Copyrights.LocalClients")
                //       .Include("Recordings.Track.Copyrights.AquisitionLocationCodes")
                //       .Include("Recordings.Track.Artist")
                // .Include("Recordings.LicenseRecording") //Add to database??  BROKEN, its in database, but when its 'on' recordings are not returned

                //          .Where(_ => _.LicenseId == response.CloneLicenseId).ToList();

                //    response.LicenseProducts = licenseProduct;
                return response;
            }
        }

        public bool DeleteSnapshotLicense(Snapshot_License license)
        {
            using (var context = new DataContext())
            {
                //var licenseToBeDeleted = context.Snapshot_Licenses
                // //   .Include("LicenseType")
                // //   .Include("LicensePriority")
                // //   .Include("LicenseStatus")
                // //   .Include("LicenseProducts")
                // //   .Include("LicenseMethod")
                //    .FirstOrDefault(sl => sl.CloneLicenseId == licenseId);

                context.Snapshot_Licenses.Attach(license);
                context.Snapshot_Licenses.Remove(license);
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