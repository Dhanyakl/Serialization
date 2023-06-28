using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriallization
{
    public class SerializeExecution : ISerialization
    {
        class Configuration
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public void WriteConfig()
        {
            try
            {
                Configuration configuration = GetConfiguration();

                // Serialize the Configuration object to JSON
                string json = JsonConvert.SerializeObject(configuration, Formatting.Indented);

                // Write the JSON to a file
                File.WriteAllText("config.json", json);

                Console.WriteLine("Configuration file updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static Configuration GetConfiguration()
        {
            return new Configuration
            {
                Server = "localhost",
                Database = "mydb",
                Username = "admin",
                Password = "password123"
            };
        }

        public void ReadConfig()
        {
            try
            {
                // Read the JSON file
                string json = File.ReadAllText("config.json");

                // Deserialize the JSON into a Configuration object
                Configuration configuration = JsonConvert.DeserializeObject<Configuration>(json);
               
                Console.WriteLine(json);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
