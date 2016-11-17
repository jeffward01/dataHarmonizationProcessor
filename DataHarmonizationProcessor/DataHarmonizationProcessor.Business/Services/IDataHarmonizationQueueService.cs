using UMPG.USL.Models.DataHarmonization;
using UMPG.USL.Models.LookupModel;

namespace DataHarmonizationProcessor.Business.Services
{
    public interface IDataHarmonizationQueueService
    {
        int GetPendingCountForAllActionRequests();
        int GetPendingCountForCreateRequests();
        int GetPendingCountForDeleteRequests();
        DataHarmonizationQueue GetFirstItemInQueue();
        bool ArePendingItemsInQueue();
        DataHarmonizationQueue CreateMarkAsComplete(DataHarmonizationQueue dataHarmonizationQueueItem);
        DataHarmonizationQueue MarkAsInProcess(DataHarmonizationQueue dataHarmonizationQueueItem);
        DataHarmonizationQueue DeleteMarkAsComplete(DataHarmonizationQueue dataHarmonizationQueueItem);
        DataHarmonizationQueue MarkAsError(DataHarmonizationQueue dataHarmonizationQueueItem);
        LU_ActionType GetActionType(DataHarmonizationQueue dataHarmonizationQueueItem);
    }
}