using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
namespace dataHandler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Detailes> collected = new List<Detailes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }


        protected void secondery_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Detailes> collected = new List<Detailes>();
            List<Detailes> temp = new List<Detailes>();
            string m = mainCategory.SelectedValue.ToString();
            string s = secondery.SelectedValue.ToString();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AzureData"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("SubCat");

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<SubCatEntity> query = new TableQuery<SubCatEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, s));

            // Print the fields for each customer.
            foreach (SubCatEntity entity in table.ExecuteQuery(query))
            {
                temp = getDteailes(entity.RowKey.ToString());
                collected.Concat(temp);
                temp.Clear();

            }
            list.DataSource = collected;
            list.DataBind();


        }
        protected void OnListItemDeleting(object sender, EventArgs e)
        {
        }

        private void EnsureContainerExists()
        {
            var container = GetContainer();
            container.CreateIfNotExists();
            var permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }

        protected void mainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondery.Items.Clear();
            string mCat = mainCategory.SelectedItem.Value;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                                              CloudConfigurationManager.GetSetting("AzureData"));


            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable wordTable = tableClient.GetTableReference("Category");
            TableQuery<WordEntity> query = new TableQuery<WordEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, mCat));

            // Print the fields for each customer.
            foreach (WordEntity entity in wordTable.ExecuteQuery(query))
            {
                secondery.Items.Add(entity.RowKey.ToString());
            }
            secondery.DataBind();
        }

        protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                var blob = ((ListViewDataItem)(e.Item)).DataItem as CloudBlockBlob;
                // If this blob is a snapshot, rename button to "Delete Snapshot"
                if (blob != null)
                {
                    if (metadataRepeater != null)
                    {
                        //bind to metadata
                        metadataRepeater.DataSource = from key in blob.Metadata.Keys
                                                      select new
                                                      {
                                                          iteName = key,
                                                          Value = blob.Metadata[key]
                                                      };
                        metadataRepeater.DataBind();
                    }
                }
            }
        }
        private double CalcRating(string blobId, int selection)
        {
            double res = 5.0;
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AzureData"));




            return res;
        }
        private List<Detailes> getDteailes(string word)
        {
            List<Detailes> d = new List<Detailes>();
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
               CloudConfigurationManager.GetSetting("AzureData"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Word");

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<WordEntity> query = new TableQuery<WordEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, word));


            // Print the fields for each customer.
            foreach (WordEntity entity in table.ExecuteQuery(query))
            {

                d.Add(new Detailes()
                {
                    PicUrl = getUrl(entity.RowKey),
                    BlobName = getName(entity.RowKey),
                     Rating = getRating(entity.RowKey),
                    Text = word
                });
            }
            return d;
        }
        private CloudBlobContainer GetContainer()
        {
            // Get a handle on account, create a blob service client and get container proxy

            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureData"));
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName") + "-photo1");
        }
        private void RefreshGallery()
        {
            list.DataSource =
            this.GetContainer().ListBlobs(null, true, BlobListingDetails.All, new BlobRequestOptions(), null);
            list.DataBind();

        }
        //for a specific image/sound
        private void RefreshGallery(string blob)
        {

            list.DataSource =
            this.GetContainer().ListBlobs().OfType<CloudBlockBlob>().Where(b => b.Name.Equals(blob));//   (null, true, BlobListingDetails., new BlobRequestOptions(), null);
            list.DataBind();
        }

        protected void SearchB_Click(object sender, EventArgs e)
        {

            List<Detailes> d = new List<Detailes>();
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AzureData"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("Word");

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<WordEntity> query = new TableQuery<WordEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, NameBox.Text.ToString()));
            int i = 0;


            // Print the fields for each customer.
            foreach (WordEntity entity in table.ExecuteQuery(query))
            {

                d.Add(new Detailes()
                {
                    PicUrl = getUrl(entity.RowKey),
                    BlobName = getName(entity.RowKey),
                    Rating = getRating(entity.RowKey),
                    Text = NameBox.Text.ToString()
                });
                Console.WriteLine("{0}, {1}", entity.PartitionKey, entity.RowKey);
                i++;
            }
            list.DataSource = d;
            list.DataBind();
            // RefreshGallery(NameBox.Text.ToString());
            //status.Text = "Total Number of images with the name-" + NameBox.Text.ToString() + ",is[" + i + "].";
        }

        protected void Rate()
        {
        }
        public Uri getUrl(string blob)
        {
            return GetContainer("pic").GetBlockBlobReference(blob).Uri;

        }
        public string getName(string blob)
        {
            return GetContainer("pic").GetBlockBlobReference(blob).Name;

        }
        public string getRating(string blob)
        {
            CloudBlockBlob b = GetContainer("pic").GetBlockBlobReference(blob);
            b.FetchAttributes();
            return b.Metadata["Rating"];

        }

        private CloudBlobContainer GetContainer(String st)
        {
            // Get a handle on account, create a blob service client and get container proxy

            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureData"));
            var client = account.CreateCloudBlobClient();
            if (st.Equals("pic"))
                return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName") + "-photo1");
            else
                return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName") + "-sound");
        }

        protected void secondery_SelectedIndexChanged1(object sender, EventArgs e)
        {
            List<Detailes> collected = new List<Detailes>();
            List<Detailes> temp = new List<Detailes>();
            string m = mainCategory.SelectedValue.ToString();
            string s = secondery.SelectedValue.ToString();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AzureData"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("SubCat");

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<SubCatEntity> query = new TableQuery<SubCatEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, s));

            // Print the fields for each customer.
            foreach (SubCatEntity entity in table.ExecuteQuery(query))
            {
                temp = getDteailes(entity.RowKey.ToString());
                foreach (Detailes d in temp)
                {
                    collected.Add(d);
                }
                temp.Clear();

            }
            list.DataSource = collected;
            list.DataBind();
        }

        protected void add_Command(object sender, CommandEventArgs e)
        {

            CloudTable userTable = getTable("UserBlobs");
           
            try
            {
                
                // Build insert operation.
                TableOperation insertOperation = TableOperation.Insert(new UserEntity(Context.User.Identity.GetUserName(),e.CommandArgument.ToString()));
                // Execute the insert operation.
                userTable.Execute(insertOperation);

            }
            catch (DataServiceRequestException ex)
            {
                //status.Text = "Unable to connect to the table storage server. Please check that the service is running.<br>" + ex.Message;
            }
            string f= null;
        }
        protected CloudTable getTable(string table)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                                           CloudConfigurationManager.GetSetting("AzureData"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(table);
        }
    }
    class Detailes
    {
        public Uri PicUrl { get; set; }

        public Uri SndUrl { get; set; }

        public string Text { get; set; }

        public string Rating { get; set; }

        public string BlobName { get; set; }

    }
}