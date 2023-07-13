using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Parameters
{
    public class DateWisesDailyParameter
    {
        public Int32 ParameterTypeId { get; set; }
        public String ParameterTypeName { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public Decimal DayValue { get; set; }
        public Decimal TodateValue { get; set; }
        public DateTime EntryDate { get; set; }
    }
}