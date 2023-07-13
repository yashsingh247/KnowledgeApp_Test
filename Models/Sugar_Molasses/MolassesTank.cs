using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Sugar_Molasses
{
    public class MolassesTank
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MolassesTankId { get; set; }
        //[EditLink]
        public String TankNumber { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 CrushingSeasonId { get; set; }
        public String CrushingSeasonCrushingSeasonName { get; set; }
        public String Grade { get; set; }
        public Decimal Opening { get; set; }
        public Boolean Discontinued { get; set; }
        //public List<CrushingSeason> CrushingSeason { get; set; }
    }
}