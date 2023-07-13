using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models
{
    public class Company
    {
       
        public Int32 CompanyId { get; set; }
        //[EditLink]
        public String CompanyName { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 EnterpriseId { get; set; }
        public String EnterpriseName { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public List<Enterprise> enterprises { get; set; }
        //public virtual Enterprise Enterprise { get; set; }
        
    }
  
}