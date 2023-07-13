using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Parameter = KnowledgeApp_Test.Models.Parameters.Parameter;
using Unit = KnowledgeApp_Test.Models.Common.Unit;

namespace KnowledgeApp_Test.Models.BenchMarking
{
    public class YearlyBenchMark
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 YearlyBenchMarkId { get; set; }
        public Int32 ParameterId { get; set; }
        public String ParameterUnit { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 BenchMarkParameterId { get; set; }
        //[EditLink]
        public String BenchMarkCode { get; set; }
        public String BenchMarkParameterName { get; set; }
        public Int32 YearSerial { get; set; }
        public Int16 ApplicableYear { get; set; }
        public Decimal ApplicableValue { get; set; }
        public Int32 RowNumber { get; set; }
       
     
    }
}