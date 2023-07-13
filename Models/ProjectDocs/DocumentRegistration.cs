using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class DocumentRegistration
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DocumentRegistrationId { get; set; }
        //[EditLink]
        public String DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        public String Subject { get; set; }
        public Int16 DocumentType { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentClassId { get; set; }
        public String DocumentClassClassName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentOwnerId { get; set; }
        public String DocumentOwnerEmployeeCode { get; set; }
        public string DocumentOwnerName { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 DocumentApproverId { get; set; }
        public String DocumentApproverEmployeeCode { get; set; }
        public HttpPostedFileBase DocumentFile { get; set; }
        public DateTime DocumentApproverDate { get; set; }
        public String Preamble { get; set; }
        public Int16 ApprovalStatus { get; set; }
        public String ApprovalStatusName { get;set;}
        public String ImagePath { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentSubClassId { get; set; }
        public String DocumentSubClassSubClassName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentDepartmentId { get; set; }
        public String DocumentDepartmentDepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentSubDepartmentId { get; set; }
        public String DocumentSubDepartmentSubDepartmentName { get; set; }
        public String DocumentApproverEmployeeName { get; set; }
    }
}