using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class Position
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 PositionId { get; set; }
        public Int16 PositionCode { get; set; }
        //[EditLink]
        public String PositionName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 MillParameterId { get; set; }
        public String MillParameterMillParameterName { get; set; }
        public String ShortName { get; set; }
    }
}