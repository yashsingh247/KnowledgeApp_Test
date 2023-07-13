using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class MassecuiteStock
    {
   public int UnitID { get; set; } 
   public string UnitUnitName { get; set; }
   public string ShiftID { get; set;} 
   public string ShiftName { get; set;} 
   public string MASSECUITE { get; set;} 
   public string SHIFT_RCV { get; set;} 
   public string DROPP { get; set; }
   public string CURED { get; set; }
   public string BALANCE { get; set; }
   public DateTime AnalysisDate { get; set; }


    }
}