using System;

namespace DataHarmonizationProcessor.Business.Services
{
    public class DataProcessorService : IDataProcessorService
    {
        private readonly ITimeSpanUtil _timeSpanUtil;
        public DataProcessorService(ITimeSpanUtil timeSpanUtil)
        {
            _timeSpanUtil = timeSpanUtil;
        }
        public void PauseForXSeconds(int secondCount)
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(_timeSpanUtil.ConvertSecondsToMilliseconds(secondCount)));
        }
    }
}