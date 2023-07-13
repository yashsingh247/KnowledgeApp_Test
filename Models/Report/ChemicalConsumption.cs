using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class ChemicalConsumption
    {
          public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public string ChemicalName { get; set; }
        public string BalanceOfPerShift { get; set; }
        public string IssuedQuantity { get; set; }
        public string Total { get; set; }
        public string ConsumedQuantity { get; set; }
        public string bal { get; set; }
        public DateTime AnalysisDate { get; set; }

    }
}