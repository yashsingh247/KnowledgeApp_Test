using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Parameters
{
    public class EntryType
    {
        public Int32 EntryTypeId { get; set; }
        //[EditLink]
        public String EntryTypeName { get; set; }
        public Int32 EntryOrder { get; set; }
    }
}