using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class Employee
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 EmployeeId { get; set; }

        //[Visible(false), QuickFilter]
        //public Int32 UnitId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 PlantDepartmentId { get; set; }
        public String PlantDepartmentDepartmentName { get; set; }
        //[EditLink]
        public String EmployeeCode { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeeClass { get; set; }
        public Boolean IsApprover { get; set; }
    }
}