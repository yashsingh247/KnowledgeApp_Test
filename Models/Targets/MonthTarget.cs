using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Targets
{
    public class MonthTarget
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MonthTargetId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        //[EditLink]
        public String CrushingSeasonName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 MonthId { get; set; }
        //[EditLink]
        public String MonthName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }
        public Decimal TargetValue { get; set; }
        public Decimal ActualValue { get; set; }
        public List<Unit> Unit { get; set; }
        public List<CrushingSeason> CrushingSeason { get; set; }
        public List<SeasonMonth> SeasonMonth { get; set; }
        public List<Parameter> Parameter { get; set; }
    }
}