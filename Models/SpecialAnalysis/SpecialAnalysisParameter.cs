using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.SpecialAnalysis
{
    public class SpecialAnalysisParameter
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SpecialAnalysisParameterId { get; set; }
        //[EditLink]
        public String SpecialAnalysisParameterCode { get; set; }
        public String SpecialAnalysisParameterName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SpecialAnalysisTypeId { get; set; }
        public String SpecialAnalysisTypeSpecialAnalysisTypeName { get; set; }
        public Boolean IsInput { get; set; }
        public String Formula { get; set; }
        public Int16 DataType { get; set; }
        public String ShortName { get; set; }
        public String DescriptiveFormula { get; set; }
        public Int32 RowNumber { get; set; }
        public Int32 ColumnNumber { get; set; }
        public Int32 CalculationLevel { get; set; }
        public List<SpecialAnalysisType> SpecialAnalysisType { get; set; }
    }
}