using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Graph
{
    public class StoppageReasonWiseGraph
    {
        public string ParameterName { get; set; }
        public double? DayValue { get; set; }
        public string EntryDateFrom { get; set; }
        public string EntryDateTo { get; set; }
        public string StoppageReason { get; set; }
    }
}