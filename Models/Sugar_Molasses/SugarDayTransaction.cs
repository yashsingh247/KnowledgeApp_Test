using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Sugar_Molasses
{
    public class SugarDayTransaction
    {
       
        public Int32 SugarDayTransactionId { get; set; }
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        public Int32 SugarGodownId { get; set; }
        public String SugarGodownGodownNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Production { get; set; }
        public Decimal ShiftingIn { get; set; }
        public Decimal Sales { get; set; }
        public Decimal ShiftingOut { get; set; }
        public Decimal TornBagCount { get; set; }
        public Decimal IcumsaValue { get; set; }
        public Decimal MoistureValue { get; set; }
        public DateTime LineReplaceDate { get; set; }

    }
}