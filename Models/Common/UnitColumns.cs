using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models
{
    public class UnitColumns
    {
         //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
            public Int32 UnitId { get; set; }
            //[EditLink]
            public String UnitName { get; set; }
            //[Visible(false), QuickFilter]
            public Int32 CompanyId { get; set; }
            public String CompanyCompanyName { get; set; }
            public String AddressLine1 { get; set; }
            public String AddressLine2 { get; set; }
        
    }
}