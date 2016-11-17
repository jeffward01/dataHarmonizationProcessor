using System;

namespace DataHarmonizationProcessor.Business.Logging
{
    public interface IDataHarmonizationLogManager
    {
        void LogErrors(Exception ex);
        void LogMessage(string message);
    }
}