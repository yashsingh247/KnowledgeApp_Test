using KnowledgeApp_Test.Models.BenchMarking;
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
    public class BenchMarkingController : Controller
    {
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        BenchMarkingServices benchMarkingservices = new BenchMarkingServices();
        #region BenchMarkParameter
        // GET: BenchMarking
        [HttpGet]
        public ActionResult BenchMarkParameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult BenchMarkParameterData(string Parameter,string ParameterUnit)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<BenchMarkParameter> benchMark = new List<BenchMarkParameter>();
            benchMark = benchMarkingservices.BenchMarkParameter(Parameter, ParameterUnit);
            int rowstotal = benchMark.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                benchMark = benchMark.Where(x => x.BenchMarkParameterId.ToString().Contains(searchvalue.ToLower()) || x.BenchMarkName.ToLower().Contains(searchvalue.ToLower()) || x.BenchMarkCode.ToString().Contains(searchvalue.ToLower()) || x.BenchMarkType.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterUnitId.ToString().Contains(searchvalue.ToLower()) || x.RowNumber.ToString().Contains(searchvalue.ToLower())).ToList<BenchMarkParameter>();
            }
            int totalrowsafterfiltering = benchMark.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            benchMark = benchMark.Skip(start).Take(length).ToList<BenchMarkParameter>();
            return Json(new { data = benchMark, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditBenchMarkParameter(int id=0) 
        {

            if (id == 0)
            {

                return View(new BenchMarkParameter());
            }
            else
            {
                List<BenchMarkParameter> daily = new List<BenchMarkParameter>();
                //List<Centre> Centerlist = new List<Centre>();
                daily = benchMarkingservices.BenchMarkParameter("", "");
                return View(daily.Where(x => x.BenchMarkParameterId == id).FirstOrDefault<BenchMarkParameter>());
            }
        }
        [HttpPost]
        public ActionResult AddeditBenchMarkParameter(BenchMarkParameter benchMarkParameter)
        {
            var Id = benchMarkParameter.BenchMarkParameterId;
            var BenchMarkName = benchMarkParameter.BenchMarkName;
            var BenchMarkCode = benchMarkParameter.BenchMarkCode;
            var PId = benchMarkParameter.ParameterId;
            var PuId = benchMarkParameter.ParameterUnitId;
            var BMType = benchMarkParameter.BenchMarkType;
            var RowNo = benchMarkParameter.RowNumber;
            DataTable data = benchMarkingservices.BenchMarkParameter(Id, BenchMarkName, BenchMarkCode, PId, PuId, BMType, RowNo);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("BenchMarkParameter");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("BenchMarkParameter");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                return RedirectToAction("BenchMarkParameter");

            }
        }
        #endregion BenchMarkParameter
        #region Yearly
        public ActionResult YearlyBenchMark()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult YearlyBenchMarkData(string BenchMark)
        {
           
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<YearlyBenchMark> YearlyBenchMark = new List<YearlyBenchMark>();
            YearlyBenchMark = benchMarkingservices.YearlyBenchMark(BenchMark);
            int rowstotal = YearlyBenchMark.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                YearlyBenchMark = YearlyBenchMark.Where(x => x.YearlyBenchMarkId.ToString().Contains(searchvalue.ToLower()) || x.BenchMarkParameterId.ToString().Contains(searchvalue.ToLower()) || x.BenchMarkCode.ToString().Contains(searchvalue.ToLower()) || x.ApplicableYear.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.YearSerial.ToString().Contains(searchvalue.ToLower()) || x.RowNumber.ToString().Contains(searchvalue.ToLower())).ToList<YearlyBenchMark>();
            }
            int totalrowsafterfiltering = YearlyBenchMark.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            YearlyBenchMark = YearlyBenchMark.Skip(start).Take(length).ToList<YearlyBenchMark>();
            return Json(new { data = YearlyBenchMark, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditYearlyBenchMarkParameter(int id = 0)
        {
            if (id == 0)
            {
                return View(new YearlyBenchMark());
            }
            else
            {
                List<YearlyBenchMark> daily = new List<YearlyBenchMark>();
                //List<Centre> Centerlist = new List<Centre>();
                daily = benchMarkingservices.YearlyBenchMark("");
                return View(daily.Where(x => x.YearlyBenchMarkId == id).FirstOrDefault<YearlyBenchMark>());
            }
        }
        [HttpPost]
        public ActionResult AddeditYearlyBenchMarkParameter(YearlyBenchMark yearlyBenchMark)
        {
            if (yearlyBenchMark.YearSerial==0)
            {
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Please Select Year Serial");
                return RedirectToAction("YearlyBenchMark");
            }
            var Id = yearlyBenchMark.YearlyBenchMarkId;
            var BMPId = yearlyBenchMark.BenchMarkParameterId;
            var YearSerial = yearlyBenchMark.YearSerial;
            var APPYear = yearlyBenchMark.ApplicableYear;
            var AppValue = yearlyBenchMark.ApplicableValue;
            DataTable data = benchMarkingservices.InsertYearlyBenchMarkParameter(Id, BMPId, YearSerial, APPYear, AppValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("YearlyBenchMark");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("YearlyBenchMark");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                return RedirectToAction("YearlyBenchMark");

            }
        }

        #endregion Yearly
    }
}