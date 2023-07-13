using KnowledgeApp_Test.Models.TPT;
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
    public class TPTController : Controller
    {
        TPTServices TPTServices = new TPTServices();
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        // GET: TPT
        #region UnitParameter
        [HttpGet]
        public ActionResult UnitParameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditUnitParameter(int id = 0)
        {
            if (id == 0)
                return View(new UnitParameter());
            else
            {
                List<UnitParameter> unitParameter = new List<UnitParameter>();
                //List<Centre> Centerlist = new List<Centre>();
                unitParameter = TPTServices.UnitParameter();
                return View(unitParameter.Where(x => x.UnitParameterId == id).FirstOrDefault<UnitParameter>());

            }
        }
        [HttpPost]
        public ActionResult AddeditUnitParameter(UnitParameter unitParameter)
        {
            var Id = unitParameter.UnitParameterId;
            var Unit = unitParameter.UnitId;
            var Parameter = unitParameter.ParameterId;
            DataTable data = TPTServices.InsertUnitParameter(Id, Unit, Parameter);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("UnitParameter");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("UnitParameter");
                }

            }
            else
            {
                 TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("UnitParameter");
            }
        }
        [HttpPost]
        public JsonResult UnitParameterData()
        {
            //var data = TPTServices.UnitParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<UnitParameter> unitParameters = new List<UnitParameter>();
            unitParameters = TPTServices.UnitParameter();
            int rowstotal = unitParameters.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                unitParameters = unitParameters.Where(x => x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.UnitParameterId.ToString().Contains(searchvalue.ToLower())).ToList<UnitParameter>();

            }
            int totalrowsafterfiltering = unitParameters.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            unitParameters = unitParameters.Skip(start).Take(length).ToList<UnitParameter>();
            return Json(new { data = unitParameters, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion Unit Parameter
        #region Tpt Parameter
        [HttpGet]
        public ActionResult TptParameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }


        [HttpGet]
        public ActionResult AddeditTptParameter(int id = 0)
        {
            if (id == 0)
                return View(new TptParameter());
            else
            {
                List<TptParameter> tptParameter = new List<TptParameter>();
                //List<Centre> Centerlist = new List<Centre>();
                tptParameter = TPTServices.TptParameter("", "", "", "");
                return View(tptParameter.Where(x => x.TptParameterId == id).FirstOrDefault<TptParameter>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptParameter(TptParameter tptParameter)
        {
            var Id = tptParameter.TptParameterId;
            var Code = tptParameter.ParameterCode;
            var Name = tptParameter.ParameterName;
            var IsInputParameter = tptParameter.IsInputParameter;
            var DataType = tptParameter.DataType;
            var ParameterUnitId = tptParameter.ParameterUnitId;
            var Formula = tptParameter.Formula;
            var ParameterId = tptParameter.ParameterId;
            var HighPositive = tptParameter.HighlightPositive;
            var DeviationPercent = tptParameter.DeviationPercent;
            var DifferenceValue = tptParameter.DifferenceValue;
            var ConsolidationType = tptParameter.ConsolidationType;
            var ConsolidationParameterId = tptParameter.ConsolidationParameterId;
            var CalculationLevel = tptParameter.CalculationLevel;
            var Precision = tptParameter.Precision;
            var ShowOnFinalTpt = tptParameter.ShowOnFinalTpt;
            var ReportType = tptParameter.ReportType;
            var DisplayOrder = tptParameter.DisplayOrder;
            var TpTptSerial = tptParameter.TpTptSerial;
            var DescriptiveFormula = tptParameter.DescriptiveFormula;
            var TexParameterId = tptParameter.TexParameterId;
            var WilParameterId = tptParameter.WilParameterId;
            var ShowOnOutput = tptParameter.ShowOnOutput;
            var OutputRowNumber = tptParameter.OutputRowNumber;
            var OutputSerial = tptParameter.OutputSerial;
            DataTable data = TPTServices.InsertTptParameter(Id, Code, Name, IsInputParameter, DataType, ParameterUnitId, Formula, ParameterId, HighPositive, DeviationPercent, DifferenceValue, ConsolidationType, ConsolidationParameterId, CalculationLevel, Precision, ShowOnFinalTpt, ReportType, DisplayOrder, TpTptSerial, DescriptiveFormula, TexParameterId, WilParameterId, ShowOnOutput, OutputRowNumber, OutputSerial);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                     TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptParameter");
                }
                else
                {
                     TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptParameter");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptParameter");
            }
        }

        [HttpPost]
        public JsonResult TptParameterData(string Parameter, string ParameterUnit, string TexParameter, string WilParameter)
        {
            //var data = TPTServices.TptParameter(Parameter, ParameterUnit, TexParameter, WilParameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptParameter> tptParameter = new List<TptParameter>();
            tptParameter = TPTServices.TptParameter(Parameter, ParameterUnit, TexParameter, WilParameter);
            int rowstotal = tptParameter.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptParameter = tptParameter.Where(x => x.ParameterCode.ToLower().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.DataType.ToString().Contains(searchvalue.ToLower()) || x.ParameterUnitParameterUnitName.ToLower().Contains(searchvalue.ToLower()) || x.Formula.ToLower().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.HighlightPositive.ToString().Contains(searchvalue.ToLower()) || x.DeviationPercent.ToString().Contains(searchvalue.ToLower()) || x.DifferenceValue.ToString().Contains(searchvalue.ToLower()) || x.ConsolidationType.ToString().Contains(searchvalue.ToLower()) || x.ConsolidationParameterId.ToString().Contains(searchvalue.ToLower()) || x.CalculationLevel.ToString().Contains(searchvalue.ToLower()) || x.Precision.ToString().Contains(searchvalue.ToLower()) || x.ShowOnFinalTpt.ToString().Contains(searchvalue.ToLower()) || x.ReportType.ToString().Contains(searchvalue.ToLower()) || x.DisplayOrder.ToString().Contains(searchvalue.ToLower()) || x.TpTptSerial.ToString().Contains(searchvalue.ToLower()) || x.DescriptiveFormula.ToString().Contains(searchvalue.ToLower()) || x.TexParameterParameterName.ToLower().Contains(searchvalue.ToLower()) || x.WilParameterParameterName.ToLower().Contains(searchvalue.ToLower()) || x.ShowOnOutput.ToString().Contains(searchvalue.ToLower()) || x.OutputRowNumber.ToString().Contains(searchvalue.ToLower()) || x.OutputSerial.ToString().Contains(searchvalue.ToLower()) || x.TexParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterUnitId.ToString().Contains(searchvalue.ToLower()) || x.TexParameterId.ToString().Contains(searchvalue.ToLower()) || x.WilParameterId.ToString().Contains(searchvalue.ToLower())).ToList<TptParameter>();

            }
            int totalrowsafterfiltering = tptParameter.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptParameter = tptParameter.Skip(start).Take(length).ToList<TptParameter>();
            return Json(new { data = tptParameter, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion Tpt Parameter
        #region TptPower
        [HttpGet]
        public ActionResult TptPower()
        {
           
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditTptPower(int id = 0)
        {
            if (id == 0)
                return View(new TptPower());
            else
            {
                List<TptPower> tptParameter = new List<TptPower>();
                //List<Centre> Centerlist = new List<Centre>();
                tptParameter = TPTServices.TptPower("", "");
                return View(tptParameter.Where(x => x.TptPowerParameterId == id).FirstOrDefault<TptPower>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptPower(TptPower tptPower)
        {
            var Id = tptPower.TptPowerParameterId;
            var Code = tptPower.TptPowerCode;
            var Name = tptPower.TptPowerName;
            var Type = tptPower.ParameterType;
            var Formula = tptPower.Formula;
            var ParameterUnitId = tptPower.ParameterUnitId;
            var DescretiveFormula = tptPower.DescriptiveFormula;
            var Parameter = tptPower.ParameterId;
            DataTable data = TPTServices.InsertTptPower(Id, Code, Name, Type, Formula, ParameterUnitId, DescretiveFormula, Parameter);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptPower");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptPower");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptPower");
            }
        }

        [HttpPost]
        public JsonResult TptPowerData(string Parameter, string ParameterUnit)
        {
            // var data = TPTServices.TptPower(Parameter, ParameterUnit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptPower> tptParameter = new List<TptPower>();
            tptParameter = TPTServices.TptPower(Parameter, ParameterUnit);
            int rowstotal = tptParameter.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptParameter = tptParameter.Where(x => x.TptPowerCode.ToLower().Contains(searchvalue.ToLower()) || x.TptPowerName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterType.ToString().Contains(searchvalue.ToLower()) || x.Formula.ToLower().Contains(searchvalue.ToLower()) || x.Formula.ToLower().Contains(searchvalue.ToLower()) || x.ParameterUnitParameterUnitName.ToLower().Contains(searchvalue.ToLower()) || x.DescriptiveFormula.ToLower().Contains(searchvalue.ToLower()) || x.ParameterParameterName.ToString().Contains(searchvalue.ToLower()) || x.TptPowerParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterUnitId.ToString().Contains(searchvalue.ToLower())).ToList<TptPower>();

            }
            int totalrowsafterfiltering = tptParameter.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptParameter = tptParameter.Skip(start).Take(length).ToList<TptPower>();
            return Json(new { data = tptParameter, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion TptPower
        #region Tpt Revision
        [HttpGet]
        public ActionResult TptRevision()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult TptRevisionData(string Unit, string CreationDate2, string CreationDate3, string CrushingSeason)
        {
            //var data = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptRevision> tptRevisions = new List<TptRevision>();
            tptRevisions = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int rowstotal = tptRevisions.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptRevisions = tptRevisions.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.RevisionName.ToLower().Contains(searchvalue.ToLower()) || x.RevisionCode.ToString().Contains(searchvalue.ToLower()) || x.CreationDate.ToString().Contains(searchvalue.ToLower()) || x.SeasonStartDate.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonCrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) || x.SeasonDays.ToString().Contains(searchvalue.ToLower()) || x.SeasonEndDate.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.RevisionId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<TptRevision>();

            }
            int totalrowsafterfiltering = tptRevisions.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptRevisions = tptRevisions.Skip(start).Take(length).ToList<TptRevision>();
            return Json(new { data = tptRevisions, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditTptRevision(int id = 0)
        {
            if (id == 0)
                return View(new TptRevision());
            else
            {
                List<TptRevision> tptRevision = new List<TptRevision>();
                //List<Centre> Centerlist = new List<Centre>();
                tptRevision = TPTServices.TptRevision("", "", "", "");
                return View(tptRevision.Where(x => x.RevisionId == id).FirstOrDefault<TptRevision>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptRevision(TptRevision tptRevision)
        {
            var Id = tptRevision.RevisionId;
            var Code = tptRevision.RevisionCode;
            var Name = tptRevision.RevisionName;
            var Unit = tptRevision.UnitId;
            var CreationDate = tptRevision.CreationDate;
            var SeasonStartDate = tptRevision.SeasonStartDate;
            var SeasonEndDate = tptRevision.SeasonEndDate;
            var CrushingSeason = tptRevision.CrushingSeasonId;
            var SeasonDays = tptRevision.SeasonDays;
            DataTable data = TPTServices.InsertTptRevisison(Id, Code, Name, Unit, CreationDate, SeasonStartDate, SeasonEndDate, CrushingSeason, SeasonDays);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptRevision");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptRevision");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptRevision");
            }
        }
        #endregion Tpt Revision
        #region Tpt Season
        [HttpGet]
        public ActionResult TptSeason()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult TptSeasonData(string tptRevision, string tptParameter)
        {
            //var data = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptSeason> tptSeason = new List<TptSeason>();
            tptSeason = TPTServices.TptSeason(tptRevision, tptParameter);
            int rowstotal = tptSeason.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptSeason = tptSeason.Where(x => x.TptParameterParameterCode.ToLower().Contains(searchvalue.ToLower()) || x.RevisionRevisionName.ToLower().Contains(searchvalue.ToLower()) || x.TptYear.ToString().Contains(searchvalue.ToLower()) || x.Target.ToString().Contains(searchvalue.ToLower()) || x.Actual.ToString().Contains(searchvalue.ToLower()) || x.LastYearActual.ToString().Contains(searchvalue.ToLower()) || x.TargetTex.ToString().Contains(searchvalue.ToLower()) || x.TagetWil.ToString().Contains(searchvalue.ToLower()) || x.ActualTex.ToString().Contains(searchvalue.ToLower()) || x.ActualWil.ToString().Contains(searchvalue.ToLower()) || x.TptSeasonId.ToString().Contains(searchvalue.ToLower()) || x.RevisionId.ToString().Contains(searchvalue.ToLower()) || x.TptParameterId.ToString().Contains(searchvalue.ToLower())).ToList<TptSeason>();

            }
            int totalrowsafterfiltering = tptSeason.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptSeason = tptSeason.Skip(start).Take(length).ToList<TptSeason>();
            return Json(new { data = tptSeason, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditTptSeason(int id = 0)
        {
            if (id == 0)
                return View(new TptSeason());
            else
            {
                List<TptSeason> tptSeason = new List<TptSeason>();
                //List<Centre> Centerlist = new List<Centre>();
                tptSeason = TPTServices.TptSeason("", "");
                return View(tptSeason.Where(x => x.TptSeasonId == id).FirstOrDefault<TptSeason>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptSeason(TptSeason tptSeason)
        {
            var Id = tptSeason.TptSeasonId;
            var TptYear = tptSeason.TptYear;
            var RevisionId = tptSeason.RevisionId;
            var TptParameterId = tptSeason.TptParameterId;
            var Target = tptSeason.Target;
            var Actual = tptSeason.Actual;
            var LastYearActual = tptSeason.LastYearActual;
            var TargetTex = tptSeason.TargetTex;
            var TagetWil = tptSeason.TagetWil;
            var ActualTex = tptSeason.ActualTex;
            var ActualWil = tptSeason.ActualWil;
            DataTable data = TPTServices.InsertTptSeason(Id, TptYear, RevisionId, TptParameterId, Target, Actual, LastYearActual, TargetTex, TagetWil, ActualTex, ActualWil);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptSeason");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptSeason");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptSeason");
            }
        }

        #endregion Tpt Season
        #region TptMonthly
        [HttpGet]
        public ActionResult TptMonthly()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult TptMonthlyData(string tptRevision, string tptParameter)
        {
            //var data = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptMonthly> tptMonth = new List<TptMonthly>();
            tptMonth = TPTServices.TptMonthly(tptRevision, tptParameter);
            int rowstotal = tptMonth.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptMonth = tptMonth.Where(x => x.TptParameterParameterCode.ToLower().Contains(searchvalue.ToLower()) || x.RevisionRevisionName.ToLower().Contains(searchvalue.ToLower()) || x.TptYear.ToString().Contains(searchvalue.ToLower()) || x.Target.ToString().Contains(searchvalue.ToLower()) || x.Actual.ToString().Contains(searchvalue.ToLower()) || x.LastYearActual.ToString().Contains(searchvalue.ToLower()) || x.TargetTex.ToString().Contains(searchvalue.ToLower()) || x.TagetWil.ToString().Contains(searchvalue.ToLower()) || x.ActualTex.ToString().Contains(searchvalue.ToLower()) || x.ActualWil.ToString().Contains(searchvalue.ToLower()) || x.TptMonthlyId.ToString().Contains(searchvalue.ToLower()) || x.RevisionId.ToString().Contains(searchvalue.ToLower()) || x.TptParameterId.ToString().Contains(searchvalue.ToLower()) || x.TptMonth.ToString().Contains(searchvalue.ToLower())).ToList<TptMonthly>();
            }
            int totalrowsafterfiltering = tptMonth.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptMonth = tptMonth.Skip(start).Take(length).ToList<TptMonthly>();
            return Json(new { data = tptMonth, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddeditTptMonthly(int id = 0)
        {
            if (id == 0)
                return View(new TptMonthly());
            else
            {
                List<TptMonthly> tptMonth = new List<TptMonthly>();
                //List<Centre> Centerlist = new List<Centre>();
                tptMonth = TPTServices.TptMonthly("", "");
                return View(tptMonth.Where(x => x.TptMonthlyId == id).FirstOrDefault<TptMonthly>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptMonthly(TptMonthly tptMonthly)
        {
            var Id = tptMonthly.TptMonthlyId;
            var TptYear = tptMonthly.TptYear;
            var RevisionId = tptMonthly.RevisionId;
            var TptParameterId = tptMonthly.TptParameterId;
            var Target = tptMonthly.Target;
            var Actual = tptMonthly.Actual;
            var LastYearActual = tptMonthly.LastYearActual;
            var TargetTex = tptMonthly.TargetTex;
            var TagetWil = tptMonthly.TagetWil;
            var ActualTex = tptMonthly.ActualTex;
            var ActualWil = tptMonthly.ActualWil;
            var TptMonth = tptMonthly.TptMonth;
            DataTable data = TPTServices.InsertTptMonthly(Id, TptYear, TptMonth, RevisionId, TptParameterId, Target, Actual, LastYearActual, TargetTex, TagetWil, ActualTex, ActualWil);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptMonthly");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptMonthly");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptMonthly");
            }
        }
        #endregion TptMonthly
        #region TptWeekly
        [HttpGet]
        public ActionResult TptWeekly()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult TptWeeklyData(string tptRevision, string tptParameter)
        {
            //var data = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptWeekly> tptWeek = new List<TptWeekly>();
            tptWeek = TPTServices.TptWeekly(tptRevision, tptParameter);
            int rowstotal = tptWeek.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptWeek = tptWeek.Where(x => x.TptParameterParameterCode.ToLower().Contains(searchvalue.ToLower()) || x.RevisionRevisionName.ToLower().Contains(searchvalue.ToLower()) || x.TptYear.ToString().Contains(searchvalue.ToLower()) || x.Target.ToString().Contains(searchvalue.ToLower()) || x.Actual.ToString().Contains(searchvalue.ToLower()) || x.LastYearActual.ToString().Contains(searchvalue.ToLower()) || x.TargetTex.ToString().Contains(searchvalue.ToLower()) || x.TagetWil.ToString().Contains(searchvalue.ToLower()) || x.ActualTex.ToString().Contains(searchvalue.ToLower()) || x.ActualWil.ToString().Contains(searchvalue.ToLower()) || x.TptWeeklyId.ToString().Contains(searchvalue.ToLower()) || x.RevisionId.ToString().Contains(searchvalue.ToLower()) || x.TptParameterId.ToString().Contains(searchvalue.ToLower()) || x.TptWeek.ToString().Contains(searchvalue.ToLower())).ToList<TptWeekly>();
            }
            int totalrowsafterfiltering = tptWeek.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptWeek = tptWeek.Skip(start).Take(length).ToList<TptWeekly>();
            return Json(new { data = tptWeek, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditTptWeekly(int id = 0)
        {
            if (id == 0)
                return View(new TptWeekly());
            else
            {
                List<TptWeekly> tptWeekly = new List<TptWeekly>();
                //List<Centre> Centerlist = new List<Centre>();
                tptWeekly = TPTServices.TptWeekly("", "");
                return View(tptWeekly.Where(x => x.TptWeeklyId == id).FirstOrDefault<TptWeekly>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptWeekly(TptWeekly tptWeekly)
        {
            var Id = tptWeekly.TptWeeklyId;
            var TptYear = tptWeekly.TptYear;
            var RevisionId = tptWeekly.RevisionId;
            var TptParameterId = tptWeekly.TptParameterId;
            var Target = tptWeekly.Target;
            var Actual = tptWeekly.Actual;
            var LastYearActual = tptWeekly.LastYearActual;
            var TargetTex = tptWeekly.TargetTex;
            var TagetWil = tptWeekly.TagetWil;
            var ActualTex = tptWeekly.ActualTex;
            var ActualWil = tptWeekly.ActualWil;
            var TptWeek = tptWeekly.TptWeek;
            DataTable data = TPTServices.InsertTptWeekly(Id, TptYear, TptWeek, RevisionId, TptParameterId, Target, Actual, LastYearActual, TargetTex, TagetWil, ActualTex, ActualWil);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptWeekly");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptWeekly");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptWeekly");
            }
        }
        #endregion Weekly
        #region TptPowerSeason
        [HttpGet]
        public ActionResult TptPowerSeason()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult TptPowerSeasonData(string tptRevision, string tptpowerParameter)
        {
            //var data = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptPowerSeason> tptPowerSeason = new List<TptPowerSeason>();
            tptPowerSeason = TPTServices.TptPowerSeason(tptRevision, tptpowerParameter);
            int rowstotal = tptPowerSeason.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptPowerSeason = tptPowerSeason.Where(x => x.TptPowerParameterTptPowerCode.ToLower().Contains(searchvalue.ToLower()) || x.RevisionRevisionName.ToLower().Contains(searchvalue.ToLower()) || x.TptYear.ToString().Contains(searchvalue.ToLower()) || x.Target.ToString().Contains(searchvalue.ToLower()) || x.Actual.ToString().Contains(searchvalue.ToLower()) || x.LastYearActual.ToString().Contains(searchvalue.ToLower()) || x.RevisionId.ToString().Contains(searchvalue.ToLower()) || x.TptPowerParameterId.ToString().Contains(searchvalue.ToLower()) || x.TptPowerSeasonId.ToString().Contains(searchvalue.ToLower())).ToList<TptPowerSeason>();
            }
            int totalrowsafterfiltering = tptPowerSeason.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptPowerSeason = tptPowerSeason.Skip(start).Take(length).ToList<TptPowerSeason>();
            return Json(new { data = tptPowerSeason, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditTptPowerSeason(int id = 0)
        {
            if (id == 0)
                return View(new TptPowerSeason());
            else
            {
                List<TptPowerSeason> tptPowerSeason = new List<TptPowerSeason>();
                //List<Centre> Centerlist = new List<Centre>();
                tptPowerSeason = TPTServices.TptPowerSeason("", "");
                return View(tptPowerSeason.Where(x => x.TptPowerSeasonId == id).FirstOrDefault<TptPowerSeason>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptPowerSeason(TptPowerSeason tptPowerSeason)
        {
            var Id = tptPowerSeason.TptPowerSeasonId;
            var TptYear = tptPowerSeason.TptYear;
            var RevisionId = tptPowerSeason.RevisionId;
            var TptPowerParameterId = tptPowerSeason.TptPowerParameterId;
            var Target = tptPowerSeason.Target;
            var Actual = tptPowerSeason.Actual;
            var LastYearActual = tptPowerSeason.LastYearActual;

            DataTable data = TPTServices.InsertTptPowerSeason(Id, TptYear, RevisionId, TptPowerParameterId, Target, Actual, LastYearActual);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptPowerSeason");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptPowerSeason");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptPowerSeason");
            }
        }
        #endregion TptPowerSeason
        #region TptPowerMonthly
        [HttpGet]
        public ActionResult TptPowerMonthly()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult TptPowerMonthlyData(string tptRevision, string tptpowerParameter)
        {
            //var data = TPTServices.TptRevision(Unit, CreationDate2, CreationDate3, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TptPowerMonthly> tptPowerMonth = new List<TptPowerMonthly>();
            tptPowerMonth = TPTServices.TptPowerMonthly(tptRevision, tptpowerParameter);
            int rowstotal = tptPowerMonth.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                tptPowerMonth = tptPowerMonth.Where(x => x.TptPowerParameterTptPowerCode.ToLower().Contains(searchvalue.ToLower()) || x.RevisionRevisionName.ToLower().Contains(searchvalue.ToLower()) || x.TptYear.ToString().Contains(searchvalue.ToLower()) || x.Target.ToString().Contains(searchvalue.ToLower()) || x.Actual.ToString().Contains(searchvalue.ToLower()) || x.LastYearActual.ToString().Contains(searchvalue.ToLower()) || x.RevisionId.ToString().Contains(searchvalue.ToLower()) || x.TptPowerParameterId.ToString().Contains(searchvalue.ToLower()) || x.TptMonth.ToString().Contains(searchvalue.ToLower())).ToList<TptPowerMonthly>();
            }
            int totalrowsafterfiltering = tptPowerMonth.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            tptPowerMonth = tptPowerMonth.Skip(start).Take(length).ToList<TptPowerMonthly>();
            return Json(new { data = tptPowerMonth, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditTptPowerMonthly(int id = 0)
        {
            if (id == 0)
                return View(new TptPowerMonthly());
            else
            {
                List<TptPowerMonthly> tptPowerMonth = new List<TptPowerMonthly>();
                //List<Centre> Centerlist = new List<Centre>();
                tptPowerMonth = TPTServices.TptPowerMonthly("", "");
                return View(tptPowerMonth.Where(x => x.TptPowerMonthlyId == id).FirstOrDefault<TptPowerMonthly>());
            }

        }
        [HttpPost]
        public ActionResult AddeditTptPowerMonthly(TptPowerMonthly tptPowerMonthly)
        {
            var Id = tptPowerMonthly.TptPowerMonthlyId;
            var TptYear = tptPowerMonthly.TptYear;
            var TptMonth = tptPowerMonthly.TptMonth;
            var RevisionId = tptPowerMonthly.RevisionId;
            var TptPowerParameterId = tptPowerMonthly.TptPowerParameterId;
            var Target = tptPowerMonthly.Target;
            var Actual = tptPowerMonthly.Actual;
            var LastYearActual = tptPowerMonthly.LastYearActual;

            DataTable data = TPTServices.InsertTptPowerMonthly(Id, TptYear, TptMonth, RevisionId, TptPowerParameterId, Target, Actual, LastYearActual);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("TptPowerMonthly");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("TptPowerMonthly");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("TptPowerMonthly");
            }
        }
        #endregion TptPowerMonthly
    }
}