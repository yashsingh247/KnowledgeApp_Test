using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class StationWiseStoppageReport
    {
        public String StationName { get; set; }
        public DateTime StoppageDate { get; set; }
        public DateTime StoppageStart { get; set; }
        public DateTime StoppageTill { get; set; }
        public String Duration { get; set; }
        public string DurationHour { get; set; }
        public string Remarks { get; set; }
    }
    public class DailyStoppageReport
    { 
        public string From { get; set; }
        public string Till { get; set; }
        public string Duration { get; set; }

        public string StationName { get; set; }
        public string Remarks { get; set; }
        public string StoppageTypeName { get; set; }
        public int StoppageType { get; set; }
        public DateTime Stoppagedate { get; set; }
    }

    public class GroupWiseStoppageReport
    { 
        public string DepartmentName { get; set; }
        public string StationName { get; set; }
        public string Duration { get; set; }
        public string DurationInMinutes { get; set; }
        public string UnitId { get; set; }
        public string StationId { get; set; }
        public string DepartmentId { get; set; }
        public DateTime StoppageDate { get; set; }
        public DateTime StoppageDate2 { get; set; }

    }

}