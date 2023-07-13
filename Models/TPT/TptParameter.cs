using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.TPT
{
    public class TptParameter
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 TptParameterId { get; set; }
        //[EditLink]
        public String ParameterCode { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }
        public Boolean IsInputParameter { get; set; }
        public Int16 DataType { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterUnitId { get; set; }
        public String ParameterUnitParameterUnitName { get; set; }
        public String Formula { get; set; }
        public String ParameterParameterName { get; set; }
        public Boolean HighlightPositive { get; set; }
        public Decimal DeviationPercent { get; set; }
        public Decimal DifferenceValue { get; set; }
        public Int16 ConsolidationType { get; set; }
        public Int32 ConsolidationParameterId { get; set; }
        public Int16 CalculationLevel { get; set; }
        public Int16 Precision { get; set; }
        public Boolean ShowOnFinalTpt { get; set; }
        public Int16 ReportType { get; set; }
        public Int16 DisplayOrder { get; set; }
        public Int16 TpTptSerial { get; set; }
        public String DescriptiveFormula { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 TexParameterId { get; set; }
        public String TexParameterParameterName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 WilParameterId { get; set; }
        public String WilParameterParameterName { get; set; }
        public Boolean ShowOnOutput { get; set; }
        public Int16 OutputRowNumber { get; set; }
        public Int16 OutputSerial { get; set; }

    }
}