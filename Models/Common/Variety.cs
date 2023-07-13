using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class Variety
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 VrId { get; set; }
        public Int16 VrCode { get; set; }
        //[EditLink]
        public String VrName { get; set; }
        public Decimal VrMaxRec { get; set; }
        public DateTime VrMaxdt { get; set; }
        public Int16 VrMatPeriod { get; set; }
        public Decimal VrAvgLoss { get; set; }
        public String VrCreatedBy { get; set; }
        public String VrEditedBy { get; set; }
        public String UnitName { get; set; }
        public Int32 UnitId { get; set; }
        //public List<Unit> Unit { get; set; }
    }
}