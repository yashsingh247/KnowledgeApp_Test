using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class InterAllocationRegistration
    {
       // [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 InterAlocationRegistrationId { get; set; }
       // [EditLink]
        public String RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 UnitId { get; set; }
        public String UnitUnitName { get; set; }
        public String Subject { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 IntiatorId { get; set; }
        public String IntiatorEmployeeName { get; set; }
        public String Remarks { get; set; }
        public Int16 SerialNumber { get; set; }
        //public DateTime UnitHeadApprovalDate { get; set; }
        //public String UnitHeadComment { get; set; }
        //public Int16 TechnicalCoordinatorApprovalState { get; set; }
        //public DateTime TechnicalCoordinatorApprovalDate { get; set; }
        //public String TechnicalCoordinatorComment { get; set; }
        //public Int16 CttEngineerApprovalState { get; set; }
        //public DateTime CttEngineerApprovalDate { get; set; }
        //public String CttEngineerComment { get; set; }
        //public Int16 CttProcessApprovalState { get; set; }
        //public DateTime CttProcessApprovalDate { get; set; }
        //public String CttProcessComment { get; set; }
        //public Int16 FinalAuthorityApprovalState { get; set; }
        //public DateTime FinalAuthorityApprovalDate { get; set; }
        //public String FinalAuthorityComment { get; set; }
        public String OldNumber { get; set; }
        public String Flag { get; set; }

        public String Equipment { get; set; }

        public String Activity { get; set; }

        public String BudgetAmount { get; set; }
        public String ActualAmount { get; set; }
        
       public String SavedAmount { get; set; }
        public String Reason { get; set; }

        public Int16 ApprovalStatus { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentDepartmentId { get; set; }
        public String DocumentDepartmentDepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentSubDepartmentId { get; set; }
        public String DocumentSubDepartmentSubDepartmentName { get; set; }
    }
    public class InterAllocationRegistrationDetail
    {
        public Int32 InterAllocationRegistrationDetailId { get; set; }
        public Int32 InterAlocationRegistrationId { get; set; }
        public Int16 SerialNumber { get; set; }
       
        public Int16 Flag { get; set; }

        public String Equipment { get; set; }

        public String Activity { get; set; }

        public Decimal BudgetAmount { get; set; }
        public Decimal ActualAmount { get; set; }

        public Decimal SavedAmount { get; set; }
        public String Reason { get; set; }

       
    }
}