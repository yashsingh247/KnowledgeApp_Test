using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class Shift
    {
        public Int32 ShiftId { get; set; }
        public Int16 ShiftCode { get; set; }
        //[EditLink]
        public String ShiftName { get; set; }
        public String ShortCode { get; set; }
        public Int32 FirstHour { get; set; }
        public Int32 SecondHour { get; set; }
        public Int32 ThirdHour { get; set; }
        public Int32 FourthHour { get; set; }
    }
}