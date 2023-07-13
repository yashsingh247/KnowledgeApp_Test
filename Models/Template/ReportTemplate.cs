using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Template
{
    public class ReportTemplate
    {
        public Int32 ReportTemplateId { get; set; }
        public String ReportTemplateName { get; set; }
        public Boolean PrintStoppageDetail { get; set; }
        public Int16 SeasonRow { get; set; }
        public Int16 SeasonColumn { get; set; }
        public Int16 CropDayRow { get; set; }
        public Int16 CropDayColumn { get; set; }
        public Int16 ReportType { get; set; }
        public Int16 ColumnCount { get; set; }
        //public String TemplateFileName { get; set; }
        public Int16 RowNumber { get; set; }
        public Int16 ColumnNumber { get; set; }
        public Int16 FixedValue { get; set; }
        public Int16 PreFixValue { get; set; }
        public Int16 PostFixValue { get; set; }

        public Int16 ParameterId { get; set; }
        public Int16 ParameterType { get; set; }
        public Int32 Code { get; set; }
        public HttpPostedFileBase ImagePath { get; set; }
        public String TemplateFileName { get; set; }
    }
    public class ReportType 
    {
        public Int32 ReportTypeId { get; set; }
        public String ReportTypeName { get; set; }
    }


    public class ReportTemplateDetails 
    {
        public Int32 ReportTemplateDetailID { get; set; }
        public Int32 ReportTemplateID { get; set; }
        public Int16 RowNumber { get; set; }
        public Int16 ColumnNumber { get; set; }
        public Int32 ParameterID { get; set; }
        public Int32 ParameterType { get; set; }
        public String FixedValue { get; set; }
        public String PrefixValue { get; set; }
        public String PostfixValue { get; set; }
        public String ParameterName { get; set; }
        public String ReportTypeName { get; set; }
        public String ReportTemplateName { get; set; }
    }
}