using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KnowledgeApp_Test.Models.Sugar_Molasses
{
    public class SugarWeekTransaction
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SugarWeekTransactionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SugarGodownId { get; set; }
        //[EditLink]
        public String SugarGodownGodownNumber { get; set; }
        public Int32 TransactionWeek { get; set; }
        public Decimal IcumsaValue { get; set; }
        public Decimal MoistureValue { get; set; }
        public List<SugarGodown> SugarGodown { get; set; }
        public List<Unit> Unit { get; set; }
    }
}