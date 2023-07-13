using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Common
{
    public class ControlParameterValue
    {
        public Int32 ControlParameterValueId { get; set; }
        //[QuickFilter, Visible(false)]
        public Int32 ParameterId { get; set; }
        //[EditLink]
        public String ParameterParameterCode { get; set; }
        //[QuickFilter, Visible(false)]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        //public Int32 DataPeriodId { get; set; }
        //[EditLink]
        public String ParameterValue { get; set; }
    }
}