using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Parameters
{
    public class ParameterUnit
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ParameterUnitId { get; set; }
        public Int32 ParameterUnitCode { get; set; }
        //[EditLink]
        public String ParameterUnitName { get; set; }
        public Int16 DataType { get; set; }
    }
}