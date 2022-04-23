namespace DataProcessor.Interface
{
    public interface IDataProcessor
    {
        public string DataProcessorType { get; set; }
        void ProcessData(string filePath);
    }
}
