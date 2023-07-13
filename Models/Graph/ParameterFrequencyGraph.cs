using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Graph
{
    public class ParameterFrequencyGraph
    {
        public int ParameterId { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
        public int Gap { get; set; }
        public double? DayValue { get; set; }
        public string EntryDateFrom { get; set; }
        public string EntryDateTo { get; set; }
        public List<ParameterFrequencyGraph> ParaFrequencyList { get; set; }
    }
}