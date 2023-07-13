using KnowledgeApp_Test.Models.PlantData;
using KnowledgeApp_Test.Models.ProjectDocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class ClarificationHouse
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ClarificationHouseId { get; set; }
        //[EditLink]
        public DateTime TransactionDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ShiftId { get; set; }
        public String ShiftShiftName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ProcessHeadId { get; set; }
        public String ProcessHeadEmployeeName { get; set; }
        public Boolean IsChemist { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SectionHeadId { get; set; }
        public String SectionHeadEmployeeName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DepartmentHeadId { get; set; }
        public String DepartmentHeadEmployeeName { get; set; }
        public Int32 SerialNo { get; set; }
        public Int32 ClarificationValue { get; set; }

        
    }
    public class ClarificationHouseDetail
    {
        public string ClarificationName { get; set; }
        public Int32 ClarificationHouseId { get; set; }
        public Int32 ClarificationHouseDetailID { get; set; }
        public Int32 ClarificationID { get; set; }
        public Int16 SerialNo { get; set; }
        public Decimal ClarificationValue { get; set; }

    }
}