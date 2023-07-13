using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Parameters
{
    public class ParameterType
    {
        public Int32 ParameterTypeId { get; set; }
        //[EditLink]
        public String ParameterTypeName { get; set; }
        public Boolean IsComputed { get; set; }
        public Int16 ParameterTypeCode { get; set; }
        public Boolean IsStoppageType { get; set; }
        public Boolean IsStockType { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 EntryTypeId { get; set; }
        public String EntryTypeName { get; set; }
        public List<EntryType> EntryType { get; set; }
    }


    public class ParameterTypeModel
    {
        public int ParameterTypeID { get; set; }
        public string TabClass { get; set; }
        public string TabPaneClass { get; set; }
        public string tablehtml { get; set; }
        public int ParameterTypeCode { get; set; }
        public string ParameterTypeName { get; set; }
        public List<Parameter> ParameterList { get; set; }
        public virtual Parameter Parameter {get;set;}
    }
    public enum Stoppage
    {
        SelectHour = 0,
        [Description("1")]
        OneHour = 1,
        [Description("2")]
        TwoHour = 2,
        [Description("3")]
        ThreeHour = 3,
    }



}