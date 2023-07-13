using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;



namespace KnowledgeApp_Test.Models
{
    public class Enterprise
    {
       
            //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
            public Int32 EnterpriseId { get; set; }
            //[EditLink]
            public String EnterpriseName { get; set; }
            public String AddressLine1 { get; set; }
            public String AddressLine2 { get; set; }

        public static implicit operator Enterprise(DataTable v)
        {
            throw new NotImplementedException();
        }
    }
    public class EnterpriseView 
    { 
    public virtual Enterprise Enterprise { get; set; }
        public List<Enterprise> enterprise { get; set; }
    }

}
