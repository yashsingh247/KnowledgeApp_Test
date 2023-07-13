using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Lab
{
    public class Stock
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 StockId { get; set; }
        //[EditLink]
        public DateTime EntryDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }


        //public Int32 DataPeriodId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        public String CrushingSeasonName { get; set; }
        public Decimal DayValue { get; set; }
        public List<Unit> Unit { get; set; }
        public List<Parameter> Parameter { get; set; }
        public List<CrushingSeason> CrushingSeason { get; set; }
    }
}