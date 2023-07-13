using KnowledgeApp_Test.Models.ProjectDocs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class ProjectDocsServices
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'ProjectDocsServices.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'ProjectDocsServices.sdr' is never used

        public List<DocumentProposal> DocumentProposal()
        {
            cmd = new SqlCommand("select * from Lab.DocumentProposal", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentProposal> DocumentProposal = new List<DocumentProposal>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentProposal.Add(new DocumentProposal
                {
                    DocumentProposalId = Convert.ToInt32(dr["DocumentProposalID"]),
                    ProposalName = dr["ProposalName"].ToString(),
                    ProposalCode = Convert.ToInt16(dr["ProposalCode"])

                });

            }
            return DocumentProposal;
        }

        public List<DocumentClass> DocumentClass()
        {
            cmd = new SqlCommand("select * from Lab.DocumentClass", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentClass> DocumentClass = new List<DocumentClass>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentClass.Add(new DocumentClass
                {
                    DocumentClassId = Convert.ToInt32(dr["DocumentClassID"]),
                    ClassCode = Convert.ToInt16(dr["ClassCode"]),
                    ClassName = dr["ClassName"].ToString(),
                    ShortCode = dr["ShortCode"].ToString()
                });

            }
            return DocumentClass;
        }
        public List<DocumentSubClass> DocumentSubClass(string DocumentClassId)
        {
            string sql = "select  * from Lab.DocumentSubClass where 1=1";
            if (DocumentClassId != "" && DocumentClassId != null && DocumentClassId != "undefined" && DocumentClassId != "null")
            {
                sql = sql + " and DocumentClassID='" + DocumentClassId + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentSubClass> DocumentSubClass = new List<DocumentSubClass>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentSubClass.Add(new DocumentSubClass
                {
                    DocumentSubClassId = Convert.ToInt32(dr["DocumentSubClassID"]),
                    SubClassCode = Convert.ToInt16(dr["SubClassCode"]),
                    SubClassName = dr["SubClassName"].ToString(),
                    ShortCode = dr["ShortCode"].ToString(),
                    DocumentClassId = Convert.ToInt32(dr["DocumentClassID"])

                });

            }
            return DocumentSubClass;
        }

        public DataTable InsertAddDocumentProposal(int documentProposalId, short proposalCode, string proposalName)
        {
            //suresh_11102021
            string SqlQujery = "Exec DocumentProposal " + documentProposalId + "," + proposalCode + ",'" + proposalName + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public List<Employee> Employee(string PlantDepartment)
        {
            string sql = "select LE.EmployeeID,LE.UnitID,LE.PlantDepartmentID,LE.EmployeeCode,LE.EmployeeName,ISnull(LE.EmployeeClass,'')EmployeeClass,LE.IsApprover,CU.UnitName,LPD.DepartmentName from Lab.EMPLOYEE LE Left Outer join Common.Unit CU on LE.UnitID=CU.UnitID Left Outer join Lab.PlantDepartment LPD on LE.PlantDepartmentID=LPD.PlantDepartmentID where 1=1";
            if (PlantDepartment != "" && PlantDepartment != "undefined" && PlantDepartment != null && PlantDepartment != "null")
            {
                sql = sql + "and LE. PlantDepartmentID='" + PlantDepartment + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Employee> Employee = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                Employee.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeID"]),
                    PlantDepartmentDepartmentName = dr["DepartmentName"].ToString(),
                    EmployeeCode = dr["EmployeeCode"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    EmployeeClass = dr["EmployeeClass"].ToString(),
                    IsApprover = (bool)(dr["IsApprover"]),
                    PlantDepartmentId = Convert.ToInt16(dr["PlantDepartmentID"]),

                });

            }
            return Employee;
        }

        public DataTable InsertAddDocumentClass(int documentClassId, short classCode, string ClassName, string ShortCode)
        {
            string SqlQujery = "Exec DocumentClass " + documentClassId + "," + classCode + ",'" + ClassName + "','" + ShortCode + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public List<Employee> PlantDepartmentddl()
        {
            cmd = new SqlCommand("select * from Lab.DocumentClass", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Employee> Employee = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                Employee.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeID"]),
                    PlantDepartmentDepartmentName = dr["DepartmentName"].ToString(),
                    EmployeeCode = dr["EmployeeCode"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    EmployeeClass = dr["EmployeeClass"].ToString(),
                    IsApprover = (bool)(dr["IsApprover"]),
                    PlantDepartmentId = Convert.ToInt16(dr["PlantDepartmentID"]),

                });
            }
            return Employee;
        }

        public List<DocumentRegistration> DocumentRegistration(string Unit, string DocumentClass, string DocumentOwner, string DocumentApprover, string DocumentSubClass, string DocumentDepartment, string DocumentSubDepartment)
        {
            string sql = "select ISnull(LDR.DocumentRegistrationID,'')DocumentRegistrationID,ISnull(LDR.DocumentNumber,'')DocumentNumber,ISnull(LDR.DocumentDate,'')DocumentDate,ISnull(LDR.UnitID,'')UnitID,ISnull(LDR.Subject,'')Subject,ISnull(LDR.DocumentType,'')DocumentType,ISnull(LDR.DocumentClassID,'')DocumentClassID,ISnull(LDR.DocumentOwnerID,'')DocumentOwnerID,ISnull(LDR.DocumentApproverID,'')DocumentApproverID,ISnull(LDR.DocumentFile,'')DocumentFile,ISnull(LDR.DocumentApproverDate,'')DocumentApproverDate,ISnull(LDR.Preamble,'')Preamble,ISnull(LDR.ApprovalStatus,'')ApprovalStatus,ISnull(LDR.DocumentSubClassID,'')DocumentSubClassID,ISnull(LDR.DocumentDepartmentID,'')DocumentDepartmentID,ISnull(LDR.DocumentSubDepartmentID,'')DocumentSubDepartmentID,ISnull(LDC.ClassName,'')ClassName,ISnull(LDSC.SubClassName,'')SubClassName,ISnull(LE.EmployeeName,'')DocumentOwner,ISnull(LEE.EmployeeName,'')DocumentApprover,ISnull(LPD.DepartmentName,'')DepartmentName,ISnull(LPSD.SubDepartmentName,'')SubDepartmentName,ISnull(A.ApprovalStatusName,'')ApprovalStatusName,CU.UnitName from Lab.DOCUMENT_REGISTRATION LDR Left Outer Join Lab.DocumentClass LDC on LDR.DocumentClassID=LDC.DocumentClassID Left Outer Join Lab.DocumentSubClass LDSC on LDR.DocumentSubClassID =LDSC.DocumentSubClassID Left Outer Join Lab.EMPLOYEE LE On LDR. DocumentOwnerID=LE.EmployeeID Left Outer Join Lab.EMPLOYEE LEE On LDR.DocumentApproverID=LEE.EmployeeID Left Outer Join Lab.PlantDepartment LPD on LDR.DocumentDepartmentID=LPD.PlantDepartmentID left Outer Join Lab.PlantSubDepartment LPSD on LDR.DocumentDepartmentID=LPSD.PlantSubDepartmentID Left outer Join ApprovalStatus A on LDR.ApprovalStatus=A.ApprovalStatusID Left Outer Join Common.Unit CU On LDR.UnitID= CU.UnitID where 1=1";
            if (Unit != "" && Unit != null && Unit != "undefined" && Unit != "null")
            {
                sql = sql + "and LDR. UnitID='" + Unit + "'";
            }
            if (DocumentClass != "" && DocumentClass != null && DocumentClass != "undefined" && DocumentClass != "null")
            {
                sql = sql + "and LDR. DocumentClassID='" + DocumentClass + "'";
            }
            if (DocumentOwner != "" && DocumentOwner != null && DocumentOwner != "undefined" && DocumentOwner != "null")
            {
                sql = sql + "and LDR. DocumentOwnerID='" + DocumentOwner + "'";
            }
            if (DocumentApprover != "" && DocumentApprover != null && DocumentApprover != "undefined" && DocumentApprover != "null")
            {
                sql = sql + "and LDR. DocumentApproverID='" + DocumentApprover + "'";
            }
            if (DocumentSubClass != "" && DocumentSubClass != null && DocumentSubClass != "undefined" && DocumentSubClass != "null")
            {
                sql = sql + "and LDR. DocumentSubClassID='" + DocumentSubClass + "'";
            }
            if (DocumentDepartment != "" && DocumentDepartment != null && DocumentDepartment != "undefined" && DocumentDepartment != "null")
            {
                sql = sql + "and LDR. DocumentDepartmentID='" + DocumentDepartment + "'";
            }
            if (DocumentSubDepartment != "" && DocumentSubDepartment != null && DocumentSubDepartment != "undefined" && DocumentSubDepartment != "null")
            {
                sql = sql + "and LDR. DocumentSubDepartmentID='" + DocumentSubDepartment + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentRegistration> DocumentRegistration = new List<DocumentRegistration>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentRegistration.Add(new DocumentRegistration
                {
                    DocumentRegistrationId = Convert.ToInt32(dr["DocumentRegistrationID"]),
                    DocumentNumber = dr["DocumentNumber"].ToString(),
                    DocumentDate =DateTime.Parse(dr["DocumentDate"].ToString()),
                    UnitUnitName = dr["UnitName"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    DocumentClassClassName = dr["ClassName"].ToString(),
                    DocumentType = Convert.ToInt16(dr["DocumentType"]),
                    DocumentOwnerEmployeeCode = dr["DocumentOwner"].ToString(),
                    DocumentApproverEmployeeCode = dr["DocumentApprover"].ToString(),
                    ImagePath = dr["DocumentFile"].ToString(),
                    DocumentApproverDate =DateTime.Parse(dr["DocumentApproverDate"].ToString()),
                    Preamble = dr["Preamble"].ToString(),
                    ApprovalStatusName = dr["ApprovalStatusName"].ToString(),
                    DocumentSubClassSubClassName = dr["SubClassName"].ToString(),
                    DocumentDepartmentDepartmentName = dr["DepartmentName"].ToString(),
                    DocumentSubDepartmentSubDepartmentName = dr["SubDepartmentName"].ToString(),
                    DocumentApproverId = Convert.ToInt32(dr["DocumentApproverID"]),
                    DocumentClassId = Convert.ToInt32(dr["DocumentClassID"]),
                    DocumentDepartmentId = Convert.ToInt32(dr["DocumentDepartmentID"]),
                    DocumentOwnerId = Convert.ToInt32(dr["DocumentOwnerID"]),
                    DocumentSubClassId = Convert.ToInt32(dr["DocumentSubClassID"]),
                    DocumentSubDepartmentId = Convert.ToInt32(dr["DocumentSubDepartmentID"]),

                });

            }
            return DocumentRegistration;
        }

        public DataTable InsertAddDocumentSubClass(int documentSubClassId, int DocumentClassId, int subClassCode, string subClassName, string shortCode)
        {
            string SqlQujery = "Exec DocumentSubClass " + documentSubClassId + "," + DocumentClassId + "," + subClassCode + ",'" + subClassName + "','" + shortCode + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertAddEmployee(int employeeId, int plantDepartmentId, string employeeCode1, string employeeCode2, string employeeName, string employeeClass, bool isApprover)
        {
            //suresh_11102022
            string SqlQujery = "Exec EMPLOYEE " + employeeId + "," + 1 + "," + plantDepartmentId + ",'" + employeeCode2 + "','" + employeeName + "','" + employeeClass + "'," + isApprover + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public List<CmpRegistration> CmpRegistration(string Unit, string Intiator, string DocumentDepartment, string DocumentSubDepartment)
        {
            string sql = "select LCR.CMPRegistrationID,LCR.RegistrationNumber,isnull (LCR.RegistrationDate,'')RegistrationDate,isnull (LCR.UnitID,'')UnitID,LCR.Subject,LCR.Status,LCR.ProposedActivity,LCR.ExpectedImprovement,LCR.OtherImplications,isnull (LCR.IsDrawingAtached,'')IsDrawingAtached,isnull (LCR.CostOfChange,0)CostOfChange,LCR.IsEstimationAttached,LCR.ROI,LCR.IsROICalculationAttached,LCR.ProposalDrawnFrom,LCR.IsTrainingRequired,Isnull(LCR.IntiatorID,'')IntiatorID,LCR.Remarks,LCR.DrawingDocument,LCR.ROICalculationDocument,isnull (LCR.UnitHeadApprovalState,'')UnitHeadApprovalState,isnull(LCR.UnitHeadApprovalDate,'')UnitHeadApprovalDate,isnull (LCR.UnitHeadComment,'')UnitHeadComment,isnull (LCR.TechnicalCoordinatorApprovalState,'')TechnicalCoordinatorApprovalState,isnull(LCR.TechnicalCoordinatorApprovalDate,'')TechnicalCoordinatorApprovalDate,isnull (LCR.TechnicalCoordinatorComment,'')TechnicalCoordinatorComment,isnull (LCR.CTT_EngineerApprovalState,'')CTT_EngineerApprovalState,isnull (LCR.CTT_EngineerApprovalDate,'')CTT_EngineerApprovalDate,isnull (LCR.CTT_EngineerComment,'')CTT_EngineerComment,isnull (LCR.CTT_ProcessApprovalState,'')CTT_ProcessApprovalState,isnull (LCR.CTT_ProcessApprovalDate,'')CTT_ProcessApprovalDate,isnull (LCR.CTT_ProcessComment,'')CTT_ProcessComment,isnull (LCR.FinalAuthorityApprovalState,'')FinalAuthorityApprovalState,isnull(LCR.FinalAuthorityApprovalDate,'')FinalAuthorityApprovalDate,isnull (LCR.FinalAuthorityComment,'')FinalAuthorityComment,LCR.IsImplemented,isnull (LCR.DocumentType,'')DocumentType,isnull (LCR.ApprovalStatus,'')ApprovalStatus,LCR.Preamble,LCR.ImpactQuantity,LCR.ImpactQuantityDetail,LCR.IsImpactOnSafety,LCR.ImpactOnSafetyDetail,LCR.IsImpactOnEnvironment,LCR.ImpactOnEnvironmentDetail,LCR.IsImpactOnFoodSafety,LCR.ImpactOnFoodSafetyDetail,LCR.IsLegalRequirement,LCR.LegalRequirementDetail,LCR.TrainingDetail,LCR.IsBudgetTaken,LCR.BudgetDetail,LCR.EstimationDocument,Isnull(LCR.DocumentDepartmentID,'')DocumentDepartmentID,isnull (LCR.DocumentSubDepartmentID,'')DocumentSubDepartmentID,LCR.IsSanctionRequired,LCR.NatureOfExpenditure,isnull (LCR.BudgetProvisionAmount,0)BudgetProvisionAmount,isnull (LCR.PresentProposalAmount,0)PresentProposalAmount,isnull (LCR.BalanceSanctionAmount,0)BalanceSanctionAmount,LCR.FuntionLocationInPlant,isnull (LCR.SanctionDate,'')SanctionDate,isnull (LCR.ROIDocumentType,'')ROIDocumentType,isnull (LCR.EstimateDocumentType,'')EstimateDocumentType,isnull (CU.UnitName,'')UnitName,LPD.DepartmentName,LPSD.SubDepartmentName,LE.EmployeeCode as IntiatorCode from Lab.CMP_REGISTRATION LCR left Outer Join Common.Unit CU on LCR.UnitID=CU.UnitID Left Outer Join Lab.PlantDepartment LPD on LCR.DocumentDepartmentID=LPD.PlantDepartmentID Left Outer Join Lab.PlantSubDepartment LPSD on LCR.DocumentSubDepartmentID =LPSD.PlantSubDepartmentID Left Outer join Lab.EMPLOYEE LE on LCR.IntiatorID=LE.EmployeeID where 1=1";
            if (Unit != "" && Unit != null && Unit != "undefined" && Unit != "null")
            {
                sql = sql + "and LCR. UnitID='" + Unit + "'";
            }
            if (Intiator != "" && Intiator != null && Intiator != "undefined" && Intiator != "null")
            {
                sql = sql + "and LCR. IntiatorID='" + Intiator + "'";
            }
            if (DocumentDepartment != "" && DocumentDepartment != null && DocumentDepartment != "undefined" && DocumentDepartment != "null")
            {
                sql = sql + "and LCR. DocumentDepartmentID='" + DocumentDepartment + "'";
            }
            if (DocumentSubDepartment != "" && DocumentSubDepartment != null && DocumentSubDepartment != "undefind" && DocumentSubDepartment != "null")
            {
                sql = sql + " and LCR. DocumentSubDepartmentID='" + DocumentSubDepartment + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<CmpRegistration> CmpRegistration = new List<CmpRegistration>();
            foreach (DataRow dr in dt.Rows)
            {
                CmpRegistration.Add(new CmpRegistration
                {
                    CmpRegistrationId = Convert.ToInt32(dr["CMPRegistrationID"]),
                    RegistrationNumber = dr["RegistrationNumber"].ToString(),
                    RegistrationDate = DateTime.Parse(dr["RegistrationDate"].ToString()),
                    UnitUnitName = dr["UnitName"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    Status = dr["Status"].ToString(),
                    ProposedActivity = dr["ProposedActivity"].ToString(),
                    OtherImplications = dr["OtherImplications"].ToString(),
                    IsDrawingAtached = (bool)(dr["IsDrawingAtached"]),
                    CostOfChange = Convert.ToInt32(dr["CostOfChange"]),
                    IsEstimationAttached = (bool)(dr["IsEstimationAttached"]),
                    Roi = dr["ROI"].ToString(),
                    IsRoiCalculationAttached = (bool)(dr["IsRoiCalculationAttached"]),
                    ProposalDrawnFrom = Convert.ToInt16(dr["ProposalDrawnFrom"]),
                    IsTrainingRequired = (bool)(dr["IsTrainingRequired"]),
                    IntiatorEmployeeCode = dr["IntiatorCode"].ToString(),
                    DrawingDocument = dr["DrawingDocument"].ToString(),
                    RoiCalculationDocument = dr["ROICalculationDocument"].ToString(),
                    IsImplemented = (bool)(dr["IsImplemented"]),
                    DocumentType = Convert.ToInt16(dr["DocumentType"]),
                    Preamble = dr["Preamble"].ToString(),
                    ImpactQuantity = (bool)(dr["ImpactQuantity"]),
                    ImpactQuantityDetail = dr["ImpactQuantityDetail"].ToString(),
                    IsImpactOnSafety = (bool)(dr["IsImpactOnSafety"]),
                    ImpactOnSafetyDetail = dr["ImpactOnSafetyDetail"].ToString(),
                    IsImpactOnEnvironment = (bool)(dr["IsImpactOnEnvironment"]),
                    ImpactOnEnvironmentDetail = dr["ImpactOnEnvironmentDetail"].ToString(),
                    IsImpactOnFoodSafety = (bool)(dr["IsImpactOnFoodSafety"]),
                    ImpactOnFoodSafetyDetail = dr["ImpactOnFoodSafetyDetail"].ToString(),
                    IsLegalRequirement = (bool)(dr["IsLegalRequirement"]),
                    LegalRequirementDetail = dr["LegalRequirementDetail"].ToString(),
                    TrainingDetail = dr["LegalRequirementDetail"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                    IsBudgetTaken = (bool)(dr["IsBudgetTaken"]),
                    BudgetDetail = dr["BudgetDetail"].ToString(),
                    EstimationDocument = dr["EstimationDocument"].ToString(),
                    DocumentDepartmentDepartmentName = dr["DepartmentName"].ToString(),
                    DocumentSubDepartmentSubDepartmentName = dr["SubDepartmentName"].ToString(),
                    IsSanctionRequired = (bool)(dr["IsSanctionRequired"]),
                    NatureOfExpenditure = dr["NatureOfExpenditure"].ToString(),
                    BudgetProvisionAmount = Convert.ToInt16(dr["BudgetProvisionAmount"]),
                    PresentProposalAmount = Convert.ToInt16(dr["PresentProposalAmount"]),
                    BalanceSanctionAmount = Convert.ToInt16(dr["BalanceSanctionAmount"]),
                    FuntionLocationInPlant = dr["FuntionLocationInPlant"].ToString(),
                    SanctionDate = DateTime.Parse(dr["SanctionDate"].ToString()),
                    RoiDocumentType = Convert.ToInt16(dr["ROIDocumentType"]),
                    EstimateDocumentType = Convert.ToInt16(dr["EstimateDocumentType"]),
                    DocumentDepartmentId = Convert.ToInt32(dr["DocumentDepartmentID"]),
                    DocumentSubDepartmentId = Convert.ToInt32(dr["DocumentSubDepartmentID"]),
                    IntiatorId = Convert.ToInt32(dr["IntiatorID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])

                });

            }
            return CmpRegistration;
        }
        public DataTable InsertDocumentRegistration(int DocumentRegistrationId, string documentNumber, DateTime documentDate, int UnitId, string subject, short documentType, int documentClassID, int documentOwnerID, int documentApproverID, string documentFile, DateTime documentApproverDate, string preamble, short approvalStatus, int documentSubClassID, int documentDepartmentID, int documentSubDepartmentID)
        {
            //suresh_14102022 .ToString("yyyy-MM-dd")

            string SqlQujery = "Exec DOCUMENT_REGISTRATION " + DocumentRegistrationId + "," + documentNumber + ",'" + documentDate.ToString("yyyy-MM-dd") + "'," + UnitId + ",'" + subject + "'," + documentType + "," + documentClassID + "," + documentOwnerID + "," + documentApproverID + ",'" + documentFile + "','" + documentApproverDate.ToString("yyyy-MM-dd") + "','" + preamble + "'," + approvalStatus + "," + documentSubClassID + "," + documentDepartmentID + "," + documentSubDepartmentID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public List<InterAllocationRegistration> InterAllocationRegistration(string Unit, string Intiator, string DocumentDepartment, string DocumentSubDepartment)
        {
            string sql = "select LIAR.InterAlocationRegistrationID,LIAR.RegistrationNumber,isnull(LIAR.RegistrationDate,'')RegistrationDate,isnull(LIAR.UnitID,'')UnitID,LIAR.Subject,isnull(LIAR.IntiatorID,'')IntiatorID,isnull(LIAR.Remarks,'')Remarks,LIAR.OldNumber,Isnull(LIAR.ApprovalStatus,'')ApprovalStatus,isnull(LIAR.DocumentDepartmentID,'')DocumentDepartmentID,Isnull(LIAR.DocumentSubDepartmentID,'')DocumentSubDepartmentID,CU.UnitName,LE.EmployeeName,LPD.DepartmentName ,LPSD.SubDepartmentName,ASt.ApprovalStatusName from Lab.INTER_ALLOCATION_REGISTRATION LIAR left outer join Common.Unit CU on LIAR.UnitID= CU.UnitID left outer join Lab.EMPLOYEE LE on LIAR.IntiatorID= LE.EmployeeID left outer join Lab.PlantDepartment LPD on LIAR.DocumentDepartmentID= LPD.PlantDepartmentID left outer join Lab.PlantSubDepartment LPSD on LIAR.DocumentSubDepartmentID= LPSD.PlantSubDepartmentID left outer join ApprovalStatus ASt on LIAR.ApprovalStatus= ASt.ApprovalStatusID where 1=1";
            if (Unit != "undefined" && Unit != null && Unit != "" && Unit != "null")
            {
                sql = sql + "and LIAR.UnitID='" + Unit + "'";
            }
            if (Intiator != "undefined" && Intiator != null && Intiator != "null" && Intiator!="")
            {
                sql = sql + "and LIAR.IntiatorID='" + Intiator + "'";
            }

            if (DocumentDepartment!="" && DocumentDepartment != "undefined" && DocumentDepartment != null && DocumentDepartment != "null")
            {
                sql = sql + "and LIAR.DocumentDepartmentID='" + DocumentDepartment + "'";

            }
            if (DocumentSubDepartment != "undefined" && DocumentSubDepartment != null && DocumentSubDepartment != "null" && DocumentSubDepartment!="")
            {
                sql = sql + "and LIAR.DocumentSubDepartmentID='" + DocumentSubDepartment + "'";
            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<InterAllocationRegistration> InterAllocationRegistration = new List<InterAllocationRegistration>();
            foreach (DataRow dr in dt.Rows)
            {
                InterAllocationRegistration.Add(new InterAllocationRegistration
                {
                    InterAlocationRegistrationId = Convert.ToInt32(dr["InterAlocationRegistrationID"]),
                    RegistrationNumber = dr["RegistrationNumber"].ToString(),
                    RegistrationDate = DateTime.Parse(dr["RegistrationDate"].ToString()),
                    UnitUnitName = dr["UnitName"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    IntiatorEmployeeName = dr["EmployeeName"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                    OldNumber = dr["OldNumber"].ToString(),
                    ApprovalStatus = Convert.ToInt16(dr["ApprovalStatus"]),
                    DocumentDepartmentDepartmentName = dr["DepartmentName"].ToString(),
                    DocumentSubDepartmentSubDepartmentName = dr["SubDepartmentName"].ToString(),
                    DocumentDepartmentId = Convert.ToInt32(dr["DocumentDepartmentID"]),
                    DocumentSubDepartmentId = Convert.ToInt32(dr["DocumentSubDepartmentID"]),
                    IntiatorId = Convert.ToInt32(dr["IntiatorID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])
                });

            }
            return InterAllocationRegistration;
        }
        public List<InterAllocationApproval> InterAllocationApproval(string Unit, string Initiator, string ApprovalStatus, string RejectedStatus)
        {
            string sql = "select isnull(IAR.InterAlocationRegistrationID,'')InterAlocationRegistrationID,isnull(IAR.RegistrationNumber,'')RegistrationNumber,isnull(IAR.RegistrationDate,'')RegistrationDate, CU.UnitName,IAR.Subject,LEE.EMPLOYEEName, Isnull(IAR.ApprovalStatus,'')ApprovalStatus,isnull(case when isnull(IAR.ApprovalStatus,'')=9 then 'Approved' end ,'') as ApprovedStatus,isnull(case when isnull(IAR.ApprovalStatus,'')=10 then 'Rejected' end,'' )as RejectedStatus,isnull(IAR.IntiatorID,'')IntiatorID,isnull(IAR.UnitID,'')UnitID from Lab.INTER_ALLOCATION_REGISTRATION IAR Left outer join common.Unit CU on IAR.UnitID=CU.UnitID left outer join ApprovalStatus A on IAR.ApprovalStatus=A.ApprovalStatusID left outer join Lab.EMPLOYEE LEE on IAR.IntiatorID=LEE.EmployeeID where 1=1";
            if (Unit != "undefined" && Unit != null && Unit != "" && Unit != "null")
            {
                sql = sql + " and IAR.UnitID=" + Unit + "";
            }
            if (Initiator != "" && Initiator != "undefined" && Initiator != null && Initiator != "null")
            {
                sql = sql + " and IAR.IntiatorID=" + Initiator + "";
            }

            if (ApprovalStatus != "" && ApprovalStatus != "undefined" && ApprovalStatus != null && ApprovalStatus != "null")
            {
                sql = sql + " and IAR.ApprovalStatus=" + ApprovalStatus + "";

            }
            if (RejectedStatus != "" && RejectedStatus != "undefined" && RejectedStatus != null && RejectedStatus != "null")
            {
                sql = sql + " and IAR.ApprovalStatus=" + RejectedStatus + "";

            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<InterAllocationApproval> InterAllocationApproval = new List<InterAllocationApproval>();
            foreach (DataRow dr in dt.Rows)
            {
                InterAllocationApproval.Add(new InterAllocationApproval
                {
                    InterAlocationRegistrationId = Convert.ToInt16(dr["InterAlocationRegistrationID"]),
                    RegistrationNumber = dr["RegistrationNumber"].ToString(),
                    RegistrationDate = Convert.ToDateTime(dr["RegistrationDate"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    IntiatorEmployeeName = dr["EmployeeName"].ToString(),
                    ApprovalStatus = Convert.ToInt16(dr["ApprovalStatus"]),
                    ApprovedStatus = dr["ApprovedStatus"].ToString(),
                    IntiatorId = Convert.ToInt16(dr["IntiatorId"]),
                    RejectedStatus = dr["RejectedStatus"].ToString(),
                    UnitId = Convert.ToInt16(dr["UnitId"]),
                });

            }
            return InterAllocationApproval;
        }
       
        public List<DocumentRegistration> DocumentRegistrationApprovalData(string Unit, string DocumentApprover, string ApprovalStatus)
        {
            string sql = "select LDR.DocumentRegistrationID ,LDR.DocumentNumber ,isnull (LDR.DocumentDate,'') DocumentDate,isnull (LDR.UnitID,'')UnitID ,isnull (LDR.Subject,'')Subject ,isnull (LDR.DocumentType,'')DocumentType ,isnull (LDR.DocumentClassID,'')DocumentClassID ,isnull (LDR.DocumentOwnerID,'')DocumentOwnerID ,isnull(LDR.DocumentApproverID,'')DocumentApproverID ,LDR.DocumentFile ,LDR.DocumentApproverDate ,isnull (LDR.Preamble,'')Preamble ,Isnull(LDR.ApprovalStatus,'')ApprovalStatus ,isnull (LDR.DocumentSubClassID,'')DocumentSubClassID ,isnull (LDR.DocumentDepartmentID,'')DocumentDepartmentID ,isnull (LDR.DocumentSubDepartmentID,'')DocumentSubDepartmentID ,isnull (CU.UnitName,'')UnitName ,isnull (LDC.ClassName,'')ClassName ,isnull(LE.EmployeeName,'')  DocumentOwnerName ,isnull(LEE.EmployeeName,'') DocumentApproverName ,isnull(A.ApprovalStatusName,'')ApprovalStatusName ,isnull(LDSC.SubClassName,'' )SubClassName,isnull(LPD.DepartmentName,'')DepartmentName ,isnull(LPSD.SubDepartmentName,'')SubDepartmentName from Lab.DOCUMENT_REGISTRATION LDR Left outer join Common.Unit CU on LDR.UnitID= CU.UnitID Left outer join Lab.DocumentClass LDC on LDR.DocumentClassID=LDC.DocumentClassID left outer join Lab.EMPLOYEE LE on LDR.DocumentOwnerID=LE.EmployeeID left outer join Lab.EMPLOYEE LEE on LDR.DocumentApproverID=LEE.EmployeeID left outer join ApprovalStatus A on LDR.ApprovalStatus=A.ApprovalStatusID left outer join Lab.DocumentSubClass LDSC on LDR.DocumentSubClassID=LDSC.DocumentSubClassID left outer Join Lab.PlantDepartment LPD  on LDR.DocumentDepartmentID =LPD.PlantDepartmentID Left outer join Lab.PlantSubDepartment LPSD on LDR.DocumentSubDepartmentID = LPSD.PlantSubDepartmentID where 1=1";
            if (Unit != "undefined" && Unit != null && Unit != "" && Unit != "null")
            {
                sql = sql + " and LDR.UnitID=" + Unit + "";
            }
            if (DocumentApprover != "" && DocumentApprover != "undefined" && DocumentApprover != null && DocumentApprover != "null")
            {
                sql = sql + " and LDR.DocumentApproverID=" + DocumentApprover + "";
            }

            if (ApprovalStatus != "" && ApprovalStatus != "undefined" && ApprovalStatus != null && ApprovalStatus != "null")
            {
                sql = sql + " and LDR.ApprovalStatus=" + ApprovalStatus + "";

            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentRegistration> DocumentRegistrationApproval = new List<DocumentRegistration>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentRegistrationApproval.Add(new DocumentRegistration
                {
                    DocumentRegistrationId = Convert.ToInt32(dr["DocumentRegistrationId"]),
                    DocumentNumber = dr["DocumentNumber"].ToString(),
                    UnitUnitName = dr["UnitName"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    DocumentType = Convert.ToInt16(dr["DocumentType"]),
                    DocumentApproverEmployeeName = dr["DocumentApproverName"].ToString(),
                    DocumentApproverDate = Convert.ToDateTime(dr["DocumentApproverDate"]),
                    ApprovalStatus = Convert.ToInt16(dr["ApprovalStatus"]),
                    DocumentClassClassName=dr["ClassName"].ToString(),
                    DocumentClassId=Convert.ToInt32(dr["DocumentClassID"]),
                    DocumentOwnerName = dr["DocumentOwnerName"].ToString(),
                    Preamble= dr["Preamble"].ToString(),
                    DocumentSubClassId=Convert.ToInt32(dr["DocumentSubClassID"]),
                    DocumentSubClassSubClassName=dr["SubClassName"].ToString(),
                    DocumentDepartmentId=Convert.ToInt32(dr["DocumentDepartmentID"]),
                    DocumentDepartmentDepartmentName=dr["DepartmentName"].ToString(),
                    DocumentSubDepartmentId=Convert.ToInt32(dr["DocumentSubDepartmentID"]),
                    DocumentSubDepartmentSubDepartmentName=dr["SubDepartmentName"].ToString(),
                    ImagePath=dr["DocumentFile"].ToString(),
                    DocumentApproverId=Convert.ToInt32(dr["DocumentApproverID"]),
                    
                });

            }
            return DocumentRegistrationApproval;
        }
        public DataTable InsertAddInterAllocationRegistration(int interAlocationRegistrationId, string registrationNumber, DateTime registrationDate, int unitId, string subject, int intiatorId, string remarks, string oldNumber, int DocumentDepartmentId, int DocumentSubDepartmentId)
        {
            //suresh_14102022 
            string SqlQujery = "Exec INTER_ALLOCATION_REGISTRATION " + interAlocationRegistrationId + ",'" + registrationNumber + "','" + registrationDate.ToString("yyyy-MM-dd") + "'," + unitId + ",'" + subject + "'," + intiatorId + ",'" + remarks + "','" + oldNumber + "'," + DocumentDepartmentId + "," + DocumentSubDepartmentId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertAddInterAllocationRegistrationDetail(int interAllocationRegistrationDetailId, int interAlocationRegistrationId, short serialNumber, short flag, string equipment, string activity, decimal budgetAmount, decimal actualAmount, decimal savedAmount, string reason)
        {
            //suresh_14102022 
            string SqlQujery = "Exec INTER_ALLOCATION_REGISTRATION_DETAIL " + interAllocationRegistrationDetailId + "," + interAlocationRegistrationId + "," + serialNumber + "," + flag + ",'" + equipment + "','" + activity + "'," + budgetAmount + "," + actualAmount + "," + savedAmount + ",'" + reason + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertAddCmpRegistration(int cmpRegistrationId, string registrationNumber, DateTime registrationDate, int unitId, string subject, string status, string proposedActivity, string expectedImprovement, string otherImplications, bool isDrawingAtached, decimal costOfChange, bool isEstimationAttached, string roi, bool isRoiCalculationAttached, short proposalDrawnFrom, bool isTrainingRequired, int intiatorId, string remarks, string drawingDocument, string roiCalculationDocument, bool isImplemented, short documentType, string preamble, bool impactQuantity, string impactQuantityDetail, bool isImpactOnSafety, string impactOnSafetyDetail, bool isImpactOnEnvironment, string impactOnEnvironmentDetail, bool isImpactOnFoodSafety, string impactOnFoodSafetyDetail, bool isLegalRequirement, string legalRequirementDetail, string trainingDetail, bool isBudgetTaken, string budgetDetail, string estimationDocument, int documentDepartmentId, int documentSubDepartmentId, bool isSanctionRequired, string natureOfExpenditure, decimal budgetProvisionAmount, decimal presentProposalAmount, decimal balanceSanctionAmount, string funtionLocationInPlant, DateTime sanctionDate, short roiDocumentType, short estimateDocumentType)
        {
            //suresh_14102022 
            // string SqlQujery = "Exec CMP_REGISTRATION " + cmpRegistrationId + ",'" + registrationNumber + "','" + registrationDate.ToString("yyyy-MM-dd") + "'," + unitId + ",'" + subject + "'" + status + "'" + proposedActivity + "'" + expectedImprovement + "'" + otherImplications + "" + isDrawingAtached + "," + costOfChange + "," + isEstimationAttached + ",'" + roi + "'," + isRoiCalculationAttached + "," + proposalDrawnFrom + "," + isTrainingRequired + "," + intiatorId + ",'" + remarks + ",'" + drawingDocument + ",'" + roiCalculationDocument + "," + isImplemented + "," + documentType + ",'" + preamble + "'," + impactQuantity + ",'" + impactQuantityDetail + "'," + isImpactOnSafety + ",'" + impactOnSafetyDetail + "'," + isImpactOnEnvironment + ",'" + impactOnEnvironmentDetail + "'," + isImpactOnFoodSafety + ",'" + impactOnFoodSafetyDetail + "'," + isLegalRequirement + ",'" + legalRequirementDetail + "','" + trainingDetail + "'," + isBudgetTaken + ",'" + budgetDetail + "','" + estimationDocument + "'," + documentDepartmentId + "," + documentSubDepartmentId + "," + isSanctionRequired + ",'" + natureOfExpenditure + "'," + budgetProvisionAmount + "," + presentProposalAmount + "," + balanceSanctionAmount + ",'" + funtionLocationInPlant + "','" + sanctionDate.ToString("yyyy-MM-dd") + "'," + roiDocumentType + "," + estimateDocumentType + "";
            string SqlQujery = "Exec CMP_REGISTRATION " + cmpRegistrationId + ",'" + registrationNumber + "','" + registrationDate.ToString("yyyy-MM-dd") + "'," + unitId + ",'" + subject + "','" + status + "','" + proposedActivity + "','" + expectedImprovement + "','" + otherImplications + "'," + isDrawingAtached + "," + costOfChange + "," + isEstimationAttached + ",'" + roi + "'," + isRoiCalculationAttached + "," + proposalDrawnFrom + "," + isTrainingRequired + "," + intiatorId + ",'" + remarks + "','" + drawingDocument + "','" + roiCalculationDocument + "'," + isImplemented + "," + documentType + ",'" + preamble + "'," + impactQuantity + ",'" + impactQuantityDetail + "'," + isImpactOnSafety + ",'" + impactOnSafetyDetail + "'," + isImpactOnEnvironment + ",'" + impactOnEnvironmentDetail + "'," + isImpactOnFoodSafety + ",'" + impactOnFoodSafetyDetail + "'," + isLegalRequirement + ",'" + legalRequirementDetail + "','" + trainingDetail + "'," + isBudgetTaken + ",'" + budgetDetail + "','" + estimationDocument + "'," + documentDepartmentId + "," + documentSubDepartmentId + "," + isSanctionRequired + ",'" + natureOfExpenditure + "'," + budgetProvisionAmount + "," + presentProposalAmount + "," + balanceSanctionAmount + ",'" + funtionLocationInPlant + "','" + sanctionDate.ToString("yyyy-MM-dd") + "'," + roiDocumentType + "," + estimateDocumentType + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public List<InterAllocationRegistrationDetail> InterAllocationRegistrationDetail(string InterAlocationRegistrationID)
        {
            string Query = "select InterAlocationRegistrationDetailID, Isnull(InterAlocationRegistrationID, '')InterAlocationRegistrationID,Isnull(SerialNumber, '')SerialNumber,Isnull(Flag, '')Flag,Isnull(Equipment, '')Equipment,Isnull(Activity, '')Activity,Isnull(BudgetAmount, 0)BudgetAmount,Isnull(ActualAmount, 0)ActualAmount,Isnull(SavedAmount, 0)SavedAmount,Isnull(Reason, '')Reason from Lab.INTER_ALLOCATION_REGISTRATION_DETAIL where 1=1";
              if (InterAlocationRegistrationID != "undefined" && InterAlocationRegistrationID != null && InterAlocationRegistrationID != "" && InterAlocationRegistrationID != "null")
            {
                Query = Query + "and InterAlocationRegistrationID=" + InterAlocationRegistrationID + "";
            }
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<InterAllocationRegistrationDetail> interAllocationRegistrationDetails = new List<InterAllocationRegistrationDetail>();

            foreach (DataRow dr in dt.Rows)
            {
                interAllocationRegistrationDetails.Add(new InterAllocationRegistrationDetail
                {
                    InterAllocationRegistrationDetailId = Convert.ToInt32(dr["InterAlocationRegistrationDetailID"]),
                    InterAlocationRegistrationId = Convert.ToInt32(dr["InterAlocationRegistrationID"]),
                    Equipment = dr["Equipment"].ToString(),
                    SerialNumber = Convert.ToInt16(dr["SerialNumber"].ToString()),
                    Activity = dr["Activity"].ToString(),
                    Reason = dr["Reason"].ToString(),
                    Flag = Convert.ToInt16(dr["Flag"]),
                    BudgetAmount = Convert.ToDecimal(dr["BudgetAmount"]),
                    ActualAmount = Convert.ToDecimal(dr["ActualAmount"]),
                    SavedAmount = Convert.ToDecimal(dr["SavedAmount"]),

                }); ;

            }
            return interAllocationRegistrationDetails;
        }
    }
}