using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class InterAllocationApproval
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 InterAlocationRegistrationId { get; set; }
        //[EditLink]
        public String RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        public String Subject { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 IntiatorId { get; set; }
        public String IntiatorEmployeeName { get; set; }
        //[Width(200)]
        public Int16 ApprovalStatus { get; set; }
        //[Visible(false), QuickFilter, Width(200)]
        public string ApprovedStatus { get; set; }
        
        //[Visible(false), QuickFilter, Width(200)]
        public string RejectedStatus { get; set; }
    }
}
