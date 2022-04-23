using DataProcessor.Interface;
using System;
using System.IO;
using System.Linq;
namespace DataProcessor.Implementation
{
    public class BinaryDataProcessor : IDataProcessor
    {
        public string DataProcessorType { get; set; }
        public BinaryDataProcessor()
        {
            DataProcessorType = "BinaryDataProcessor";
        }
        public void ProcessData(string filePath)
        {
            var bytes = File.ReadAllBytes(filePath);
            var file = Convert.ToBase64String(bytes);
            foreach (var selectedChar in file.Take(7))
                Console.WriteLine(selectedChar);
        }
    }
}
