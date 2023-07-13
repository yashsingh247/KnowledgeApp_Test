using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class ClarificationType
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ClarificationTypeId { get; set; }
        public Int16 ClarificationTypeCode { get; set; }
        //[EditLink]
        public String ClarificationName { get; set; }
        public Int16 ClarificationNature { get; set; }
    }
}