using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Azure;

namespace populateDB
{
    class Common
    {
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }

        public static CloudTable CreateTable(string tableName)
        {
            string storageConnectionString;
#if DEBUG
            storageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionStringLocal");

#else
            storageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
#endif

            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);
            Console.WriteLine("Using connection string: " + storageConnectionString);
            
            // Create a table client for interacting with the table service
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            Console.WriteLine("Create a Table for the demo");

            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);
            if (table.CreateIfNotExists())            
            {
                Console.WriteLine("Created Table named: {0}", tableName);
            }
            else
            {
                Console.WriteLine("Table {0} already exists", tableName);
            }

            Console.WriteLine();
            return table;
        }
    }
}
