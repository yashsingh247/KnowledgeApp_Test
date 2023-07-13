using KnowledgeApp_Test.Models.PlantData;
using KnowledgeApp_Test.Models.ProjectDocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class MassecuiteConditioningData
    {
    
        public Int32 MassecuiteConditioningDataId { get; set; }
      
        public DateTime AnalysisDate { get; set; }

       
        public Int32 ShiftId { get; set; }
        public String ShiftShiftName { get; set; }

       
        public Int32 ProcessHeadId { get; set; }
        public String ProcessHeadEmployeeName { get; set; }

      
        public Int32 SectionHeadId { get; set; }
        public String SectionHeadEmployeeName { get; set; }

       
        public Int32 DepartmentHeadId { get; set; }
        public String DepartmentHeadEmployeeName { get; set; }
        public Int32 SerialNo { get; set; }
        public Int32 AnalysisValue { get; set; }
       


    }
    public class MassecuiteConditioningDataDetails
    {
        public Int32 MassecuiteConditioningDataDetailsId { get; set; }
        public Int16 SerialNo { get; set; }
        public Int32 MassecuiteConditioningDataId { get; set; }
        public Decimal AnalysisValue { get; set; }
        public Int32 MassecuiteConditioningID { get; set; }
        public String MassecuiteConditioningName { get; set; }
    }


}