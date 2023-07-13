using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.TPT
{
    public class UnitParameter
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 UnitParameterId { get; set; }
        //[EditLink]
        public Int32 UnitId { get; set; }
        public Int32 ParameterId { get; set; }
    }
}