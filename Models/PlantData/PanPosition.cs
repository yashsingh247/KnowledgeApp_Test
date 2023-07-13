using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class PanPosition
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 PanPositionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }


        //[EditLink]
        public DateTime AnalysisDate { get; set; }
        public Int32 ShiftId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ProcessHeadId { get; set; }
        public String ProcessHeadEmployeeCode { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SectionHeadId { get; set; }
        public String SectionHeadEmployeeCode { get; set; }
        public Int32 DepartmentHeadId { get; set; }
        public String DepartmentHeadEmployeeCode { get; set; }
        public List<Pan> Pan { get; set; }
    }
    public class PanPositionDetail
    {
        public Int32 PanPositionDetailID { get; set; }
        public Int32 PanPositionID { get; set; }
        public Int32 SerialNumber { get; set; }
        public Decimal PanValue { get; set; }
        public Int32 PanID { get; set; }
        public string PanName { get; set; }


    }
}

