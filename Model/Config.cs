using DataProcessor.Interface;
namespace DataProcessor.Model
{
    public class Config
    {
        public IDataProcessorService DataProcessorService { get; set; }
        public string FilePath { get; set; }
        public Config(IDataProcessorService dataProcessorService, string filePath) => (DataProcessorService, FilePath) = (dataProcessorService, filePath);
    }
}
