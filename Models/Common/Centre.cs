using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class Centre
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 CId { get; set; }
        public Int32 CCode { get; set; }
        //[EditLink]
        public String CName { get; set; }
        public String CHname { get; set; }
        public String CCreatedBy { get; set; }
        public String CEditedBy { get; set; }
        public String UnitName { get; set; }
        public Int32 UnitID { get; set; }
        //public List<Unit> Unit { get; set; }
    }
}