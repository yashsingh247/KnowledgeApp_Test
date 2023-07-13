using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Sugar_Molasses
{
    public class MolassesDayTransaction
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MolassesDayTransactionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 MolassesTankId { get; set; }
        //[EditLink]
        public String MolassesTankTankNumber { get; set; }

        //[QuickFilter]
        public DateTime TransactionDate { get; set; }
        public Decimal Production { get; set; }
        public Decimal ShiftingIn { get; set; }
        public Decimal Sales { get; set; }
        public Decimal ShiftingOut { get; set; }
        public Decimal InTemperature1 { get; set; }
        public Decimal InTemperature2 { get; set; }
        public Decimal InTemperature3 { get; set; }
        public Decimal InTemperature4 { get; set; }
        public Decimal InTemperature5 { get; set; }
        public Decimal OutTemperature1 { get; set; }
        public Decimal OutTemperature2 { get; set; }
        public Decimal OutTemperature3 { get; set; }
        public Decimal OutTemperature4 { get; set; }
        public Decimal OutTemperature5 { get; set; }
        public Decimal WaterIn1 { get; set; }
        public Decimal WaterIn2 { get; set; }
        public Decimal WaterIn3 { get; set; }
        public Decimal WaterIn4 { get; set; }
        public Decimal WaterIn5 { get; set; }
        public Decimal WaterOut1 { get; set; }
        public Decimal WaterOut2 { get; set; }
        public Decimal WaterOut3 { get; set; }
        public Decimal WaterOut4 { get; set; }
        public Decimal WaterOut5 { get; set; }
        public Decimal MolassesTemperature1 { get; set; }
        public Decimal MolassesTemperature2 { get; set; }
        public Decimal MolassesTemperature3 { get; set; }
        public Decimal MolassesTemperature4 { get; set; }
        public Decimal MolassesTemperature5 { get; set; }
        public Decimal Brix { get; set; }
        public Decimal Trs { get; set; }
        public Decimal ProductionTemperature1 { get; set; }
        public Decimal ProductionTemperature2 { get; set; }
        public Decimal ProductionTemperature3 { get; set; }
        public Decimal ProductionTemperature4 { get; set; }
        public Decimal ProductionTemperature5 { get; set; }
        public Int16 RecirculationHours { get; set; }
        public Int16 WaterSpayHours { get; set; }
    }
}