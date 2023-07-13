using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class ShiftEngineer
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 EngineerLogbookId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }

        //[EditLink]
        public Int32 DocumentNumber { get; set; }

        //[QuickFilter]
        public DateTime LogDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 PlantDepartmentId { get; set; }
        public String PlantDepartmentDepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 PlantSubDepartmentId { get; set; }
        public String PlantSubDepartmentSubDepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ShiftId { get; set; }
        public String ShiftShiftName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ShiftInchargeId { get; set; }
        public String ShiftInchargeEmployeeCode { get; set; }
        public Boolean IsChemist { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SectionHeadId { get; set; }
        public String SectionHeadEmployeeCode { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DepartmentHeadId { get; set; }
        public String DepartmentHeadEmployeeCode { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }

    }
}