using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class YearlyBenchMark
    {
        public string SerialNumber { get; set; }
        public string BenchMarkCode { get; set; }
        public string BenchMarkName { get; set; }
        public string ApplicableYear { get; set; }
        public string ApplicableValue { get; set; }
        public string RowNumber { get; set; }
    }
}