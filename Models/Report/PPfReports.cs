using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class PPfReports
    {
        public int UnitID { get; set; }
        public string UnitUnitName { get;set;}
        public string ShiftName { get; set; }
        public string LogHour { get; set; }
        public string CaneCrushed { get; set; }
        public string SugarBagged { get; set; }
        public string FBDAirTemperature { get; set; }

        public string ExhaustTemperature { get; set; }
        public string ImbitionPercent { get; set; }
        public DateTime EnterDate { get; set; }



    }
}