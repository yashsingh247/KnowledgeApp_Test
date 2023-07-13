using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.PlantData
{
    public class MillParameter
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 MillParameterId { get; set; }
        public Int16 MillParameterCode { get; set; }
        //[EditLink]
        public String MillParameterName { get; set; }
        public Int16 Flag { get; set; }
        public Boolean IsApplicableForWil { get; set; }
        public Boolean IsTwoHourly { get; set; }
        public String ShortName { get; set; }
    }
}