using KnowledgeApp_Test.Models.Parameters;
using KnowledgeApp_Test.Models.Report;
using KnowledgeApp_Test.Services;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static KnowledgeApp_Test.Models.Common_Model.Alert;
using Parameter = KnowledgeApp_Test.Models.Parameters.Parameter;

namespace KnowledgeApp_Test.Controllers
{
    public class ParametersController : Controller
    {
        private Configuration config;
        private readonly HostingEnvironment _env;
        private const string _unitString = "{{Unit}}";
        private const string _dateString = "{{Date}}";
        private const string _seasonString = "{{Season}}";
        ParameterServices parameterService = new ParameterServices();
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        TemplateServices TS = new TemplateServices();

        // GET: Parameters
        #region EntryType
        [HttpGet]
        public ActionResult EntryType()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditEntryType(int id=0)
        {
            if (id == 0)
            {

                return View(new EntryType());
            }
            else
            {
                List<EntryType> Brix = new List<EntryType>();
                //List<Centre> Centerlist = new List<Centre>();
                Brix = parameterService.EntryType();
                return View(Brix.Where(x => x.EntryTypeId == id).FirstOrDefault<EntryType>());

            }
        }
        [HttpPost]
        public ActionResult AddeditEntryType(EntryType entryType)
        {
            var Id = entryType.EntryTypeId;
            var EntryTypeName = entryType.EntryTypeName;
            var EntryOrder = entryType.EntryOrder;
           
            DataTable data = parameterService.InsertEntryType(Id, EntryTypeName, EntryOrder);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("EntryType");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("EntryType");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("EntryType");

            }

        }
        [HttpPost]
        public JsonResult EntryTypeData()
        {
            //var data = parameterService.EntryType();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<EntryType> entryTypes = new List<EntryType>();
            entryTypes = parameterService.EntryType();
            int rowstotal = entryTypes.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                entryTypes = entryTypes.Where(x => x.EntryTypeId.ToString().Contains(searchvalue.ToLower()) || x.EntryTypeName.ToLower().Contains(searchvalue.ToLower()) || x.EntryOrder.ToString().Contains(searchvalue.ToLower()) ).ToList<EntryType>();


            }
            int totalrowsafterfiltering = entryTypes.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            entryTypes = entryTypes.Skip(start).Take(length).ToList<EntryType>();
            return Json(new { data = entryTypes, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion EntryType
        #region ParameterType
        public ActionResult ParameterType()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditParameterType(int id=0)
        {
            if (id == 0)
            {

                return View(new ParameterType());
            }
            else
            {
                List<ParameterType> parameterType = new List<ParameterType>();
                //List<Centre> Centerlist = new List<Centre>();
                parameterType = parameterService.ParameterType("");
                return View(parameterType.Where(x => x.ParameterTypeId == id).FirstOrDefault<ParameterType>());

            }

        }
        [HttpPost]
        public ActionResult AddeditParameterType(ParameterType parameterType)
        {
            var Id = parameterType.ParameterTypeId;
            var PTName = parameterType.ParameterTypeName;
            var ISCmp = parameterType.IsComputed;
            var PTCode = parameterType.ParameterTypeCode;
            var isStpgType = parameterType.IsStoppageType;
            var isStkType = parameterType.IsStockType;
            var EntrtyId = parameterType.EntryTypeId;
            DataTable data = parameterService.InsertParameterType(Id, PTName, ISCmp, PTCode, isStpgType, isStkType, EntrtyId);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ParameterType");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ParameterType");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("ParameterType");

            }

        }
        [HttpPost]
        public JsonResult ParameterTypeData(string EntryType)
        {
            // var data = parameterService.ParameterType(EntryType);
            // data = parameterService.EntryType();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ParameterType> parameterTypes = new List<ParameterType>();
            parameterTypes = parameterService.ParameterType(EntryType);
            int rowstotal = parameterTypes.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                parameterTypes = parameterTypes.Where(x => x.ParameterTypeId.ToString().Contains(searchvalue.ToLower()) || x.EntryTypeName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterTypeName.ToLower().Contains(searchvalue.ToLower()) || x.EntryTypeId.ToString().Contains(searchvalue.ToLower()) || x.ParameterTypeCode.ToString().Contains(searchvalue.ToLower())).ToList<ParameterType>();


            }
            int totalrowsafterfiltering = parameterTypes.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            parameterTypes = parameterTypes.Skip(start).Take(length).ToList<ParameterType>();
            return Json(new { data = parameterTypes, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion ParameterType
        #region ParameterUnit
        [HttpGet]
        public ActionResult ParameterUnit()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditParameterUnit(int id = 0)
        {
            if (id == 0)
            {

                return View(new ParameterUnit());
            }
            else
            {
                List<ParameterUnit> parameterUnit = new List<ParameterUnit>();
                //List<Centre> Centerlist = new List<Centre>();
                parameterUnit = parameterService.ParameterUnit();
                return View(parameterUnit.Where(x => x.ParameterUnitId == id).FirstOrDefault<ParameterUnit>());
            }
        }
        [HttpPost]
        public ActionResult AddeditParameterUnit(ParameterUnit parameterUnit)
        {
            var Id = parameterUnit.ParameterUnitId;
            var PUName = parameterUnit.ParameterUnitName;
            var PUCode = parameterUnit.ParameterUnitCode;
            var DataType = parameterUnit.DataType;
           
            DataTable data = parameterService.InsertParameterUnit(Id, PUName, PUCode, DataType);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ParameterUnit");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ParameterUnit");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("ParameterUnit");

            }

        }
        [HttpPost]
        public JsonResult ParameterUnitData()
        {
            //var data = parameterService.ParameterUnit();
            var data = parameterService.EntryType();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ParameterUnit> parameterUnit = new List<ParameterUnit>();
            parameterUnit = parameterService.ParameterUnit();
            int rowstotal = parameterUnit.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                parameterUnit = parameterUnit.Where(x => x.ParameterUnitId.ToString().Contains(searchvalue.ToLower()) || x.ParameterUnitName.ToLower().Contains(searchvalue.ToLower()) || x.DataType.ToString().Contains(searchvalue.ToLower()) || x.ParameterUnitCode.ToString().Contains(searchvalue.ToLower())).ToList<ParameterUnit>();


            }
            int totalrowsafterfiltering = parameterUnit.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            parameterUnit = parameterUnit.Skip(start).Take(length).ToList<ParameterUnit>();
            return Json(new { data = parameterUnit, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        #endregion ParameterUnit
        #region Parameter
        public ActionResult Parameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult ParameterData( string ParameterType)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Parameter> parameter = new List<Parameter>();
            parameter = parameterService.Parameter(ParameterType);
            int rowstotal = parameter.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                parameter = parameter.Where(x => x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterTypeParameterTypeName.ToLower().Contains(searchvalue.ToLower()) || x.PrevousDayParameterId.ToString().Contains(searchvalue.ToLower()) || x.MaximumValue.ToString().Contains(searchvalue.ToLower()) || x.MinimumValue.ToString().Contains(searchvalue.ToLower()) || x.DefaultValue.ToString().Contains(searchvalue.ToLower()) || x.BeforeDecimalDigit.ToString().Contains(searchvalue.ToLower()) || x.AfterDecimalDigit.ToString().Contains(searchvalue.ToLower()) || x.PrintBeforeDecimalDigit.ToString().Contains(searchvalue.ToLower()) || x.PrintAfterDecimalDigit.ToString().Contains(searchvalue.ToLower()) || x.TodateType.ToString().Contains(searchvalue.ToLower()) || x.AverageBasisParameter.ToString().Contains(searchvalue.ToLower()) || x.Formula.ToString().Contains(searchvalue.ToLower()) || x.TodateFormula.ToString().Contains(searchvalue.ToLower()) || x.DescriptiveFormula.ToString().Contains(searchvalue.ToLower()) || x.DescriptiveTodateFormula.ToString().Contains(searchvalue.ToLower()) || x.Uom.ToString().Contains(searchvalue.ToLower()) || x.AverageBasisParameter.ToString().Contains(searchvalue.ToLower())).ToList<Parameter>();


            }
            int totalrowsafterfiltering = parameter.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            parameter = parameter.Skip(start).Take(length).ToList<Parameter>();
            return Json(new { data = parameter, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditParameter(int id=0) 
        {
            if (id == 0)
            {

                return View(new Parameter());
            }
            else
            {
                List<Parameter> parameter = new List<Parameter>();
                //List<Centre> Centerlist = new List<Centre>();
                parameter = parameterService.Parameter("");
                return View(parameter.Where(x => x.ParameterId == id).FirstOrDefault<Parameter>());
            }

        }
        [HttpPost]
        public ActionResult AddeditParameter(Parameter parameter)
        {
            var Id = parameter.ParameterId;
            var ParameterCode = parameter.ParameterCode;
            var ParameterName = parameter.ParameterName;
            var ParameterTypeID = parameter.ParameterTypeId;
            var Discontinued = parameter.Discontinued;
            var IsUserDefined = parameter.IsUserDefined;
            var IsPreviousDay = parameter.IsPreviousDay;
            var IsStoppageParameter = parameter.IsStoppageParameter;
            var PrevousDayParameterID = parameter.PrevousDayParameterId;
            var MaximumValue = parameter.MaximumValue;
            var MinimumValue = parameter.MinimumValue;
            var DefaultValue = parameter.DefaultValue;
            var BeforeDecimalDigit = parameter.BeforeDecimalDigit;
            var AfterDecimalDigit = parameter.AfterDecimalDigit;
            var PrintBeforeDecimalDigit = parameter.PrintBeforeDecimalDigit;
            var PrintAfterDecimalDigit = parameter.PrintAfterDecimalDigit;
            var TodateType = parameter.TodateType;
            var AverageBasisParameterID = parameter.AverageBasisParameterId;
            var Formula = parameter.Formula;
            var TodateFormula = parameter.TodateFormula;
            var DescriptiveFormula = parameter.DescriptiveFormula;
            var DescriptiveTodateFormula = parameter.DescriptiveTodateFormula;
            var CalculationLevel = parameter.CalculationLevel;
            var IsStockParameter = parameter.IsStockParameter;
            var UOM = parameter.Uom;
            var IsBrixWeightParameter = parameter.IsBrixWeightParameter;
            var IsCalculatedOnBrixWeight = parameter.IsCalculatedOnBrixWeight;
            var IsHourlyEntry = parameter.IsHourlyEntry;
            var IsAdditional_Entry = parameter.IsAdditionalEntry;
            var AverageBasisParameter = parameter.AverageBasisParameter;
            DataTable data = parameterService.InsertParameter(Id, ParameterCode, ParameterName, ParameterTypeID, Discontinued, IsUserDefined, IsPreviousDay, IsStoppageParameter, PrevousDayParameterID, MaximumValue, MinimumValue, DefaultValue, BeforeDecimalDigit, AfterDecimalDigit, PrintBeforeDecimalDigit, PrintAfterDecimalDigit, TodateType, AverageBasisParameterID, Formula, TodateFormula, DescriptiveFormula, DescriptiveTodateFormula, CalculationLevel, IsStockParameter, UOM, IsBrixWeightParameter, IsCalculatedOnBrixWeight, IsHourlyEntry, IsAdditional_Entry, AverageBasisParameter);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("Parameter");
                }
                else
                {
                   TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("Parameter");
                }

            }
            else
            {
               TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("Parameter");

            }

        }
    

            #endregion Parameter
        [HttpGet]
        public ActionResult DateWiseDailyParameter()
        {
            
            return View();
        }
        [HttpPost]
        public PartialViewResult PartialDateWiseDailyParameter(string Entrydate = "", string Entrydate2 = "", string unit = "", string parametertype = "", string parameter = "")
        {
            List<DateWisesDailyParameter> DWDP = new List<DateWisesDailyParameter>();
            DWDP = parameterService.DateWiseDailyParameter(parametertype, parameter, unit, Entrydate, Entrydate2);
            TempData["DateWiseDailyParameter"] = DWDP;
            return PartialView("_PartialDateWiseDailyParameter", DWDP);
        }
        

        public ActionResult DateWiseStockParameter()
        {
           
           return View();
        }
        [HttpPost]
        public PartialViewResult PartialDateWiseStockParameter(string Entrydate = "", string Entrydate2 = "", string unit = "", string parametertype = "", string parameter = "")
        {
            List<DateWiseStockParameter> DWSP = new List<DateWiseStockParameter>();
            DWSP = parameterService.DateWisestockParameter(parametertype, parameter, unit, Entrydate, Entrydate2);
            return PartialView("PartialDateWiseStockParameter", DWSP);
        }




        public ActionResult DownloadTemplateReport()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RenderData(string UnitId, string TempId, string ReportDate)
        {


            //var template = TS.GetReportTemplate(TempId.ToString());
            try
            {

               // var connection = SqlConnections.NewByKey("KMS");
                var template = TS.GetReportTemplate(TempId.ToString());
                if (template != null)
                {
                    var templatename = template[0].TemplateFileName;
                    var reportData = parameterService.ReportTemplateReport(UnitId, TempId, ReportDate);
                    if (reportData == null || reportData.Count == 0)
                    {
                        return Json(new { success = false, responseText = "Report Date is not matching, Please check and try again " });
                    }
                    FileInfo excelfile;
                    //try
                    //{
                    //    excelfile = new FileInfo(templatename);
                    //    if (!excelfile.Exists)
                    //    //new FileInfo(Path.Combine(_env.ContentRootPath, config.GetValue<string>("AppSettings:UploadSettings:Path").Replace("~/", ""), templatename)); if (!excelfile.Exists)
                    //    {
                    //        return Json(new { success = false, responseText = "Report Template file not found " });
                    //    }
                    //    else
                    //    {
                    //        return Json(new { success = false, responseText = "Report Template file not found " });
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    return Json(new { success = false, responseText = "Report Template file not found " });
                    //}

                    //var stream = new FileStream(excelfile.FullName, FileMode.Open, FileAccess.ReadWrite);
                    return Json(new { success = true, responseText = $"every thing is fine" });
                }
                return Json(new { success = false, responseText = $"Unable to Process your request" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = $"Error :{ex.StackTrace}" });
            }


        }

        public ActionResult DownloadExcel(int UnitId, int TempId, string ReportDate)
        {
            ReportDate = DateTime.ParseExact(ReportDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            try
            {
                var template = TS.GetReportTemplate(TempId.ToString());
                var templateRow = template[0];
                if (template != null)
                {
                    var templatename = template[0].TemplateFileName;
                    var reportData = parameterService.ReportTemplateReport(UnitId.ToString(), TempId.ToString(), ReportDate);
                    var RepCount= reportData.Count;
                    var RepcountDay=reportData.Where(x=>x.DayValue>0).Count();
                    if (reportData == null || reportData.Count == 0)
                    {
                        return Json(new { success = false, responseText = "Report Date is not matching, Please check and try again " });
                    }
                    FileInfo excelfile;
                    string FileName = Path.GetFileName(templatename);
                    string FolderPath = ConfigurationManager.AppSettings["Template"];
                    excelfile = new FileInfo(Path.Combine(Server.MapPath(FolderPath + FileName)));

                    if (!excelfile.Exists)
                    {
                        return Json(new { success = false, responseText = "Report Template file not found " });
                    }
                    using (ExcelPackage excelPackage = new ExcelPackage(excelfile))
                    {
                        ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                        ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets.First();
                        foreach (var rowdata in reportData)
                        {
                            var renderdata = new ReportTemplateReport

                            {
                                ParameterID = rowdata.ParameterID,
                                ColumnNumber = rowdata.ColumnNumber,
                                DayValue = rowdata.DayValue,
                                FixedValue = rowdata.FixedValue,
                                ParameterType = rowdata.ParameterType,
                                PostfixValue = rowdata.PostfixValue,
                                PrefixValue = rowdata.PrefixValue,
                                RowNumber = rowdata.RowNumber,
                                //EntryDate = DateTime.Parse(rowdata.EntryDate.ToString("yyyy-MM-dd")),
                                TodateValue = rowdata.TodateValue,
                                PreDayValue = rowdata.PreDayValue,
                                PreTodateValue = rowdata.PreTodateValue,
                            };
                            ExcelConditions(renderdata, excelWorksheet);
                        }
                        int seasonRow =  templateRow.SeasonRow;
                        int seasonColumn = templateRow.SeasonColumn;
                        int cropDayRow = templateRow.CropDayRow;
                        int cropDayColumn = templateRow.CropDayColumn;

                        var unit = TS.GetReportTemplateQuery(UnitId);
                        //connection.Query($"select UnitName from common.unit where unitid={UnitId}").FirstOrDefault();
                        DateTime.TryParse(ReportDate, out DateTime reportdate);
                        try
                        {
                            var headerText = Convert.ToString(excelWorksheet.GetValue(1, 1));
                            /// excelWorksheet.SetValue(1, 1, headerText.Replace(_unitString, unit.UnitName));
                            var dateText = Convert.ToString(excelWorksheet.GetValue(3,1).ToString());
                            excelWorksheet.SetValue(3, 1, dateText.Replace(_dateString, reportdate.ToString("yyyy-MM-dd")));
                        }
                        catch (Exception)
                        {
                        }
                        var seasonText = Convert.ToString(excelWorksheet.GetValue(seasonRow, seasonColumn));



                        string season = "";
                        if (reportdate.Month > 5) season = reportdate.Year + "-" + reportdate.Year + 1;
                        else if (reportdate.Month <= 5) season = reportdate.Year - 1 + "-" + reportdate.Year;
                        excelWorksheet.SetValue(seasonRow, seasonColumn, seasonText.ToString().Replace(_seasonString, season));
                        /// for crop day

                        DataTable cropday = TS.Query12(UnitId, ReportDate);

                        double DayValue = Convert.ToDouble(cropday.Rows[0]["DayValue"]);

                        // var cropday =connection.Query($"select DayValue  from lab.daily where parameterid=2 and UnitID={UnitId} and EntryDate='{ReportDate}'").FirstOrDefault();

                        excelWorksheet.SetValue(cropDayRow, cropDayColumn, cropday == null ? 0 : DayValue);

                        string FileName12 = Path.GetFileName("downloadFile.xlsx");
                        string FolderPath12 = ConfigurationManager.AppSettings["Template"];
                        string FilePath12 = Server.MapPath(FolderPath + FileName);

                        excelPackage.SaveAs(new FileInfo(Path.Combine(FilePath12)));

                        var stream = new FileStream(Path.Combine(FilePath12), FileMode.Open, FileAccess.ReadWrite);

                        var contentType = "application/vnd.ms-excel";
                        var fileName = $"{template[0].ReportTemplateName}_{ReportDate}.xlsx";
                        return File(stream, contentType, fileName);

                    }


                }
                return Json(new { success = false, responseText = $"Unable to Process your request" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = $"Error :{ex.StackTrace}" });
            }
            //var stream=new FileStream(,)


        }

        private void ExcelConditions(ReportTemplateReport renderdata, ExcelWorksheet excelWorksheet)
        {

            if (renderdata.ParameterID == null || renderdata.ParameterID == 0)
            {
                SetCellValue(excelWorksheet, renderdata.RowNumber, renderdata.ColumnNumber, $"{renderdata.PrefixValue.ToString() ?? ""}{renderdata.FixedValue.ToString() ?? ""}{renderdata.PostfixValue.ToString() ?? ""}");
            }
            else
            {

                //if (renderdata.ParameterType == 0 || renderdata.ParameterType == 1)
               // {


                    if (renderdata.ParameterType == 1)
                    {
                        SetCellValue(excelWorksheet, renderdata.RowNumber, renderdata.ColumnNumber, renderdata.TodateValue.ToString());
                    }
                    else if (renderdata.ParameterType == 3)
                    {
                        SetCellValue(excelWorksheet, renderdata.RowNumber, renderdata.ColumnNumber, renderdata.PreDayValue.ToString());
                    }
                    else if (renderdata.ParameterType == 4)
                    {
                        SetCellValue(excelWorksheet, renderdata.RowNumber, renderdata.ColumnNumber, renderdata.PreTodateValue.ToString());
                    }
                    else
                    {
                        SetCellValue(excelWorksheet, renderdata.RowNumber, renderdata.ColumnNumber, renderdata.DayValue.ToString());
                    }
                //}
            }
        }


        private void SetCellValue(ExcelWorksheet excelWorksheet, int rowNumber, int columnNumber, string v)
        {
            try
            {
                var value = v;
                if (!value.Contains('.')) value += ".00";
                excelWorksheet.SetValue((int)rowNumber, (int)columnNumber, $"{value}");
            }
            catch (Exception ex)
            {

            }
        }




    }
}