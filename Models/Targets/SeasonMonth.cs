using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Unit = KnowledgeApp_Test.Models.Common.Unit;

namespace KnowledgeApp_Test.Models.Targets
{
    public class SeasonMonth
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MonthId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        //[EditLink]
        public String CrushingSeasonName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }
        public Int16 YearNumber { get; set; }
        public Int16 MonthNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int16 Days { get; set; }
        public Int16 TargetDays { get; set; }
        //[EditLink]
        public String MonthName { get; set; }
        public Int16 MonthSerial { get; set; }
        public List<Unit> Unit { get; set; }
        public List<Parameter> Parameter { get; set; }
        public List<CrushingSeason> CrushingSeason { get; set; }
    }
}