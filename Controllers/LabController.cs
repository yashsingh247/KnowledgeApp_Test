using KnowledgeApp_Test.Models.General;
using KnowledgeApp_Test.Models.Lab;
using KnowledgeApp_Test.Models.Parameters;
using KnowledgeApp_Test.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{

    public class LabController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        LabService labService = new LabService();
        #region SampleSlip
        [HttpGet]
        public ActionResult SampleSlip()
        {
            Daily daily = new Daily();
            daily.EntryDate = DateTime.Now;
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSampleSlip(int id=0)
        {
            if (id == 0)
            {

                return View(new SampleSlip());
            }
            else
            {
                List<SampleSlip> parameter = new List<SampleSlip>();
                //List<Centre> Centerlist = new List<Centre>();
                parameter = labService.SampleSlip("","");
                return View(parameter.Where(x => x.SampleSlipId == id).FirstOrDefault<SampleSlip>());
            }
        }
        [HttpPost]
        public ActionResult AddeditSampleSlip(SampleSlip sampleSlip)
        {
            var Id = sampleSlip.SampleSlipId;
            var SampleSlipNo = sampleSlip.SampleSlipNumber;
            var UnitId = sampleSlip.UnitId;
            var sampleslipdate = sampleSlip.SampleSlipDate;
            var GrowerID = sampleSlip.GrowerId;
            var VarietyID = sampleSlip.VarietyId;
            var SlipTyple = sampleSlip.SlipTyple;

            var BRIX = sampleSlip.Brix;
            var POL = sampleSlip.Pol;
            var JAVARatio = sampleSlip.JavaRatio;
            var LOSSES = sampleSlip.Losses;
            var VillageID = sampleSlip.VillageId;
            DataTable data = labService.InsertSampleSlip(Id,UnitId,SampleSlipNo,sampleslipdate,GrowerID,VarietyID,SlipTyple,BRIX,POL,JAVARatio,LOSSES,VillageID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {


                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("SampleSlip");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("SampleSlip");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
               return RedirectToAction("SampleSlip");

            }
        }

            [HttpPost]
        public JsonResult SampleSlipData(string Unit,string SampleSlipDate2)
        {
            //var data = labService.SampleSlip(Unit, SampleSlipDate2, SampleSlipDate3);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SampleSlip> sampleSlip = new List<SampleSlip>();
            sampleSlip = labService.SampleSlip(Unit, SampleSlipDate2);
            int rowstotal = sampleSlip.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                sampleSlip = sampleSlip.Where(x => x.   SampleSlipId.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.SampleSlipDate.ToString().Contains(searchvalue.ToLower()) || x.SampleSlipNumber.ToString().Contains(searchvalue.ToLower()) || x.GrowerId.ToString().Contains(searchvalue.ToLower()) || x.VarietyId.ToString().Contains(searchvalue.ToLower()) || x.SlipTyple.ToString().Contains(searchvalue.ToLower()) || x.Brix.ToString().Contains(searchvalue.ToLower()) || x.Pol.ToString().Contains(searchvalue.ToLower()) || x.JavaRatio.ToString().Contains(searchvalue.ToLower()) || x.Losses.ToString().Contains(searchvalue.ToLower())).ToList<SampleSlip>();


            }
            int totalrowsafterfiltering = sampleSlip.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            sampleSlip = sampleSlip.Skip(start).Take(length).ToList<SampleSlip>();
            return Json(new { data = sampleSlip, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion sampleslip
        #region Stock
        public ActionResult Stock()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult StockData(string Unit, string Parameter, string CrushingSeason)
        {
            //var data = labService.Stock(Unit, Parameter, CrushingSeason);
            //var data = benchMarkingservices.BenchMarkParameter(Parameter, ParameterUnit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Stock> Stock = new List<Stock>();
            Stock = labService.Stock(Unit, Parameter, CrushingSeason);
            int rowstotal = Stock.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                Stock = Stock.Where(x => x.StockId.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.EntryDate.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.DayValue.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower())).ToList<Stock>();
            }
            int totalrowsafterfiltering = Stock.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            Stock = Stock.Skip(start).Take(length).ToList<Stock>();
            return Json(new { data = Stock, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditStock(int id=0)
        {
            if (id == 0)
            {
                return View(new Stock());
            }
            else {
                List<Stock> stock = new List<Stock>();
                //List<Centre> Centerlist = new List<Centre>();
                stock = labService.Stock("", "", "");
                return View(stock.Where(x => x.StockId == id).FirstOrDefault<Stock>());
            }
        }
        [HttpPost]
        public ActionResult AddeditStock(Stock stock)
        {
            var Id = stock.StockId;
            var EntryDate = stock.EntryDate;
            var Unit = stock.UnitId;
            var ParameterID = stock.ParameterId;
            var CrushingId = stock.CrushingSeasonId;
            var DayValue = stock.DayValue;
            DataTable data = labService.InsertStck(Id, EntryDate, Unit, ParameterID, CrushingId, DayValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {


                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("Stock");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("Stock");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
               return RedirectToAction("Stock");

            }
        }
        #endregion
        #region StoppageEntry
        public ActionResult StoppageEntry(int EntryTypeId=0)
        {
            var paramtypes = new List<ParameterTypeModel>();
            var ptypes = labService.EntryParameterType(EntryTypeId, 2);
                var ptype = new ParameterTypeModel();
                int PrevPTypeID = 0;

                foreach (var item in ptypes)
                {
                    if (PrevPTypeID == 0 || PrevPTypeID != item.ParameterTypeId)
                    {
                        if (PrevPTypeID != 0) paramtypes.Add(ptype);
                        ptype = new ParameterTypeModel();
                        ptype.TabClass = "";
                        ptype.TabPaneClass = "tab-pane";
                        if (PrevPTypeID == 0)
                        {
                            ptype.TabClass = "active";
                            ptype.TabPaneClass = "tab-pane active box";
                        }
                        ptype.ParameterTypeID = item.ParameterTypeId;
                        ptype.ParameterTypeName = item.ParameterTypeParameterTypeName;
                        ptype.ParameterTypeCode = item.ParameterTypeCode;
                        ptype.ParameterList = new List<Parameter>();
                        ptype.ParameterList.Add(new Parameter
                        {
                            ParameterId = item.ParameterId,
                            ParameterCode = item.ParameterCode,
                            ParameterName = item.ParameterName,
                            MinimumValue = item.MinimumValue,
                            MaximumValue = item.MaximumValue
                        });
                    }
                    else
                    {
                        ptype.ParameterList.Add(new Parameter
                        {
                            ParameterId = item.ParameterId,
                            ParameterCode = item.ParameterCode,
                            ParameterName = item.ParameterName,
                            MinimumValue = item.MinimumValue,
                            MaximumValue = item.MaximumValue
                        });
                    }
                    PrevPTypeID = item.ParameterTypeId;
                }
                if (PrevPTypeID != 0) paramtypes.Add(ptype);
                ViewBag.EntryHour = new List<Stoppage>();


                foreach (var ptype_item in paramtypes)
                {
                    var Counter = 0;
                    var remainder = 0;

                    ptype_item.tablehtml = "";
                    ptype_item.tablehtml += "<table id='tblPara" + ptype_item.ParameterTypeID + "' class='table table-bordered'>";

                    foreach (var parameter_item in ptype_item.ParameterList)
                    {
                        remainder = (Counter % 2);

                        if (Counter == 0)
                        {
                            ptype_item.tablehtml += "<tr>";
                        }
                        if (Counter > 0 && remainder == 0)
                        {
                            ptype_item.tablehtml += "</tr><tr>";
                        }

                        ptype_item.tablehtml += "<td>" + parameter_item.ParameterName + "</td>";
                        ptype_item.tablehtml += "<td class='columnName'><input type='text' class='parametervalueclass' id='"
                            + parameter_item.ParameterId + "'><input type='hidden' class='parameterid' value='"
                            + parameter_item.ParameterId + "'/></td>";
                        Counter++;
                    }
                    ptype_item.tablehtml += "</tr></table>";
                }
                return View(paramtypes);
            //}
        }
        #endregion StoppageEntry
        #region Daily
        [HttpGet]
        public ActionResult Daily()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditDaily(int id=0)
        { 
            if(id==0)
            {

                return View(new Daily());
            }
            else
            {
                List<Daily> daily = new List<Daily>();
                //List<Centre> Centerlist = new List<Centre>();
                daily = labService.Daily("", "", "","","");
                return View(daily.Where(x => x.DailyId == id).FirstOrDefault<Daily>());
            }
        }
            [HttpPost]
        public JsonResult DailyData(string EntryDate,string EntryDate2, string Unit, string Parameter, string CrushingSeason)
         {
           // var data = labService.Daily(EntryDate, EntryDate2,Unit, Parameter, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Daily> daily = new List<Daily>();
            daily = labService.Daily(EntryDate, EntryDate2, Unit, Parameter, CrushingSeason);
            int rowstotal = daily.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                daily = daily.Where(x => x.DailyId.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.EntryDate.ToString().Contains(searchvalue.ToLower()) || x.DayValue.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.TodateValue.ToString().Contains(searchvalue.ToLower()) || x.PrevDayValue.ToString().Contains(searchvalue.ToLower()) || x.PrevTodateValue.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToString().Contains(searchvalue.ToLower())).ToList<Daily>();


            }
            int totalrowsafterfiltering = daily.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            daily = daily.Skip(start).Take(length).ToList<Daily>();
            return Json(new { data = daily, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddeditDaily(Daily daily)
        {
            var Id = daily.DailyId;
            var EntryDate = daily.EntryDate;
            var UnitID = daily.UnitId;
            var ParameterID = daily.ParameterId;
            var CrushingSeasonID = daily.CrushingSeasonId;
            var DayValue = daily.DayValue;
            var TodateValue = daily.TodateValue;
            var PrevDayValue = daily.PrevDayValue;
            var PrevTodateValue = daily.PrevTodateValue;
            DataTable data = labService.InsertDaily(Id,EntryDate,UnitID,ParameterID,CrushingSeasonID,DayValue,TodateValue,PrevDayValue,PrevTodateValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {


                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("Daily");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("Daily");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
               return RedirectToAction("Daily");

            }
        }


        #endregion Daily
        #region Hourly
        public ActionResult Hourly()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        public JsonResult HourData(string EntryDate, string EntryDate2, string Unit, string Parameter, string CrushingSeason)
        {
            //var data = labService.Hour(EntryDate, EntryDate2, Unit, Parameter, CrushingSeason);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Hourly> hourly = new List<Hourly>();
            hourly = labService.Hour(EntryDate, EntryDate2, Unit, Parameter, CrushingSeason);
            int rowstotal = hourly.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                hourly = hourly.Where(x => x.HourlyId.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.EntryDate.ToString().Contains(searchvalue.ToLower()) || x.DayValue.ToString().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.HourValue.ToString().Contains(searchvalue.ToLower()) || x.PrevDayValue.ToString().Contains(searchvalue.ToLower()) || x.PrevHourValue.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonName.ToString().Contains(searchvalue.ToLower()) || x.EntryHour.ToString().Contains(searchvalue.ToLower())).ToList<Hourly>();
            }
            int totalrowsafterfiltering = hourly.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            hourly = hourly.Skip(start).Take(length).ToList<Hourly>();
            return Json(new { data = hourly, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditHourly(int id=0)
        {
            if (id == 0)
            {

                return View(new Hourly());
            }
            else
            {
                List<Hourly> hourly = new List<Hourly>();
                //List<Centre> Centerlist = new List<Centre>();
                hourly = labService.Hour("", "", "","","");
                return View(hourly.Where(x => x.HourlyId == id).FirstOrDefault<Hourly>());
            }
        }
        [HttpPost]
        public ActionResult AddeditHourly(Hourly hourly)
        {
            var Id = hourly.HourlyId;
            var EntryDate = hourly.EntryDate;
            var EntryHour = hourly.EntryHour;
            var UnitID = hourly.UnitId;
            var ParameterID = hourly.ParameterId;
            var CrushingSeasonID = hourly.CrushingSeasonId;
            var DayValue = hourly.DayValue;
            var HourValue = hourly.HourValue;
            var PrevHourValue = hourly.PrevHourValue;
            var PrevDayValue = hourly.PrevDayValue;
            DataTable data = labService.InsertHourly(Id,EntryDate,EntryHour,UnitID,ParameterID,CrushingSeasonID,HourValue,DayValue,PrevHourValue,PrevDayValue);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                   return RedirectToAction("Hourly");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                   return RedirectToAction("Hourly");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
               return RedirectToAction("Hourly");

            }
        }
        #endregion Hourly
        #region FormulaEntry
        [HttpGet]
        public ActionResult FormulaEntry()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public ActionResult FormulaEntry(FormulaEntry formulaEntry)
        {
            if (formulaEntry.ParameterID == 0) 
            {
                return View(formulaEntry);
            }
            var ParameterID = formulaEntry.ParameterID;
            var FormulaType = formulaEntry.FormulaType;
            var Formula = formulaEntry.ModifiedFormula;

            DataTable data = labService.InsertFormula(FormulaType, ParameterID, Formula);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {


                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("FormulaEntry");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("FormulaEntry");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong........");
                return RedirectToAction("FormulaEntry");

            }
        }
        [HttpPost]
        public JsonResult ParameterFormulaData(int FormulaType,int ParameterId) 
        {
            var ParameterFormula = labService.Formula(FormulaType, ParameterId);
            return Json(ParameterFormula, JsonRequestBehavior.AllowGet);
        }
        #endregion FormulaEntry
        #region HourlyEntry
        public ActionResult HourlyEntry(int EntryTypeId) 
        {
            TempData["Name"] = labService.Entryname(EntryTypeId);
            var paramtypes = new List<ParameterTypeModel>();
            //con.Query<Parameter>("GetAllInputParameter 1",commandType: System.Data.CommandType.StoredProcedure);
            var ptypes = labService.EntryParameterType(EntryTypeId,1);


            var ptype=new ParameterTypeModel();
            int PrevPTypeID = 0;

            foreach (var item in ptypes)
            {
                //counterParameter = 0;
                if (PrevPTypeID == 0 || PrevPTypeID != item.ParameterTypeId)
                {
                    if (PrevPTypeID != 0) paramtypes.Add(ptype);
                    ptype = new ParameterTypeModel();
                    ptype.TabClass = "";
                    ptype.TabPaneClass = "tab-pane";
                    if (PrevPTypeID == 0)
                    {
                        ptype.TabClass = "active";
                        ptype.TabPaneClass = "tab-pane active box";
                    }
                    ptype.ParameterTypeID = item.ParameterTypeId;
                    ptype.ParameterTypeName = item.ParameterTypeParameterTypeName;
                    ptype.ParameterTypeCode = item.ParameterTypeCode;
                    ptype.ParameterList = new List<Parameter>();
                    ptype.ParameterList.Add(new Parameter
                    {
                        ParameterId = item.ParameterId,
                        ParameterCode = item.ParameterCode,
                        ParameterName = item.ParameterName,
                        MinimumValue = item.MinimumValue,
                        MaximumValue = item.MaximumValue
                    });

                }
                else
                {
                    ptype.ParameterList.Add(new Parameter
                    {
                        ParameterId = item.ParameterId,
                        ParameterCode = item.ParameterCode,
                        ParameterName = item.ParameterName,
                        MinimumValue = item.MinimumValue,
                        MaximumValue = item.MaximumValue
                    });


                }

                PrevPTypeID = item.ParameterTypeId;
            }

            if (PrevPTypeID != 0) paramtypes.Add(ptype);
            ViewBag.EntryHour = new List<Hourly>();
       

            foreach (var ptype_item in paramtypes)
            {
                var Counter = 0;
                var remainder = 0;

                 ptype_item.tablehtml = "";
                ptype_item.tablehtml += "<table id='tblPara" + ptype_item.ParameterTypeID + "' class='table table-bordered'>";

                // remainderParamList = (ptype_item.ParameterList.Count % 2);
                foreach (var parameter_item in ptype_item.ParameterList)
                {

                    remainder = (Counter % 2);

                    if (Counter == 0)
                    {
                        ptype_item.tablehtml += "<tr>";
                    }

                    if (Counter > 0 && remainder == 0)
                    {
                        ptype_item.tablehtml += "</tr><tr>";
                    }

                ptype_item.tablehtml += "<td>" + parameter_item.ParameterName + "</td>";
                ptype_item.tablehtml += "<td class='columnName'><input type='text' class='parametervalueclass' id='"
                + parameter_item.ParameterId + "'><input type='hidden' class='parameterid' value='"
                 + parameter_item.ParameterId + "'/></td>";
                    Counter++;

                }
                //if (remainderParamList != 0)
                //{
                //    ptype_item.tablehtml += "<td></td><td></td>";
                //}
                ptype_item.tablehtml += "</tr></table>";
            }
            return View(paramtypes);
        }
        public JsonResult AllParameterHourValue(DateTime EntryDate,int EntryHour, int UnitId )
        {
            var data = labService.GetEntryHour(EntryDate, EntryHour, UnitId);
            return Json(data);
        }
        [HttpPost]
        public JsonResult SaveAllHaourEntry(List<paramList> jsonData)
        {
            if (jsonData != null)
            {
                try
                {
                    foreach (var item in jsonData)
                    {
                        var EntryDate = item.EntryDate;
                        var EntryHour = item.EntryHour;
                        var UnitId = item.UnitId;
                        var ParameterID = item.ParameterID;
                        var HourValue = item.HourValue;
                        data = labService.InsertHourlyEntryParameter(EntryDate, EntryHour, UnitId, ParameterID, HourValue);
                        if (data.Rows.Count > 0 && data != null)
                        {
                            string status = data.Rows[0]["status"].ToString();
                            string message = data.Rows[0]["msg"].ToString();
                            if (status == "0" && status == "")
                            {
                                //return Json(data, JsonRequestBehavior.AllowGet);
                                break;

                            }

                        }
                        else
                        {

                        }
                    }
                    // return Json(data, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                bool mess = true;
                string alertmess = mess ? "Data Inserted" : "Failed";
                return Json(alertmess);
                //return Json(new { result = data }, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                bool mess = false;
                string alertmess = mess ? "Data Not Inserted" : "Please Enter A Correct Value";
                return Json(alertmess);
            }
        }
       
        #endregion HourlyEntry
        #region DailyEntry
        public ActionResult DailyEntry(int EntryTypeId) 
        {
            TempData["Name"] = labService.Entryname(EntryTypeId);
            var paramtypes = new List<ParameterTypeModel>();
            //con.Query<Parameter>("GetAllInputParameter 1",commandType: System.Data.CommandType.StoredProcedure);
            var ptypes = labService.EntryParameterType(EntryTypeId,1);


            var ptype = new ParameterTypeModel();
            int PrevPTypeID = 0;

            foreach (var item in ptypes)
            {
                //counterParameter = 0;
                if (PrevPTypeID == 0 || PrevPTypeID != item.ParameterTypeId)
                {
                    if (PrevPTypeID != 0) paramtypes.Add(ptype);
                    ptype = new ParameterTypeModel();
                    ptype.TabClass = "";
                    ptype.TabPaneClass = "tab-pane";
                    if (PrevPTypeID == 0)
                    {
                        ptype.TabClass = "active";
                        ptype.TabPaneClass = "tab-pane active box";
                    }
                    ptype.ParameterTypeID = item.ParameterTypeId;
                    ptype.ParameterTypeName = item.ParameterTypeParameterTypeName;
                    ptype.ParameterTypeCode = item.ParameterTypeCode;
                    ptype.ParameterList = new List<Parameter>();
                    ptype.ParameterList.Add(new Parameter
                    {
                        ParameterId = item.ParameterId,
                        ParameterCode = item.ParameterCode,
                        ParameterName = item.ParameterName,
                        MinimumValue = item.MinimumValue,
                        MaximumValue = item.MaximumValue
                    });

                }
                else
                {
                    ptype.ParameterList.Add(new Parameter
                    {
                        ParameterId = item.ParameterId,
                        ParameterCode = item.ParameterCode,
                        ParameterName = item.ParameterName,
                        MinimumValue = item.MinimumValue,
                        MaximumValue = item.MaximumValue
                    });


                }

                PrevPTypeID = item.ParameterTypeId;
            }

            if (PrevPTypeID != 0) paramtypes.Add(ptype);
            ViewBag.EntryHour = new List<Hourly>();


            foreach (var ptype_item in paramtypes)
            {
                var Counter = 0;
                var remainder = 0;

                ptype_item.tablehtml = "";
                ptype_item.tablehtml += "<table id='tblPara" + ptype_item.ParameterTypeID + "' class='table table-bordered'>";

                // remainderParamList = (ptype_item.ParameterList.Count % 2);
                foreach (var parameter_item in ptype_item.ParameterList)
                {

                    remainder = (Counter % 2);

                    if (Counter == 0)
                    {
                        ptype_item.tablehtml += "<tr>";
                    }

                    if (Counter > 0 && remainder == 0)
                    {
                        ptype_item.tablehtml += "</tr><tr>";
                    }

                    ptype_item.tablehtml += "<td>" + parameter_item.ParameterName + "</td>";
                    ptype_item.tablehtml += "<td class='columnName'><input type='text' class='parametervalueclass' id='"
                    + parameter_item.ParameterId + "'><input type='hidden' class='parameterid' value='"
                     + parameter_item.ParameterId + "'/></td>";
                    Counter++;

                }
                //if (remainderParamList != 0)
                //{
                //    ptype_item.tablehtml += "<td></td><td></td>";
                //}
                ptype_item.tablehtml += "</tr></table>";
            }
            return View(paramtypes);
        }
        [HttpPost]
        public JsonResult AllParameterDailyValue(DateTime EntryDate,int UnitId)
        {
            var data = labService.GetDailyParameter(EntryDate,UnitId);
            return Json(data);
        }
        DataTable data;

        public JsonResult SaveAllDailyEntry(List<paramList> jsonData)
        {
            if (jsonData != null)
            {
                try
                {
                    foreach (var item in jsonData)
                    {
                        var EntryDate = item.EntryDate;
                        var UnitId = item.UnitId;
                        var ParameterID = item.ParameterID;
                        var DayValue = item.DayValue;
                        data = labService.InsertDailyEntryParameter(EntryDate, UnitId, ParameterID, DayValue);
                        if (data.Rows.Count > 0 && data != null)
                        {
                            string status = data.Rows[0]["status"].ToString();
                            string message = data.Rows[0]["msg"].ToString();
                            if (status == "0" && status == "")
                            {

                                break;

                            }

                        }
                        else
                        {

                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                bool mess = true;
                string alertmess = mess ? "Data Inserted" : "Failed";
                return Json(alertmess);
            }
            else
            {
                bool mess = false;
                string alertmess = mess ? "Data Not Inserted" : "Please Enter A Correct Value";
                return Json(alertmess);
            }

        }

        #endregion
        #region StockEntry
        public ActionResult StockEntry()
        {
            TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Data for this Page is Not Available");
            return View();
        }
        #endregion StockEntry 
    }
}