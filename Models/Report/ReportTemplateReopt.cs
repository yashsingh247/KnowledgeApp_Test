using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class ReportTemplateReport
    {

        public Int32 ParameterID { get; set; }
        public Int32 ParameterType { get; set; }
        public Int32 RowNumber { get; set; }
        public Int32 ColumnNumber { get; set; }
        public decimal PrefixValue { get; set; }
        public decimal FixedValue { get; set; }
        public decimal PreDayValue { get; set; }
        public decimal PreTodateValue { get; set; }
        public decimal PostfixValue { get; set; }
        public decimal DayValue { get; set; }
        public decimal TodateValue { get; set; }
        public DateTime EntryDate { get; set; }
    }
}