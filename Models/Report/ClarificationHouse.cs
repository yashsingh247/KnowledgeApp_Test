using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class ClarificationHouse
    {

        public string TransactionDate { get; set; }
        public  string ClarificationTypeName { get; set; }
        public string ClarificationName { get; set; }
        public string Shift6To2 { get; set; }
        public string Shift2To10 { get; set; }
        public string Shift10To6 { get; set; }
        public DateTime AnalysisDate { get; set; }
    }
}