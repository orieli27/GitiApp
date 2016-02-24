using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace dataHandler
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("Data"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            CloudTable wordTable = getTable(tableClient, "Word");
            CloudTable catTable = getTable(tableClient, "Category");
            CloudTable RatingTable = getTable(tableClient, "Rate");
            CloudTable wbTable = getTable(tableClient, "SubCat");
            CloudTable userTable = getTable(tableClient, "UserBlobs");


            return base.OnStart();
        }
        public CloudTable getTable(CloudTableClient tableClient, string name)
        {
            CloudTable table = tableClient.GetTableReference(name);
            table.CreateIfNotExists();
            return table;

        }
    }
}
