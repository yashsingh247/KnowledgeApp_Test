using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.HouseData
{
    public class Chemical
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ChemicalId { get; set; }
        public Int16 ChemicalCode { get; set; }
        //[EditLink]
        public String ChemicalName { get; set; }
    }
}