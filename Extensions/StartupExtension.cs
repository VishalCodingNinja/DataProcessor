using DataProcessor.Enums;
using DataProcessor.Facade;
using DataProcessor.Implementation;
using DataProcessor.Interface;
using DataProcessor.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataProcessor.Extensions
{
    public static class StartupExtension
    {
        public static Config StartupWithAssemblyReflectionLibraries(this Program program) {
            // Declare Instance of class Assembly
            // Call the GetExecutingAssembly method
            // to load the current assembly
            Assembly executing = Assembly.GetExecutingAssembly();

            // Array to store types of the assembly
            Type[] types = executing.GetTypes();


            Console.Write("Enter the file path --filePath : ");
            var filePathOfDataSource = Console.ReadLine();
            Console.WriteLine("Types of data Available: " + GetDataTypesAvailable());
            Console.WriteLine("Note: **Name of the datatypes are case sensitive**");
            Console.Write("Enter the data type --datatype : ");
            var dataTypeObjectName = Console.ReadLine();
            var fullName = types.Where(type => type.Name == dataTypeObjectName).FirstOrDefault().FullName;
            IDataProcessor dataProcessor = (IDataProcessor)executing.CreateInstance(fullName);
            ILogger logger = (ILogger)executing.CreateInstance("DataProcessor.Implementation.Logger");
            return new Config(new DataProcessorService(dataProcessor, logger), filePathOfDataSource);
        }

        public static async Task StartupWithIHostReflectionLibrariesAsync(this Program program, string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
                    .AddScoped<IDataProcessorService, DataProcessorService>()
                    .AddScoped<IDataProcessor, TextDataProcessor>()
                    .AddSingleton<ILogger, Logger>())
            .Build();

            await host.RunAsync();
        }

        private static string GetDataTypesAvailable()
        {
            // We can cofigure these data types in database or sitefinity also(instead of reading from enums)
            string dataTypeString = "";
            foreach (DataType dataType in Enum.GetValues(typeof(DataType)))
            {
                dataTypeString += $"   { dataType}";
            }
            dataTypeString += " ";
            return dataTypeString;
        }
    }
}
