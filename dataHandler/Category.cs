using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{
    public class CategoryEntity : 
        Microsoft.WindowsAzure.Storage.Table.TableEntity
    { 
        
        public string Description { get; set; }

        public CategoryEntity() { }

        public CategoryEntity(string name, string sub,string desc)
        {
            PartitionKey = name;
            RowKey = sub;
            Description = desc;
            
        }

    }
}