using System.Threading.Tasks;

namespace DataProcessor.Interface
{
    public interface IDataProcessorService
    {
        public bool ProcessData(string fileNameWithPath);
    }
}
