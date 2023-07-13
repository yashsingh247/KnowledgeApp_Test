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
using System.Web.UI.WebControls;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{
    public class TemplateController : Controller
    {
        TemplateServices templateServices = new TemplateServices();
        DropdownListSevices DropdownListSevices = new DropdownListSevices();
        // GET: Template

        #region ChartTemplate
        public ActionResult ChartTemplate()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditChartTemplate(int id = 0)
        {
            TempData["ChartTemplateId"] = id;
            if (id == 0)
                return View(new ChartTemplate());
            else
            {
                List<ChartTemplate> chartTemplate = new List<ChartTemplate>();
                //List<Centre> Centerlist = new List<Centre>();
                chartTemplate = templateServices.GetChartTemplate();
                return View(chartTemplate.Where(x => x.ChartTemplateId == id).FirstOrDefault<ChartTemplate>());

            }
        }
        [HttpPost]
        public ActionResult AddeditChartTemplate(ChartTemplate chartTemplate)
        {
            var Id = chartTemplate.ChartTemplateId;
            var TemplateName = chartTemplate.ChartTemplateName;
            var ChartType = chartTemplate.ChartType;
            var FileName = chartTemplate.TemplateFileName;
            DataTable data = templateServices.InsertChartTemplate(Id, TemplateName, ChartType, FileName);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ChartTemplate");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ChartTemplate");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                 return RedirectToAction("ChartTemplate");
            }
        }
        [HttpGet]
        public ActionResult AddeditChartTemplateDetails(int id = 0)
        {
            ViewBag.ChartTemplateId = TempData["ChartTemplateId"];
            if (id == 0)
                return View(new ChartTemplateDetails());
            else
            {
                List<ChartTemplateDetails> chartTemplateDetails = new List<ChartTemplateDetails>();
                //List<Centre> Centerlist = new List<Centre>();
                chartTemplateDetails = templateServices.GetChartTemplateDetails("","");
                return View(chartTemplateDetails.Where(x => x.ChartTemplateDetailID == id).FirstOrDefault<ChartTemplateDetails>());

            }
        }
        [HttpPost]
        public ActionResult AddeditChartTemplateDetails(ChartTemplateDetails chartTemplateDetails)
        {
            var Id = chartTemplateDetails.ChartTemplateDetailID;
            var Template = chartTemplateDetails.ChartTemplateID;
            var Serial = chartTemplateDetails.SerialNumber;
            var Parameter = chartTemplateDetails.ParameterID;
            var PType = chartTemplateDetails.ParameterType;
            DataTable data = templateServices.InsertChartTemplateDetails(Id, Template, Serial, Parameter, PType);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ChartTemplate");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ChartTemplate");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                 return RedirectToAction("ChartTemplate");
            }
        }
        [HttpPost]
        public JsonResult ChartTemplateData()
        {
            //var data = templateServices.GetChartTemplate();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ChartTemplate> ChartTemplate = new List<ChartTemplate>();
            ChartTemplate = templateServices.GetChartTemplate();
            int rowstotal = ChartTemplate.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                ChartTemplate = ChartTemplate.Where(x => x.ChartTemplateId.ToString().Contains(searchvalue.ToLower()) || x.ChartTemplateName.ToLower().Contains(searchvalue.ToLower()) || x.ChartType.ToString().Contains(searchvalue.ToLower())  || x.TemplateFileName.ToLower().Contains(searchvalue.ToLower())).ToList<ChartTemplate>();

            }
            int totalrowsafterfiltering = ChartTemplate.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            ChartTemplate = ChartTemplate.Skip(start).Take(length).ToList<ChartTemplate>();
            return Json(new { data = ChartTemplate, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChartTemplateDetailsData(string ChartTemplate, string Parameter)
        {
            //var data = templateServices.GetChartTemplate();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ChartTemplateDetails> chartTemplateDetails = new List<ChartTemplateDetails>();
            chartTemplateDetails = templateServices.GetChartTemplateDetails(ChartTemplate, Parameter);
            int rowstotal = chartTemplateDetails.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                chartTemplateDetails = chartTemplateDetails.Where(x => x.ChartTemplateDetailID.ToString().Contains(searchvalue.ToLower()) || x.ChartTemplateName.ToLower().Contains(searchvalue.ToLower()) || x.ChartTemplateID.ToString().Contains(searchvalue.ToLower()) || x.SerialNumber.ToString().Contains(searchvalue.ToLower()) || x.ParameterType.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToLower().Contains(searchvalue.ToLower()) ).ToList<ChartTemplateDetails>();

            }
            int totalrowsafterfiltering = chartTemplateDetails.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            chartTemplateDetails = chartTemplateDetails.Skip(start).Take(length).ToList<ChartTemplateDetails>();

            return Json(new { data = chartTemplateDetails, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }



        #endregion ChartTemplate
        #region ReportTemplate
        public ActionResult ReportTemplate()
        {
            TempData["Alert"] =TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditReportTemplate(int id = 0)
        {
            TempData["ReportTemplateId"] = id;
            if (id == 0)
                return View(new ReportTemplate());
            else
            {
                List<ReportTemplate> reportTemplate = new List<ReportTemplate>();
                //List<Centre> Centerlist = new List<Centre>();
                reportTemplate = templateServices.GetReportTemplate("");
                return View(reportTemplate.Where(x => x.ReportTemplateId == id).FirstOrDefault<ReportTemplate>());

            }

        }
        public ActionResult AddeditReportTemplateDetails(int id = 0)
        {
            ViewBag.ReportTemplateId = TempData["ReportTemplateId"];
            if (id == 0)
                return View(new ReportTemplateDetails());
            else
            {
                List<ReportTemplateDetails> reportTemplateDetails = new List<ReportTemplateDetails>();
                //List<Centre> Centerlist = new List<Centre>();
                reportTemplateDetails = templateServices.GetReportTemplateDetails("","");
                return View(reportTemplateDetails.Where(x => x.ReportTemplateDetailID == id).FirstOrDefault<ReportTemplateDetails>());
            }
        }
        public JsonResult ReportTemplateData()
        {
            // var data = templateServices.GetReportTemplate();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ReportTemplate> ReportTemplate = new List<ReportTemplate>();
            ReportTemplate = templateServices.GetReportTemplate("");
            int rowstotal = ReportTemplate.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                ReportTemplate = ReportTemplate.Where(x => x.ReportTemplateId.ToString().Contains(searchvalue.ToLower()) || x.ReportTemplateName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ReportType.ToString().Contains(searchvalue.ToLower()) || x.ParameterType.ToString().Contains(searchvalue.ToLower()) || x.TemplateFileName.ToLower().Contains(searchvalue.ToLower()) || x.SeasonRow.ToString().Contains(searchvalue.ToLower()) || x.SeasonColumn.ToString().Contains(searchvalue.ToLower()) || x.CropDayRow.ToString().Contains(searchvalue.ToLower()) || x.CropDayColumn.ToString().Contains(searchvalue.ToLower()) || x.ColumnCount.ToString().Contains(searchvalue.ToLower()) || x.Code.ToString().Contains(searchvalue.ToLower())).ToList<ReportTemplate>();

            }
            int totalrowsafterfiltering = ReportTemplate.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            ReportTemplate = ReportTemplate.Skip(start).Take(length).ToList<ReportTemplate>();
            return Json(new { data = ReportTemplate, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddeditReportTemplate(ReportTemplate reportTemplate)
        {
            string FilePath = null;
            if (reportTemplate.ImagePath != null)
            {
                if (reportTemplate.ImagePath.ContentLength > 0 && reportTemplate.ImagePath!=null)
                {
                    string extension = System.IO.Path.GetExtension(reportTemplate.ImagePath.FileName);
                    //if (extension.ToUpper() != ".XLS" && extension.ToUpper() != ".XLSX")
                    //{
                    //    lblupload.Text = "Upload XLS/XLSX File only.";
                    //    lblupload.ForeColor = System.Drawing.Color.Red;
                    //    return;
                    //}
                    string FileName = Path.GetFileName(reportTemplate.ImagePath.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["Template"];
                    FilePath = Server.MapPath(FolderPath + FileName);
                    reportTemplate.TemplateFileName = FileName;
                    reportTemplate.ImagePath.SaveAs(FilePath);
                }
            }
            var FilePathforsave = reportTemplate.TemplateFileName;
            var Id = reportTemplate.ReportTemplateId;
            var TemplateName = reportTemplate.ReportTemplateName;
            var PrintStoppage = reportTemplate.PrintStoppageDetail;
            var SeasonRow = reportTemplate.SeasonRow;
            var SeasonColumn = reportTemplate.CropDayRow;
            var CropDayRow = reportTemplate.CropDayRow;
            var CropDayColumn = reportTemplate.CropDayColumn;
            var ReportType = reportTemplate.ReportType;
            var ColumnCount = reportTemplate.ColumnCount;
            //var File = reportTemplate.TemplateFileName;
            var code = reportTemplate.Code;
            DataTable data = templateServices.InsertReportTemplate(Id, TemplateName, PrintStoppage, SeasonRow, SeasonColumn, CropDayRow, CropDayColumn, ReportType, ColumnCount, FilePathforsave, code);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ReportTemplate");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ReportTemplate");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents wrong....");
                 return RedirectToAction("ReportTemplate");

            }

        }
        [HttpPost]
        public ActionResult AddeditReportTemplateDetails(ReportTemplateDetails reportTemplateDetails) 
        {
            var Id = reportTemplateDetails.ReportTemplateDetailID;
            var TempId = reportTemplateDetails.ReportTemplateID;
            var RowNo = reportTemplateDetails.RowNumber;
            var Colno = reportTemplateDetails.ColumnNumber;
            var PId = reportTemplateDetails.ParameterID;
            var Ptype = reportTemplateDetails.ParameterType;
            var fixedValue = reportTemplateDetails.FixedValue;
            var Prefixvalue = reportTemplateDetails.PrefixValue;
            var Postfixvalue = reportTemplateDetails.PostfixValue;
            DataTable data = templateServices.InsertReportTemplateDetails( Id,TempId,RowNo,Colno,PId,Ptype,fixedValue,Prefixvalue, Postfixvalue);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                     return RedirectToAction("ReportTemplate");
                }
                else
                {
                    TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                     return RedirectToAction("ReportTemplate");
                }

            }
            else
            {
                TempData["Alert"] =DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                 return RedirectToAction("ReportTemplate");
            }
        }
        [HttpPost]
        public JsonResult ReportTemplateDetailsData(string ReportTemplateId,string Parameter)
        {
            // var data = templateServices.GetReportTemplate();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ReportTemplateDetails> ReportTemplateDetails = new List<ReportTemplateDetails>();
            ReportTemplateDetails = templateServices.GetReportTemplateDetails(ReportTemplateId, Parameter);
            int rowstotal = ReportTemplateDetails.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                ReportTemplateDetails = ReportTemplateDetails.Where(x => x.ReportTemplateDetailID.ToString().Contains(searchvalue.ToLower()) || x.ReportTemplateName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterID.ToString().Contains(searchvalue.ToLower()) || x.ParameterType.ToString().Contains(searchvalue.ToLower()) || x.ParameterName.ToString().Contains(searchvalue.ToLower()) || x.RowNumber.ToString().Contains(searchvalue.ToLower()) || x.ColumnNumber.ToString().Contains(searchvalue.ToLower()) || x.FixedValue.ToString().Contains(searchvalue.ToLower()) || x.PrefixValue.ToString().Contains(searchvalue.ToLower()) || x.PostfixValue.ToString().Contains(searchvalue.ToLower())).ToList<ReportTemplateDetails>();
            }
            int totalrowsafterfiltering = ReportTemplateDetails.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            ReportTemplateDetails = ReportTemplateDetails.Skip(start).Take(length).ToList<ReportTemplateDetails>();
            return Json(new { data = ReportTemplateDetails, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion ReportTemplate
    }
}