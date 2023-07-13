using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Template
{
    public class ChartTemplate
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ChartTemplateId { get; set; }
        public String ParameterType { get; set; }
        public Int32 ParameterId { get; set; }
        //[EditLink]
        public String ChartTemplateName { get; set; }
        public String ChartTypeName { get; set; }
        public Int16 ChartType { get; set; }
        public String TemplateFileName { get; set; }
        public String SerialNumber { get; set; }
    }
    public class ChartTemplateDetails
    {
        public Int32 ChartTemplateDetailID{ get; set; }
        public Int32 ChartTemplateID { get; set; }
        public Int16 SerialNumber { get; set; }
        public Int32 ParameterID { get; set; }
        public Int32 ParameterType { get; set; }
        public String ChartTemplateName { get; set; }

        public String ParameterName { get; set; }
        public String ParameterTypeName { get; set; }


    }

    public class ChartType 
    {
        public Int32 ChartTypeId { get; set; }
        public String ChartTypeName { get; set; }
    }

}