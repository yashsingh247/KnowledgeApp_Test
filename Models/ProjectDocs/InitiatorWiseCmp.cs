using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class InitiatorWiseCmp
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 CmpRegistrationId { get; set; }
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
        public Int16 ApprovedStatus { get; set; }
        //[Visible(false), QuickFilter, Width(200)]
        public Int16 RejectedStatus { get; set; }

    }
}