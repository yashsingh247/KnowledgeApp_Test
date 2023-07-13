using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class MillLog
    {
        public Int32 MillLogId { get; set; }
        public Int32 UnitId { get; set; }

        public String UnitUnitName { get; set; }
        public String SerialNumber { get; set; }
        public String LogValue { get; set; }
        public Int32 DocumentNumber { get; set; }
        public DateTime LogDate { get; set; }
        public Int16 LogHour { get; set; }
        public Int32 MillType { get; set; }
        public Int32 EntryType { get; set; }
       public Int32 MillParameterId { get; set; }
        public Int32 MillId { get; set; }
    }

    public class MillLogDetails
    {
        public Int32 MillLogDetailID { get; set; }
        public Int32 SerialNumber { get; set; }
        public Int32 MillParameterId { get; set; }
        public String MillParameterName { get; set; }
        public Int32 MillId { get; set; }
        public String MillName { get; set; }
        public Int32 LogValue { get; set; }
        public Int32 MillLogID { get; set; }

    }
}