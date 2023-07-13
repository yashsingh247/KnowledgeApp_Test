using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class PlantPerformance
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 PlantPerformanceId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }

        //[EditLink]
        public DateTime LogDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ShiftId { get; set; }
        public String ShiftShiftName { get; set; }
        public Int16 LogHour { get; set; }
        public Decimal CaneCrushed { get; set; }
        public Int32 SugarBagged { get; set; }
        public Int32 FbdAirTemperature { get; set; }
        public Int32 ExhaustTemperature { get; set; }
        public Decimal ImbitionPercent { get; set; }

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
}