using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Lab
{
    public class SampleSlip
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SampleSlipId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        //[EditLink]
        public String UnitUnitName { get; set; }
        public Int32 SampleSlipNumber { get; set; }

        //[QuickFilter]
        public DateTime SampleSlipDate { get; set; }
        public Int32 GrowerId { get; set; }
        public Int32 VarietyId { get; set; }
        public Int16 SlipTyple { get; set; }
        public Decimal Brix { get; set; }
        public Decimal Pol { get; set; }
        public Decimal JavaRatio { get; set; }
        public Decimal Losses { get; set; }
        public Int32 VillageId { get;set; }
        public List<Unit>Unit { get; set; }
    }
}