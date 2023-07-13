using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class Grower
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 GId { get; set; }
        public Int32 GVill { get; set; }
        public String GVillVName { get; set; }
        public Int16 GCode { get; set; }
        //[EditLink]
        public String GName { get; set; }
        public String GFather { get; set; }
        public String GHname { get; set; }
        public String GHfather { get; set; }
        public String GCreatedBy { get; set; }
        public String GEditedBy { get; set; }
        public String UnitName { get; set; }
        public Int32 UnitId { get; set; }
        //public List<Unit> Unit { get; set; }
       // public List<Village> Village { get; set; }
    }
}