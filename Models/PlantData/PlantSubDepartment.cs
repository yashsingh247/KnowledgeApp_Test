using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class PlantSubDepartment
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 PlantSubDepartmentId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 PlantDepartmentId { get; set; }
        public String PlantDepartmentName { get; set; }
        public Int16 OldCode { get; set; }
        //[EditLink]
        public String SubDepartmentName { get; set; }
        public String ShortName { get; set; }
        public String DepartmentCode { get; set; }
    }
}