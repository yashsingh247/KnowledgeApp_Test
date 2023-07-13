using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class StopPage
    {
        public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string TotalTime { get; set; }
        public string Frequency { get; set; }
        public string DepartmentName { get; set; }
    }
}