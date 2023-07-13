using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.PlantData;
using KnowledgeApp_Test.Models.ProjectDocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class ChemicalConsumption
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ChemicalConsumptionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        //[EditLink]
        public DateTime ConsumptionDate { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 ShiftId { get; set; }
        public String ShiftShiftName { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 ProcessHeadId { get; set; }
        public String ProcessHeadEmployeeCode { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 SectionHeadId { get; set; }
        public String SectionHeadEmployeeCode { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 DepartmentHeadId { get; set; }
        public String DepartmentHeadEmployeeCode { get; set; }
       
      
    }
    public class ChemicalConsumptionDetails
    {
        public Int32 ChemicalConsumptionDetailID { get; set; }
        public Int32 ChemicalConsumptionID { get; set; }
        public Int32 SerialNumber { get; set; }
        public Decimal IssuedQuantity { get; set; }
        public Decimal ConsumedQuantity { get; set; }
        public Int32 ChemicalID { get; set; }
        public String ChemicalName { get; set; }

    }
}