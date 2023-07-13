using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Graph
{
    public class ParameterGraph
    {
        public string ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public double? DayValue { get; set; }
        public string EntryDateFrom { get; set; }
        public string EntryDateTo { get; set; }
        public double? Ajbapur { get; set; }
        public double? Rupapur { get; set; }
        public double? Hariawan { get; set; }
        public double? Loni { get; set; }

        public double? CaneCrushed { get; set; }
        public double? TotalSugarBags { get; set; }
        public double? BagasseQuantity { get; set; }
        public double? PressCakeQuantity { get; set; }
        public double? MolassesWeightPerTank { get; set; }
        public double? Recovery { get; set; }
    }

}