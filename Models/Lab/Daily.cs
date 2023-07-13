using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Lab
{
    public class Daily
    {

       
        public Int32 DailyId { get; set; }

      
        public DateTime EntryDate { get; set; }
        
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }

       
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }

      
        public Int32 CrushingSeasonId { get; set; }
        public String CrushingSeasonName { get; set; }
        public Decimal DayValue { get; set; }
        public Decimal TodateValue { get; set; }
        public Decimal PrevDayValue { get; set; }
        public Decimal PrevTodateValue { get; set; }
        public List<Unit> Unit { get; set; }
        public List<Parameter> Parameter { get; set; }
        public List<CrushingSeason> CrushingSeason { get; set; }
    }
}