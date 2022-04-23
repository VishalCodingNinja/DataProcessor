using DataProcessor.Interface;
using System;
namespace DataProcessor.Implementation
{
    public class Logger : ILogger
    {
        public void Log(string message, string logLevel)
        {
            Console.WriteLine($"Log Level: {logLevel}, Message: {message}");
        }
    }
}
