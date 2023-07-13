using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class StoppageDefect
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DefectId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 SpareProcessId { get; set; }
        public String SpareProcessCode { get; set; }
        //[EditLink]
        public String DefectCode { get; set; }
        public String DefectName { get; set; }
        public List<StoppageSparesProcess> StoppageSparesProcess { get; set; }
    }
}