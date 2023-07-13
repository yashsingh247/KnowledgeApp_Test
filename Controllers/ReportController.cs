
using KnowledgeApp_Test.Models;
using KnowledgeApp_Test.Models.Report;
using KnowledgeApp_Test.Models.Sugar_Molasses;
using KnowledgeApp_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MolassesDayTransaction = KnowledgeApp_Test.Models.Sugar_Molasses.MolassesDayTransaction;

namespace KnowledgeApp_Test.Controllers
{
    public class ReportController : Controller
    {
        ParameterServices parameterService = new ParameterServices();
       
        public ActionResult CMPStatusReport()
        {
            
            return View();
        }
        public PartialViewResult PartialCMPStatusReport(string unit = "", string Entrydate = "", string Entrydate2 = "")
        {
            List<CMPStatus> CMPStatus = new List<CMPStatus>();
            CMPStatus = parameterService.NewCMPStatusReport(unit, Entrydate, Entrydate2);
            return PartialView("PartialCMPStatusReport", CMPStatus);
        }
        public ActionResult PlantPerformanceReport()
        {
            
            return View();
        }
        public PartialViewResult PartialPlantPerformanceReport(string unit = "", string Entrydate2 = "")
        {
            List<PPfReports> PPfR = new List<PPfReports>();
            PPfR = parameterService.NewPPfReport(unit, Entrydate2);
            return PartialView("PartialPlantPerformanceReport", PPfR);

        }
        public ActionResult MassecuiteStockReport()
        {
         
            return View();
        }
        public PartialViewResult PartialMassecuiteStockReport(string unit = "", string AnalysisDate = "")
        {
            List<MassecuiteStock> MassSReport = new List<MassecuiteStock>();
            MassSReport = parameterService.NewMassStoctReport(unit, AnalysisDate);
            return PartialView("PartialMassecuiteStockReport", MassSReport);
        }
        public ActionResult ShiftLogbookReport()
        {
           
            return View();
        }
        public PartialViewResult PartialShiftLogbookReport(string unit = "", string AnalysisDate = "")
        {
            List<ShiftLogbook> ShiftLogbook = new List<ShiftLogbook>();
            ShiftLogbook = parameterService.NewShiftLogbookReport(unit, AnalysisDate);
            return PartialView("PartialShiftLogbookReport", ShiftLogbook);
        }
        public ActionResult ChemistLogbookReport()
        {

            return View();
        }
        public PartialViewResult PartialChemistLogbookReport(string unit = "", string AnalysisDate = "")
        {
            List<ChemistLogbook> LogBookReport = new List<ChemistLogbook>();
            LogBookReport = parameterService.NewChemistLogoBookReport(unit, AnalysisDate);
            return PartialView("PartialChemistLogbookReport", LogBookReport);
        }
        public ActionResult ChemicalConsumptionReport()
        {
           
            return View();
        }    
        public PartialViewResult PartialChemicalConsumptionReport(string unit = "", string AnalysisDate = "")
        {
            List<ChemicalConsumption> ChemicalConsumptionReport = new List<ChemicalConsumption>();
            ChemicalConsumptionReport = parameterService.NewChemicalConsumptionReport(unit, AnalysisDate);
            return PartialView("PartialChemicalConsumptionReport", ChemicalConsumptionReport);
        }
        public ActionResult ClarificationHouseReport()
        {
           
            return View();
        }
        public PartialViewResult PartialClarificationHouseReport(string AnalysisDate = "")
        {
            List<ClarificationHouse> ClarificationHouseReport = new List<ClarificationHouse>();
            ClarificationHouseReport = parameterService.NewClarificationHouseReport(AnalysisDate);
            return PartialView("PartialClarificationHouseReport", ClarificationHouseReport);
        }
        public ActionResult MassecuiteConditioningDataReport()
        {
           
            return View();
        }
        public PartialViewResult PartialMassecuiteConditioningDataReport(string AnalysisDate = "")
        {
            List<MassecuiteConditioningData> MassecuiteConditioningDataReport = new List<MassecuiteConditioningData>();
            MassecuiteConditioningDataReport = parameterService.NewMassecuiteConditioningDataReport(AnalysisDate);
            return PartialView("PartialMassecuiteConditioningDataReport", MassecuiteConditioningDataReport);
        }

        public ActionResult TPTReports()
        {
           
            return View();
        }
        public PartialViewResult PartialTPTReports(string unit = "", string RevisionID = "", string CrushingSeasonid = "")
        {
            List<TPTReports> TPTReports = new List<TPTReports>();
            TPTReports = parameterService.TPTReports(unit, RevisionID, CrushingSeasonid);
            return PartialView("PartialTPTReports", TPTReports);
        }
        public ActionResult YearlyBenchMarkList(string AnalysisDate = "")
        {
            List<YearlyBenchMark> YearlyBenchMark = new List<YearlyBenchMark>();
            YearlyBenchMark = parameterService.NewYearlyBenchMark(AnalysisDate);
            return View(YearlyBenchMark);
        }
        public ActionResult MillLogReport()
        {
           
            return View();
        }
        public PartialViewResult PartialMillLogReport(string unit = "", string Entrydate = "", string Entrydate2 = "")
        {
            List<MillLog> MillLog = new List<MillLog>();
            MillLog = parameterService.NewMillLogReport(unit, Entrydate, Entrydate2);
            return PartialView("PartialMillLogReport", MillLog);
        }
        public ActionResult IAADStatusReport()
        {
       
            return View();
        }

        public PartialViewResult PartialIAADStatusReport(string unit = "", string Entrydate = "", string Entrydate2 = "")
        {
            List<IAADStatus> IAADStatus = new List<IAADStatus>();
            IAADStatus = parameterService.IAADStatusReport(unit, Entrydate, Entrydate2);
            return PartialView("PartialIAADStatusReport", IAADStatus);
        }
        public ActionResult AuditLogReport()
        {
            return View();
        }
        public PartialViewResult PartialAuditLogReport(string TableName = "", string Entrydate = "", string Entrydate2 = "")
        {
            List<Auditlog> NewAuditLog = new List<Auditlog>();
            NewAuditLog = parameterService.AuditlogStatusReport(TableName, Entrydate, Entrydate2);
            return PartialView(NewAuditLog);
        }
        public ActionResult MolassesDayTransactionReport(string Entrydate = "", string Entrydate2 = "")
        {
            List<Models.Report.MolassesDayTransaction> MDTtatus = new List<Models.Report.MolassesDayTransaction>();
            MDTtatus = parameterService.MolassesDayTransaction(Entrydate, Entrydate2);
            return View(MDTtatus);
        }
        public ActionResult SugarDayTransactionReport()
        {
            return View();
        }
        public PartialViewResult PartialSugarDayTransactionReport(string unit = "", string SugarGodownID = "", string Entrydate = "", string Entrydate2 = "")
        {
            List<Models.Report.SugarWeekTransaction> SDTR = new List<Models.Report.SugarWeekTransaction>();
            SDTR = parameterService.NewSDTRReport(unit, SugarGodownID, Entrydate, Entrydate2);
            return PartialView("PartialSugarDayTransactionReport", SDTR);
        }
    }




}