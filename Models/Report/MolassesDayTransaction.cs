using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class MolassesDayTransaction
    {

        public string TankNumber { get; set; }
        public string TransactionDate { get; set; }
        public string Production { get; set; }
        public string ShiftingIN { get; set; }
        public string TotalIn { get; set; }
        public string Sales { get; set; }
        public string ShiftingOut { get; set; }
        public string TotalOut { get; set; }


    }
}