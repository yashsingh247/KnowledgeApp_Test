﻿using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class ShiftEngineerLogbook
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

       //>
        public Int32 PlantSubDepartmentId { get; set; }
        public String PlantSubDepartmentSubDepartmentName { get; set; }

       
        public Int32 ShiftId { get; set; }
        public String ShiftShiftName { get; set; }

       
        public Int32 ShiftInchargeId { get; set; }
        public String ShiftInchargeEmployeeCode { get; set; }
        public Boolean IsChemist { get; set; }

       
        public Int32 SectionHeadId { get; set; }
        public String SectionHeadEmployeeCode { get; set; }

   
        public Int32 DepartmentHeadId { get; set; }
        public String DepartmentHeadEmployeeCode { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public List<Unit> Unit { get; set; }
        public List<Shift> Shift { get; set; }
        public Int32 SerialNo { get; set; }
        public String Observations { get; set; }
        public String WorkDone { get; set; }
        public String WorkToBeDone { get; set; }
        public String Remarks { get; set; }
    }
    public class ShiftEngineerLogbookDetails
    {
        public Int32 DetailsId { get; set; }
        public Int32 EngineerLogbookId { get; set; }
        public Int32 SerialNo { get; set; }
        public String Observations { get; set; }
        public String WorkDone { get; set; }
        public String WorkToBeDone { get; set; }
        public String Remarks { get; set; }

    }


}