using KnowledgeApp_Test.Models.Stoppages;
using KnowledgeApp_Test.Services;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{
    public class StoppagesController : Controller
    {
        StoppagesServices StoppagesServices = new StoppagesServices();
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        // GET: Stoppages
        #region StoppageDepartment
        [HttpGet]
        public ActionResult StoppageDepartment()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditStoppageDepartment(int id = 0)
        {
            if (id == 0)
            {
                return View(new StoppageDepartment());
            }
            else
            {
                List<StoppageDepartment> stoppageDepartment = new List<StoppageDepartment>();
                //List<Centre> Centerlist = new List<Centre>();
                stoppageDepartment = StoppagesServices.StoppageDepartment("");
                return View(stoppageDepartment.Where(x => x.DepartmentId == id).FirstOrDefault<StoppageDepartment>());
            }
        }
        [HttpPost]
        public ActionResult AddeditStoppageDepertment(StoppageDepartment stoppageDepartment)
        {
            var Id = stoppageDepartment.DepartmentId;
            var Code = stoppageDepartment.DepartmentCode;
            var Name = stoppageDepartment.DepartmentName;
            var PId = stoppageDepartment.ParameterId;
            DataTable data = StoppagesServices.InsertStoppageDepartment(Id, Code, Name, PId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("StoppageDepartment");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("StoppageDepartment");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("StoppageDepartment");

            }
        }
        public JsonResult StoppageDepartmentData(string Parameter)
        {
            // var data = StoppagesServices.StoppageDepartment(Parameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<StoppageDepartment> stoppageDepartment = new List<StoppageDepartment>();
            stoppageDepartment = StoppagesServices.StoppageDepartment(Parameter);
            int rowstotal = stoppageDepartment.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                stoppageDepartment = stoppageDepartment.Where(x => x.DepartmentName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentCode.ToString().Contains(searchvalue.ToLower()) || x.DepartmentId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower())).ToList<StoppageDepartment>();

            }
            int totalrowsafterfiltering = stoppageDepartment.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            stoppageDepartment = stoppageDepartment.Skip(start).Take(length).ToList<StoppageDepartment>();
            return Json(new { data = stoppageDepartment, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion StoppageDepartment
        #region StoppageSparesProcess
        [HttpGet]
        public ActionResult StoppageSparesProcess()
        {
            var StoppageStation = dropdownListSevices.GetStoppageStationddl();
            ViewBag.StoppageStation = StoppageStation;
           ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditStoppageSparesProcess(int id = 0)
        {
            if (id == 0)
            {
                return View(new StoppageSparesProcess());
            }
            else
            {
                List<StoppageSparesProcess> StoppageSparesProcess = new List<StoppageSparesProcess>();
                //List<Centre> Centerlist = new List<Centre>();
                StoppageSparesProcess = StoppagesServices.StoppageSparesProcess("");
                return View(StoppageSparesProcess.Where(x => x.SpareProcessId == id).FirstOrDefault<StoppageSparesProcess>());
            }
        }
        [HttpPost]
        public ActionResult AddeditStoppageSparesProcess(StoppageSparesProcess stoppageSparesProcess)
        {
            var Id = stoppageSparesProcess.SpareProcessId;
            var Code = stoppageSparesProcess.SpareProcessCode;
            var Name = stoppageSparesProcess.SpareProcessName;
            var IsProcess = stoppageSparesProcess.IsProcess;
            var SId = stoppageSparesProcess.StationId;
            DataTable data = StoppagesServices.InsertStoppageSparesProcess(Id, Code, Name, IsProcess, SId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("StoppageSparesProcess");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("StoppageSparesProcess");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("StoppageSparesProcess");

            }
        }


        [HttpPost]
        public JsonResult StoppageSparesProcessData(string Station)
        {
            // var data = StoppagesServices.StoppageSparesProcess(Station);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<StoppageSparesProcess> stoppageDepartment = new List<StoppageSparesProcess>();
            stoppageDepartment = StoppagesServices.StoppageSparesProcess(Station);
            int rowstotal = stoppageDepartment.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                stoppageDepartment = stoppageDepartment.Where(x => x.SpareProcessName.ToLower().Contains(searchvalue.ToLower()) || x.SpareProcessCode.ToString().Contains(searchvalue.ToLower()) || x.StationId.ToString().Contains(searchvalue.ToLower()) || x.SpareProcessId.ToString().Contains(searchvalue.ToLower())).ToList<StoppageSparesProcess>();

            }
            int totalrowsafterfiltering = stoppageDepartment.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            stoppageDepartment = stoppageDepartment.Skip(start).Take(length).ToList<StoppageSparesProcess>();
            return Json(new { data = stoppageDepartment, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion StoppageSparesProcess
        #region StoppageStation
        [HttpGet]
        public ActionResult StoppageStation()
        {
           ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditStoppageStation(int id = 0)
        {
            if (id == 0)
            {
                return View(new StoppageStation());
            }
            else
            {
                List<StoppageStation> stoppageStation = new List<StoppageStation>();
                stoppageStation = StoppagesServices.StoppageStation("", "");
                return View(stoppageStation.Where(x => x.StationId == id).FirstOrDefault<StoppageStation>());
            }

        }
        [HttpPost]
        public ActionResult AddeditStoppageStation(StoppageStation stoppageStation)
        {
            var Id = stoppageStation.StationId;
            var Code = stoppageStation.StationCode;
            var Name = stoppageStation.StationName;
            var DId = stoppageStation.DepartmentId;
            var PId = stoppageStation.ParameterId;
            DataTable data = StoppagesServices.InsertStoppageStation(Id, Code, Name, DId, PId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("StoppageStation");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("StoppageStation");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("StoppageStation");

            }
        }
        [HttpPost]
        public JsonResult StoppageStationData(string Parameter, string Department)
        {
            //var data = StoppagesServices.StoppageStation(Parameter, Department);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<StoppageStation> stoppageStation = new List<StoppageStation>();
            stoppageStation = StoppagesServices.StoppageStation(Parameter, Department);
            int rowstotal = stoppageStation.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                stoppageStation = stoppageStation.Where(x => x.StationName.ToLower().Contains(searchvalue.ToLower()) || x.StationCode.ToLower().Contains(searchvalue.ToLower()) || x.StationId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.DepartmentId.ToString().Contains(searchvalue.ToLower()) || x.DepartmentName.ToLower().Contains(searchvalue.ToLower())).ToList<StoppageStation>();

            }
            int totalrowsafterfiltering = stoppageStation.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            stoppageStation = stoppageStation.Skip(start).Take(length).ToList<StoppageStation>();
            return Json(new { data = stoppageStation, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion StoppageStation
        #region StoppageDefect
        [HttpGet]
        public ActionResult StoppageDefect()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditStoppageDefect(int id = 0)
        {
            if (id == 0)
            {
                return View(new StoppageDefect());
            }
            else
            {
                List<StoppageDefect> SD = new List<StoppageDefect>();
                SD = StoppagesServices.StoppageDefect("");
                return View(SD.Where(x => x.DefectId == id).FirstOrDefault<StoppageDefect>());

            }
        }
        [HttpPost]
        public ActionResult AddeditStoppageDefect(StoppageDefect stoppageDefect)
        {
            var Id = stoppageDefect.DefectId;
            var Code = stoppageDefect.DefectCode;
            var Name = stoppageDefect.DefectName;
            var ProcessId = stoppageDefect.SpareProcessId;
            DataTable data = StoppagesServices.InsertStoppageDefect(Id, Code, Name, ProcessId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("StoppageDefect");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("StoppageDefect");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("StoppageDefect");

            }
        }
        [HttpPost]
        public JsonResult StoppageDefectData(string SparesProcess)
        {
            //var data = StoppagesServices.StoppageDefect(SparesProcess);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<StoppageDefect> stoppageDefect = new List<StoppageDefect>();
            stoppageDefect = StoppagesServices.StoppageDefect(SparesProcess);
            int rowstotal = stoppageDefect.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                stoppageDefect = stoppageDefect.Where(x => x.DefectName.ToLower().Contains(searchvalue.ToLower()) || x.DefectCode.ToLower().Contains(searchvalue.ToLower()) || x.DefectId.ToString().Contains(searchvalue.ToLower()) || x.SpareProcessId.ToString().Contains(searchvalue.ToLower()) || x.SpareProcessCode.ToLower().Contains(searchvalue.ToLower())).ToList<StoppageDefect>();

            }
            int totalrowsafterfiltering = stoppageDefect.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            stoppageDefect = stoppageDefect.Skip(start).Take(length).ToList<StoppageDefect>();
            return Json(new { data = stoppageDefect, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion StoppageDefect
        #region Stoppage
        [HttpGet]
        public ActionResult Stoppage()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditStoppage(int id = 0)
        {
            if (id == 0)
            {
                return View(new Stoppage());

            }
            else
            {
                List<Stoppage> stoppages = new List<Stoppage>();
                stoppages = StoppagesServices.Stoppage("", "", "", "", "", "", "", "");
                return View(stoppages.Where(x => x.StoppageId == id).FirstOrDefault<Stoppage>());

            }

        }
        [HttpPost]
        public ActionResult AddeditStoppage(Stoppage stoppage)
        {
            var Id = stoppage.StoppageId;
            var UId = stoppage.UnitId;
            var CSId = stoppage.CrushingSeasonId;
            var StoppageDate = stoppage.StoppageDate;
            var DateSerial = stoppage.DateSerial;
            var StoppageStart = stoppage.StoppageStart;
            var StoppageTil = stoppage.StoppageTill;
            var StartTime = stoppage.StartTime;
            var EndTime = stoppage.EndTime;
            var SId = stoppage.StationId;
            var Duration = stoppage.Duration;
            var DurationHour = stoppage.DurationHour;
            var Remarks = stoppage.Remarks;
            var stoppageType = stoppage.StoppageType;
            var SPId = stoppage.SpareProcessId;
            var DefctId = stoppage.DefectId;
            var AId = stoppage.ActionId;
            DataTable data = StoppagesServices.InsertStoppage(Id, UId, CSId, StoppageDate, DateSerial, StoppageStart, StoppageTil, StartTime, EndTime, SId, Duration, DurationHour, Remarks, stoppageType, SPId, DefctId, AId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("Stoppage");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("Stoppage");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("Stoppage");

            }


        }


        [HttpPost]
        public JsonResult StoppageData(string Unit, string CrushingSeason, string StoppageDate, string StoppageTill, string StoppageStation, string StoppageSparesProcess, string StoppageActionTaken, string StoppageDefect)
        {
            //var data = StoppagesServices.Stoppage(Unit, CrushingSeason, StoppageDate, StoppageTill, StoppageStation, StoppageSparesProcess, StoppageActionTaken, StoppageDefect);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Stoppage> stoppage = new List<Stoppage>();
            stoppage = StoppagesServices.Stoppage(Unit, CrushingSeason, StoppageDate, StoppageTill, StoppageStation, StoppageSparesProcess, StoppageActionTaken, StoppageDefect);
            int rowstotal = stoppage.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                stoppage = stoppage.Where(x => x.DefectDefectName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) || x.StationId.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.DefectDefectName.ToLower().Contains(searchvalue.ToLower()) || x.DefectId.ToString().Contains(searchvalue.ToLower()) || x.DefectCode.ToLower().Contains(searchvalue.ToLower()) || x.ActionCode.ToLower().Contains(searchvalue.ToLower()) || x.StationCode.ToLower().Contains(searchvalue.ToLower()) || x.DateSerial.ToString().Contains(searchvalue.ToLower()) || x.StoppageDate.ToString().Contains(searchvalue.ToLower()) || x.StoppageStart.ToString().Contains(searchvalue.ToLower()) || x.StoppageTill.ToString().Contains(searchvalue.ToLower()) || x.StoppageTypeName.ToLower().Contains(searchvalue.ToLower()) || x.Remarks.ToLower().Contains(searchvalue.ToLower()) || x.Duration.ToString().Contains(searchvalue.ToLower()) || x.DurationHour.ToString().Contains(searchvalue.ToLower()) || x.SpareProcessCode.ToLower().Contains(searchvalue.ToLower())).ToList<Stoppage>();

            }
            int totalrowsafterfiltering = stoppage.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            stoppage = stoppage.Skip(start).Take(length).ToList<Stoppage>();
            return Json(new { data = stoppage, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DateDiff(string StartDate,String SatrtTime,string EndDate, string EndTime)
        {
            DateTime FirstDate = DateTime.ParseExact(StartDate+" "+ SatrtTime, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime SecondDate = DateTime.ParseExact(EndDate + " " + EndTime, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            
            TimeSpan ts = SecondDate - FirstDate;
           int differenceInDays = ts.Days;
            int diffhours = ts.Hours;
            int diffminute = ts.Minutes;
            int Diffsec = ts.Seconds;
            int TotalHourse = (differenceInDays * 24) + diffhours;
            int totalMin = TotalHourse * 60;
            string[] date = { Diffsec.ToString(),TotalHourse.ToString(), differenceInDays.ToString(), diffhours.ToString(), diffminute.ToString(), totalMin.ToString() };
            // return Json(new { data = differenceInDays, diffhours, diffminute, Diffsec, TotalHourse, totalMin }, JsonRequestBehavior.AllowGet);
            return Json(new { data = date }, JsonRequestBehavior.AllowGet);
        }


        #endregion Stoppage
        #region StoppageActionTaken
        [HttpGet]
        public ActionResult StoppageActionTaken()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        public ActionResult AddeditStoppageActionTaken(int id = 0)
        {
            if (id == 0)
            {
                return View(new StoppageActionTaken());
            }
            else
            {
                List<StoppageActionTaken> stoppageActionTaken = new List<StoppageActionTaken>();
                stoppageActionTaken = StoppagesServices.StoppageActionTaken("");
                return View(stoppageActionTaken.Where(x => x.ActionId == id).FirstOrDefault<StoppageActionTaken>());
            }
        }
        [HttpPost]
        public JsonResult StoppageActionTakenData(string Defect)
        {
            //var data = StoppagesServices.StoppageActionTaken(Defect);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<StoppageActionTaken> atoppageActionTaken = new List<StoppageActionTaken>();
            atoppageActionTaken = StoppagesServices.StoppageActionTaken(Defect);
            int rowstotal = atoppageActionTaken.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                atoppageActionTaken = atoppageActionTaken.Where(x => x.ActionName.ToLower().Contains(searchvalue.ToLower()) || x.ActionCode.ToLower().Contains(searchvalue.ToLower()) || x.ActionId.ToString().Contains(searchvalue.ToLower()) || x.DefectId.ToString().Contains(searchvalue.ToLower()) || x.DefectCode.ToLower().Contains(searchvalue.ToLower())).ToList<StoppageActionTaken>();

            }
            int totalrowsafterfiltering = atoppageActionTaken.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            atoppageActionTaken = atoppageActionTaken.Skip(start).Take(length).ToList<StoppageActionTaken>();
            return Json(new { data = atoppageActionTaken, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddeditStoppageActionTaken(StoppageActionTaken stoppageActionTaken)
        {
            var Id = stoppageActionTaken.ActionId;
            var Code = stoppageActionTaken.ActionCode;
            var Name = stoppageActionTaken.ActionName;
            var DfctId = stoppageActionTaken.DefectId;
            DataTable data = StoppagesServices.InsertStoppageActionTaken(Id, Code, Name, DfctId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("StoppageActionTaken");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("StoppageActionTaken");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("StoppageActionTaken");

            }
        }
        #endregion StoppageActionTaken
        public ActionResult StationWiseStoppageReport()
        {
            return View();
        }
        public PartialViewResult PartialStationWiseStoppageReport(string StartDate= "", string EndDate = "", string UnitId = "", string StationId = "")
        {
            List<StationWiseStoppageReport> SWSR = new List<StationWiseStoppageReport>();
            SWSR = StoppagesServices.StationWiseStoppageReport(StartDate, EndDate, UnitId, StationId);
            return PartialView("PartialStationWiseStoppageReport", SWSR);
        }
        public ActionResult DailyStoppageReport()
        {
            return View();
        }
        public PartialViewResult PartialDailyStoppageReport(string StartDate = "", string UnitId = "")
        {
            List<DailyStoppageReport> SWSR = new List<DailyStoppageReport>();
            SWSR = StoppagesServices.DailyStoppageReport(StartDate, UnitId);
            return PartialView("PartialDailyStoppageReport", SWSR);
        }
        public ActionResult GroupWiseStoppageReport()
        {
            return View();
        }
        public PartialViewResult PartialGroupWiseStoppageReport(string StartDate="", string EndDate="", string UnitId="", string StationId="", string DepartmentId="")
        {
            List<GroupWiseStoppageReport> GWSR = new List<GroupWiseStoppageReport>();
            GWSR = StoppagesServices.GroupWiseStoppageReport(StartDate, EndDate, UnitId, StationId, DepartmentId);
            return PartialView("PartialGroupWiseStoppageReport", GWSR);
        }



    }

}
