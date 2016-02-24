using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{
    public class RankEntity :
        Microsoft.WindowsAzure.Storage.Table.TableEntity
    {
        public float Rank { get; set; }
       

        public RankEntity() { }

        public RankEntity(string blob, string user,float rank)
        {
            PartitionKey = blob;
            RowKey = user;
            Rank = rank;
        }

    }
}