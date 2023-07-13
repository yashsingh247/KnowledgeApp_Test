using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Report
{
    public class IAADStatus
    {
        public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string Subject { get; set; }
        public string ApprovalStatus { get; set; }
        public string UnitHeadApprovalState { get; set; }
        public string UnitHeadApprovalDate { get; set; }
        public string UnitHeadComment { get; set; }
        public string TechnicalCoordinatorApprovalState { get; set; }
        public string TechnicalCoordinatorApprovalDate { get; set; }
        public string TechnicalCoordinatorComment { get; set; }
        public string CTT_EngineerApprovalState { get; set; }
        public string CTT_EngineerApprovalDate { get; set; }
        public string CTT_EngineerComment { get; set; }
        public string CTT_ProcessApprovalState { get; set; }
        public string CTT_ProcessApprovalDate { get; set; }
        public string CTT_ProcessComment { get; set; }
        public string FinalAuthorityApprovalState { get; set; }
        public string FinalAuthorityApprovalDate { get; set; }
        public string FinalAuthorityComment { get; set; }
        public DateTime Entrydate1 { get; set; }
        public DateTime Entrydate2 { get; set; }
    }
}