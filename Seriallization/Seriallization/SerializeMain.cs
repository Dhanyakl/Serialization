using Seriallization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Serialization
{
    class SerializeMain 
    {
       private static void SelectOption(ISerialization Serialize)
        {
            try
            {
                Console.WriteLine("Select an option to proceed : ");
                Console.WriteLine("1 : Write a JSON configuration file.");
                Console.WriteLine("2 : Read a JSON configuration file.");
                int selectedOption = Convert.ToInt16(Console.ReadLine());
                switch (selectedOption)
                {
                    case 1:
                        // Writes config file
                        Serialize.WriteConfig();
                        break;
                    case 2:
                        //Reads config file
                        Serialize.ReadConfig();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

       private static void ExecuteSerialization(ISerialization Serialize)
        {
            try
            {
                SelectOption(Serialize);
                Console.WriteLine();
                Console.WriteLine("Do you want to continue. Press Y or N");
                var response = Console.ReadLine();
                if (response != null &&
                    response.ToUpper() == "Y")
                {
                    ExecuteSerialization(Serialize);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var instance = host.Services.GetService<ISerialization>();
            ExecuteSerialization(instance);

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ISerialization, SerializeExecution>();
                });

            return hostBuilder;
        }
    }
}





