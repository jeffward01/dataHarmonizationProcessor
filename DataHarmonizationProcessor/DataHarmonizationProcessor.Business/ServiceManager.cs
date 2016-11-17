using System;
using System.Runtime.InteropServices;
using DataHarmonizationProcessor.Business.Logging;
using DataHarmonizationProcessor.Business.Managers;
using DataHarmonizationProcessor.Business.Services;
using DataHarmonizationProcessor.Data.Repositories;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly IDataHarmonizationLogManager _logManager;
        private readonly IDataHarmonizationQueueService _dataHarmonizationService;
        private readonly IDataProcessorService _dataProcessorService;
        private readonly IDataHarmonizationManager _dataHarmonizationManager;
        private readonly IDataHarmonizationQueueRepository _dataHarmonizationQueueRepository;

        public  ServiceManager(IDataHarmonizationLogManager logManager, IDataHarmonizationQueueService dataHarmonizationQueueService, IDataProcessorService dataProcessorService, IDataHarmonizationManager dataHarmonizationManager, IDataHarmonizationQueueRepository dataHarmonizationQueueRepository)
        {
            _dataHarmonizationQueueRepository = dataHarmonizationQueueRepository;
            _dataHarmonizationManager = dataHarmonizationManager;
            _logManager = logManager;
            _dataProcessorService = dataProcessorService;
            _dataHarmonizationService = dataHarmonizationQueueService;
        }

        //check to see if queue has items
        public void ProcessQueue()
        {
            //check if items are in Queue
            var numberOfItemsInQueue = _dataHarmonizationService.GetPendingCountForAllActionRequests();

            if (numberOfItemsInQueue != 0)
            {
                _logManager.LogMessage(numberOfItemsInQueue + " items in Queue");
                while (numberOfItemsInQueue != 0)
                {
                    //get first item in queue
                    var firstPendingItem = GetFirstItemInQueue();
                    _logManager.LogMessage("Processing LicenseId " + firstPendingItem.LicenseId + ", Action Type: " + ReturnActionType(firstPendingItem.ActionTypeId));

                    if (firstPendingItem.ActionTypeId == 1)
                    {
                        //create
                        _logManager.LogMessage("About to create snapshot for LicenseId " + firstPendingItem.LicenseId);

                        _dataHarmonizationManager.CreateLicenseSnapshot(firstPendingItem.LicenseId, firstPendingItem);
                    }
                    else
                    {
                        //delete
                        _logManager.LogMessage("About to delete snapshot for LicenseId " + firstPendingItem.LicenseId);
                        _dataHarmonizationManager.DeleteLicenseSnapshot(firstPendingItem.LicenseId, firstPendingItem);
                    }
                    _logManager.LogMessage("Finsihed Processing LicenseId: "+firstPendingItem.LicenseId + " Action: " + ReturnActionType(firstPendingItem.ActionTypeId));
                    numberOfItemsInQueue = _dataHarmonizationService.GetPendingCountForAllActionRequests();
                    _logManager.LogMessage(numberOfItemsInQueue + " items in Queue");
                }
            }
            else
            {
                _logManager.LogMessage(numberOfItemsInQueue + " items in Queue.  Queue is empty.  Sleep for 5 seconds.");
                _dataProcessorService.PauseForXSeconds(5);
            }
        }

        private string ReturnActionType(int typeId)
        {
            return typeId == 1 ? "Create" : "Delete";
        }

        private DataHarmonizationQueue GetFirstItemInQueue()
        {
            var firstPendingItem = _dataHarmonizationService.GetFirstItemInQueue();
            firstPendingItem.ModifiedDate = DateTime.Now;
            _dataHarmonizationQueueRepository.EditDataHarmonizationQueue(firstPendingItem);
            return firstPendingItem;

        }
    }
}