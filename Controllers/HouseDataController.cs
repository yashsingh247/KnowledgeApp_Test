using KnowledgeApp_Test.Models.HouseData;
using KnowledgeApp_Test.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static KnowledgeApp_Test.Models.Common_Model.Alert;
using static KnowledgeApp_Test.Models.HouseData.ChemicalConsumption;

namespace KnowledgeApp_Test.Controllers
{

    public class HouseDataController : Controller
    {
        HouseDataServices House = new HouseDataServices();
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        // GET: HouseData
        #region ClarificationType
        [HttpGet]
        public ActionResult ClarificationType()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditClarificationType(int id = 0)
        {
            if (id == 0)
                return View(new ClarificationType());
            else
            {
                List<ClarificationType> specialAnalysis = new List<ClarificationType>();
                //List<Centre> Centerlist = new List<Centre>();
                specialAnalysis = House.ClarificationType();
                return View(specialAnalysis.Where(x => x.ClarificationTypeId == id).FirstOrDefault<ClarificationType>());

            }

        }
        [HttpPost]
        public ActionResult AddeditClarificationType(ClarificationType clarificationType)
        {
            var Id = clarificationType.ClarificationTypeId;
            var ClarificationTypeCode = clarificationType.ClarificationTypeCode;
            var ClarificationName = clarificationType.ClarificationName;
            var ClarificationNature = clarificationType.ClarificationNature;
            DataTable data = House.InsertCLARIFICATIONType(Id, ClarificationTypeCode, ClarificationName, ClarificationNature);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ClarificationType");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ClarificationType");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("ClarificationType");

            }
        }
        [HttpPost]
        public JsonResult ClarificationTypeData()
        {
            // var data = House.ClarificationType();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ClarificationType> clarification = new List<ClarificationType>();
            clarification = House.ClarificationType();
            int rowstotal = clarification.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                clarification = clarification.Where(x => x.ClarificationTypeId.ToString().Contains(searchvalue.ToLower()) || x.ClarificationTypeCode.ToString().Contains(searchvalue.ToLower()) || x.ClarificationName.ToLower().Contains(searchvalue.ToLower()) || x.ClarificationNature.ToString().Contains(searchvalue.ToLower())).ToList<ClarificationType>();
            }
            int totalrowsafterfiltering = clarification.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            clarification = clarification.Skip(start).Take(length).ToList<ClarificationType>();
            return Json(new { data = clarification, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion ClarificationType
        #region Clarification
        [HttpGet]
        public ActionResult Clarification()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditClarification(int id = 0)
        {
            if (id == 0)
                return View(new Clarification());
            else
            {
                List<Clarification> Clarification = new List<Clarification>();
                //List<Centre> Centerlist = new List<Centre>();
                Clarification = House.Clarification("");
                return View(Clarification.Where(x => x.ClarificationId == id).FirstOrDefault<Clarification>());

            }
        }
        [HttpPost]
        public ActionResult AddeditClarification(Clarification clarification)
        {
            var Id = clarification.ClarificationId;
            var ClarificationTypeId = clarification.ClarificationTypeId;
            var ClarificationCode = clarification.ClarificationCode;
            var ClarificationName = clarification.ClarificationName;
            DataTable data = House.InsertCLARIFICATIONNew(Id, ClarificationTypeId, ClarificationCode, ClarificationName);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("Clarification");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("Clarification");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("Clarification");

            }
        }
        [HttpPost]
        public JsonResult ClarificationData(string Clarification)
        {

            //var data = House.Clarification(Clarification);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Clarification> clarification = new List<Clarification>();
            clarification = House.Clarification(Clarification);
            int rowstotal = clarification.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                clarification = clarification.Where(x => x.ClarificationTypeId.ToString().Contains(searchvalue.ToLower()) || x.ClarificationCode.ToString().Contains(searchvalue.ToLower()) || x.ClarificationName.ToLower().Contains(searchvalue.ToLower()) || x.ClarificationTypeName.ToLower().Contains(searchvalue.ToLower()) || x.ClarificationId.ToString().Contains(searchvalue.ToLower())).ToList<Clarification>();
            }
            int totalrowsafterfiltering = clarification.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            clarification = clarification.Skip(start).Take(length).ToList<Clarification>();
            return Json(new { data = clarification, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion Clarification
        #region ClarificationHouse
        [HttpGet]
        public ActionResult ClarificationHouse()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }

        [HttpGet]
        public ActionResult AddeditClarificationHouse(int id = 0)
        {
            TempData["ClarificationHouse"] = id;

            if (id == 0)
                return View(new ClarificationHouse());
            else
            {
                List<ClarificationHouse> ClarificationHouse = new List<ClarificationHouse>();
                //List<Centre> Centerlist = new List<Centre>();
                ClarificationHouse = House.ClarificationHouse("", "", "", "");
                return View(ClarificationHouse.Where(x => x.ClarificationHouseId == id).FirstOrDefault<ClarificationHouse>());

            }

        }
        [HttpPost]
        public ActionResult AddeditClarificationHouse(ClarificationHouse clarificationhouse)
        {
            var Id = clarificationhouse.ClarificationHouseId;
            var TransactionDate = clarificationhouse.TransactionDate;
            var ShiftID = clarificationhouse.ShiftId;
            var ProcessHeadID = clarificationhouse.ProcessHeadId;
            var IsChemist = clarificationhouse.IsChemist;
            var SectionHeadID = clarificationhouse.SectionHeadId;
            var DepartmentHeadID = clarificationhouse.DepartmentHeadId;
            
            DataTable data = House.InsertClarificationHouseNew(Id, TransactionDate, ShiftID, ProcessHeadID, IsChemist, SectionHeadID, DepartmentHeadID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ClarificationHouse");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ClarificationHouse");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("ClarificationHouse");

            }
        }
        [HttpPost]
        public JsonResult ClarificationHouseData(string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {
            //var data = House.ClarificationHouse(Shift, ProcessHead, SectionHead, DepartmentHead);
            int start = Convert.ToInt32(Request["start"]); 
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ClarificationHouse> clarificationhouse = new List<ClarificationHouse>();
            clarificationhouse = House.ClarificationHouse(Shift, ProcessHead, SectionHead, DepartmentHead);
            int rowstotal = clarificationhouse.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                clarificationhouse = clarificationhouse.Where(x => x.TransactionDate.ToString().Contains(searchvalue.ToLower()) || x.ShiftShiftName.ToLower().Contains(searchvalue.ToLower()) || x.ProcessHeadEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.IsChemist.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.ClarificationHouseId.ToString().Contains(searchvalue.ToLower()) || x.ProcessHeadId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower())).ToList<ClarificationHouse>();
            }
            int totalrowsafterfiltering = clarificationhouse.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            clarificationhouse = clarificationhouse.Skip(start).Take(length).ToList<ClarificationHouse>();
            return Json(new { data = clarificationhouse, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
       
        //[HttpPost]
        // public ActionResult ClarificationHouseDetail()
        // {
        //     return View();
        // }
        [HttpGet]
        public ActionResult AddeditClarificationHouseDetail(int id = 0)
        {
            ViewBag.ClarificationHouse= TempData["ClarificationHouse"];
            if (id == 0)
                return View(new ClarificationHouseDetail());
            else
            {
                List<ClarificationHouseDetail> ClarificationHouseDetail = new List<ClarificationHouseDetail>();
                ClarificationHouseDetail = House.ClarificationHouseDetail("","");
                return View(ClarificationHouseDetail.Where(x => x.ClarificationHouseDetailID == id).FirstOrDefault<ClarificationHouseDetail>());
            }

         }
        [HttpPost]
        public ActionResult AddeditClarificationHouseDetail(ClarificationHouseDetail clarificationhousedetail)
        {
            var Id = clarificationhousedetail.ClarificationHouseDetailID;
            var ClarificationHouseID = clarificationhousedetail.ClarificationHouseId;
            var SerialNumber = clarificationhousedetail.SerialNo;
            var ClarificationID = clarificationhousedetail.ClarificationID;
            var ClarificationValue = clarificationhousedetail.ClarificationValue;
            
            DataTable data = House.InsertClarificationHouseDetailNew(Id, ClarificationHouseID, SerialNumber, ClarificationID, ClarificationValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ClarificationHouse");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ClarificationHouse");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("ClarificationHouse");

            }
        }
        [HttpPost]
        public JsonResult ClarificationHouseDetailData(string Clrification, string HouseId)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ClarificationHouseDetail> clarificationhousedetail = new List<ClarificationHouseDetail>();
            clarificationhousedetail = House.ClarificationHouseDetail(Clrification, HouseId);
            int rowstotal = clarificationhousedetail.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                clarificationhousedetail = clarificationhousedetail.Where(x => x.ClarificationHouseDetailID.ToString().Contains(searchvalue.ToLower()) || x.SerialNo.ToString().Contains(searchvalue.ToLower()) || x.ClarificationHouseId.ToString().Contains(searchvalue.ToLower()) || x.ClarificationValue.ToString().Contains(searchvalue.ToLower())||x.ClarificationName.ToLower().Contains(searchvalue.ToString())).ToList<ClarificationHouseDetail>();
            }
            int totalrowsafterfiltering = clarificationhousedetail.Count;
            clarificationhousedetail = clarificationhousedetail.Skip(start).Take(length).ToList<ClarificationHouseDetail>();
            return Json(new { data = clarificationhousedetail, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion ClarificationHouse
        #region MassecuiteConditioning
        [HttpGet]
        public ActionResult MassecuiteConditioning()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditMassecuiteConditioning(int id = 0)
        {
            if (id == 0)
                return View(new MassecuiteConditioning());
            else
            {
                List<MassecuiteConditioning> MassecuiteConditioning = new List<MassecuiteConditioning>();
                //List<Centre> Centerlist = new List<Centre>();
                MassecuiteConditioning = House.MassecuiteConditioning();
                return View(MassecuiteConditioning.Where(x => x.MassecuiteConditioningId == id).FirstOrDefault<MassecuiteConditioning>());

            }

        }
        [HttpPost]
        public ActionResult AddeditMassecuiteConditioning(MassecuiteConditioning massecuiteconditioning)
        {
            var Id = massecuiteconditioning.MassecuiteConditioningId;
            var Code = massecuiteconditioning.MassecuiteConditioningCode;
            var Name = massecuiteconditioning.MassecuiteConditioningName;
            DataTable data = House.InsertMASSECUITECONDITIONINGNew(Id, Code, Name);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("MassecuiteConditioning");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("MassecuiteConditioning");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("MassecuiteConditioning");

            }
        }
        [HttpPost]
        public JsonResult MassecuiteData()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MassecuiteConditioning> massecuiteconditioning = new List<MassecuiteConditioning>();
            massecuiteconditioning = House.MassecuiteConditioning();
            int rowstotal = massecuiteconditioning.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                massecuiteconditioning = massecuiteconditioning.Where(x => x.MassecuiteConditioningId.ToString().Contains(searchvalue.ToLower()) || x.MassecuiteConditioningCode.ToString().Contains(searchvalue.ToLower()) || x.MassecuiteConditioningName.ToLower().Contains(searchvalue.ToLower())).ToList<MassecuiteConditioning>();
            }
            int totalrowsafterfiltering = massecuiteconditioning.Count;

            massecuiteconditioning = massecuiteconditioning.Skip(start).Take(length).ToList<MassecuiteConditioning>();
            return Json(new { data = massecuiteconditioning, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion MassecuiteConditioning
        #region MassecuiteConditioningData
        [HttpGet]
        public ActionResult MassecuiteConditioningData()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditMassecuiteConditioningData(int id = 0)
        {
            TempData["MassecuiteConditioningData"] = id;
            if (id == 0)
                return View(new MassecuiteConditioningData());
            else
            {
                List<MassecuiteConditioningData> MassecuiteConditioningData = new List<MassecuiteConditioningData>();
                //List<Centre> Centerlist = new List<Centre>();
                MassecuiteConditioningData = House.MassecuiteConditioningData("", "", "", "");
                return View(MassecuiteConditioningData.Where(x => x.MassecuiteConditioningDataId == id).FirstOrDefault<MassecuiteConditioningData>());
            }


        }

        [HttpPost]
        public ActionResult AddeditMassecuiteConditioningData(MassecuiteConditioningData massecuiteconditioningdata)
        {
            var Id = massecuiteconditioningdata.MassecuiteConditioningDataId;
            var AnalysisDate = massecuiteconditioningdata.AnalysisDate;
            var ShiftID = massecuiteconditioningdata.ShiftId;
            var ProcessHeadID = massecuiteconditioningdata.ProcessHeadId;
            var SectionHeadID = massecuiteconditioningdata.SectionHeadId;
            var DepartmentHeadID = massecuiteconditioningdata.DepartmentHeadId;
            DataTable data = House.InsertMASSECUITECONDITIONINGDataNew(Id,AnalysisDate,ShiftID,ProcessHeadID,SectionHeadID,DepartmentHeadID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("MassecuiteConditioningData");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("MassecuiteConditioningData");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("MassecuiteConditioningData");

            }
        }

        [HttpPost]
        public JsonResult MassecuiteConditioningDataData(string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MassecuiteConditioningData> massecuiteconditioningdata = new List<MassecuiteConditioningData>();
            massecuiteconditioningdata = House.MassecuiteConditioningData(Shift, ProcessHead, SectionHead, DepartmentHead);
            int rowstotal = massecuiteconditioningdata.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                massecuiteconditioningdata = massecuiteconditioningdata.Where(x => x.MassecuiteConditioningDataId.ToString().Contains(searchvalue.ToLower()) || x.ShiftShiftName.ToLower().Contains(searchvalue.ToLower()) || x.ProcessHeadEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadEmployeeName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.AnalysisDate.ToString().Contains(searchvalue.ToLower()) || x.ProcessHeadId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower())).ToList<MassecuiteConditioningData>();
            }
            int totalrowsafterfiltering = massecuiteconditioningdata.Count;
            massecuiteconditioningdata = massecuiteconditioningdata.Skip(start).Take(length).ToList<MassecuiteConditioningData>();
            return Json(new { data = massecuiteconditioningdata, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]

        public ActionResult MassecuiteConditioningDataDetails()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditMassecuiteConditioningDataDetails(int id = 0)
        {
            ViewBag.MassecuiteConditioningData = TempData["MassecuiteConditioningData"];
            if (id == 0)
                return View(new MassecuiteConditioningDataDetails());
            else
            {
                List<MassecuiteConditioningDataDetails> MassecuiteConditioningDataDetails = new List<MassecuiteConditioningDataDetails>();
                MassecuiteConditioningDataDetails = House.MassecuiteConditioningDataDetails("","");
                return View(MassecuiteConditioningDataDetails.Where(x => x.MassecuiteConditioningDataDetailsId == id).FirstOrDefault<MassecuiteConditioningDataDetails>());
            }

         }
        [HttpPost]
        public ActionResult AddeditMassecuiteConditioningDetailsData(MassecuiteConditioningDataDetails massecuiteconditioningdatadetails)
        {
            var Id = massecuiteconditioningdatadetails.MassecuiteConditioningDataDetailsId;
            var MassecuiteConditioningDataID = massecuiteconditioningdatadetails.MassecuiteConditioningDataId;
            var SerialNumber = massecuiteconditioningdatadetails.SerialNo;
            var MassecuiteConditioningID = massecuiteconditioningdatadetails.MassecuiteConditioningID;
            var AnalysisValue = massecuiteconditioningdatadetails.AnalysisValue;
            DataTable data = House.InsertMASSECUITECONDITIONINGDETAILDATANew(Id, MassecuiteConditioningDataID, SerialNumber, MassecuiteConditioningID, AnalysisValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("MassecuiteConditioningData");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("MassecuiteConditioningData");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("MassecuiteConditioningData");

            }
        }
        [HttpPost]

        public JsonResult MassecuiteConditioningDetailsDataData(string conditinung ,string DataId)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MassecuiteConditioningDataDetails> massecuiteconditioningdatadetails = new List<MassecuiteConditioningDataDetails>();
            massecuiteconditioningdatadetails = House.MassecuiteConditioningDataDetails(conditinung, DataId);
            int rowstotal = massecuiteconditioningdatadetails.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                massecuiteconditioningdatadetails = massecuiteconditioningdatadetails.Where(x => x.MassecuiteConditioningDataDetailsId.ToString().Contains(searchvalue.ToLower()) || x.MassecuiteConditioningDataId.ToString().Contains(searchvalue.ToLower()) || x.SerialNo.ToString().Contains(searchvalue.ToLower()) || x.AnalysisValue.ToString().Contains(searchvalue.ToLower())).ToList<MassecuiteConditioningDataDetails>();
            }
            int totalrowsafterfiltering = massecuiteconditioningdatadetails.Count;

            massecuiteconditioningdatadetails = massecuiteconditioningdatadetails.Skip(start).Take(length).ToList<MassecuiteConditioningDataDetails>();
            return Json(new { data = massecuiteconditioningdatadetails, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion MassecuiteConditioningData
        #region MassecuiteStock
        [HttpGet]
        public ActionResult MassecuiteStock()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditMassecuiteStock(int id = 0)
        {
            if (id == 0)
                return View(new MassecuiteStock());
            else
            {
                List<MassecuiteStock> MassecuiteStock = new List<MassecuiteStock>();
                //List<Centre> Centerlist = new List<Centre>();
                MassecuiteStock = House.MassecuiteStock("", "", "", "", "", "", "");
                return View(MassecuiteStock.Where(x => x.MassecuiteStockId == id).FirstOrDefault<MassecuiteStock>());
            }

        }
        [HttpPost]
        public ActionResult AddeditMassecuiteStock(MassecuiteStock massecuitestock)
        {
            var Id = massecuitestock.MassecuiteStockId;
            var AnalysisDate = massecuitestock.AnalysisDate;
            var ShiftID = massecuitestock.ShiftId;
            var SHIFT_RCV_A = massecuitestock.ShiftRcvA;
            var DROPP_A = massecuitestock.DroppA;
            var CURED_A = massecuitestock.CuredA;
            var BAL_A = massecuitestock.BalA;
            var SHIFT_RCV_A1 = massecuitestock.ShiftRcvA1;
            var DROPP_A1 = massecuitestock.DroppA1;
            var CURED_A1 = massecuitestock.CuredA1;
            var BAL_A1 = massecuitestock.BalA1;
            var SHIFT_RCV_B = massecuitestock.ShiftRcvB;
            var DROPP_B = massecuitestock.DroppB;
            var CURED_B = massecuitestock.CuredB;
            var BAL_B = massecuitestock.BalB;
            var SHIFT_RCV_C1 = massecuitestock.ShiftRcvC1;
            var DROPP_C1 = massecuitestock.DroppC1;
            var CURED_C1 = massecuitestock.CuredC1;
            var BAL_C1 = massecuitestock.BalC1;
            var SHIFT_RCV_C = massecuitestock.ShiftRcvC;
            var DROPP_C = massecuitestock.DroppC;
            var CURED_C = massecuitestock.CuredC;
            var BAL_C = massecuitestock.BalC;
            var ProcessHeadID = massecuitestock.ProcessHeadId;
            var SectionHeadID = massecuitestock.SectionHeadId;
            var DepartmentHeadID = massecuitestock.DepartmentHeadId;
            var UnitID = massecuitestock.UnitId;
            DataTable data = House.InsertMASSECUITESTOCK(Id,AnalysisDate,ShiftID,SHIFT_RCV_A,DROPP_A,CURED_A,BAL_A,SHIFT_RCV_A1,DROPP_A1,CURED_A1,BAL_A1,SHIFT_RCV_B,DROPP_B,CURED_B,BAL_B,SHIFT_RCV_C1,DROPP_C1,CURED_C1,BAL_C1,SHIFT_RCV_C,DROPP_C,CURED_C,BAL_C,ProcessHeadID,SectionHeadID,DepartmentHeadID,UnitID);
           String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("MassecuiteStock");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("MassecuiteStock");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("MassecuiteStock");

            }
        }
        [HttpPost]
        public JsonResult MassecuiteStockData(string Unit, string Shift, string AnalysisDate2, string AnalysisDate3, string ProcessHeadId, string SectionHeadId, string DepartmentHeadId)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MassecuiteStock> massecuitestock = new List<MassecuiteStock>();
            massecuitestock = House.MassecuiteStock(Unit, Shift, AnalysisDate2, AnalysisDate3, ProcessHeadId, SectionHeadId, DepartmentHeadId);
            int rowstotal = massecuitestock.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                massecuitestock = massecuitestock.Where(x => x.MassecuiteStockId.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.AnalysisDate.ToString().Contains(searchvalue.ToLower()) || x.ShiftRcvA.ToString().Contains(searchvalue.ToLower()) || x.DroppA.ToString().Contains(searchvalue.ToLower()) || x.CuredA.ToString().Contains(searchvalue.ToLower()) || x.BalA.ToString().Contains(searchvalue.ToLower()) || x.ShiftRcvA1.ToString().Contains(searchvalue.ToLower()) || x.DroppA1.ToString().Contains(searchvalue.ToLower()) || x.CuredA1.ToString().Contains(searchvalue.ToLower()) || x.BalA1.ToString().Contains(searchvalue.ToLower()) || x.ShiftRcvB.ToString().Contains(searchvalue.ToLower()) || x.DroppB.ToString().Contains(searchvalue.ToLower()) || x.CuredB.ToString().Contains(searchvalue.ToLower()) || x.BalB.ToString().Contains(searchvalue.ToLower()) || x.ShiftRcvC1.ToString().Contains(searchvalue.ToLower()) || x.DroppC1.ToString().Contains(searchvalue.ToLower()) || x.CuredC1.ToString().Contains(searchvalue.ToLower()) || x.BalC1.ToString().Contains(searchvalue.ToLower()) || x.ShiftRcvC.ToString().Contains(searchvalue.ToLower()) || x.DroppC.ToString().Contains(searchvalue.ToLower()) || x.CuredC.ToString().Contains(searchvalue.ToLower()) || x.BalC.ToString().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.ProcessHeadId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<MassecuiteStock>();
            }
            int totalrowsafterfiltering = massecuitestock.Count;
            massecuitestock = massecuitestock.Skip(start).Take(length).ToList<MassecuiteStock>();
            return Json(new { data = massecuitestock, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion MassecuiteStock
        #region Chemical
        [HttpGet]

        public ActionResult Chemical()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }

        [HttpGet]
        public ActionResult AddeditChemical(int id = 0)
        {
            if (id == 0)
                return View(new Chemical());
            else
            {
                List<Chemical> Chemical = new List<Chemical>();
                //List<Centre> Centerlist = new List<Centre>();
                Chemical = House.Chemical();
                return View(Chemical.Where(x => x.ChemicalId == id).FirstOrDefault<Chemical>());

            }

        }
        [HttpPost]
        public ActionResult AddeditChemical(Chemical chemical)
        {
            var Id = chemical.ChemicalId;
            var Code = chemical.ChemicalCode;
            var Name = chemical.ChemicalName;
            DataTable data = House.InsertCHEMICALNew(Id, Code, Name);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Chemical");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Chemical");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("Chemical");

            }
        }
        [HttpPost]
        public JsonResult ChemicalData()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Chemical> chemical = new List<Chemical>();
            chemical = House.Chemical();
            int rowstotal = chemical.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                chemical = chemical.Where(x => x.ChemicalId.ToString().Contains(searchvalue.ToLower()) || x.ChemicalCode.ToString().Contains(searchvalue.ToLower()) || x.ChemicalName.ToLower().Contains(searchvalue.ToLower())).ToList<Chemical>();
            }
            int totalrowsafterfiltering = chemical.Count;

            chemical = chemical.Skip(start).Take(length).ToList<Chemical>();
            return Json(new { data = chemical, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion Chemical
        #region ChemicalConsumption
        [HttpGet]
        public ActionResult ChemicalConsumption()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }

        [HttpGet]
        public ActionResult AddeditChemicalConsumption(int id = 0)
        {
            TempData["CunsumstionId"] = id;
            if (id == 0)
                return View(new ChemicalConsumption());
            else
            {
                List<ChemicalConsumption> ChemicalConsumption = new List<ChemicalConsumption>();
                ChemicalConsumption = House.ChemicalConsumption("", "", "", "", "");
                return View(ChemicalConsumption.Where(x => x.ChemicalConsumptionId == id).FirstOrDefault<ChemicalConsumption>());
            }
        }

        [HttpPost]
        public ActionResult AddeditChemicalConsumption(ChemicalConsumption chemicalconsumption)
        {
            var Id = chemicalconsumption.ChemicalConsumptionId;
            var ConsumptionDate = chemicalconsumption.ConsumptionDate;
            var ShiftID = chemicalconsumption.ShiftId;
            var ProcessHeadID = chemicalconsumption.ProcessHeadId;
            var SectionHeadID = chemicalconsumption.SectionHeadId;
            var DepartmentHeadID = chemicalconsumption.DepartmentHeadId;
            var UnitID = chemicalconsumption.UnitId;
            DataTable data = House.InsertCHEMICALCONSUMPTIONNew(Id, ConsumptionDate, ShiftID, ProcessHeadID, SectionHeadID, DepartmentHeadID, UnitID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ChemicalConsumption");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ChemicalConsumption");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("ChemicalConsumption");

            }
        }

        [HttpPost]
        public JsonResult ChemicalConsumptionData(string Unit, string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ChemicalConsumption> chemicalconsumption = new List<ChemicalConsumption>();
            chemicalconsumption = House.ChemicalConsumption(Unit,Shift, ProcessHead, SectionHead, DepartmentHead);
            int rowstotal = chemicalconsumption.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                chemicalconsumption = chemicalconsumption.Where(x => x.ChemicalConsumptionId.ToString().Contains(searchvalue.ToLower()) || x.ConsumptionDate.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.ShiftShiftName.ToLower().Contains(searchvalue.ToLower()) || x.ProcessHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower()) || x.ChemicalConsumptionId.ToString().Contains(searchvalue.ToLower())).ToList<ChemicalConsumption>();
            }
            int totalrowsafterfiltering = chemicalconsumption.Count;
            chemicalconsumption = chemicalconsumption.Skip(start).Take(length).ToList<ChemicalConsumption>();
            return Json(new { data = chemicalconsumption, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddeditChemicalConsumptionDetails(int id = 0)
        {
            ViewBag.CunsumstionId = TempData["CunsumstionId"];
            if (id == 0)
                return View(new ChemicalConsumptionDetails());
            else
            {
                List<ChemicalConsumptionDetails> ChemicalConsumptionDetails = new List<ChemicalConsumptionDetails>();
                ChemicalConsumptionDetails = House.ChemicalConsumptionDetails("","");
                return View(ChemicalConsumptionDetails.Where(x => x.ChemicalConsumptionDetailID == id).FirstOrDefault<ChemicalConsumptionDetails>());
            }

        }
        [HttpPost]
        public ActionResult AddeditChemicalConsumptionDetails(ChemicalConsumptionDetails ChemicalConsumptiondetails)
        {
            var Id = ChemicalConsumptiondetails.ChemicalConsumptionDetailID;
            var ChemicalConsumptionID = ChemicalConsumptiondetails.ChemicalConsumptionID;
            var SerialNumber = ChemicalConsumptiondetails.SerialNumber;
            var ChemicalID = ChemicalConsumptiondetails.ChemicalID;
            var IssuedQuantity = ChemicalConsumptiondetails.IssuedQuantity;
            var ConsumedQuantity = ChemicalConsumptiondetails.ConsumedQuantity;
            DataTable data = House.InsertCHEMICALCONSUMPTIONDetailNew(Id, ChemicalConsumptionID, SerialNumber, ChemicalID, IssuedQuantity, ConsumedQuantity);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ChemicalConsumption");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ChemicalConsumption");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                 return RedirectToAction("ChemicalConsumption");

            }
        }
        [HttpPost]

        public JsonResult ChemicalConsumptionDetailsData(string Chemical,string CunsumptionId)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ChemicalConsumptionDetails> chemicalconsumptiondetails = new List<ChemicalConsumptionDetails>();
            chemicalconsumptiondetails = House.ChemicalConsumptionDetails(Chemical,CunsumptionId);
            int rowstotal = chemicalconsumptiondetails.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                chemicalconsumptiondetails = chemicalconsumptiondetails.Where(x => x.ChemicalConsumptionDetailID.ToString().Contains(searchvalue.ToLower()) || x.ChemicalConsumptionID.ToString().Contains(searchvalue.ToLower()) || x.SerialNumber.ToString().Contains(searchvalue.ToLower()) || x.ChemicalID.ToString().Contains(searchvalue.ToLower()) || x.IssuedQuantity.ToString().Contains(searchvalue.ToLower()) || x.ConsumedQuantity.ToString().Contains(searchvalue.ToLower()) || x.ChemicalName.ToLower().Contains(searchvalue.ToLower())).ToList<ChemicalConsumptionDetails>();
            }
            int totalrowsafterfiltering = chemicalconsumptiondetails.Count;
            chemicalconsumptiondetails = chemicalconsumptiondetails.Skip(start).Take(length).ToList<ChemicalConsumptionDetails>();
            return Json(new { data = chemicalconsumptiondetails, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion ChemicalConsumption



    }
}