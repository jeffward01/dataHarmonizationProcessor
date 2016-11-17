using NLog;
using System;

namespace DataHarmonizationProcessor.Business.Logging
{
    public class DataHarmonizationLogManager : IDataHarmonizationLogManager
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void LogErrors(Exception ex)
        {
            _logger.Debug(ex.Message);
            _logger.Debug(ex.StackTrace);
            _logger.Debug(ex.InnerException);
        }

        public void LogMessage(string message)
        {
            _logger.Debug(message);
        }
    }
}