using DataProcessor.Interface;
using System;
using System.IO;
using System.Linq;
using System.Text;
namespace DataProcessor.Implementation
{
    public class TextReverseDataProcessor : IDataProcessor
    {
        public string DataProcessorType { get; set; }
        public TextReverseDataProcessor()
        {
            DataProcessorType = "TextReverseDataProcessor";
        }
        public void ProcessData(string filePath)
        {
            if (File.Exists(filePath))
            {
                using var reader = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        foreach (var selectedChar in line.Take(7).Reverse())
                            Console.WriteLine(selectedChar);
                        return;
                    }
                }
            }
        }
    }
}
