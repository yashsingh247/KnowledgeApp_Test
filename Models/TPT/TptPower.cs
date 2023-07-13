using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.TPT
{
    public class TptPower
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 TptPowerParameterId { get; set; }
        //[EditLink]
        public String TptPowerCode { get; set; }
        public String TptPowerName { get; set; }
        public Int16 ParameterType { get; set; }
        public String Formula { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterUnitId { get; set; }
        public String ParameterUnitParameterUnitName { get; set; }
        public String DescriptiveFormula { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterParameterName { get; set; }
    }
}