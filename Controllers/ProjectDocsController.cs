using KnowledgeApp_Test.Models.ProjectDocs;
using KnowledgeApp_Test.Models.Template;
using KnowledgeApp_Test.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{
    public class ProjectDocsController : Controller
    {
        ProjectDocsServices ProjectDocsServices = new ProjectDocsServices();
        DropdownListSevices DropdownListSevices = new DropdownListSevices();
        // GET: ProjectDocs
        #region DocumentProposal
        public ActionResult DocumentProposal()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult DocumentProposalData()
        {
            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DocumentProposal> documentProposal = new List<DocumentProposal>();
            documentProposal = ProjectDocsServices.DocumentProposal();
            int rowstotal = documentProposal.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                documentProposal = documentProposal.Where(x => x.ProposalName.ToLower().Contains(searchvalue.ToLower()) || x.ProposalCode.ToString().Contains(searchvalue.ToLower()) || x.DocumentProposalId.ToString().Contains(searchvalue.ToLower())).ToList<DocumentProposal>();

            }
            int totalrowsafterfiltering = documentProposal.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            documentProposal = documentProposal.Skip(start).Take(length).ToList<DocumentProposal>();
            return Json(new { data = documentProposal, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddDocumentProposal(int id = 0)
        {
            //suresh_11102021
            if (id == 0)
                return View(new DocumentProposal());
            else
            {
                List<DocumentProposal> dateConfiguration = new List<DocumentProposal>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.DocumentProposal();
                return View(dateConfiguration.Where(x => x.DocumentProposalId == id).FirstOrDefault<DocumentProposal>());

            }
        }
        public ActionResult AddDocumentProposal(DocumentProposal DocumentProposal)
        {
            //suresh_11102021
            var DocumentProposalId = DocumentProposal.DocumentProposalId;
            var ProposalCode = DocumentProposal.ProposalCode;
            var ProposalName = DocumentProposal.ProposalName;
            DataTable data = ProjectDocsServices.InsertAddDocumentProposal(DocumentProposalId, ProposalCode, ProposalName);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {
                    //TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("DocumentProposal");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("DocumentProposal");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("DocumentProposal");
            }

        }
        #endregion Proposal
        #region  DocumentClass
        [HttpGet]
        public ActionResult DocumentClass()
        {
            //suresh_12102021
            ViewBag.Alert = TempData["Alert"];
            return View();
           
        }
        [HttpGet]
        public ActionResult AddDocumentClass(int id = 0)
        {
            //suresh_12102021
            if (id == 0)
                return View(new DocumentClass());
            else
            {
                List<DocumentClass> dateConfiguration = new List<DocumentClass>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.DocumentClass();
                return View(dateConfiguration.Where(x => x.DocumentClassId == id).FirstOrDefault<DocumentClass>());

            }
        }
        [HttpPost]
        public ActionResult AddDocumentClass(DocumentClass DocumentClass)
        {
            //suresh_12102021
            var DocumentClassId = DocumentClass.DocumentClassId;
            var ClassCode = DocumentClass.ClassCode;
            var ClassName = DocumentClass.ClassName;
            var ShortCode = DocumentClass.ShortCode;
            DataTable data = ProjectDocsServices.InsertAddDocumentClass(DocumentClassId, ClassCode, ClassName, ShortCode);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("DocumentClass");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("DocumentClass");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("DocumentClass");
            }
        }
        [HttpPost]
        public JsonResult DocumentClassData()
        {
            //suresh_14102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DocumentClass> DocumentClass = new List<DocumentClass>();
            DocumentClass = ProjectDocsServices.DocumentClass();
            int rowstotal = DocumentClass.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                DocumentClass = DocumentClass.Where(x => x.ClassName.ToLower().Contains(searchvalue.ToLower()) || x.ClassCode.ToString().Contains(searchvalue.ToLower()) || x.DocumentClassId.ToString().Contains(searchvalue.ToLower())).ToList<DocumentClass>();

            }
            int totalrowsafterfiltering = DocumentClass.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            DocumentClass = DocumentClass.Skip(start).Take(length).ToList<DocumentClass>();
            return Json(new { data = DocumentClass, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion Class
        #region Subclass
        [HttpGet]
        public ActionResult DocumentSubClass()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddDocumentSubClass(int id = 0)
        {
            //suresh_12102021
            if (id == 0)
                return View(new DocumentSubClass());
            else
            {
                List<DocumentSubClass> dateConfiguration = new List<DocumentSubClass>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.DocumentSubClass("");
                return View(dateConfiguration.Where(x => x.DocumentSubClassId == id).FirstOrDefault<DocumentSubClass>());

            }
        }
        [HttpPost]
        public ActionResult AddDocumentSubClass(DocumentSubClass DocumentSubClass)
        {
            //suresh_14102021
            var DocumentSubClassId = DocumentSubClass.DocumentSubClassId;
            var DocumentClassId = DocumentSubClass.DocumentClassId;
            var SubClassCode = DocumentSubClass.SubClassCode;
            var SubClassName = DocumentSubClass.SubClassName;
            var ShortCode = DocumentSubClass.ShortCode;
            DataTable data = ProjectDocsServices.InsertAddDocumentSubClass(DocumentSubClassId, DocumentClassId, SubClassCode, SubClassName, ShortCode);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("DocumentSubClass");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("DocumentSubClass");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("DocumentSubClass");
            }
        }
        public JsonResult DocumentSubClassData(string DocumentClassId)
        {
            //suresh_14102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DocumentSubClass> DocumentSubClass = new List<DocumentSubClass>();
            DocumentSubClass = ProjectDocsServices.DocumentSubClass(DocumentClassId);
            int rowstotal = DocumentSubClass.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                DocumentSubClass = DocumentSubClass.Where(x => x.SubClassName.ToLower().Contains(searchvalue.ToLower()) || x.SubClassCode.ToString().Contains(searchvalue.ToLower()) || x.DocumentSubClassId.ToString().Contains(searchvalue.ToLower())).ToList<DocumentSubClass>();

            }
            int totalrowsafterfiltering = DocumentSubClass.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            DocumentSubClass = DocumentSubClass.Skip(start).Take(length).ToList<DocumentSubClass>();
            return Json(new { data = DocumentSubClass, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion SubClass
        #region Employee
        [HttpGet]
        public ActionResult Employee()
        {
            ViewBag.Alert = TempData["Alert"];
            //suresh_11102021
            return View();
        }
        [HttpPost]
        public JsonResult EmployeeData(string PlantDepartment)
        {
            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Employee> Employee = new List<Employee>();
            Employee = ProjectDocsServices.Employee(PlantDepartment);
            int rowstotal = Employee.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                Employee = Employee.Where(x => x.EmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.EmployeeCode.ToString().Contains(searchvalue.ToLower()) || x.EmployeeId.ToString().Contains(searchvalue.ToLower())).ToList<Employee>();

            }
            int totalrowsafterfiltering = Employee.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            Employee = Employee.Skip(start).Take(length).ToList<Employee>();
            return Json(new { data = Employee, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            //var data = ProjectDocsServices.Employee(PlantDepartment);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddEmployee(int id = 0)
        {
            //suresh_12102021
            if (id == 0)
                return View(new Employee());
            else
            {
                List<Employee> dateConfiguration = new List<Employee>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.Employee("");
                return View(dateConfiguration.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>());

            }
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee Employee)
        {
            //suresh_11102021
            var EmployeeId = Employee.EmployeeId;
            var PlantDepartmentId = Employee.PlantDepartmentId;
            var EmployeeCode = Employee.EmployeeCode;
            var EmployeeName = Employee.EmployeeName;
            var EmployeeClass = Employee.EmployeeClass;
            var IsApprover = Employee.IsApprover;
            DataTable data = ProjectDocsServices.InsertAddEmployee(EmployeeId, PlantDepartmentId, EmployeeCode, EmployeeCode, EmployeeName, EmployeeClass, IsApprover);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Employee");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Employee");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Employee");
            }
        }
        #endregion Employee
        #region DocumentRegistration
        [HttpGet]
        public ActionResult DocumentRegistration()
        {
            //suresh_12102021
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddDocumentRegistration(int id = 0)
        {
            //suresh_12102021
            if (id == 0)
                return View(new DocumentRegistration());
            else
            {
                List<DocumentRegistration> dateConfiguration = new List<DocumentRegistration>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.DocumentRegistration("", "", "", "", "", "", "");
                return View(dateConfiguration.Where(x => x.DocumentRegistrationId == id).FirstOrDefault<DocumentRegistration>());

            }
        }
        [HttpPost]
        public ActionResult AddDocumentRegistration(DocumentRegistration DocumentRegistration)
        {

            string FilePath = null;
            if (DocumentRegistration.DocumentFile != null)
            {
                if (DocumentRegistration.DocumentFile.ContentLength > 0 && DocumentRegistration.DocumentFile != null)
                {
                    string extension = System.IO.Path.GetExtension(DocumentRegistration.DocumentFile.FileName);
                    //if (extension.ToUpper() != ".XLS" && extension.ToUpper() != ".XLSX")
                    //{
                    //    lblupload.Text = "Upload XLS/XLSX File only.";
                    //    lblupload.ForeColor = System.Drawing.Color.Red;
                    //    return;
                    //}
                    string FileName = Path.GetFileName(DocumentRegistration.DocumentFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    FilePath = Server.MapPath(FolderPath + FileName);
                    DocumentRegistration.ImagePath = FileName;
                    DocumentRegistration.DocumentFile.SaveAs(FilePath);
                }
            }
            var FilePathforsave = DocumentRegistration.ImagePath;
           
            //suresh_11102021
            var DocumentRegistrationId = DocumentRegistration.DocumentRegistrationId;
            var DocumentNumber = DocumentRegistration.DocumentNumber;
            var DocumentDate = DocumentRegistration.DocumentDate;
            var UnitId = DocumentRegistration.UnitId;
            var Subject = DocumentRegistration.Subject;
            var DocumentType = DocumentRegistration.DocumentType;
            var DocumentClassID = DocumentRegistration.DocumentClassId;
            var DocumentApproverId = DocumentRegistration.DocumentApproverId;
            var DocumentFile = DocumentRegistration.DocumentFile;
            var DocumentApproverDate = DocumentRegistration.DocumentApproverDate;
            var Preamble = DocumentRegistration.Preamble;
            var DocumentApproverID = DocumentRegistration.DocumentApproverId;
            var ApprovalStatus = DocumentRegistration.ApprovalStatus;
            var DocumentDepartmentID = DocumentRegistration.DocumentDepartmentId;
            var DocumentOwnerID = DocumentRegistration.DocumentOwnerId;
            var DocumentSubClassID = DocumentRegistration.DocumentSubClassId;
            var DocumentSubDepartmentID = DocumentRegistration.DocumentSubDepartmentId;
           DataTable data = ProjectDocsServices.InsertDocumentRegistration(DocumentRegistrationId, DocumentNumber, DocumentDate, UnitId, Subject, DocumentType, DocumentClassID, DocumentOwnerID, DocumentApproverID, FilePathforsave, DocumentApproverDate, Preamble, ApprovalStatus, DocumentSubClassID, DocumentDepartmentID, DocumentSubDepartmentID);

           
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("DocumentRegistration");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("DocumentRegistration");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("DocumentRegistration");
            }
        }
        public JsonResult DocumentRegistrationData(string Unit, string DocumentClass, string DocumentOwner, string DocumentApprover, string DocumentSubClass, string DocumentDepartment, string DocumentSubDepartment)
        {
            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DocumentRegistration> DocumentRegistration = new List<DocumentRegistration>();
            DocumentRegistration = ProjectDocsServices.DocumentRegistration(Unit, DocumentClass, DocumentOwner, DocumentApprover, DocumentSubClass, DocumentDepartment, DocumentSubDepartment);
            int rowstotal = DocumentRegistration.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                DocumentRegistration = DocumentRegistration.Where(x => x.DocumentClassClassName.ToLower().Contains(searchvalue.ToLower()) || x.DocumentApproverEmployeeCode.ToString().Contains(searchvalue.ToLower()) || x.DocumentDepartmentId.ToString().Contains(searchvalue.ToLower())).ToList<DocumentRegistration>();

            }
            int totalrowsafterfiltering = DocumentRegistration.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            DocumentRegistration = DocumentRegistration.Skip(start).Take(length).ToList<DocumentRegistration>();
            return Json(new { data = DocumentRegistration, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            //var data = ProjectDoc
            //var data = ProjectDocsServices.DocumentRegistration(Unit, DocumentClass, DocumentOwner, DocumentApprover, DocumentSubClass, DocumentDepartment, DocumentSubDepartment);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion Registration

        [HttpGet]
        public ActionResult InitiatorWiseCmp()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        
        [HttpGet]
        public ActionResult InterAllocationApproval()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult InterAllocationApprovalData(string Unit, string IntiatorId, string ApprovalStatus,string RejectedStatus)
         {
            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<InterAllocationApproval> InterAllocationApproval = new List<InterAllocationApproval>();
            InterAllocationApproval = ProjectDocsServices.InterAllocationApproval(Unit, IntiatorId, ApprovalStatus, RejectedStatus);
            int rowstotal = InterAllocationApproval.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                InterAllocationApproval = InterAllocationApproval.Where(x =>x.InterAlocationRegistrationId.ToString().Contains(searchvalue.ToLower()) || x.RegistrationNumber.ToLower().Contains(searchvalue.ToLower()) || x.RegistrationDate.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.Subject.ToLower().Contains(searchvalue.ToLower()) || x.IntiatorEmployeeName.ToLower().Contains(searchvalue.ToLower())|| x.ApprovalStatus.ToString().Contains(searchvalue.ToLower()) || x.ApprovedStatus.ToLower().Contains(searchvalue.ToLower()) || x.IntiatorId.ToString().Contains(searchvalue.ToLower()) || x.RejectedStatus.ToLower().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<InterAllocationApproval>();

            }
            int totalrowsafterfiltering = InterAllocationApproval.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            InterAllocationApproval = InterAllocationApproval.Skip(start).Take(length).ToList<InterAllocationApproval>();
            return Json(new { data = InterAllocationApproval, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult DocumentRegistrationApproval()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();

        }
        [HttpPost]

        public JsonResult DocumentRegistrationApprovalData(string Unit, string DocumentApprover, string ApprovalStatus)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DocumentRegistration> DocumentRegistrationApproval = new List<DocumentRegistration>();
            DocumentRegistrationApproval = ProjectDocsServices.DocumentRegistrationApprovalData(Unit, DocumentApprover, ApprovalStatus);
            int rowstotal = DocumentRegistrationApproval.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                DocumentRegistrationApproval = DocumentRegistrationApproval.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.DocumentApproverEmployeeName.ToString().Contains(searchvalue.ToLower()) || x.DocumentApproverId.ToString().Contains(searchvalue.ToLower())||x.DocumentRegistrationId.ToString().Contains(searchvalue.ToLower())|| x.Subject.ToLower().Contains(searchvalue.ToLower()) || x.DocumentType.ToString().Contains(searchvalue.ToLower()) || x.DocumentApproverEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.DocumentApproverDate.ToString().Contains(searchvalue.ToLower()) || x.ApprovalStatus.ToString().Contains(searchvalue.ToLower())).ToList<DocumentRegistration>();

            }
            int totalrowsafterfiltering = DocumentRegistrationApproval.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            DocumentRegistrationApproval = DocumentRegistrationApproval.Skip(start).Take(length).ToList<DocumentRegistration>();
            return Json(new { data = DocumentRegistrationApproval, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult CmpRegistration()
        {
            ViewBag.Alert = TempData["Alert"];
            //suresh_12102021
            return View();

        }
        [HttpGet]
        public ActionResult AddCmpRegistration(int id = 0)
        {
            //suresh_12102021
            if (id == 0)
                return View(new CmpRegistration());
            else
            {
                List<CmpRegistration> dateConfiguration = new List<CmpRegistration>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.CmpRegistration("", "", "", "");
                return View(dateConfiguration.Where(x => x.CmpRegistrationId == id).FirstOrDefault<CmpRegistration>());

            }
        }
        [HttpPost]
        public ActionResult AddCmpRegistration(CmpRegistration CmpRegistration)
        {
            var CmpRegistrationId = CmpRegistration.CmpRegistrationId;
            var RegistrationNumber = CmpRegistration.RegistrationNumber;
            var RegistrationDate = CmpRegistration.RegistrationDate;
            var UnitId = CmpRegistration.UnitId;
            var Subject = CmpRegistration.Subject;
            var Status = CmpRegistration.Status;
            var ProposedActivity = CmpRegistration.ProposedActivity;
            var ExpectedImprovement = CmpRegistration.ExpectedImprovement;
            var OtherImplications = CmpRegistration.OtherImplications;
            var IsDrawingAtached = CmpRegistration.IsDrawingAtached;
            var CostOfChange = CmpRegistration.CostOfChange;
            var IsEstimationAttached = CmpRegistration.IsEstimationAttached;
            var Roi = CmpRegistration.Roi;
            var IsRoiCalculationAttached = CmpRegistration.IsRoiCalculationAttached;
            var ProposalDrawnFrom = CmpRegistration.ProposalDrawnFrom;
            var IsTrainingRequired = CmpRegistration.IsTrainingRequired;
            var IntiatorId = CmpRegistration.IntiatorId;
            var Remarks = CmpRegistration.Remarks;
            var DrawingDocument = CmpRegistration.DrawingDocument;
            var RoiCalculationDocument = CmpRegistration.RoiCalculationDocument;
            var IsImplemented = CmpRegistration.IsImplemented;
            var DocumentType = CmpRegistration.DocumentType;
            var Preamble = CmpRegistration.Preamble;
            var ImpactQuantity = CmpRegistration.ImpactQuantity;
            var ImpactQuantityDetail = CmpRegistration.ImpactQuantityDetail;
            var IsImpactOnSafety = CmpRegistration.IsImpactOnSafety;
            var ImpactOnSafetyDetail = CmpRegistration.ImpactOnSafetyDetail;
            var IsImpactOnEnvironment = CmpRegistration.IsImpactOnEnvironment;
            var ImpactOnEnvironmentDetail = CmpRegistration.ImpactOnEnvironmentDetail;
            var IsImpactOnFoodSafety = CmpRegistration.IsImpactOnFoodSafety;
            var ImpactOnFoodSafetyDetail = CmpRegistration.ImpactOnFoodSafetyDetail;
            var IsLegalRequirement = CmpRegistration.IsLegalRequirement;
            var LegalRequirementDetail = CmpRegistration.LegalRequirementDetail;
            var TrainingDetail = CmpRegistration.TrainingDetail;
            var IsBudgetTaken = CmpRegistration.IsBudgetTaken;
            var BudgetDetail = CmpRegistration.BudgetDetail;
            var EstimationDocument = CmpRegistration.EstimationDocument;
            var DocumentDepartmentId = CmpRegistration.DocumentDepartmentId;
            var DocumentSubDepartmentId = CmpRegistration.DocumentSubDepartmentId;
            var IsSanctionRequired = CmpRegistration.IsSanctionRequired;
            var NatureOfExpenditure = CmpRegistration.NatureOfExpenditure;
            var BudgetProvisionAmount = CmpRegistration.BudgetProvisionAmount;
            var PresentProposalAmount = CmpRegistration.PresentProposalAmount;
            var BalanceSanctionAmount = CmpRegistration.BalanceSanctionAmount;
            var FuntionLocationInPlant = CmpRegistration.FuntionLocationInPlant;
            var SanctionDate = CmpRegistration.SanctionDate;
            var RoiDocumentType = CmpRegistration.RoiDocumentType;
            var EstimateDocumentType = CmpRegistration.EstimateDocumentType;

            DataTable data = ProjectDocsServices.InsertAddCmpRegistration(CmpRegistrationId, RegistrationNumber, RegistrationDate, UnitId, Subject, Status, ProposedActivity, ExpectedImprovement, OtherImplications, IsDrawingAtached, CostOfChange, IsEstimationAttached, Roi, IsRoiCalculationAttached, ProposalDrawnFrom, IsTrainingRequired, IntiatorId, Remarks, DrawingDocument, RoiCalculationDocument, IsImplemented, DocumentType, Preamble, ImpactQuantity, ImpactQuantityDetail, IsImpactOnSafety, ImpactOnSafetyDetail, IsImpactOnEnvironment, ImpactOnEnvironmentDetail, IsImpactOnFoodSafety, ImpactOnFoodSafetyDetail, IsLegalRequirement, LegalRequirementDetail, TrainingDetail, IsBudgetTaken, BudgetDetail, EstimationDocument, DocumentDepartmentId, DocumentSubDepartmentId, IsSanctionRequired, NatureOfExpenditure, BudgetProvisionAmount, PresentProposalAmount, BalanceSanctionAmount, FuntionLocationInPlant, SanctionDate, RoiDocumentType, EstimateDocumentType);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("CmpRegistration");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("CmpRegistration");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("CmpRegistration");
            }
        }
        public JsonResult CmpRegistrationData(string Unit, string Intiator, string DocumentDepartment, string DocumentSubDepartment)
        {

            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<CmpRegistration> CmpRegistration = new List<CmpRegistration>();
            CmpRegistration = ProjectDocsServices.CmpRegistration(Unit, Intiator, DocumentDepartment, DocumentSubDepartment);
            int rowstotal = CmpRegistration.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                CmpRegistration = CmpRegistration.Where(x => x.DocumentDepartmentDepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.DocumentDepartmentDepartmentName.ToString().Contains(searchvalue.ToLower()) || x.CmpRegistrationId.ToString().Contains(searchvalue.ToLower())).ToList<CmpRegistration>();

            }
            int totalrowsafterfiltering = CmpRegistration.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            CmpRegistration = CmpRegistration.Skip(start).Take(length).ToList<CmpRegistration>();
            return Json(new { data = CmpRegistration, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult InterAllocationRegistration()
        {
            ViewBag.Alert = TempData["Alert"];
            //suresh_12102021
            return View();
        }
        [HttpGet]
        public ActionResult AddInterAllocationRegistration(int id = 0)
        {
            TempData["InterAllocationRegistration"] = id;
            //suresh_12102021
            if (id == 0)
                return View(new InterAllocationRegistration());
            else
            {
                List<InterAllocationRegistration> dateConfiguration = new List<InterAllocationRegistration>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = ProjectDocsServices.InterAllocationRegistration("", "", "", "");
                return View(dateConfiguration.Where(x => x.InterAlocationRegistrationId == id).FirstOrDefault<InterAllocationRegistration>());

            }
        }
        [HttpPost]
        public ActionResult AddInterAllocationRegistration(InterAllocationRegistration InterAllocationRegistration)
        {
            //suresh_11102021
            var InterAlocationRegistrationId = InterAllocationRegistration.InterAlocationRegistrationId;
            var RegistrationNumber = InterAllocationRegistration.RegistrationNumber;
            var RegistrationDate = InterAllocationRegistration.RegistrationDate;
            var UnitId = InterAllocationRegistration.UnitId;
            var Subject = InterAllocationRegistration.Subject;
            var IntiatorId = InterAllocationRegistration.IntiatorId;
            var Remarks = InterAllocationRegistration.Remarks;
            var OldNumber = InterAllocationRegistration.OldNumber;
            var DocumentDepartmentId = InterAllocationRegistration.DocumentDepartmentId;
            var DocumentSubDepartmentId = InterAllocationRegistration.DocumentSubDepartmentId;
            DataTable data = ProjectDocsServices.InsertAddInterAllocationRegistration(InterAlocationRegistrationId, RegistrationNumber, RegistrationDate, UnitId, Subject, IntiatorId, Remarks, OldNumber, DocumentDepartmentId, DocumentSubDepartmentId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("InterAllocationRegistration");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("InterAllocationRegistration");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("InterAllocationRegistration");
            }
        }
        [HttpGet]
        public ActionResult AddInterAllocationRegistrationDetail(int id = 0)
        {
            ViewBag.AlloctionRegistrationId = TempData["InterAllocationRegistration"];
            //suresh_12102021
            if (id == 0)
                return View(new InterAllocationRegistrationDetail());
            else
            {
                List<InterAllocationRegistrationDetail> interAllocationRegistrationDetails = new List<InterAllocationRegistrationDetail>();
                //List<Centre> Centerlist = new List<Centre>();
                interAllocationRegistrationDetails = ProjectDocsServices.InterAllocationRegistrationDetail("");
                return View(interAllocationRegistrationDetails.Where(x => x.InterAllocationRegistrationDetailId == id).FirstOrDefault<InterAllocationRegistrationDetail>());

            }
        }
        [HttpPost]
        public ActionResult AddInterAllocationRegistrationDetail(InterAllocationRegistrationDetail InterAllocationRegistrationDetail)
        {
            var InterAllocationRegistrationDetailId = InterAllocationRegistrationDetail.InterAllocationRegistrationDetailId;
            var InterAlocationRegistrationId = InterAllocationRegistrationDetail.InterAlocationRegistrationId;
            var SerialNumber = InterAllocationRegistrationDetail.SerialNumber;
            var Flag = InterAllocationRegistrationDetail.Flag;
            var Equipment = InterAllocationRegistrationDetail.Equipment;
            var Activity = InterAllocationRegistrationDetail.Activity;
            var BudgetAmount = InterAllocationRegistrationDetail.BudgetAmount;
            var ActualAmount = InterAllocationRegistrationDetail.ActualAmount;
            var SavedAmount = InterAllocationRegistrationDetail.SavedAmount;
            var Reason = InterAllocationRegistrationDetail.Reason;
            DataTable data = ProjectDocsServices.InsertAddInterAllocationRegistrationDetail(InterAllocationRegistrationDetailId, InterAlocationRegistrationId, SerialNumber, Flag, Equipment, Activity, BudgetAmount, ActualAmount, SavedAmount, Reason);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("InterAllocationRegistration");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("InterAllocationRegistration");
                }
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("InterAllocationRegistration");
            }
        }
        [HttpPost]
        public JsonResult InterAllocationRegistrationData(string Unit, string Intiator, string DocumentDepartment, string DocumentSubDepartment)
        {
            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<InterAllocationRegistration> InterAllocationRegistration = new List<InterAllocationRegistration>();
            InterAllocationRegistration = ProjectDocsServices.InterAllocationRegistration(Unit, Intiator, DocumentDepartment, DocumentSubDepartment);
            int rowstotal = InterAllocationRegistration.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                InterAllocationRegistration = InterAllocationRegistration.Where(x => x.RegistrationNumber.ToLower().Contains(searchvalue.ToLower()) || x.RegistrationNumber.ToString().Contains(searchvalue.ToLower()) || x.InterAlocationRegistrationId.ToString().Contains(searchvalue.ToLower())).ToList<InterAllocationRegistration>();

            }
            int totalrowsafterfiltering = InterAllocationRegistration.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            InterAllocationRegistration = InterAllocationRegistration.Skip(start).Take(length).ToList<InterAllocationRegistration>();
            return Json(new { data = InterAllocationRegistration, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult InterAllocationRegistrationDetailData(string RegistraionId)
        {
            //suresh_11102021
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<InterAllocationRegistrationDetail> InterAllocationRegistrationDetail = new List<InterAllocationRegistrationDetail>();
            InterAllocationRegistrationDetail = ProjectDocsServices.InterAllocationRegistrationDetail(RegistraionId);
            int rowstotal = InterAllocationRegistrationDetail.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                InterAllocationRegistrationDetail = InterAllocationRegistrationDetail.Where(x => x.Reason.ToLower().Contains(searchvalue.ToLower()) || x.SerialNumber.ToString().Contains(searchvalue.ToLower()) || x.InterAlocationRegistrationId.ToString().Contains(searchvalue.ToLower())).ToList<InterAllocationRegistrationDetail>();

            }
            int totalrowsafterfiltering = InterAllocationRegistrationDetail.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            InterAllocationRegistrationDetail = InterAllocationRegistrationDetail.Skip(start).Take(length).ToList<InterAllocationRegistrationDetail>();
            return Json(new { data = InterAllocationRegistrationDetail, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddDocumentRegistrationApproval(int id = 0)
        {
            if (id == 0)
                return View(new DocumentRegistrationApproval());
            else
            {
                List<DocumentRegistration> approvals = new List<DocumentRegistration>();
                //List<Centre> Centerlist = new List<Centre>();
                approvals = ProjectDocsServices.DocumentRegistrationApprovalData("", "", "");
                return View(approvals.Where(x => x.DocumentRegistrationId == id).FirstOrDefault<DocumentRegistration>());

            }

        }

    }
}