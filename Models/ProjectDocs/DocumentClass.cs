using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class DocumentClass
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DocumentClassId { get; set; }
        public Int16 ClassCode { get; set; }
        //[EditLink]
        public String ClassName { get; set; }
        public String ShortCode { get; set; }
    }
}