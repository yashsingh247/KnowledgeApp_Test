using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Control
{
    public class ControlParameterValue
    {
        
        public Int32 ControlParameterValueId { get; set; }
      
        public Int32 ParameterId { get; set; }
      
        public String ParameterCode { get; set; }
       
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        
        public String ParameterValue { get; set; }
        //public List<ControlParameter> ControlParameter { get; set; }
        //public List<Unit> Unit{ get; set; }
    }
}