using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class UnitCrushingSeason
    {
       

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 UnitCrushingSeasonId { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        //[EditLink]
        public String CrushingSeasonName { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }
        //[QuickFilter]
        public DateTime CrushingStartDate { get; set; }

        public DateTime CrushingEndDate { get; set; }
        //[Visible(false)]
        public Int32 MinutesDelayedStart { get; set; }
        //[Visible(false)]
        public Int32 MinutesEarlyEnd { get; set; }

        public List<CrushingSeason> CrushingSeason { get; set; }
        public List<Unit> Unit { get; set; }

    }
    

}