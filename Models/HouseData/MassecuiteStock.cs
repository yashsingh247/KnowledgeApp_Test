using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.PlantData;
using KnowledgeApp_Test.Models.ProjectDocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class MassecuiteStock
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MassecuiteStockId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitName { get; set; }

        //[EditLink, QuickFilter]
        public DateTime AnalysisDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ShiftId { get; set; }
        public Decimal ShiftRcvA { get; set; }
        public Decimal DroppA { get; set; }
        public Decimal CuredA { get; set; }
        public Decimal BalA { get; set; }
        public Decimal ShiftRcvA1 { get; set; }
        public Decimal DroppA1 { get; set; }
        public Decimal CuredA1 { get; set; }
        public Decimal BalA1 { get; set; }
        public Decimal ShiftRcvB { get; set; }
        public Decimal DroppB { get; set; }
        public Decimal CuredB { get; set; }
        public Decimal BalB { get; set; }
        public Decimal ShiftRcvC1 { get; set; }
        public Decimal DroppC1 { get; set; }
        public Decimal CuredC1 { get; set; }
        public Decimal BalC1 { get; set; }
        public Decimal ShiftRcvC { get; set; }
        public Decimal DroppC { get; set; }
        public Decimal CuredC { get; set; }
        public Decimal BalC { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ProcessHeadId { get; set; }
     
        public String ShiftShiftName { get; set; }
        public Int32 SectionHeadId { get; set; }


        //[Visible(false), QuickFilter]
        public Int32 DepartmentHeadId { get; set; }


        public List<Unit> Unit { get; set; }
        public List<MassecuiteConditioning> MassecuiteConditioning { get; set; }
        public List<Clarification> Clarification { get; set; }
        public List<Shift> Shift { get; set; }
        public List<Employee> Employee { get; set; }

    }
}