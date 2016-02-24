using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dataHandler
{
    public class WordEntity : 
        Microsoft.WindowsAzure.Storage.Table.TableEntity
    { 
        public string Name { get; set; }
        public string Blob { get; set; }


        public WordEntity() { }

        public WordEntity(string name, string blob,string snd)
        {
            PartitionKey = name;
            RowKey = blob;
            Name = name;
            Blob = snd;
        }

    }
}