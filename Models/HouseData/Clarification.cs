using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class Clarification
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ClarificationId { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 ClarificationTypeId { get; set; }
        public String ClarificationTypeName { get; set; }
        public Int16 ClarificationCode { get; set; }
        //[EditLink]
        public String ClarificationName { get; set; }
        public List<ClarificationType> ClarificationType { get; set; }
    }
}