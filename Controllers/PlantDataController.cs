using KnowledgeApp_Test.Models.PlantData;
using KnowledgeApp_Test.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{
    public class PlantDataController : Controller
    {
        PlantDataServices PlantData = new PlantDataServices();
        // GET: PlantData
        #region MillParameter
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        [HttpGet]
        public ActionResult MillParameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditMillParameter(int id = 0)
        {
            if (id == 0)
                return View(new MillParameter());
            else
            {
                List<MillParameter> millParameter = new List<MillParameter>();
                //List<Centre> Centerlist = new List<Centre>();
                millParameter = PlantData.MillParameter();
                return View(millParameter.Where(x => x.MillParameterId == id).FirstOrDefault<MillParameter>());
            }
        }
        [HttpPost]
        public ActionResult AddeditMillParameter(MillParameter millParameter)
        {
            var Id = millParameter.MillParameterId;
            var Code = millParameter.MillParameterCode;
            var Name = millParameter.MillParameterName;
            var Flag = millParameter.Flag;
            var IsApplicableForWIL = millParameter.IsApplicableForWil;
            var IsTwoHourly = millParameter.IsTwoHourly;
            var ShortName = millParameter.ShortName;
            DataTable data = PlantData.InsertMillParameter(Id, Code, Name, Flag, IsApplicableForWIL, IsTwoHourly, ShortName);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("MillParameter");
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("MillParameter");
            }

        }
        [HttpPost]
        public JsonResult MillParameterData()
        {
            // var data = PlantData.MillParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MillParameter> millParameter = new List<MillParameter>();
            millParameter = PlantData.MillParameter();
            int rowstotal = millParameter.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                millParameter = millParameter.Where(x => x.MillParameterName.ToLower().Contains(searchvalue.ToLower()) || x.MillParameterCode.ToString().Contains(searchvalue.ToLower()) || x.MillParameterId.ToString().Contains(searchvalue.ToLower()) || x.ShortName.ToLower().Contains(searchvalue.ToLower())).ToList<MillParameter>();

            }
            int totalrowsafterfiltering = millParameter.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            millParameter = millParameter.Skip(start).Take(length).ToList<MillParameter>();
            return Json(new { data = millParameter, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion MillParameter
        #region Mill
        public ActionResult Mill()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult MillData()
        {
            //var data = PlantData.Mill();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Mill> mill = new List<Mill>();
            mill = PlantData.Mill();
            int rowstotal = mill.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                mill = mill.Where(x => x.MillName.ToLower().Contains(searchvalue.ToLower()) || x.MillCode.ToString().Contains(searchvalue.ToLower()) || x.MillId.ToString().Contains(searchvalue.ToLower()) || x.MillTypeName.ToLower().Contains(searchvalue.ToLower())).ToList<Mill>();

            }
            int totalrowsafterfiltering = mill.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            mill = mill.Skip(start).Take(length).ToList<Mill>();
            return Json(new { data = mill, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditMill(int id = 0)
        {
            if (id == 0)
                return View(new Mill());
            else
            {
                List<Mill> mill = new List<Mill>();
                //List<Centre> Centerlist = new List<Centre>();
                mill = PlantData.Mill();
                return View(mill.Where(x => x.MillId == id).FirstOrDefault<Mill>());
            }
        }
        [HttpPost]
        public ActionResult AddeditMill(Mill mill)
        {
            var Id = mill.MillId;
            var Code = mill.MillCode;
            var Name = mill.MillName;
            var Type = mill.MillType;
            DataTable data = PlantData.InsertMill(Id, Code, Name, Type);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("Mill");
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("Mill");
            }

        }
        #endregion
        #region MillLog
        [HttpGet]
        public ActionResult MillLog()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult MillLogData(string Unit)
        {
            //var data = PlantData.MillLog(Unit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MillLog> millLog = new List<MillLog>();
            millLog = PlantData.MillLog(Unit);
            int rowstotal = millLog.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                millLog = millLog.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.DocumentNumber.ToString().Contains(searchvalue.ToLower()) || x.LogDate.ToString().Contains(searchvalue.ToLower()) || x.LogHour.ToString().Contains(searchvalue.ToLower()) || x.EntryType.ToString().Contains(searchvalue.ToLower()) || x.MillLogId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<MillLog>();

            }
            int totalrowsafterfiltering = millLog.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            millLog = millLog.Skip(start).Take(length).ToList<MillLog>();
            return Json(new { data = millLog, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditMilllog(int id = 0)
        {
            TempData["Milllog"] = id;
            if (id == 0)
                return View(new MillLog());
            else
            {
                List<MillLog> millLog = new List<MillLog>();
                //List<Centre> Centerlist = new List<Centre>();
                millLog = PlantData.MillLog("");
                return View(millLog.Where(x => x.MillLogId == id).FirstOrDefault<MillLog>());
            }
        }
        [HttpPost]
        public ActionResult AddeditMilllog(MillLog millLog)
        {
            var Id = millLog.MillId;
            var Unit = millLog.UnitId;
            var DocNo = millLog.DocumentNumber;
            var LogDate = millLog.LogDate;
            var LogHour = millLog.LogHour;
            var EntryType = millLog.EntryType;
            var Type = millLog.MillType;
            DataTable data = PlantData.InsertMillLog(Id, Unit, DocNo, LogDate, LogHour,Type, EntryType);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("MillLog");
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("MillLog");
            }

        }
        [HttpGet]
        public ActionResult AddeditMilllogDetails(int id = 0)
        {
            ViewBag.Milllogid = TempData["Milllog"];
            if (id == 0)
                return View(new MillLogDetails());
            else
            {
                List<MillLogDetails> millLogDetails = new List<MillLogDetails>();
                //List<Centre> Centerlist = new List<Centre>();
                millLogDetails = PlantData.MillLogDetails("", "", "", id.ToString());
                return View(millLogDetails.Where(x => x.MillLogDetailID == id).FirstOrDefault<MillLogDetails>());
            }

        }
        [HttpPost]
        public ActionResult AddeditMilllogDetails(MillLogDetails millLogDetails)
        {
            var Id = millLogDetails.MillLogDetailID;
            var MillLogID = millLogDetails.MillLogID;
            var SerialNumber = millLogDetails.SerialNumber;
            var MPId = millLogDetails.MillParameterId;
            var MId = millLogDetails.MillId;
            var Value = millLogDetails.LogValue;
            DataTable data = PlantData.InsertMillLogDetails(Id, MillLogID, SerialNumber, MPId, MId, Value);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("MillLog");
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("MillLog");
            }

        }
        [HttpPost]
        public JsonResult MilllogDetailsData(string MillLog, string MillParameter, string Mill, string DetailId)
        {
            // var data = PlantData.Pan();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MillLogDetails> millLogDetails = new List<MillLogDetails>();
            millLogDetails = PlantData.MillLogDetails(MillLog, MillParameter, Mill, DetailId);
            int rowstotal = millLogDetails.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                millLogDetails = millLogDetails.Where(x => x.MillParameterName.ToLower().Contains(searchvalue.ToLower()) || x.MillParameterId.ToString().Contains(searchvalue.ToLower()) || x.MillName.ToLower().Contains(searchvalue.ToLower()) || x.MillId.ToString().Contains(searchvalue.ToLower()) || x.MillLogDetailID.ToString().Contains(searchvalue.ToLower()) || x.MillLogID.ToString().Contains(searchvalue.ToLower()) || x.SerialNumber.ToString().Contains(searchvalue.ToLower()) || x.LogValue.ToString().Contains(searchvalue.ToLower())).ToList<MillLogDetails>();
            }
            int totalrowsafterfiltering = millLogDetails.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            millLogDetails = millLogDetails.Skip(start).Take(length).ToList<MillLogDetails>();
            return Json(new { data = millLogDetails, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion MillLog
        #region Pan
        [HttpGet]
        public ActionResult Pan()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult PanData()
        {
            // var data = PlantData.Pan();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Pan> pan = new List<Pan>();
            pan = PlantData.Pan();
            int rowstotal = pan.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                pan = pan.Where(x => x.PanName.ToLower().Contains(searchvalue.ToLower()) || x.PanCode.ToString().Contains(searchvalue.ToLower()) || x.PanId.ToString().Contains(searchvalue.ToLower())).ToList<Pan>();

            }
            int totalrowsafterfiltering = pan.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            pan = pan.Skip(start).Take(length).ToList<Pan>();
            return Json(new { data = pan, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditPan(int id = 0)
        {
            if (id == 0)
                return View(new Pan());
            else
            {
                List<Pan> pan = new List<Pan>();
                //List<Centre> Centerlist = new List<Centre>();
                pan = PlantData.Pan();
                return View(pan.Where(x => x.PanId == id).FirstOrDefault<Pan>());
            }

        }
        [HttpPost]
        public ActionResult AddeditPan(Pan pan)
        {
            var Id = pan.PanId;
            var Code = pan.PanCode;
            var Name = pan.PanName;
            DataTable data = PlantData.InsertPan(Id, Code, Name);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {


                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Pan");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Pan");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents wrong!............");
                return RedirectToAction("Pan");
            }

        }
        #endregion Pan
        #region Shift
        [HttpGet]
        public ActionResult Shift()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult ShiftData()
        {
            // var data = PlantData.Shift();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Shift> shift = new List<Shift>();
            shift = PlantData.Shift();
            int rowstotal = shift.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                shift = shift.Where(x => x.ShiftName.ToLower().Contains(searchvalue.ToLower()) || x.ShortCode.ToString().Contains(searchvalue.ToLower()) || x.ShortCode.ToLower().Contains(searchvalue.ToLower()) || x.FirstHour.ToString().Contains(searchvalue.ToLower()) || x.SecondHour.ToString().Contains(searchvalue.ToLower()) || x.ThirdHour.ToString().Contains(searchvalue.ToLower()) || x.FirstHour.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower())).ToList<Shift>();
            }
            int totalrowsafterfiltering = shift.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            shift = shift.Skip(start).Take(length).ToList<Shift>();
            return Json(new { data = shift, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditShift(int id = 0)
        {
            if (id == 0)
                return View(new Shift());
            else
            {
                List<Shift> pan = new List<Shift>();
                //List<Centre> Centerlist = new List<Centre>();
                pan = PlantData.Shift();
                return View(pan.Where(x => x.ShiftId == id).FirstOrDefault<Shift>());
            }

        }
        [HttpPost]
        public ActionResult AddeditShift(Shift shift)
        {
            var Id = shift.ShiftId;
            var Code = shift.ShiftCode;
            var Name = shift.ShiftName;
            var ShortCode =shift.ShortCode;
            var FirstHour = shift.FirstHour;
            var SecondHour = shift.SecondHour;
            var ThirdHour = shift.ThirdHour;
            var FourthHour = shift.FirstHour;
            DataTable data = PlantData.InsertShift(Id, Code, Name, ShortCode, FirstHour, SecondHour, ThirdHour, FourthHour);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Shift");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Shift");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("Shift");

            }
        }
        #endregion Shift
        #region ShiftEngineerLogbook

        public ActionResult ShiftEngineerLogbook()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }

        public JsonResult ShiftEngineerLogbookData(string Unit, string Shift, string LogDate2, string LogDate3, string PlantDepartment, string PlantSubDepartment, string ShiftIncharge, string SectionHead, string DepartmentHead)
        {
            //var data = PlantData.ShiftEngineerLogbook(Unit, Shift, LogDate2, LogDate3, PlantDepartment, PlantSubDepartment, ShiftIncharge, SectionHead, DepartmentHead);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ShiftEngineerLogbook> shiftEngineerLogbook = new List<ShiftEngineerLogbook>();
            shiftEngineerLogbook = PlantData.ShiftEngineerLogbook(Unit, Shift, LogDate2, LogDate3, PlantDepartment, PlantSubDepartment, ShiftIncharge, SectionHead, DepartmentHead);
            int rowstotal = shiftEngineerLogbook.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                shiftEngineerLogbook = shiftEngineerLogbook.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.DocumentNumber.ToString().Contains(searchvalue.ToLower()) || x.LogDate.ToString().Contains(searchvalue.ToLower()) || x.PlantDepartmentDepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.PlantSubDepartmentSubDepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.ShiftShiftName.ToLower().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.EntryUserId.ToString().Contains(searchvalue.ToLower()) || x.EntryDate.ToString().Contains(searchvalue.ToLower()) || x.PlantDepartmentId.ToString().Contains(searchvalue.ToLower()) || x.PlantSubDepartmentId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower()) || x.ShiftInchargeId.ToString().Contains(searchvalue.ToLower())).ToList<ShiftEngineerLogbook>();

            }
            //int totalrowsafterfiltering = shiftEngineerLogbook.Count;
            //shiftEngineerLogbook = shiftEngineerLogbook.Skip(start).Take(length).ToList<ShiftEngineerLogbook>();
            int totalrowsafterfiltering = shiftEngineerLogbook.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            //shiftEngineerLogbook = shiftEngineerLogbook.Skip(start).Take(length).ToList<ShiftEngineerLogbook>();
            return Json(new { data = shiftEngineerLogbook, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditShiftEngineerLogbook(int id = 0)
        {
            TempData["ShiftLogBook"] = id;
            if (id == 0)
                return View(new ShiftEngineerLogbook());
            else
            {
                List<ShiftEngineerLogbook> shiftEngineerLogbook = new List<ShiftEngineerLogbook>();
                //List<Centre> Centerlist = new List<Centre>();
                shiftEngineerLogbook = PlantData.ShiftEngineerLogbook("", "", "", "", "", "", "", "", "");
                return View(shiftEngineerLogbook.Where(x => x.EngineerLogbookId == id).FirstOrDefault<ShiftEngineerLogbook>());
            }
        }
        [HttpPost]
        public ActionResult AddeditShiftEngineerLogbook(ShiftEngineerLogbook shiftEngineerLogbook)
        {
            var Id = shiftEngineerLogbook.EngineerLogbookId;
            var DocNo = shiftEngineerLogbook.DocumentNumber;
            var LogDate = shiftEngineerLogbook.LogDate;
            var PDId = shiftEngineerLogbook.PlantDepartmentId;
            var PSDId = shiftEngineerLogbook.PlantSubDepartmentId;
            var SId = shiftEngineerLogbook.ShiftId;
            var SInId = shiftEngineerLogbook.ShiftInchargeId;
            var IsChemist = shiftEngineerLogbook.IsChemist;
            var SHId = shiftEngineerLogbook.SectionHeadId;
            var DHId = shiftEngineerLogbook.DepartmentHeadId;
            var EntryuserId = shiftEngineerLogbook.EntryUserId;
            var EntryDate = shiftEngineerLogbook.EntryDate;
            var UId = shiftEngineerLogbook.UnitId;
            DataTable data = PlantData.InsertShiftEngineerLogBook(Id, DocNo, LogDate, PDId, PSDId, SId, SInId, IsChemist, SHId, DHId, EntryuserId, EntryDate, UId);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("ShiftEngineerLogbook");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("ShiftEngineerLogbook");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("ShiftEngineerLogbook");

            }
        }
        [HttpPost]
        public JsonResult ShiftEngineerLogbookDataDetails(string EngineerLogbook, string Details)
        {
            //var data = PlantData.ShiftEngineerLogbook(Unit, Shift, LogDate2, LogDate3, PlantDepartment, PlantSubDepartment, ShiftIncharge, SectionHead, DepartmentHead);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ShiftEngineerLogbookDetails> shiftEngineerLogbookDetails = new List<ShiftEngineerLogbookDetails>();
            shiftEngineerLogbookDetails = PlantData.ShiftEngineerLogbookDetails(EngineerLogbook, Details);
            int rowstotal = shiftEngineerLogbookDetails.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                shiftEngineerLogbookDetails = shiftEngineerLogbookDetails.Where(x => x.ToString().Contains(searchvalue.ToLower()) || x.EngineerLogbookId.ToString().Contains(searchvalue.ToLower()) || x.Observations.ToLower().Contains(searchvalue.ToLower()) || x.SerialNo.ToString().Contains(searchvalue.ToLower()) || x.WorkDone.ToLower().Contains(searchvalue.ToLower()) || x.WorkToBeDone.ToLower().Contains(searchvalue.ToLower()) || x.Remarks.ToLower().Contains(searchvalue.ToLower())).ToList<ShiftEngineerLogbookDetails>();

            }
            int totalrowsafterfiltering = shiftEngineerLogbookDetails.Count;
            shiftEngineerLogbookDetails = shiftEngineerLogbookDetails.Skip(start).Take(length).ToList<ShiftEngineerLogbookDetails>();
            return Json(new { data = shiftEngineerLogbookDetails, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddeditShiftEngineerLogbookDetails(int id = 0)
        {
            ViewBag.ShiftLogBookDetail = TempData["ShiftLogBook"];
            if (id == 0)
                return View(new ShiftEngineerLogbookDetails());
            else
            {
                List<ShiftEngineerLogbookDetails> shiftEngineerLogbook = new List<ShiftEngineerLogbookDetails>();
                //List<Centre> Centerlist = new List<Centre>();
                shiftEngineerLogbook = PlantData.ShiftEngineerLogbookDetails("", id.ToString());
                return View(shiftEngineerLogbook.Where(x => x.DetailsId == id).FirstOrDefault<ShiftEngineerLogbookDetails>());
            }
        }
        [HttpPost]
        public ActionResult AddeditShiftEngineerLogbookDetails(ShiftEngineerLogbookDetails shiftEngineerLogbookDetails)
        {
            var Id = shiftEngineerLogbookDetails.DetailsId;
            var EngineerLogbookID = shiftEngineerLogbookDetails.EngineerLogbookId;
            var SerialNumber = shiftEngineerLogbookDetails.SerialNo;
            var Observations = shiftEngineerLogbookDetails.Observations;
            var WorkDone = shiftEngineerLogbookDetails.WorkDone;
            var WorkToBeDone = shiftEngineerLogbookDetails.WorkToBeDone;
            var Remarks = shiftEngineerLogbookDetails.Remarks;

            DataTable data = PlantData.InsertShiftEngineerLogDetailsBook(Id, EngineerLogbookID, SerialNumber, Observations, WorkDone, WorkToBeDone, Remarks);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("ShiftEngineerLogbook");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("ShiftEngineerLogbook");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("ShiftEngineerLogbook");

            }
        }
        #endregion ShiftEngineerLogbook
        #region PlantPerformance
        [HttpGet]
        public ActionResult PlantPerformance()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult PlantPerformanceData(string Unit, string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {
            ///var data = PlantData.PlantPerformance(Unit, Shift, ProcessHead, SectionHead, DepartmentHead);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<PlantPerformance> plantPerformance = new List<PlantPerformance>();
            plantPerformance = PlantData.PlantPerformance(Unit, Shift, ProcessHead, SectionHead, DepartmentHead);
            int rowstotal = plantPerformance.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                plantPerformance = plantPerformance.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.ShiftShiftName.ToLower().Contains(searchvalue.ToLower()) || x.ProcessHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.LogDate.ToString().Contains(searchvalue.ToLower()) || x.CaneCrushed.ToString().Contains(searchvalue.ToLower()) || x.SugarBagged.ToString().Contains(searchvalue.ToLower()) || x.LogHour.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower()) || x.ExhaustTemperature.ToString().Contains(searchvalue.ToLower()) || x.FbdAirTemperature.ToString().Contains(searchvalue.ToLower()) || x.ImbitionPercent.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.ProcessHeadId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<PlantPerformance>();
            }
            int totalrowsafterfiltering = plantPerformance.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            plantPerformance = plantPerformance.Skip(start).Take(length).ToList<PlantPerformance>();
            return Json(new { data = plantPerformance, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditPlantPerformance(int id = 0)
        {
            if (id == 0)
                return View(new PlantPerformance());
            else
            {
                List<PlantPerformance> plantPerformance = new List<PlantPerformance>();
                //List<Centre> Centerlist = new List<Centre>();
                plantPerformance = PlantData.PlantPerformance("", "", "", "", "");
                return View(plantPerformance.Where(x => x.PlantPerformanceId == id).FirstOrDefault<PlantPerformance>());
            }
        }
        [HttpPost]
        public ActionResult AddeditPlantPerformance(PlantPerformance plantPerformance)
        {
            var Id = plantPerformance.PlantPerformanceId;
            var LogDate = plantPerformance.LogDate;
            var ShiftID = plantPerformance.ShiftId;
            var LogHour = plantPerformance.LogHour;
            var CaneCrushed = plantPerformance.CaneCrushed;
            var FBDAirTemperature = plantPerformance.FbdAirTemperature;
            var ExhaustTemperature = plantPerformance.ExhaustTemperature;

            var ImbitionPercent = plantPerformance.ImbitionPercent;
            var ProcessHeadID = plantPerformance.ProcessHeadId;
            var SectionHeadID = plantPerformance.SectionHeadId;
            var DepartmentHeadID = plantPerformance.DepartmentHeadId;
            var UnitID = plantPerformance.UnitId;
            var SugarBagged = plantPerformance.SugarBagged;
            DataTable data = PlantData.InsertPlantPerformance(Id, LogDate, ShiftID, LogHour, CaneCrushed, FBDAirTemperature, ExhaustTemperature, ImbitionPercent, ProcessHeadID, SectionHeadID, DepartmentHeadID, UnitID, SugarBagged);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("PlantPerformance");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("PlantPerformance");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("PlantPerformance");

            }
        }
        #endregion PlantPerformance
        #region PlantDepartment
        public ActionResult PlantDepartment()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult PlantDepartmentData()
        {
            //var data = PlantData.PlantDepartment();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<PlantDepartment> plantDepartment = new List<PlantDepartment>();
            plantDepartment = PlantData.PlantDepartment();
            int rowstotal = plantDepartment.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                plantDepartment = plantDepartment.Where(x => x.DepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.ShortName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentCode.ToLower().Contains(searchvalue.ToLower()) || x.OldCode.ToString().Contains(searchvalue.ToLower()) || x.PlantDepartmentId.ToString().Contains(searchvalue.ToLower())).ToList<PlantDepartment>();
            }
            int totalrowsafterfiltering = plantDepartment.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            plantDepartment = plantDepartment.Skip(start).Take(length).ToList<PlantDepartment>();
            return Json(new { data = plantDepartment, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddeditPlantDepartment(int id = 0)
        {
            if (id == 0)
                return View(new PlantDepartment());
            else
            {
                List<PlantDepartment> plantDepartment = new List<PlantDepartment>();
                //List<Centre> Centerlist = new List<Centre>();
                plantDepartment = PlantData.PlantDepartment();
                return View(plantDepartment.Where(x => x.PlantDepartmentId == id).FirstOrDefault<PlantDepartment>());
            }
        }
        [HttpPost]
        public ActionResult AddeditPlantDepartment(PlantDepartment plantDepartment)
        {
            var Id = plantDepartment.PlantDepartmentId;
            var OldCode = plantDepartment.OldCode;
            var DepartmentName = plantDepartment.DepartmentName;
            var ShortName = plantDepartment.ShortName;
            var DepartmentCode = plantDepartment.DepartmentCode;
            DataTable data = PlantData.InsertPlantDepartment(Id, OldCode, DepartmentName, ShortName, DepartmentCode);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("PlantDepartment");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("PlantDepartment");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("PlantDepartment");

            }
        }
        #endregion PlantDepartment
        #region PlantSubDepartment
        [HttpGet]
        public ActionResult PlantSubDepartment()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult PlantSubDepartmentData(string PlantDepartment)
        {
            //var data = PlantData.PlantSubDepartment(PlantDepartment);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<PlantSubDepartment> plantSubDepartment = new List<PlantSubDepartment>();
            plantSubDepartment = PlantData.PlantSubDepartment(PlantDepartment);
            int rowstotal = plantSubDepartment.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                plantSubDepartment = plantSubDepartment.Where(x => x.PlantDepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.ShortName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentCode.ToLower().Contains(searchvalue.ToLower()) || x.OldCode.ToString().Contains(searchvalue.ToLower()) || x.PlantDepartmentId.ToString().Contains(searchvalue.ToLower()) || x.SubDepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.PlantSubDepartmentId.ToString().Contains(searchvalue.ToLower())).ToList<PlantSubDepartment>();
            }
            int totalrowsafterfiltering = plantSubDepartment.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            plantSubDepartment = plantSubDepartment.Skip(start).Take(length).ToList<PlantSubDepartment>();
            return Json(new { data = plantSubDepartment, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditPlantSubDepartment(int id=0)
        {
            if (id == 0)
                return View(new PlantSubDepartment());
            else
            {
                List<PlantSubDepartment> subDepartment = new List<PlantSubDepartment>();
                //List<Centre> Centerlist = new List<Centre>();
                subDepartment = PlantData.PlantSubDepartment("");
                return View(subDepartment.Where(x => x.PlantSubDepartmentId == id).FirstOrDefault<PlantSubDepartment>());
            }

        }
        [HttpPost]
        public ActionResult AddeditPlantSubDepartment(PlantSubDepartment plantSubDepartment)
        {
            var Id = plantSubDepartment.PlantSubDepartmentId;
            var PlantDepartmentID = plantSubDepartment.PlantDepartmentId;
            var OldCode = plantSubDepartment.OldCode;
            var ShortName = plantSubDepartment.ShortName;
            var SubDepartmentName = plantSubDepartment.SubDepartmentName;
            var DepartmentCode = plantSubDepartment.DepartmentCode;
            DataTable data = PlantData.InsertPlantSubDepartment(Id, PlantDepartmentID, OldCode, SubDepartmentName, ShortName, DepartmentCode);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("PlantSubDepartment");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("PlantSubDepartment");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("PlantSubDepartment");

            }
        }
#endregion PlantSubDepartment
        #region Position
        [HttpGet]
        public ActionResult Position()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult PositionData(string MillParameter)
        {
            //var data = PlantData.Position(MillParameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Position> position = new List<Position>();
            position = PlantData.Position(MillParameter);
            int rowstotal = position.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                position = position.Where(x => x.PositionName.ToLower().Contains(searchvalue.ToLower()) || x.ShortName.ToLower().Contains(searchvalue.ToLower()) || x.PositionCode.ToString().Contains(searchvalue.ToLower()) || x.MillParameterId.ToString().Contains(searchvalue.ToLower()) || x.PositionId.ToString().Contains(searchvalue.ToLower())).ToList<Position>();
            }
            int totalrowsafterfiltering = position.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            position = position.Skip(start).Take(length).ToList<Position>();
            return Json(new { data = position, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddreditPosition(int id = 0)
        {
            if (id == 0)
                return View(new Position());
            else
            {
                List<Position> position = new List<Position>();
                //List<Centre> Centerlist = new List<Centre>();
                position = PlantData.Position("");
                return View(position.Where(x => x.PositionId == id).FirstOrDefault<Position>());
            }

        }
        [HttpPost]
        public ActionResult AddreditPosition(Position position)
        {
            var Id = position.PositionId;
            var PositionCode = position.PositionCode;
            var PositionName = position.PositionName;
            var ShortName = position.ShortName;
            var MillParameterID = position.MillParameterId;
            DataTable data = PlantData.InsertPOSITION(Id, PositionCode, PositionName, MillParameterID, ShortName);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Position");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Position");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("Position");

            }
        }
#endregion Position
        #region PanPosition
        [HttpGet]
        public ActionResult PanPosition()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult PanPositionData(string Unit, string ProcessHead, string SectionHead, string DepartmentHead)
        {
            //var data = PlantData.PanPosition(Unit, ProcessHead, SectionHead, DepartmentHead);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<PanPosition> panPosition = new List<PanPosition>();
            panPosition = PlantData.PanPosition(Unit, ProcessHead, SectionHead, DepartmentHead);
            int rowstotal = panPosition.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                panPosition = panPosition.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.ProcessHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.SectionHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadEmployeeCode.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentHeadId.ToString().Contains(searchvalue.ToLower()) || x.ProcessHeadId.ToString().Contains(searchvalue.ToLower()) || x.SectionHeadId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.AnalysisDate.ToString().Contains(searchvalue.ToLower()) || x.ShiftId.ToString().Contains(searchvalue.ToLower())).ToList<PanPosition>();
            }
            int totalrowsafterfiltering = panPosition.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            panPosition = panPosition.Skip(start).Take(length).ToList<PanPosition>();
            return Json(new { data = panPosition, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddreditPanPosition(int id = 0)
        {
            TempData["PanPosition"] = id;
            if (id == 0)
                return View(new PanPosition());
            else
            {
                List<PanPosition> panPosition = new List<PanPosition>();
                //List<Centre> Centerlist = new List<Centre>();
                panPosition = PlantData.PanPosition("", "", "", "");
                return View(panPosition.Where(x => x.PanPositionId == id).FirstOrDefault<PanPosition>());
            }

        }
        [HttpPost]
        public ActionResult AddreditPanPosition(PanPosition panPosition)
        {
            var Id = panPosition.PanPositionId;
            var AnalysisDate = panPosition.AnalysisDate;
            var ShiftID = panPosition.ShiftId;
            var ProcessHeadID = panPosition.ProcessHeadId;
            var SectionHeadID = panPosition.SectionHeadId;
            var DepartmentHeadID = panPosition.DepartmentHeadId;
            var UnitID = panPosition.UnitId;
            DataTable data = PlantData.InsertPANPOSITION(Id, AnalysisDate, ShiftID, ProcessHeadID, SectionHeadID, DepartmentHeadID, UnitID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("PanPosition");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("PanPosition");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("PanPosition");

            }
        }
        [HttpGet]
        public ActionResult AddreditPanPositionDetails(int id = 0)
        {
            ViewBag.PanPosition = TempData["PanPosition"];
            if (id == 0)
                return View(new PanPositionDetail());
            else
            {
                List<PanPositionDetail> panPositionDetail = new List<PanPositionDetail>();
                //List<Centre> Centerlist = new List<Centre>();
                panPositionDetail = PlantData.PanPositionDetail("", "",id.ToString());
                return View(panPositionDetail.Where(x => x.PanPositionDetailID == id).FirstOrDefault<PanPositionDetail>());
            }

        }
        [HttpPost]
        public ActionResult AddreditPanPositionDetails(PanPositionDetail panPositionDetail)
        {
            var Id = panPositionDetail.PanPositionDetailID;
            var PanPositionID = panPositionDetail.PanPositionID;
            var SerialNumber = panPositionDetail.SerialNumber;
            var PanID = panPositionDetail.PanID;
            var PanValue = panPositionDetail.PanValue;
            DataTable data = PlantData.InsertPANPOSITIONDetail(Id, PanPositionID, SerialNumber, PanID, PanValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("PanPosition");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("PanPosition");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("PanPosition");

            }
        }
        public JsonResult PanPositionDetailData(string PanPosition,string Pan)
        {
            //var data = PlantData.Location(Position);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<PanPositionDetail> panPositionDetail = new List<PanPositionDetail>();
            panPositionDetail = PlantData.PanPositionDetail(Pan, PanPosition, "");
            int rowstotal = panPositionDetail.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                panPositionDetail = panPositionDetail.Where(x => x.SerialNumber.ToString().Contains(searchvalue.ToLower()) || x.PanName.ToLower().Contains(searchvalue.ToLower()) || x.PanValue.ToString().Contains(searchvalue.ToLower()) || x.PanPositionDetailID.ToString().Contains(searchvalue.ToLower()) ).ToList<PanPositionDetail>();
            }
            int totalrowsafterfiltering = panPositionDetail.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            panPositionDetail = panPositionDetail.Skip(start).Take(length).ToList<PanPositionDetail>();
            return Json(new { data = panPositionDetail, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion PanPosition
        #region Location
        [HttpGet]
        public ActionResult Location()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult LocationData(string Position)
        {
            //var data = PlantData.Location(Position);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Location> location = new List<Location>();
            location = PlantData.Location(Position);
            int rowstotal = location.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                location = location.Where(x => x.LocationName.ToLower().Contains(searchvalue.ToLower()) || x.PositionPositionName.ToLower().Contains(searchvalue.ToLower()) || x.ShortName.ToLower().Contains(searchvalue.ToLower()) || x.LocationCode.ToString().Contains(searchvalue.ToLower()) || x.LocationId.ToString().Contains(searchvalue.ToLower()) || x.PositionId.ToString().Contains(searchvalue.ToLower())).ToList<Location>();
            }
            int totalrowsafterfiltering = location.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            location = location.Skip(start).Take(length).ToList<Location>();
            return Json(new { data = location, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddeditLocation(int id=0)
        {
            if (id == 0)
                return View(new Location());
            else
            {
                List<Location> location = new List<Location>();
                //List<Centre> Centerlist = new List<Centre>();
                location = PlantData.Location("");
                return View(location.Where(x => x.LocationId == id).FirstOrDefault<Location>());
            }
        }
        [HttpPost]
        public ActionResult AddeditLocation(Location location)
        {
            var Id = location.LocationId;
            var LocationCode = location.LocationCode;
            var LocationName = location.LocationName;
            var PositionID = location.PositionId;
            var ShortName = location.ShortName;
            DataTable data = PlantData.InsertLOCATION(Id, LocationCode, LocationName, PositionID, ShortName);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Location");
                }
                else
                {
                   TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Location");
                }
            }
            else
            {
               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!........");
                return RedirectToAction("Location");

            }
        }
        #endregion Location
    }
}