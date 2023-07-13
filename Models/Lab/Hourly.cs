using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Lab
{
    public class Hourly
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 HourlyId { get; set; }

        //[EditLink, QuickFilter]
        public DateTime EntryDate { get; set; }
        public Int16 EntryHour { get; set; }

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
        public Decimal HourValue { get; set; }
        public Decimal DayValue { get; set; }
        public Decimal PrevHourValue { get; set; }
        public Decimal PrevDayValue { get; set; }
       
    }
}