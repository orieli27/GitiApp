using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{
    public class LangEntity : 
        Microsoft.WindowsAzure.Storage.Table.TableEntity
    { 
        public string Name { get; set; }
        public string Body { get; set; }

        public LangEntity() { }

        public LangEntity(string name, string body)
        {
            PartitionKey = "Lang";
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - 
                DateTime.Now.Ticks, Guid.NewGuid());
            Name = name;
            Body = body;
        }

    }
}