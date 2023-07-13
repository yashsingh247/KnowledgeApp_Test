using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Graph
{
    public class StoppageGraph
    {
        public string ParameterName { get; set; }
        public double? DayValue { get; set; }
        public string EntryDateFrom { get; set; }
        public string EntryDateTo { get; set; }
        public double? Ajbapur { get; set; }
        public double? Rupapur { get; set; }
        public double? Hariawan { get; set; }
        public double? Loni { get; set; }

        public double? Cane { get; set; }
        public double? Engineering { get; set; }
        public double? GenCleaning { get; set; }
        public double? Manufacturing { get; set; }
        public double? Miscellaneous { get; set; }
        public double? Utility { get; set; }
    }
}