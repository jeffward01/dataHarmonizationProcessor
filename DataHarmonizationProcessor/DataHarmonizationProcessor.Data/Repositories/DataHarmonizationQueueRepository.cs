using System.Data.Entity;
using DataHarmonizationProcessor.Data.Infrastructure;
using System.Linq;
using UMPG.USL.Models.DataHarmonization;

namespace DataHarmonizationProcessor.Data.Repositories
{
    public class DataHarmonizationQueueRepository : IDataHarmonizationQueueRepository
    {
        public int GetPendingCountForAllActionRequests()
        {
            using (var context = new DataContext())
            {
                return context.DataHarmonizationQueues.Count(_ => _.DataProcessorStatusId == 1);
            }
        }

        public int GetPendingCountForCreateRequests()
        {
            using (var context = new DataContext())
            {
                return context.DataHarmonizationQueues.Where(_ => _.ActionTypeId == 1).Count(_ => _.DataProcessorStatusId == 1);
            }
        }

        public int GetPendingCountForDeleteRequests()
        {
            using (var context = new DataContext())
            {
                return context.DataHarmonizationQueues.Where(_ => _.ActionTypeId == 2).Count(_ => _.DataProcessorStatusId == 1);
            }
        }

        public DataHarmonizationQueue GetFirstItemInQueue()
        {
            using (var context = new DataContext())
            {
                return context.DataHarmonizationQueues.FirstOrDefault(_ => _.DataProcessorStatusId == 1);
            }
        }

        public bool ArePendingItemsInQueue()
        {
            using (var context = new DataContext())
            {
                return context.DataHarmonizationQueues.Any(_ => _.DataProcessorStatusId == 1);
            }
        }

        public DataHarmonizationQueue EditDataHarmonizationQueue(DataHarmonizationQueue dataHarmonizationQueue)
        {
            using (var context = new DataContext())
            {
                context.Entry(dataHarmonizationQueue).State = EntityState.Modified;
                context.SaveChanges();
                return dataHarmonizationQueue;
            }
        }

        public DataHarmonizationQueue CreateDataHarmonizationRequest(DataHarmonizationQueue dataHarmonizationQueueItem)
        {
            using (var context = new DataContext())
            {
                context.DataHarmonizationQueues.Add(dataHarmonizationQueueItem);
                context.SaveChanges();
                return dataHarmonizationQueueItem;
            }
        }
    }
}