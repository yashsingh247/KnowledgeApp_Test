using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class PlantDepartment
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 PlantDepartmentId { get; set; }
        public Int16 OldCode { get; set; }
        //[EditLink]
        public String DepartmentName { get; set; }
        public String ShortName { get; set; }
        public String DepartmentCode { get; set; }
    }
}