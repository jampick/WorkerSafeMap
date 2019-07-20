using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using Microsoft.WindowsAzure;

namespace WorkSafeMap.Controllers.shared
{
    public class DataAccess
    {
        public static CloudTable GetDataTable(string name)
        {
            // Retrieve the storage account from the connection string.
#if DEBUG
            CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
#else
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
#endif
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(name);

            return table;
        }

    }
}