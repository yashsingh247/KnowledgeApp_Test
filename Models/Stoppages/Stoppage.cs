using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class Stoppage
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 StoppageId { get; set; }
        //[Visible(false)]
        public Int32 UnitId { get; set; }
        //[EditLink, QuickFilter]
        public String UnitUnitName { get; set; }
        //public Int32 DataPeriodId { get; set; }

        //[QuickFilter, Visible(false)]
        public Int32 CrushingSeasonId { get; set; }
        public String CrushingSeasonName { get; set; }
        //[QuickFilter]
        public DateTime StoppageDate { get; set; }
        public Int16 DateSerial { get; set; }
        public DateTime StoppageStart { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public DateTime StoppageTill { get; set; }
        public String StationCode { get; set; }
        public Int16 Duration { get; set; }
        //[EditLink]
        public String DurationHour { get; set; }
        public String Remarks { get; set; }
        public String SpareProcessCode { get; set; }
        public String DefectCode { get; set; }
        public String ActionCode { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 StationId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SpareProcessId { get; set; }
        public String SpareProcessName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DefectId { get; set; }
        public String DefectDefectName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ActionId { get; set; }
        public String ActionActionName { get; set; }
        public List<Unit> Unit { get; set; }
        public List<CrushingSeason> CrushingSeason { get; set; }
        public Int16 StoppageType { get; set; }
        public List<StoppageStation> StoppageStation { get; set; }
        public List<StoppageSparesProcess> StoppageSparesProcess { get; set; }
        public List<StoppageDefect> StoppageDefect { get; set; }
        public List<StoppageActionTaken> StoppageActionTaken { get; set; }
      public String StoppageTypeName { get; set; }



    }
    public class StoppageType 
    
    {
    public int StoppageTypeId { get; set; }
    public string StoppageTypeName { get; set; }
    }


}
  