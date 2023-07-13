using KnowledgeApp_Test.Models.SpecialAnalysis;
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
    public class SpecialAnalysisController : Controller
    {
        SpecialAnalysisServices SpecialAnalysisServices = new SpecialAnalysisServices();
        DropdownListSevices DropdownListSevices = new DropdownListSevices();
        // GET: SpecialAnalysis
        #region SpecialAnalysisType
        [HttpGet]
        public ActionResult SpecialAnalysisType()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSpecialAnalysisType(int id=0) 
        {
            if (id == 0)
                return View(new SpecialAnalysisType());
            else
            {
                List<SpecialAnalysisType> dateConfiguration = new List<SpecialAnalysisType>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = SpecialAnalysisServices.SpecialAnalysisType();
                return View(dateConfiguration.Where(x => x.SpecialAnalysisTypeId == id).FirstOrDefault<SpecialAnalysisType>());

            }
        }
        [HttpPost]
        public ActionResult AddeditSpecialAnalysisType(SpecialAnalysisType specialAnalysisType)
        {
            var Id = specialAnalysisType.SpecialAnalysisTypeId;
            var Code = specialAnalysisType.SpecialAnalysisTypeCode;
            var Name = specialAnalysisType.SpecialAnalysisTypeName;
            var Isperiodic = specialAnalysisType.IsPeriodic;
            var Startrow = specialAnalysisType.StartRowNumber;
            var ExcelTemplateName = specialAnalysisType.ExcelTemplateName;
            var DateRow = specialAnalysisType.DateRow;
            var DateColumn = specialAnalysisType.DateColumn;

            DataTable data = SpecialAnalysisServices.InsertSpecialAnalysisType(Id,Code,Name,Isperiodic,Startrow,ExcelTemplateName,DateRow,DateColumn);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SpecialAnalysisType");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SpecialAnalysisType");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("SpecialAnalysisType");
            }
        }
        [HttpPost]
        public JsonResult SpecialAnalysisTypeData()
        {
            //var data = SpecialAnalysisServices.SpecialAnalysisType();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SpecialAnalysisType> specialAnalysisType = new List<SpecialAnalysisType>();
            specialAnalysisType = SpecialAnalysisServices.SpecialAnalysisType();
            int rowstotal = specialAnalysisType.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                specialAnalysisType = specialAnalysisType.Where(x => x.SpecialAnalysisTypeName.ToLower().Contains(searchvalue.ToLower()) || x.SpecialAnalysisTypeId.ToString().Contains(searchvalue.ToLower()) || x.IsPeriodic.ToString().Contains(searchvalue.ToLower()) || x.StartRowNumber.ToString().Contains(searchvalue.ToLower()) || x.DateRow.ToString().Contains(searchvalue.ToLower())||x.DateColumn.ToString().Contains(searchvalue.ToLower())||x.ExcelTemplateName.ToLower().Contains(searchvalue.ToLower())).ToList<SpecialAnalysisType>();

            }
            int totalrowsafterfiltering = specialAnalysisType.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            specialAnalysisType = specialAnalysisType.Skip(start).Take(length).ToList<SpecialAnalysisType>();
            return Json(new { data = specialAnalysisType, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion SpecialAnalysisType
        #region SpecialAnalysisParameter
        [HttpGet]
        public ActionResult SpecialAnalysisParameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSpecialAnalysisParameter(int id=0)
        {

            if (id == 0)
                return View(new SpecialAnalysisParameter());
            else
            {
                List<SpecialAnalysisParameter> specialAnalysisParameter = new List<SpecialAnalysisParameter>();
                //List<Centre> Centerlist = new List<Centre>();
                specialAnalysisParameter = SpecialAnalysisServices.SpecialAnalysisParameter("");
                return View(specialAnalysisParameter.Where(x => x.SpecialAnalysisTypeId == id).FirstOrDefault<SpecialAnalysisParameter>());

            }
        }
        [HttpPost]
        public ActionResult AddeditSpecialAnalysisParameter(SpecialAnalysisParameter specialAnalysisParameter)
        {
            var Id = specialAnalysisParameter.SpecialAnalysisParameterId;
            var Code = specialAnalysisParameter.SpecialAnalysisParameterCode;
            var Name = specialAnalysisParameter.SpecialAnalysisParameterName;
            var IsInput = specialAnalysisParameter.IsInput;
            var SATId = specialAnalysisParameter.SpecialAnalysisParameterId;
            var Formula = specialAnalysisParameter.Formula;
            var DataType = specialAnalysisParameter.DataType;
            var ShortName = specialAnalysisParameter.ShortName;
            var DescriptiveFormula = specialAnalysisParameter.DescriptiveFormula;
            var RowNumber = specialAnalysisParameter.RowNumber;
            var ColumnNumber = specialAnalysisParameter.ColumnNumber;
            var CalculationLevel = specialAnalysisParameter.CalculationLevel;
            DataTable data = SpecialAnalysisServices.InsertSpecialAnalysisTypeParameter(Id, Code, Name, IsInput, SATId, Formula, DataType, ShortName, DescriptiveFormula, RowNumber, ColumnNumber, CalculationLevel);


            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SpecialAnalysisParameter");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SpecialAnalysisParameter");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("SpecialAnalysisParameter");
            }


        }
            [HttpPost]
        public JsonResult SpecialAnalysisParameterData( string SpecialAnalysisType)
        {
            //var data = SpecialAnalysisServices.SpecialAnalysisParameter(SpecialAnalysisType);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SpecialAnalysisParameter> specialAnalysisParameter = new List<SpecialAnalysisParameter>();
            specialAnalysisParameter = SpecialAnalysisServices.SpecialAnalysisParameter(SpecialAnalysisType);
            int rowstotal = specialAnalysisParameter.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                specialAnalysisParameter = specialAnalysisParameter.Where(x => x.SpecialAnalysisParameterCode.ToLower().Contains(searchvalue.ToLower()) || x.SpecialAnalysisTypeSpecialAnalysisTypeName.ToLower().Contains(searchvalue.ToLower()) || x.SpecialAnalysisTypeId.ToString().Contains(searchvalue.ToLower()) || x.DataType.ToString().Contains(searchvalue.ToLower()) || x.RowNumber.ToString().Contains(searchvalue.ToLower()) || x.ColumnNumber.ToString().Contains(searchvalue.ToLower()) || x.Formula.ToLower().Contains(searchvalue.ToLower()) || x.DescriptiveFormula.ToLower().Contains(searchvalue.ToLower()) || x.ShortName.ToLower().Contains(searchvalue.ToLower()) || x.CalculationLevel.ToString().Contains(searchvalue.ToLower())).ToList<SpecialAnalysisParameter>();

            }
            int totalrowsafterfiltering = specialAnalysisParameter.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            specialAnalysisParameter = specialAnalysisParameter.Skip(start).Take(length).ToList<SpecialAnalysisParameter>();
            return Json(new { data = specialAnalysisParameter, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion SpecialAnalysis 
        #region SpecialAnalysis
        [HttpGet]
        public ActionResult SpecialAnalysis()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSpecialAnalysis(int id=0)
        {
            //suresh_11102022
            TempData["Special"] = id;
            if (id == 0)
            {
                return View(new SpecialAnalysis());
            }
            else
            {
                List<SpecialAnalysis> specialAnalysis = new List<SpecialAnalysis>();
                //List<Centre> Centerlist = new List<Centre>();
                specialAnalysis = SpecialAnalysisServices.SpecialAnalysis("");
                return View(specialAnalysis.Where(x => x.SpecialAnalysisId == id).FirstOrDefault<SpecialAnalysis>());

            }
           
        }
        [HttpPost]
        public ActionResult AddeditSpecialAnalysis(SpecialAnalysis SpecialAnalysis)
        { //suresh_11102022
            var Id = SpecialAnalysis.SpecialAnalysisId;
            var AnalysisDate = SpecialAnalysis.AnalysisDate;
            var SpecialAnalysisTypeId = SpecialAnalysis.SpecialAnalysisTypeId;
            var EntryUserId = SpecialAnalysis.EntryUserId;
            var EntryDate = SpecialAnalysis.EntryDate;

            DataTable data = SpecialAnalysisServices.InsertAddeditSpecialAnalysis(Id, AnalysisDate, SpecialAnalysisTypeId, EntryUserId, EntryDate);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SpecialAnalysis");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SpecialAnalysis");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("SpecialAnalysis");
            }
        }

        [HttpGet]
        public ActionResult AddeditSpecialAnalysisDetails(int id=0)
        {
            ViewBag.SpecialAnalysis = TempData["Special"];//suresh_11102022 
          //  ViewBag.SpecialAnalysisTypeId = SpecialAnalysisTypeId;
            if (id == 0)
                return View(new SpecialAnalysisDetails());
            else
            {
                List<SpecialAnalysisDetails> SpecialAnalysisDetails = new List<SpecialAnalysisDetails>();
                //List<Centre> Centerlist = new List<Centre>();
                SpecialAnalysisDetails = SpecialAnalysisServices.SpecialAnalysisDetails("","");
                return View(SpecialAnalysisDetails.Where(x => x.SpecialAnalysisDetilsId == id).FirstOrDefault<SpecialAnalysisDetails>());

            }
          
        }
        [HttpPost]
        public ActionResult AddeditSpecialAnalysisDetails(SpecialAnalysisDetails SpecialAnalysisDetails)
        { //suresh_11102022
            var SpecialAnalysisId = SpecialAnalysisDetails.SpecialAnalysisId;
            var SpecialAnalysisDetilsId = SpecialAnalysisDetails.SpecialAnalysisDetilsId;
            var SerialNumber = SpecialAnalysisDetails.SerialNumber;
            var SpecialAnalysisParameterID = SpecialAnalysisDetails.SpecialAnalysisParameterID;
            var AnalysisValue = SpecialAnalysisDetails.AnalysisValue;
          
            DataTable data = SpecialAnalysisServices.InsertAddeditSpecialAnalysisDetails(SpecialAnalysisId, SpecialAnalysisDetilsId, SerialNumber, SpecialAnalysisParameterID, AnalysisValue);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SpecialAnalysis");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SpecialAnalysis");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("SpecialAnalysis");
            }


        }
        [HttpPost]
        public JsonResult SpecialAnalysisData(string SpecialAnalysisType)
        {
            //var data = SpecialAnalysisServices.SpecialAnalysis(SpecialAnalysisType);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SpecialAnalysis> specialAnalysis = new List<SpecialAnalysis>();
            specialAnalysis = SpecialAnalysisServices.SpecialAnalysis(SpecialAnalysisType);
            int rowstotal = specialAnalysis.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                specialAnalysis = specialAnalysis.Where(x => x.SpecialAnalysisTypeName.ToLower().Contains(searchvalue.ToLower()) || x.SpecialAnalysisTypeId.ToString().Contains(searchvalue.ToLower()) || x.AnalysisDate.ToString().Contains(searchvalue.ToLower()) || x.EntryUserId.ToString().Contains(searchvalue.ToLower()) || x.EntryDate.ToString().Contains(searchvalue.ToLower()) ||x.SpecialAnalysisId.ToString().Contains(searchvalue.ToLower())).ToList<SpecialAnalysis>();
            }
            int totalrowsafterfiltering = specialAnalysis.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            specialAnalysis = specialAnalysis.Skip(start).Take(length).ToList<SpecialAnalysis>();
            return Json(new { data = specialAnalysis, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SpecialAnalysisDetailsData(string SpecialAnalysisParameter,string Specilanalysis)
        {
            //var data = SpecialAnalysisServices.SpecialAnalysis(SpecialAnalysisType);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SpecialAnalysisDetails> specialAnalysis = new List<SpecialAnalysisDetails>();
            specialAnalysis = SpecialAnalysisServices.SpecialAnalysisDetails(Specilanalysis, SpecialAnalysisParameter);
            int rowstotal = specialAnalysis.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                specialAnalysis = specialAnalysis.Where(x => x.SpecialAnalysisDetilsId.ToString().Contains(searchvalue.ToLower()) || x.SpecialAnalysisId.ToString().Contains(searchvalue.ToLower()) || x.SpecialAnalysisParameterName.ToLower().Contains(searchvalue.ToLower()) || x.AnalysisValue.ToString().Contains(searchvalue.ToLower()) || x.SerialNumber.ToString().Contains(searchvalue.ToLower()) || x.SpecialAnalysisId.ToString().Contains(searchvalue.ToLower())).ToList<SpecialAnalysisDetails>();
            }
            int totalrowsafterfiltering = specialAnalysis.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            specialAnalysis = specialAnalysis.Skip(start).Take(length).ToList<SpecialAnalysisDetails>();
            return Json(new { data = specialAnalysis, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion SpecialAnalysis
    }

}