using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{
    public class UserEntity : TableEntity
    {

        public string blob { get; set; }

        public UserEntity() { }

        public UserEntity(string user, string blob)
        {
            PartitionKey = user;
            RowKey = blob;

        }
    }
}