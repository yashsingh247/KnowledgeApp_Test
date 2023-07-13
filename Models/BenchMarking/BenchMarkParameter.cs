using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.BenchMarking
{
    public class BenchMarkParameter
    {
       
        public Int32 BenchMarkParameterId { get; set; }
        public String BenchMarkCode { get; set; }
        public String BenchMarkName { get; set; }
        public int ParameterId { get; set; }
        public String ParameterName { get; set; }
        public int ParameterUnitId { get; set; }
        public String ParameterUnitName { get; set; }
        public Int16 BenchMarkType { get; set; }
        public Int16 RowNumber { get; set; }
        public List<Unit> Unit { get; set; }
        public List<Parameter> Parameter { get; set; }
        public List<ParameterUnit> ParameterUnit { get; set; }
    }
}