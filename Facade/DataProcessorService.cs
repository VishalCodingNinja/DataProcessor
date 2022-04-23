using DataProcessor.Enums;
using DataProcessor.Interface;
using System;
namespace DataProcessor.Facade
{
    public class DataProcessorService : IDataProcessorService
    {
        private readonly IDataProcessor _dataProcessor;
        private readonly ILogger _logger;

        public DataProcessorService(IDataProcessor dataProcessor, ILogger logger) => (_dataProcessor, _logger) = ( dataProcessor, logger);

        public bool ProcessData(string fileNameWithPath)
        {
            try
            {
                _logger.Log($"DataProcessorType: {_dataProcessor.DataProcessorType}", $"{LogLevel.Information}");
                _dataProcessor.ProcessData(fileNameWithPath);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log($"{ex.Message}", $"{LogLevel.Exception}");
                return false;
            }
        }
    }
}
