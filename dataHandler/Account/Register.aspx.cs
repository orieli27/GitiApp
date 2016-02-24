using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using dataHandler.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Table;

namespace dataHandler.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the storage account from the connection string.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("Data"));

                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                // Create the table if it doesn't exist.
                CloudTable table = tableClient.GetTableReference("Users");
                table.CreateIfNotExists();

              
                TableOperation retrieveOperation = TableOperation.Retrieve<UserEntity>(tb_UserName.Text.Substring(0,1), tb_UserName.Text);
                TableResult retrievedResult = table.Execute(retrieveOperation);
                UserEntity fetchedEntity = retrievedResult.Result as UserEntity;
                if ( fetchedEntity != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('User Name Exist Please Select a new one.');", true);
                }

                String admin="n";
                if (cb_admin.Checked)
                    admin = "y";
                UserEntity newUser = createNewUser(tb_UserName.Text, Password.Text, Email.Text,admin);

                // Create the TableOperation object that inserts the customer entity.
                TableOperation insertOperation = TableOperation.Insert(newUser);

                // Execute the insert operation.
                table.Execute(insertOperation);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //System.Windows.Forms.MessageBox.Show("Error while register process... please try again", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected UserEntity createNewUser(String user,String pass,String email ,String admin)
        {
            UserEntity newUser = new UserEntity(user,pass,email,admin);
            return newUser;
        }

        protected void checkUserName(object sender, EventArgs e)
        {
            int x = 9;
        }

        protected void tb_UserName_TextChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}