using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class TPTReports
    {
        public int UnitId { get; set; } 
        public int RevisionID { get; set; }
        public int CrushingSeasonid { get; set; }
        public string UnitUnitName { get; set; }
        public string ParameterCode { get; set; }
        public string RevisionName { get; set; }
        public string ParameterName { get; set; }
        public string Target { get; set; }
        public string Actual { get; set; }
        public string DeviationOfSubstract { get; set; }
        public string DeviationOfPercents { get; set; }
    }
}