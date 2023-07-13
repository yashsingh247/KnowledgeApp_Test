using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.General
{
    public class EntryType
    {
        public Int32 EntryTypeID { get; set; }
        public String EntryTypeName { get; set; }
        public Int32 EntryOrder { get; set; }
    }
    public class paramList
    {
        public DateTime EntryDate { get; set; }
        public int EntryHour { get; set; }
        public int UnitId { get; set; }
        public int ParameterID { get; set; }
        public float HourValue { get; set; }
        public float DayValue { get; set; }


    }
}