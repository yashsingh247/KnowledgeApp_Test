using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class CmpRegistration
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
        public String Status { get; set; }
        public String ProposedActivity { get; set; }
        public String ExpectedImprovement { get; set; }
        public String OtherImplications { get; set; }
        public Boolean IsDrawingAtached { get; set; }
        public Decimal CostOfChange { get; set; }
        public Boolean IsEstimationAttached { get; set; }
        public String Roi { get; set; }
        public Boolean IsRoiCalculationAttached { get; set; }
        public Int16 ProposalDrawnFrom { get; set; }
        public Boolean IsTrainingRequired { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 IntiatorId { get; set; }
        public String IntiatorEmployeeCode { get; set; }
        public String Remarks { get; set; }
        public String DrawingDocument { get; set; }
        public String RoiCalculationDocument { get; set; }
        //public Int16 UnitHeadApprovalState { get; set; }
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
        public Boolean IsImplemented { get; set; }
        public Int16 DocumentType { get; set; }

        public String Preamble { get; set; }
        public Boolean ImpactQuantity { get; set; }
        public String ImpactQuantityDetail { get; set; }
        public Boolean IsImpactOnSafety { get; set; }
        public String ImpactOnSafetyDetail { get; set; }
        public Boolean IsImpactOnEnvironment { get; set; }
        public String ImpactOnEnvironmentDetail { get; set; }
        public Boolean IsImpactOnFoodSafety { get; set; }
        public String ImpactOnFoodSafetyDetail { get; set; }
        public Boolean IsLegalRequirement { get; set; }
        public String LegalRequirementDetail { get; set; }
        public String TrainingDetail { get; set; }
        public Boolean IsBudgetTaken { get; set; }
        public String BudgetDetail { get; set; }
        public String EstimationDocument { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentDepartmentId { get; set; }
        public String DocumentDepartmentDepartmentName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 DocumentSubDepartmentId { get; set; }
        public String DocumentSubDepartmentSubDepartmentName { get; set; }
        public Boolean IsSanctionRequired { get; set; }
        public String NatureOfExpenditure { get; set; }
        public Decimal BudgetProvisionAmount { get; set; }
        public Decimal PresentProposalAmount { get; set; }
        public Decimal BalanceSanctionAmount { get; set; }
        public String FuntionLocationInPlant { get; set; }
        public DateTime SanctionDate { get; set; }
        public Int16 RoiDocumentType { get; set; }
        public Int16 EstimateDocumentType { get; set; }
    }
}