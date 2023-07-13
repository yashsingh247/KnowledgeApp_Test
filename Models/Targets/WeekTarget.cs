using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Targets
{
    public class WeekTarget
    {

        public Int32 WeekTargetId { get; set; }
        public Int32 WeekId { get; set; }
        public String WeekName { get; set; }
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }
        public Decimal TargetValue { get; set; }
        public Decimal ActualValue { get; set; }
        public List<Parameter> Parameter { get; set; }
        public List<SeasonWeek> SeasonWeek { get; set; }
    

    }
}