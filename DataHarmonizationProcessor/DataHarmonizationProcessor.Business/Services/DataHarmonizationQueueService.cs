using DataHarmonizationProcessor.Business.Logging;
using DataHarmonizationProcessor.Data.Repositories;
using System;
using UMPG.USL.Models.DataHarmonization;
using UMPG.USL.Models.LookupModel;

namespace DataHarmonizationProcessor.Business.Services
{
    public class DataHarmonizationQueueService : IDataHarmonizationQueueService
    {
        private readonly IDataHarmonizationQueueRepository _dataHarmonizationQueueRepository;
        private readonly IDataHarmonizationLogManager _logManager;
        private readonly ISnapshotLicenseRepository _snapshotLicenseRepository;

        public DataHarmonizationQueueService(IDataHarmonizationQueueRepository dataHarmonizationQueueRepository, IDataHarmonizationLogManager logManager, ISnapshotLicenseRepository snapshotLicenseRepository)
        {
            _logManager = logManager;
            _dataHarmonizationQueueRepository = dataHarmonizationQueueRepository;
            _snapshotLicenseRepository = snapshotLicenseRepository;
        }

        //Get New pending count (all)
        public int GetPendingCountForAllActionRequests()
        {
            return _dataHarmonizationQueueRepository.GetPendingCountForAllActionRequests();
        }

        //Get new pending count (create)
        public int GetPendingCountForCreateRequests()
        {
            return _dataHarmonizationQueueRepository.GetPendingCountForCreateRequests();
        }

        //Get new pending count (delete)
        public int GetPendingCountForDeleteRequests()
        {
            return _dataHarmonizationQueueRepository.GetPendingCountForDeleteRequests();
        }

        //Get first item from queue
        public DataHarmonizationQueue GetFirstItemInQueue()
        {
            return _dataHarmonizationQueueRepository.GetFirstItemInQueue();
        }

        //bool is items in queue
        public bool ArePendingItemsInQueue()
        {
            return _dataHarmonizationQueueRepository.ArePendingItemsInQueue();
        }

        //Mark item as in process
        public DataHarmonizationQueue MarkAsInProcess(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            dataHarmonizationQueueItem.DataProcessorStatusId = 2;
            EditQueueItem(dataHarmonizationQueueItem);

            return dataHarmonizationQueueItem;
        }

        //mark item as complete
        public DataHarmonizationQueue CreateMarkAsComplete(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            dataHarmonizationQueueItem.DataProcessorStatusId = 3;
            //check if snapshot exists, it should
            var exists = _snapshotLicenseRepository.DoesLicenseSnapshotExist(dataHarmonizationQueueItem.LicenseId);
            if (exists)
            {
                dataHarmonizationQueueItem.DataProcessorStatusId = 3;
                EditQueueItem(dataHarmonizationQueueItem);
            }
            else
            {
                dataHarmonizationQueueItem.DataProcessorStatusId = 4;
                EditQueueItem(dataHarmonizationQueueItem);
            }

            return dataHarmonizationQueueItem;
        }

        public DataHarmonizationQueue DeleteMarkAsComplete(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            //check if snapshot exists, it shouldnt
            var exists = _snapshotLicenseRepository.DoesLicenseSnapshotExist(dataHarmonizationQueueItem.LicenseId);
            if (!exists)
            {
                dataHarmonizationQueueItem.DataProcessorStatusId = 3;
                EditQueueItem(dataHarmonizationQueueItem);
            }
            else
            {
                dataHarmonizationQueueItem.DataProcessorStatusId = 4;
                EditQueueItem(dataHarmonizationQueueItem);
            }
            return dataHarmonizationQueueItem;
        }

        //mark item as error
        public DataHarmonizationQueue MarkAsError(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            dataHarmonizationQueueItem.DataProcessorStatusId = 4;
            EditQueueItem(dataHarmonizationQueueItem);

            return dataHarmonizationQueueItem;
        }

        //get actionType
        public LU_ActionType GetActionType(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            return dataHarmonizationQueueItem.ActionType;
        }

        private void EditQueueItem(DataHarmonizationQueue item)
        {
            try
            {
                _dataHarmonizationQueueRepository.EditDataHarmonizationQueue(item);
            }
            catch (Exception e)
            {
                _logManager.LogErrors(e);
                throw new Exception("Error Updating DataHarmonizationQueue Item");
            }
        }
    }
}