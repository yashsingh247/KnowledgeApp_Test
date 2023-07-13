using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class SugarWeekTransaction
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SugarWeekTransactionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }

        //[Visible(false), QuickFilter]

        // Rohit 
        public Int32 SugarGodownId { get; set; }
        public string TransactionDate { get; set; }
        public string Production { get; set; }
        public string ShiftingIN { get; set; }
        public string Sales { get; set; }
        public string ShiftingOut { get; set; }
        public string TornBagCount { get; set; }
        public string ICUMSAValue { get; set; }
        public string MoistureValue { get; set; }
        public string LineReplaceDate { get; set; }
        public string Opening { get; set; }

        //Rohit 
        //[EditLink]
        public String SugarGodownGodownNumber { get; set; }
        public Int32 TransactionWeek { get; set; }
        public Decimal IcumsaValue { get; set; }
        public DateTime Entrydate1 { get; set; }
        public DateTime Entrydate2 { get; set; }
        //public Decimal MoistureValue { get; set; }


    }
}