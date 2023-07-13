using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class Mill
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MillId { get; set; }
        public Int16 MillCode { get; set; }
        //[EditLink]
        public String MillName { get; set; }
        public Int16 MillType { get; set; }
        public String MillTypeName { get;set;}
    }
}