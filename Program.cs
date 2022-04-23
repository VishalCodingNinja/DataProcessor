using System;
using System.Threading.Tasks;
using DataProcessor.Extensions;

namespace DataProcessor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var program = new Program();
            var config = program.StartupWithAssemblyReflectionLibraries();

            // await program.StartupWithIHostReflectionLibrariesAsync(args);

            var isDataProcessSuccessful = config.DataProcessorService.ProcessData(config.FilePath);

            if (isDataProcessSuccessful)
            {
                Console.WriteLine($"Data Process is Successful");
            }
            else
            {
                Console.WriteLine($"Data Process is UnSuccessful");
            }

        }


    }
}
