using KnowledgeApp_Test.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Stoppages
{
    public class StoppageSparesProcess
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 SpareProcessId { get; set; }
        //[EditLink]
        public String SpareProcessCode { get; set; }
        public String SpareProcessName { get; set; }
        public Boolean IsProcess { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 StationId { get; set; }
        public String StationCode { get; set; }
        public List<StoppageDepartment> StoppageDepartment { get; set; }
        public List<StoppageStation> StoppageStation { get; set; }

    }
}