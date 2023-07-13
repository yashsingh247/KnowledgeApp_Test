using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Parameters
{
    public class Parameter
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ParameterId { get; set; }
        //[SortOrder(2)]
        public Int16 ParameterCode { get; set; }
        //[EditLink]
        public String ParameterName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 ParameterTypeId { get; set; }
        //[SortOrder(1)]
        public String ParameterTypeParameterTypeName { get; set; }
        public Boolean Discontinued { get; set; }
        public Boolean IsUserDefined { get; set; }
        public Boolean IsPreviousDay { get; set; }
        public Boolean IsStoppageParameter { get; set; }
        public Int32 PrevousDayParameterId { get; set; }
        public Decimal MaximumValue { get; set; }
        public Decimal MinimumValue { get; set; }
        public Decimal DefaultValue { get; set; }
        public Int16 BeforeDecimalDigit { get; set; }
        public Int16 AfterDecimalDigit { get; set; }
        public Int16 PrintBeforeDecimalDigit { get; set; }
        public Int16 PrintAfterDecimalDigit { get; set; }
        public Int16 TodateType { get; set; }
        public Int32 AverageBasisParameterId { get; set; }
        public String Formula { get; set; }
        public String TodateFormula { get; set; }
        public String DescriptiveFormula { get; set; }
        public String DescriptiveTodateFormula { get; set; }
        public Int16 CalculationLevel { get; set; }
        public Boolean IsStockParameter { get; set; }
        public String Uom { get; set; }
        public Boolean IsBrixWeightParameter { get; set; }
        public Boolean IsCalculatedOnBrixWeight { get; set; }
        public Boolean IsHourlyEntry { get; set; }
        public Boolean IsAdditionalEntry { get; set; }
        public Int16 AverageBasisParameter { get; set; }

        public Int32 EntryTypeID { get; set; }
        public String EntryName{get;set;}
        public Int32 EntryOrder { get; set; }
        
        public Int16 ParameterTypeCode { get; set; }
        public List<ParameterType> ParameterType { get; set; }
    }
}