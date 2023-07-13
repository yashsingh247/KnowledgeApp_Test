using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class Auditlog
    {
        public int AuditLogID { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public string ChangedOn { get; set; }
        public string TableNames { get; set; }
        public string RowId { get; set; }
        public string Module { get; set; }
        public string Page { get; set; }
        public string Changes { get; set; }
        public DateTime Entrydate1 { get; set; }
        public DateTime Entrydate2 { get; set; }
    }
}