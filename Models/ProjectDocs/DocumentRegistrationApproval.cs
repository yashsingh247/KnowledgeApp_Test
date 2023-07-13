using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class DocumentRegistrationApproval
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DocumentRegistrationId { get; set; }
        //[EditLink]
        public String DocumentNumber { get; set; }
        // public DateTime DocumentDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        //[Width(150)]
        public String UnitUnitName { get; set; }
        //[Width(150)]
        public String Subject { get; set; }
        //[Width(150)]
        public Int16 DocumentType { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 DocumentApproverId { get; set; }
        //[Width(150)]
        public String DocumentApproverEmployeeName { get; set; }
        //[Width(200)]
        public DateTime DocumentApproverDate { get; set; }
        //[Width(200), QuickFilter]
        public Int16 ApprovalStatus { get; set; }

    }
}