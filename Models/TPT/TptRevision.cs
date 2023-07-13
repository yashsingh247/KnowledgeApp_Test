using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.TPT
{
    public class TptRevision
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 RevisionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        public Int16 RevisionCode { get; set; }
        //[EditLink]
        public String RevisionName { get; set; }
        //[QuickFilter]
        public DateTime CreationDate { get; set; }
        public DateTime SeasonStartDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        public String CrushingSeasonCrushingSeasonName { get; set; }
        public Int16 SeasonDays { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public List<Unit> Unit { get;set;}
        public List<CrushingSeason> CrushingSeason { get; set; }
    }
}