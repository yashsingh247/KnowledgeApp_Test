using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class Village
    {
        public Int32 VId { get; set; }
        public Int16 VCode { get; set; }
        //[EditLink]
        public String VName { get; set; }
        public String VHname { get; set; }
        public String VCentreCName { get; set; }
        public String VCreatedBy { get; set; }
        public String VEditedBy { get; set; }
        public String UnitName { get; set; }
        public Int32 Centreid { get; set; } 
        public Int32 UnitId { get; set; }
        //public List<Unit> Unit { get; set; }
        //public List<Centre> Centre { get; set; }
    }
}