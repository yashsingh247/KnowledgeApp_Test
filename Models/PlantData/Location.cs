using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class Location
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 LocationId { get; set; }
        public Int32 LocationCode { get; set; }
        //[EditLink]
        public String LocationName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 PositionId { get; set; }
        public String PositionPositionName { get; set; }
        public String ShortName { get; set; }
    }
}