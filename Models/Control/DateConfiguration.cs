using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Control
{
    public class DateConfiguration
    {
        public Int32 DateConfigurationId { get; set; }
        //[EditLink]
        public DateTime ConfigurationDate { get; set; }
        public Int32 ConfigurationType { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        //public List<Unit> Unit { get; set; }
    }
}