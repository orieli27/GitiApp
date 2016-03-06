using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;

namespace dataHandler
{
    public partial class AddPic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    this.EnsureContainerExists();
                }
                //this wil load all user pictures
                this.RefreshGallery();
            }
            catch (System.Net.WebException we)
            {
                status.Text = "Network error: " + we.Message;
                if (we.Status == System.Net.WebExceptionStatus.ConnectFailure)
                {
                    status.Text += "<br />Please check if the blob service is running at " + ConfigurationManager.AppSettings["storageEndpoint"];
                }
            }
            catch (StorageException se)
            {
                Console.WriteLine("Storage service error: " + se.Message);
            }

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUp.HasFile)
            {
                string sound_id = null;
                string ext = Path.GetExtension(FileUp.PostedFile.FileName).ToLower();
                if (ext != ".jpg" && ext != ".png" && ext != ".bmp" && ext != ".jpeg")
                {
                    status.Text = "please save onle jpeg /bmp or png files";
                }
                else
                {
                    if (FileUp1.HasFile)
                    {
                        if (Path.GetExtension(FileUp1.PostedFile.FileName).ToLower() != ".mp3")
                        {
                            status.Text = "Only Mp3 files are supported has of now.";
                        }
                        else
                        {  //not avilable at this time
                            sound_id = Guid.NewGuid().ToString();
                            this.SaveSound(
                                sound_id,
                                NameBox.Text,
                                mainCategory.Text.ToString(),
                                secondery.Text.ToString(),
                                FileUp1.PostedFile.ContentType,
                                FileUp1.PostedFile.InputStream,
                                ""//System.Security.Principal.WindowsIdentity.GetCurrent().Name
                                    );
                        }
                    }
                    string blob_id = Guid.NewGuid().ToString();


                    //insert to the table

                    this.SaveImage(
                    blob_id,
                    NameBox.Text,
                    mainCategory.Text.ToString(),
                    secondery.Text.ToString(),
                    FileUp.PostedFile.ContentType,
                    FileUp.PostedFile.InputStream,
                    Context.User.Identity.GetUserName(),
                    rd_check.Checked

                    );
                    //saves word-blob index partition key is word text and row key is the blob id
                    CloudTable wordTable = getTable("Word");
                    saveWord(wordTable, new WordEntity(NameBox.Text, blob_id, sound_id));

                    //saves index to sub category retrive all images under spacific category
                    CloudTable SubTable = getTable("SubCat");
                    saveCat(SubTable, new SubCatEntity(secondery.SelectedValue.ToString(), NameBox.Text));

                    //saves rating details
                    CloudTable RatingTable = getTable("Rate");
                    CreateBlobRating(RatingTable, new RankEntity(blob_id, "total", 0));

                    //saves user-blob index
                    CloudTable userTable = getTable("UserBlobs");
                    saveUserBlob(userTable, new UserEntity(Context.User.Identity.GetUserName(), blob_id));
                    // CreateBlobRating(RatingTable, new RankEntity(sound_id, "total", 0));// not useable for now
                }
                RefreshGallery();
            }
            else
                status.Text = "No image file";
        }
        protected void saveUserBlob(CloudTable t, UserEntity u)
        {
            try
            {
                // Build insert operation.
                TableOperation insertOperation = TableOperation.Insert(u);
                // Execute the insert operation.
                t.Execute(insertOperation);

            }
            catch (DataServiceRequestException ex)
            {
                status.Text = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                   + ex.Message;
            }
        }
        //if we give the option to save categories
        private void saveCat(CloudTable t, SubCatEntity catWords)
        {
            try
            {
                // Build insert operation.
                TableOperation insertOperation = TableOperation.Insert(catWords);
                // Execute the insert operation.
                t.Execute(insertOperation);

            }
            catch (DataServiceRequestException ex)
            {
                status.Text = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                   + ex.Message;
            }

        }

        private void SaveImage(string id, string name, string mCat, string secondery, string contentType, Stream fiileStream, string owner, bool check)//, string catid, string lang, string owner, string contentType)
        {
            // Create a blob in container and upload image bytes to it
            var blob = this.GetContainer("pic").GetBlockBlobReference(id);
            blob.Properties.ContentType = contentType;
            // Create some metadata for this image
            blob.Metadata.Add("Id", id);
            blob.Metadata.Add("Text", name);
            blob.Metadata.Add("Category", String.IsNullOrEmpty(mCat) ? "General" : mCat);
            blob.Metadata.Add("subCat", String.IsNullOrEmpty(secondery) ? "General" : secondery);
            blob.Metadata.Add("Rating", "0.0");
            blob.Metadata.Add("Downloads", "0");
            blob.Metadata.Add("Tag", "NO");
            blob.Metadata.Add("Share", (check) ? "public" : "private");
            blob.Metadata.Add("Owner", String.IsNullOrEmpty(owner) ? " ? " : owner);
            blob.UploadFromStream(fiileStream);
            blob.SetMetadata();
            if (check)
                //send to queue 
                sendToQueue(id);
        }
        protected void sendToQueue(string id)
        {
            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureData"));
            CloudQueueClient queueClient = account.CreateCloudQueueClient();
            CloudQueue messageQueue = queueClient.GetQueueReference("urlqueue");
            messageQueue.CreateIfNotExists();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(id);//GetContainer("pic").GetBlockBlobReference(id).Uri.ToString());
            messageQueue.AddMessage(message);

        }
        private void SaveSound(string id, string name, string mCat, string secondery, string contentType, Stream fiileStream, string owner)//, string catid, string lang, string owner, string contentType)
        {
            // Create a blob in container and upload image bytes to it
            var blob = this.GetContainer("sound").GetBlockBlobReference(id);
            blob.Properties.ContentType = contentType;
            // Create some metadata for this image
            blob.Metadata.Add("Id", id);
            blob.Metadata.Add("Name", name);
            blob.Metadata.Add("Category", String.IsNullOrEmpty(mCat) ? "General" : mCat);
            //blob.Metadata.Add("Lang", String.IsNullOrEmpty(lang) ? "eu" : lang);
            blob.Metadata.Add("subCat", String.IsNullOrEmpty(secondery) ? "General" : secondery);
            blob.Metadata.Add("Tag", "NO");
            blob.Metadata.Add("Owner", String.IsNullOrEmpty(owner) ? " ? " : owner);
            blob.UploadFromStream(fiileStream);
            blob.SetMetadata();

            //send to queue 
            //sendToQueue(name);
        }
        private void saveWord(CloudTable t, WordEntity word)
        {
            try
            {
                // Build insert operation.
                TableOperation insertOperation = TableOperation.Insert(word);
                // Execute the insert operation.
                t.Execute(insertOperation);

            }
            catch (DataServiceRequestException ex)
            {
                status.Text = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                   + ex.Message;
            }
        }





        /// <summary>
        /// Cast out blob instance and bind it's metadata to metadata repeater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                List<picDetailes> w = new List<picDetailes>();
                var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                var blob = ((ListViewDataItem)(e.Item)).DataItem as CloudBlockBlob;
                // If this blob is a snapshot, rename button to "Delete Snapshot"
                if (blob != null)
                {
                    if (metadataRepeater != null)
                    {
                        w.Add(new picDetailes()
                        {
                            Text = blob.Metadata["Text"],
                            Rating = blob.Metadata["Rating"],
                            Uri = blob.Uri
                        });

                        //bind to metadata
                        metadataRepeater.DataSource = w;

                        metadataRepeater.DataBind();
                    }
                }
            }
        }



        protected void OnDeleteImage(object sender, CommandEventArgs e)
        {

            try
            {


                if (e.CommandName == "Delete")
                {
                    var blobUri = (string)e.CommandArgument;
                    var blob = this.GetContainer("pic").GetBlockBlobReference(blobUri);
                    blob.FetchAttributes();
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("AzureData"));

                    // Create the table client.
                    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                    // Create the CloudTable that represents the "word" table.
                    CloudTable table = tableClient.GetTableReference("UserBlobs");
                    string a = blob.Metadata["Text"].ToString();
                    string b = blob.Name.ToString();
                    
                    //string sub = blob.Metadata["SubCat"].ToString();
                    string owner = Context.User.Identity.GetUserName();

                    // // Create a retrieve operation that expects a customer entity.
                    TableOperation retrieveOperation2 = TableOperation.Retrieve<UserEntity>(owner, b);

                    // // Execute the operation.
                    TableResult fetchedRow = table.Execute(retrieveOperation2);
                    UserEntity toDelete = (UserEntity)fetchedRow.Result;
                    // Create the Delete TableOperation.
                    if (toDelete != null)
                    {
                        TableOperation deleteOperation2 = TableOperation.Delete(toDelete);
                        // Execute the operation.
                        table.Execute(deleteOperation2);
                    }
                    // bool result = blob.DeleteIfExists();
                    // status.Text = "";
                }
            }
            catch (StorageException se)
            {
                status.Text = "Storage client error: " + se.Message;
            }
            catch (Exception) { }
            RefreshGallery();
        }
        protected void delRow(CloudTable t, string p_key, string R_key)
        {


        }
        /// <param name="e"></param>
        protected void OnListItemDeleting(object sender, EventArgs e)
        {
        }
        #region
        private void EnsureContainerExists()
        {
            var container = GetContainer("pic");
            container.CreateIfNotExists();
            var permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }


        // will store pic and sound on diff containers
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


        private void RefreshGallery()
        {
            List<CloudBlockBlob> d = new List<CloudBlockBlob>();
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("AzureData"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("UserBlobs");

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<UserEntity> query = new TableQuery<UserEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, Context.User.Identity.GetUserName()));



            // Print the fields for each customer.
            foreach (UserEntity entity in table.ExecuteQuery(query))
            {
                CloudBlockBlob blob = this.GetContainer("pic").GetBlockBlobReference(entity.RowKey);
                if (blob != null)
                {
                    blob.FetchAttributes();
                    d.Add(blob);
                }

            }
            list.DataSource = d;
            list.DataBind();
            // RefreshGallery(NameBox.Text.ToString());
            // status.Text = "Total Number of images with the name-" + NameBox.Text.ToString() + ",is[" + i + "].";
            //list.DataSource =
            // this.GetContainer("pic").ListBlobs(null, true, BlobListingDetails.All, new BlobRequestOptions(), null);
            //list.DataBind();

        }



        private void CreateBlobRating(CloudTable t, RankEntity rate)
        {
            try
            {
                // Build insert operation.
                TableOperation insertOperation = TableOperation.Insert(rate);
                // Execute the insert operation.
                t.Execute(insertOperation);

            }
            catch (DataServiceRequestException ex)
            {
                status.Text = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                   + ex.Message;
            }
        }

        #endregion

        protected CloudTable getTable(string table)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                                           CloudConfigurationManager.GetSetting("AzureData"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(table);
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



    }

    class picDetailes
    {
        public string Text { get; set; }

        public string Rating { get; set; }

        public Uri Uri { get; set; }
    }
}