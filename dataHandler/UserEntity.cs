using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{
    public class UserEntity : TableEntity
    {
        
        public string email { get; set; }
        public string pass { get; set; }

         public string admin { get; set; }

         public string user { set; get; }
        public UserEntity() { }

        public UserEntity(string user, string pass, string email,string admin)
        {
            PartitionKey = user.Substring(0,1);
            RowKey = user;
            this.pass = pass;
            this.email = email;
            this.admin = admin;
        }
    }
}