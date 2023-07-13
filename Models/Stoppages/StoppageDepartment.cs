using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class StoppageDepartment
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DepartmentId { get; set; }
        //[EditLink]
        public String DepartmentCode { get; set; }
        public String DepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }
        public List<Parameter> Parameter { get; set; }
    }
}