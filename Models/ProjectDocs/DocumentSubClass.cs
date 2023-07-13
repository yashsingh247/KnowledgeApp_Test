using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class DocumentSubClass
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DocumentSubClassId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentClassId { get; set; }
        public Int16 SubClassCode { get; set; }
        //[EditLink]
        public String SubClassName { get; set; }
        public String ShortCode { get; set; }
        public List<DocumentClass> DocumentClass { get; set; }
    }
}