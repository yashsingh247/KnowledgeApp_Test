using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.SpecialAnalysis
{
    public class SpecialAnalysisType
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SpecialAnalysisTypeId { get; set; }
        public Int16 SpecialAnalysisTypeCode { get; set; }
        //[EditLink]
        public String SpecialAnalysisTypeName { get; set; }
        public Boolean IsPeriodic { get; set; }
        public Int32 StartRowNumber { get; set; }
        public String ExcelTemplateName { get; set; }
        public Int32 DateRow { get; set; }
        public Int32 DateColumn { get; set; }
        
    }
}