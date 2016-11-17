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

        public DataHarmonizationQueueService(IDataHarmonizationQueueRepository dataHarmonizationQueueRepository, IDataHarmonizationLogManager logManager)
        {
            _logManager = logManager;
            _dataHarmonizationQueueRepository = dataHarmonizationQueueRepository;
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
            try
            {
                dataHarmonizationQueueItem =
                _dataHarmonizationQueueRepository.EditDataHarmonizationQueue(dataHarmonizationQueueItem);
            }
            catch (Exception e)
            {
                _logManager.LogErrors(e);
                throw new Exception("Error Updating DataHarmonizationQueue Item");
            }
            return dataHarmonizationQueueItem;
        }

        //mark item as complete
        public DataHarmonizationQueue MarkAsComplete(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            dataHarmonizationQueueItem.DataProcessorStatusId = 3;
            try
            {
                dataHarmonizationQueueItem =
                _dataHarmonizationQueueRepository.EditDataHarmonizationQueue(dataHarmonizationQueueItem);
            }
            catch (Exception e)
            {
                _logManager.LogErrors(e);
                throw new Exception("Error Updating DataHarmonizationQueue Item");
            }
            return dataHarmonizationQueueItem;
        }

        //mark item as error
        public DataHarmonizationQueue MarkAsError(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            dataHarmonizationQueueItem.DataProcessorStatusId = 4;
            try
            {
                dataHarmonizationQueueItem =
                _dataHarmonizationQueueRepository.EditDataHarmonizationQueue(dataHarmonizationQueueItem);
            }
            catch (Exception e)
            {
                _logManager.LogErrors(e);
                throw new Exception("Error Updating DataHarmonizationQueue Item");
            }
            return dataHarmonizationQueueItem;
        }

        //get actionType
        public LU_ActionType GetActionType(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            return dataHarmonizationQueueItem.ActionType;
        }
    }
}