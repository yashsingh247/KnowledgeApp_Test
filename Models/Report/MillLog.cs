using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class MillLog
    {
        public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public string MillParameterCode { get; set; }
        public string MillParameterName { get; set; }
        public string MillName { get; set; }
        public string LogDate { get; set; }
        public string PositionShortName { get; set; }
        public string LocationShortName { get; set; }
        public string LogHour { get; set; }
        public string LogValue { get; set; }
        public DateTime Entrydate1 { get; set;}
        public DateTime Entrydate2 { get;set; }
    }
}