using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class StoppageStation
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 StationId { get; set; }
        //[EditLink]
        public String StationCode { get; set; }
        public String StationName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DepartmentId { get; set; }
        public String DepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterId { get; set; }
        public String ParameterName { get; set; }
        public List<StoppageDepartment> StoppageDepartment { get; set; }
        public List<Parameter> Parameter { get; set; }
    }
}