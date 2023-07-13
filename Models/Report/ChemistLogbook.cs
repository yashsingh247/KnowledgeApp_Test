using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class ChemistLogbook
    {
        public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public string DepartmentName { get; set; }
        public string ShiftID { get; set; }
        public string ShiftName { get; set; }
        public string DocumentNumber { get; set; }
        public string Observations { get; set; }
        public string WorkDone { get; set; }
        public string WorkToBeDone { get; set; }
        public string Remarks { get; set; }
        public int ShiftInchargeID { get; set; }
        public string SubDepartmentName { get; set; }
        public DateTime AnalysisDate { get; set; }

    }
}