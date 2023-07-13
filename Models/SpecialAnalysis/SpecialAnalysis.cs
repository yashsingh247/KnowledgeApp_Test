using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.SpecialAnalysis
{
    public class SpecialAnalysis
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SpecialAnalysisId { get; set; }
        //[EditLink]
        public DateTime AnalysisDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SpecialAnalysisTypeId { get; set; }
        public String SpecialAnalysisTypeName { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public String SerialNumber { get; set; }
        public String AnalysisValue { get; set; }
    }

    public class SpecialAnalysisDetails
    {
        public Int32 SpecialAnalysisDetilsId { get; set; }
        public Int32 SpecialAnalysisId { get; set; }
        public Int16 SerialNumber { get; set; }
        public Int32 SpecialAnalysisParameterID { get; set; }
        public String SpecialAnalysisParameterName { get; set; }
        public String AnalysisValue { get; set; }
    }
}