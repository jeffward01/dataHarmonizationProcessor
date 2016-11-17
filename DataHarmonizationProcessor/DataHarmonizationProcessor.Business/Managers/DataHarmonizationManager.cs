using DataHarmonizationProcessor.Business.Logging;
using DataHarmonizationProcessor.Business.Services;
using DataHarmonizationProcessor.Data.Repositories;
using System;
using Newtonsoft.Json.Linq;
using NLog.Layouts;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Business.Managers
{
    public class DataHarmonizationManager : IDataHarmonizationManager
    {
        private readonly IDataHarmonizationLogManager _logManager;
        private readonly ILicenseRepository _licenseRepository;
        private readonly ILicenseProductService _licenseProductService;
        private readonly ISnapshotManager _snapshotManager;
        private readonly IDataHarmonizationQueueService _dataHarmonizationQueueService;

        public DataHarmonizationManager(IDataHarmonizationLogManager logManager, ILicenseRepository licenseRepository, IDataHarmonizationQueueService dataHarmonizationQueueService,
            ILicenseProductService licenseProductService, ISnapshotManager snapshotManager)
        {
            _dataHarmonizationQueueService = dataHarmonizationQueueService;
            _snapshotManager = snapshotManager;
            _licenseProductService = licenseProductService;
            _licenseRepository = licenseRepository;
            _logManager = logManager;
        }

        public bool CreateLicenseSnapshot(int licenseId, DataHarmonizationQueue queueItem)
        {
            _dataHarmonizationQueueService.MarkAsInProcess(queueItem);

            try
            {
                //get local license, save local license as licenseSnapshot
                var localLicense = _licenseRepository.GetLicenseById(licenseId);

                //get licenseProducts from 'GetProductsNew'
                var licenseProducts = _licenseProductService.GetProductsNew(localLicense.LicenseId);

                var test = licenseProducts[0].ProductHeader.Label;
                var testPass = test;
                //save localLicense Snapshot and licenseProducts as snapshot
                _snapshotManager.TakeLicenseSnapshot(localLicense, licenseProducts);
            }
            catch (Exception e)
            {
                _dataHarmonizationQueueService.MarkAsError(queueItem);
                _logManager.LogErrors(e);
                throw new Exception("Error Creating License Snapshot.  Error: " + e.ToString());
            }
            finally
            {
                //make this smart
                _dataHarmonizationQueueService.MarkAsComplete(queueItem);
            }

            return true;
        }

        public bool DeleteLicenseSnapshot(int licenseId, DataHarmonizationQueue queueItem)
        {
            _dataHarmonizationQueueService.MarkAsInProcess(queueItem);
            try
            {
                if (_snapshotManager.DoesLicenseSnapshotExist(licenseId))
                {
                    _snapshotManager.DeleteLicenseSnapshot(licenseId);
                }
                else
                {
                    throw new Exception(
                        "Error Deleting License Snapshot.  License Snapshot cannot be found for license Id: " +
                        licenseId + ". ");
                }
            }
            catch (Exception e)
            {
                _dataHarmonizationQueueService.MarkAsError(queueItem);
                _logManager.LogErrors(e);
                throw new Exception("Error Deleting License Snapshot.  License Snapshot cannot be found for license Id: " +
                        licenseId + ".  Error: " + e.ToString());
            }
            finally
            {
                ////make this smart
                _dataHarmonizationQueueService.MarkAsComplete(queueItem);
            }
            return true;
        }
    }
}