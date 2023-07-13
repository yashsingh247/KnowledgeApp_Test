using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Targets
{
    public class SeasonWeek
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 WeekId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        //[EditLink]
        public String CrushingSeasonName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }
        public Int16 YearNumber { get; set; }
        public Int16 MonthNumber { get; set; }
        public Int16 WeekNumber { get; set; }

        //[QuickFilter]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int16 Days { get; set; }
        public Int16 TargetDays { get; set; }
        //[EditLink]
        public String WeekName { get; set; }
        public Int16 WeekSerial { get; set; }
        public List<Unit> Unit { get; set; }
        public List<CrushingSeason> CrushingSeason { get; set; }
    }
}