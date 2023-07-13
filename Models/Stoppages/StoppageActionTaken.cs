using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class StoppageActionTaken
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 ActionId { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DefectId { get; set; }
        public String DefectCode { get; set; }
        //[EditLink]
        public String ActionCode { get; set; }
        public String ActionName { get; set; }
        public List<StoppageDefect> StoppageDefect { get; set; }
    }
}