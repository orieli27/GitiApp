using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{

    public class SubCatEntity :
        Microsoft.WindowsAzure.Storage.Table.TableEntity
    { 
       
        public SubCatEntity() { }

        public SubCatEntity(string sub, string name)
        {
            PartitionKey = sub;
            RowKey = name;
            
        }

    }
}