using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Lab
{
    public class FormulaEntry
    {
        public int FormulaType { get; set; }
        public int ParameterID { get; set; }
        public string ParameterCode { get; set; }
        public string Numeral { get; set; }
        public string Operator { get; set; }
        public float DayValue { get; set; }
        public string FormulaN { get; set; }
        public string FormulaA { get; set; }
        public string Formula { get; set; }
        public string ToDateFormula { get; set; }
        public int Parameter { get; set; }
        public string ModifiedFormula { get; set; } 

    }
}