using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class CrushingSeason
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 CrushingSeasonId { get; set; }
        //[EditLink]
        public String CrushingSeasonName { get; set; }
        //public DateTime CrushingStartDate { get; set; }
        //public DateTime CrushingEndDate { get; set; }
        //public Int32 MinutesDelayedStart { get; set; }
        //public Int32 MinutesEarlyEnd { get; set; }
        public Int32 SeasonYear { get; set; }

    }
}