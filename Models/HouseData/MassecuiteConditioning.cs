using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class MassecuiteConditioning
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MassecuiteConditioningId { get; set; }
        public Int16 MassecuiteConditioningCode { get; set; }
        //[EditLink]
        public String MassecuiteConditioningName { get; set; }
    }
}