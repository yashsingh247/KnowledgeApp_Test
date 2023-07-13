using KnowledgeApp_Test.Models.Targets;
using KnowledgeApp_Test.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{
    public class TargetsController : Controller
    {
        DropdownListSevices DropdownListSevices = new DropdownListSevices();
        TargetServices targetServices = new TargetServices();
        // GET: Targets
        #region SeasonTarget
        [HttpGet]
        public ActionResult SeasonTarget()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();

        }
        [HttpGet]
        public ActionResult AddeditSeasonTarget(int id=0) 
        {

            if (id == 0)
                return View(new SeasonTarget());
            else
            {
                List<SeasonTarget> SeasonTarget = new List<SeasonTarget>();
                //List<Centre> Centerlist = new List<Centre>();
                SeasonTarget = targetServices.SeasonTarget("","","");
                return View(SeasonTarget.Where(x => x.SeasonTargetId == id).FirstOrDefault<SeasonTarget>());
            }
        }
        [HttpPost]
        public ActionResult AddeditSeasonTarget(SeasonTarget seasonTarget)
        {
            var Id = seasonTarget.SeasonTargetId;
            var CSId = seasonTarget.CrushingSeasonId;
            var UId = seasonTarget.UnitId;
            var PId = seasonTarget.ParameterId;
            var ActualVal = seasonTarget.ActualValue;
            var TargetVal = seasonTarget.TargetValue;
           
            DataTable data = targetServices.InsertSeasonTarget(Id, CSId, PId, UId, TargetVal, ActualVal);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();

                if (sp_Status == "1")
                {


                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("SeasonTarget");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("SeasonTarget");
                }

            }
            else 
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong...........");
               return RedirectToAction("SeasonTarget");
            }
        }

        [HttpPost]
        public JsonResult SeasonTargetData(string CrushingSeason, string Unit, string Parameter)
        {
            //var data = targetServices.SeasonTarget(CrushingSeason, Unit, Parameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SeasonTarget> SeasonTarget = new List<SeasonTarget>();
            SeasonTarget = targetServices.SeasonTarget(CrushingSeason, Unit, Parameter);
            int rowstotal = SeasonTarget.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                SeasonTarget = SeasonTarget.Where(x => x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.SeasonTargetId.ToString().Contains(searchvalue.ToLower()) || x.TargetValue.ToString().Contains(searchvalue.ToLower()) || x.ActualValue.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower())|| x.CrushingSeasonName.ToLower().Contains(searchvalue.ToLower())||x.ParameterName.ToLower().Contains(searchvalue.ToLower())).ToList<SeasonTarget>();

            }
            int totalrowsafterfiltering = SeasonTarget.Count;
            SeasonTarget = SeasonTarget.Skip(start).Take(length).ToList<SeasonTarget>();
            return Json(new { data = SeasonTarget, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion SesonTarget
        #region SeasonMonth
        public ActionResult SeasonMonth()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSeasonMonth(int id=0)
        {
            if (id == 0)
                return View(new SeasonMonth());
            else
            {
                List<SeasonMonth> SeasonMonth = new List<SeasonMonth>();
                //List<Centre> Centerlist = new List<Centre>();
                SeasonMonth = targetServices.SeasonMonth("", "");
                return View(SeasonMonth.Where(x => x.MonthId == id).FirstOrDefault<SeasonMonth>());
            }

        }
        [HttpPost]
        public ActionResult AddeditSeasonMonth(SeasonMonth seasonMonth) 
        {
            var Id = seasonMonth.MonthId;
            var CSId = seasonMonth.CrushingSeasonId;
            var UId = seasonMonth.UnitId;
            var YearNumber = seasonMonth.YearNumber;
            var MonthNumber = seasonMonth.MonthNumber;
            var StartDate = seasonMonth.StartDate;
            var EndDate = seasonMonth.EndDate;
            var Days = seasonMonth.Days;
            var TargetDays = seasonMonth.TargetDays;
            var MonthName = seasonMonth.MonthName;
            var MonthSerial = seasonMonth.MonthSerial;
            DataTable data = targetServices.InsertSeasonMonth(Id, CSId, UId, YearNumber, MonthNumber,StartDate,EndDate,Days,TargetDays,MonthName,MonthSerial);

            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();

                if (sp_Status == "1")
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("SeasonMonth");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("SeasonMonth");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong...........");
               return RedirectToAction("SeasonMonth");
            }

        }
        [HttpPost]
            public JsonResult SeasonMonthData(string CrushingSeason, string Unit)
        {
            //var data = targetServices.SeasonMonth(CrushingSeason, Unit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SeasonMonth> seasonMonth = new List<SeasonMonth>();
            seasonMonth = targetServices.SeasonMonth(CrushingSeason, Unit);
            int rowstotal = seasonMonth.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                seasonMonth = seasonMonth.Where(x => x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.MonthId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.YearNumber.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.StartDate.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) || x.MonthName.ToLower().Contains(searchvalue.ToLower()) || x.YearNumber.ToString().Contains(searchvalue.ToLower()) || x.MonthNumber.ToString().Contains(searchvalue.ToLower()) || x.EndDate.ToString().Contains(searchvalue.ToLower()) || x.Days.ToString().Contains(searchvalue.ToLower()) || x.TargetDays.ToString().Contains(searchvalue.ToLower()) || x.MonthSerial.ToString().Contains(searchvalue.ToLower())).ToList<SeasonMonth>();

            }
            int totalrowsafterfiltering = seasonMonth.Count;
            seasonMonth = seasonMonth.Skip(start).Take(length).ToList<SeasonMonth>();
            return Json(new { data = seasonMonth, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion SeasonMonth
        #region SeasonWeek
        public ActionResult SeasonWeek()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSeasonWeek( int id=0)
        {

            if (id == 0)
                return View(new SeasonWeek());
            else
            {
                List<SeasonWeek> SeasonWeek = new List<SeasonWeek>();
                //List<Centre> Centerlist = new List<Centre>();
                SeasonWeek = targetServices.SeasonWeek("", "", "", "");
                return View(SeasonWeek.Where(x => x.WeekId == id).FirstOrDefault<SeasonWeek>());
            }
        }
        [HttpPost]
        public ActionResult AddeditSeasonWeek(SeasonWeek seasonWeek)
        {
            var Id = seasonWeek.WeekId;
            var CSId = seasonWeek.CrushingSeasonId;
            var UId = seasonWeek.UnitId;
            var YearNumber = seasonWeek.YearNumber;
            var MonthNumber = seasonWeek.MonthNumber;
            var WeekNumber = seasonWeek.WeekNumber;
            var StartDate = seasonWeek.StartDate;
            var EndDate = seasonWeek.EndDate;
            var Days = seasonWeek.Days;
            var TargetDays = seasonWeek.TargetDays;
            var WeekName = seasonWeek.WeekName;
            var WeekSerial = seasonWeek.WeekSerial;
           
            DataTable data = targetServices.InsertSeasonWeek(Id, CSId, UId, YearNumber, MonthNumber, WeekNumber, StartDate, EndDate, Days, TargetDays, WeekName, WeekSerial);

            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();

                if (sp_Status == "1")
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("SeasonWeek");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("SeasonWeek");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong...........");
               return RedirectToAction("SeasonWeek");
            }

            }
            [HttpPost]
            public JsonResult SeasonWeekData(string CrushingSeason, string Unit, string StartDate, string StartDate2)
        {
           // var data = targetServices.SeasonWeek(CrushingSeason, Unit, StartDate, StartDate2);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SeasonWeek> seasonWeek = new List<SeasonWeek>();
            seasonWeek = targetServices.SeasonWeek(CrushingSeason, Unit, StartDate, StartDate2);
            int rowstotal = seasonWeek.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                seasonWeek = seasonWeek.Where(x => x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.WeekId.ToString().Contains(searchvalue.ToLower()) || x.Days.ToString().Contains(searchvalue.ToLower()) || x.TargetDays.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.YearNumber.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) || x.WeekName.ToLower().Contains(searchvalue.ToLower()) || x.MonthNumber.ToString().Contains(searchvalue.ToLower()) || x.WeekNumber.ToString().Contains(searchvalue.ToLower()) || x.StartDate.ToString().Contains(searchvalue.ToLower()) || x.EndDate.ToString().Contains(searchvalue.ToLower()) || x.WeekSerial.ToString().Contains(searchvalue.ToLower())).ToList<SeasonWeek>();

            }
            int totalrowsafterfiltering = seasonWeek.Count;
            seasonWeek = seasonWeek.Skip(start).Take(length).ToList<SeasonWeek>();
            return Json(new { data = seasonWeek, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        #endregion SeasonWeek
        #region WeekTarget
        [HttpGet]
        public ActionResult WeekTarget()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddWeekTarget(int id=0)
        {
            if (id == 0)
                return View(new WeekTarget());
            else
            {
                List<WeekTarget> WeekTarget = new List<WeekTarget>();
                //List<Centre> Centerlist = new List<Centre>();
                WeekTarget = targetServices.WeekTarget("", "");
                return View(WeekTarget.Where(x => x.WeekTargetId == id).FirstOrDefault<WeekTarget>());
            }
        }
        [HttpPost]
        public ActionResult AddWeekTarget(WeekTarget weekTarget)
        {
            var Id = weekTarget.WeekTargetId;
            var SWeek = weekTarget.WeekId;
            var PId = weekTarget.ParameterId;
            var TargetVal = weekTarget.TargetValue;
            var ActualVal = weekTarget.ActualValue;
            DataTable data = targetServices.InserWeekTarget(Id, SWeek, PId, TargetVal, ActualVal);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();

                if (sp_Status == "1")
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("WeekTarget");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("WeekTarget");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong...........");
               return RedirectToAction("WeekTarget");
            }

        }
        public JsonResult WeekTargetData(string Week, string Parameter)
        {
            //var data = targetServices.WeekTarget(Week, Parameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<WeekTarget> weekTarget = new List<WeekTarget>();
            weekTarget = targetServices.WeekTarget(Week, Parameter);
            int rowstotal = weekTarget.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                weekTarget = weekTarget.Where(x => x.WeekName.ToLower().Contains(searchvalue.ToLower()) || x.WeekId.ToString().Contains(searchvalue.ToLower()) || x.TargetValue.ToString().Contains(searchvalue.ToLower()) || x.ActualValue.ToString().Contains(searchvalue.ToLower()) || x.WeekTargetId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.WeekName.ToLower().Contains(searchvalue.ToLower()) ).ToList<WeekTarget>();

            }
            int totalrowsafterfiltering = weekTarget.Count;
            weekTarget = weekTarget.Skip(start).Take(length).ToList<WeekTarget>();
            return Json(new { data = weekTarget, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion WeekTarget
        #region MonthTarget
        public ActionResult MonthTarget()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }

        [HttpGet]
        public ActionResult AddeditMonthTarget(int id=0) 
        {
            if (id == 0)
                return View(new MonthTarget());
            else
            {
                List<MonthTarget> MonthTarget = new List<MonthTarget>();
                //List<Centre> Centerlist = new List<Centre>();
                MonthTarget = targetServices.MonthTarget("", "", "", "");
                return View(MonthTarget.Where(x => x.MonthTargetId == id).FirstOrDefault<MonthTarget>());
            }
        }
        [HttpPost]
        public ActionResult AddeditMonthTarget(MonthTarget monthTarget)
        {
            var Id = monthTarget.MonthTargetId;
            var UId = monthTarget.UnitId;
            var CSId = monthTarget.CrushingSeasonId;
            var PId = monthTarget.ParameterId;
            var MId = monthTarget.MonthId;
            var TargetVal = monthTarget.TargetValue;
            var ActualVal = monthTarget.ActualValue;
            DataTable data = targetServices.InserMonthTarget(Id, CSId, UId, PId, MId, TargetVal, ActualVal);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();

                if (sp_Status == "1")
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("MonthTarget");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("MonthTarget");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong...........");
               return RedirectToAction("MonthTarget");
            }

        }
        public JsonResult MonthTargetData(string SeasonMonth, string Parameter, string CrushingSeason, string Unit)
        {
            //var data = targetServices.MonthTarget(SeasonMonth, Parameter, CrushingSeason, Unit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MonthTarget> monthTarget = new List<MonthTarget>();
            monthTarget = targetServices.MonthTarget(SeasonMonth, Parameter, CrushingSeason, Unit);
            int rowstotal = monthTarget.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                monthTarget = monthTarget.Where(x => x.MonthName.ToLower().Contains(searchvalue.ToLower()) || x.MonthId.ToString().Contains(searchvalue.ToLower()) || x.TargetValue.ToString().Contains(searchvalue.ToLower()) || x.ActualValue.ToString().Contains(searchvalue.ToLower()) || x.MonthTargetId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower())).ToList<MonthTarget>();

            }
            int totalrowsafterfiltering = monthTarget.Count;
            monthTarget = monthTarget.Skip(start).Take(length).ToList<MonthTarget>();
            return Json(new { data = monthTarget, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion MonthTarget
    }
}