using KnowledgeApp_Test.Models.Sugar_Molasses;
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
    public class Sugar_MolassesController : Controller
    {
        Sugar_MolassesSerivces SMS = new Sugar_MolassesSerivces();
        // GET: Sugar_Molasses
        #region MolassesTank
        public ActionResult MolassesTank()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditMolassesTank(int id = 0)
        {
            if (id == 0)
                return View(new MolassesTank());
            else
            {
                List<MolassesTank> molassesTanks = new List<MolassesTank>();
                //List<Centre> Centerlist = new List<Centre>();
                molassesTanks = SMS.MolassesTank("");
                return View(molassesTanks.Where(x => x.MolassesTankId == id).FirstOrDefault<MolassesTank>());
            }

        }
        [HttpPost]
        public JsonResult MolassesTankData(string Crushingseason)
        {
            //var data = TPTServices.UnitParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MolassesTank> molassesTank = new List<MolassesTank>();
            molassesTank = SMS.MolassesTank(Crushingseason);
            int rowstotal = molassesTank.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                molassesTank = molassesTank.Where(x => x.TankNumber.ToString().Contains(searchvalue.ToLower()) || x.MolassesTankId.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonCrushingSeasonName.ToLower().Contains(searchvalue.ToLower())||x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower())||x.Grade.ToLower().Contains(searchvalue.ToLower())||x.Opening.ToString().Contains(searchvalue.ToLower())).ToList<MolassesTank>();
            }
            int totalrowsafterfiltering = molassesTank.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            molassesTank = molassesTank.Skip(start).Take(length).ToList<MolassesTank>();
            return Json(new { data = molassesTank, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult AddeditMolassesTank(MolassesTank molassesTank)
        {
            var Id = molassesTank.MolassesTankId;
            var TankNumber = molassesTank.TankNumber;
            var CrushingSeasonID = molassesTank.CrushingSeasonId;
            var Grade = molassesTank.Grade;
            var Opening = molassesTank.Opening;
            var Discontinued = molassesTank.Discontinued;
            DataTable data = SMS.InsertMolassesTank(Id, TankNumber, CrushingSeasonID, Grade, Opening, Discontinued);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("MolassesTank");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("MolassesTank");
                }
            }
            else 
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong");
                return RedirectToAction("MolassesTank");
            }

        }
        #endregion MolassesTank
        #region MolassesDayTransaction
        public ActionResult MolassesDayTransaction()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult MolassesDayTransactionData(string Unit, string tank, string TransactionDate, string TransactionDate2)
        {
            //var data = TPTServices.UnitParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<MolassesDayTransaction> molassesDayTransaction = new List<MolassesDayTransaction>();
            molassesDayTransaction = SMS.MolassesDayTransaction(Unit, tank, TransactionDate, TransactionDate2);
            int rowstotal = molassesDayTransaction.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                molassesDayTransaction = molassesDayTransaction.Where(x =>x.MolassesDayTransactionId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.MolassesTankId.ToString().Contains(searchvalue.ToLower()) || x.MolassesTankTankNumber.ToLower().Contains(searchvalue.ToLower()) || x.TransactionDate.ToString().Contains(searchvalue.ToLower()) || x.Production.ToString().Contains(searchvalue.ToLower()) || x.ShiftingIn.ToString().Contains(searchvalue.ToLower()) || x.Sales.ToString().Contains(searchvalue.ToLower()) || x.ShiftingOut.ToString().Contains(searchvalue.ToLower()) || x.InTemperature1.ToString().Contains(searchvalue.ToLower()) || x.InTemperature2.ToString().Contains(searchvalue.ToLower()) || x.InTemperature3.ToString().Contains(searchvalue.ToLower()) || x.InTemperature4.ToString().Contains(searchvalue.ToLower()) || x.InTemperature5.ToString().Contains(searchvalue.ToLower()) || x.OutTemperature1.ToString().Contains(searchvalue.ToLower()) || x.OutTemperature2.ToString().Contains(searchvalue.ToLower()) || x.OutTemperature3.ToString().Contains(searchvalue.ToLower()) || x.OutTemperature4.ToString().Contains(searchvalue.ToLower()) || x.OutTemperature5.ToString().Contains(searchvalue.ToLower()) || x.WaterIn1.ToString().Contains(searchvalue.ToLower()) || x.WaterIn2.ToString().Contains(searchvalue.ToLower()) || x.WaterIn3.ToString().Contains(searchvalue.ToLower()) || x.WaterIn4.ToString().Contains(searchvalue.ToLower()) || x.WaterIn5.ToString().Contains(searchvalue.ToLower()) || x.WaterOut1.ToString().Contains(searchvalue.ToLower()) || x.WaterOut2.ToString().Contains(searchvalue.ToLower()) || x.WaterOut3.ToString().Contains(searchvalue.ToLower()) || x.WaterOut4.ToString().Contains(searchvalue.ToLower()) || x.WaterOut5.ToString().Contains(searchvalue.ToLower()) || x.MolassesTemperature1.ToString().Contains(searchvalue.ToLower()) || x.MolassesTemperature2.ToString().Contains(searchvalue.ToLower()) || x.MolassesTemperature3.ToString().Contains(searchvalue.ToLower()) || x.MolassesTemperature4.ToString().Contains(searchvalue.ToLower()) || x.MolassesTemperature5.ToString().Contains(searchvalue.ToLower()) || x.Brix.ToString().Contains(searchvalue.ToLower()) || x.Trs.ToString().Contains(searchvalue.ToLower()) || x.ProductionTemperature1.ToString().Contains(searchvalue.ToLower()) || x.ProductionTemperature2.ToString().Contains(searchvalue.ToLower()) || x.ProductionTemperature3.ToString().Contains(searchvalue.ToLower()) || x.ProductionTemperature4.ToString().Contains(searchvalue.ToLower()) || x.ProductionTemperature5.ToString().Contains(searchvalue.ToLower()) || x.RecirculationHours.ToString().Contains(searchvalue.ToLower()) || x.WaterSpayHours.ToString().Contains(searchvalue.ToLower())).ToList<MolassesDayTransaction>();
            }
            int totalrowsafterfiltering = molassesDayTransaction.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            molassesDayTransaction = molassesDayTransaction.Skip(start).Take(length).ToList<MolassesDayTransaction>();
            return Json(new { data = molassesDayTransaction, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditMolassesDayTransaction(int id = 0)
        {
            if (id == 0)
                return View(new MolassesDayTransaction());
            else
            {
                List<MolassesDayTransaction> molassesDayTransactions = new List<MolassesDayTransaction>();
                //List<Centre> Centerlist = new List<Centre>();
                molassesDayTransactions = SMS.MolassesDayTransaction("","","","");
                return View(molassesDayTransactions.Where(x => x.MolassesDayTransactionId == id).FirstOrDefault<MolassesDayTransaction>());
            }

        }
        [HttpPost]
        public ActionResult AddeditMolassesDayTransaction(MolassesDayTransaction molassesDayTransaction)
        {
            var Id= molassesDayTransaction.MolassesDayTransactionId;
            var MolassesTankID = molassesDayTransaction.MolassesTankId;
            var TransactionDate = molassesDayTransaction.TransactionDate;
            var Production = molassesDayTransaction.Production;
            var ShiftingIN = molassesDayTransaction.ShiftingIn;
            var Sales = molassesDayTransaction.Sales;
            var ShiftingOut = molassesDayTransaction.ShiftingOut;
            var InTemperature1 = molassesDayTransaction.InTemperature1;
            var InTemperature2 = molassesDayTransaction.InTemperature2;
            var InTemperature3 = molassesDayTransaction.InTemperature3;
            var InTemperature4 = molassesDayTransaction.InTemperature4;
            var InTemperature5 = molassesDayTransaction.InTemperature5;
            var OutTemperature1 = molassesDayTransaction.OutTemperature1;
            var OutTemperature2 = molassesDayTransaction.OutTemperature2;
            var OutTemperature3 = molassesDayTransaction.OutTemperature3;
            var OutTemperature4 = molassesDayTransaction.OutTemperature4;
            var OutTemperature5 = molassesDayTransaction.OutTemperature5;
            var WaterIn1 = molassesDayTransaction.WaterIn1;
            var WaterIn2 = molassesDayTransaction.WaterIn2;
            var WaterIn3 = molassesDayTransaction.WaterIn3;
            var WaterIn4 = molassesDayTransaction.WaterIn4;
            var WaterIn5 = molassesDayTransaction.WaterIn5;
            var WaterOut1 = molassesDayTransaction.WaterOut1;
            var WaterOut2 = molassesDayTransaction.WaterOut2;
            var WaterOut3 = molassesDayTransaction.WaterOut3;
            var WaterOut4 = molassesDayTransaction.WaterOut4;
            var WaterOut5 = molassesDayTransaction.WaterOut5;
            var MolassesTemperature1 = molassesDayTransaction.MolassesTemperature1;
            var MolassesTemperature2 = molassesDayTransaction.MolassesTemperature2;
            var MolassesTemperature3 = molassesDayTransaction.MolassesTemperature3;
            var MolassesTemperature4 = molassesDayTransaction.MolassesTemperature4;
            var MolassesTemperature5 = molassesDayTransaction.MolassesTemperature5;
            var Brix = molassesDayTransaction.Brix;
            var TRS = molassesDayTransaction.Trs;
            var ProductionTemperature1 = molassesDayTransaction.ProductionTemperature1;
            var ProductionTemperature2 = molassesDayTransaction.ProductionTemperature2;
            var ProductionTemperature3 = molassesDayTransaction.ProductionTemperature3;
            var ProductionTemperature4 = molassesDayTransaction.ProductionTemperature4;
            var ProductionTemperature5 = molassesDayTransaction.ProductionTemperature5;
            var RecirculationHours = molassesDayTransaction.RecirculationHours;
            var WaterSpayHours = molassesDayTransaction.WaterIn5;
            var UnitID = molassesDayTransaction.UnitId;
            DataTable data = SMS.InsertMolassesDayTransaction(Id, MolassesTankID, TransactionDate, Production, ShiftingIN, Sales, ShiftingOut, InTemperature1, InTemperature2, InTemperature3, InTemperature4, InTemperature5, OutTemperature1, OutTemperature2, OutTemperature3, OutTemperature4, OutTemperature5, WaterIn1, WaterIn2, WaterIn3, WaterIn4, WaterIn5, WaterOut1, WaterOut2, WaterOut3, WaterOut4, WaterOut5, MolassesTemperature1, MolassesTemperature2, MolassesTemperature3, MolassesTemperature4, MolassesTemperature5, Brix, TRS, ProductionTemperature1, ProductionTemperature2, ProductionTemperature3, ProductionTemperature4, ProductionTemperature5, RecirculationHours, WaterSpayHours, UnitID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("MolassesDayTransaction");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("MolassesDayTransaction");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!...........");
                return RedirectToAction("MolassesDayTransaction");
            }

        }
        #endregion MolassesDayTransaction
        #region SugarGodown
        public ActionResult SugarGodown()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSugarGodown(int id = 0)
        {
            if (id == 0)
                return View(new SugarGodown());
            else
            {
                List<SugarGodown> sugarGodown = new List<SugarGodown>();
                //List<Centre> Centerlist = new List<Centre>();
                sugarGodown = SMS.SugarGodown("");
                return View(sugarGodown.Where(x => x.SugarGodownId == id).FirstOrDefault<SugarGodown>());
            }

        }
        [HttpPost]
        public ActionResult AddeditSugarGodown(SugarGodown sugarGodown)
        {
            var Id = sugarGodown.SugarGodownId;
            var GodownNumber = sugarGodown.GodownNumber;
            var LotNumber = sugarGodown.LotNumber;
            var CrushingSeasonID = sugarGodown.CrushingSeasonId;
            var Grade = sugarGodown.Grade;
            var PackSize = sugarGodown.PackSize;
            var PackType = sugarGodown.PackType;
            var Opening = sugarGodown.Opening;
            var Discontinued = sugarGodown.Discontinued;
            DataTable data = SMS.InsertSugarGodown(Id, GodownNumber, LotNumber, CrushingSeasonID, Grade, PackSize, PackType, Opening, Discontinued);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SugarGodown");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SugarGodown");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong");
                return RedirectToAction("SugarGodown");
            }

        }
        [HttpPost]
        public JsonResult SugarGodownData(string Crushingseason)
        {
            //var data = TPTServices.UnitParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SugarGodown> molassesDayTransaction = new List<SugarGodown>();
            molassesDayTransaction = SMS.SugarGodown(Crushingseason);
            int rowstotal = molassesDayTransaction.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                molassesDayTransaction = molassesDayTransaction.Where(x => x.SugarGodownId.ToString().Contains(searchvalue.ToLower()) || x.GodownNumber.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString
                
                ().Contains(searchvalue.ToLower()) || x.LotNumber.ToLower().Contains(searchvalue.ToLower()) || x.Grade.ToLower().Contains(searchvalue.ToLower()) || x.PackSize.ToString().Contains(searchvalue.ToLower()) || x.PackType.ToString().Contains(searchvalue.ToLower()) || x.Opening.ToString().Contains(searchvalue.ToLower()) || x.CrushingSeasonCrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) ).ToList<SugarGodown>();
            }
            int totalrowsafterfiltering = molassesDayTransaction.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            molassesDayTransaction = molassesDayTransaction.Skip(start).Take(length).ToList<SugarGodown>();
            return Json(new { data = molassesDayTransaction, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion SugarGodown
        #region SugarDayTransaction
        [HttpGet]
        public ActionResult SugarDayTransaction()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditSugarDayTransaction(int id=0)
        {
            if (id == 0)
                return View(new SugarDayTransaction());
            else
            {
                List<SugarDayTransaction> tptPowerSeason = new List<SugarDayTransaction>();
                //List<Centre> Centerlist = new List<Centre>();
                tptPowerSeason = SMS.SugarDayTransaction("", "","","");
                return View(tptPowerSeason.Where(x => x.SugarDayTransactionId == id).FirstOrDefault<SugarDayTransaction>());
            }
           
        }
        [HttpPost]
        public ActionResult AddeditSugarDayTransaction(SugarDayTransaction sugarDayTransaction)
        {
            var Id = sugarDayTransaction.SugarDayTransactionId;
            var SugarGodownID = sugarDayTransaction.SugarGodownId;
            var TransactionDate = sugarDayTransaction.TransactionDate;
            var Production = sugarDayTransaction.Production;
            var ShiftingIN = sugarDayTransaction.ShiftingIn;
            var Sales = sugarDayTransaction.Sales;
            var ShiftingOut = sugarDayTransaction.ShiftingOut;
            var TornBagCount = sugarDayTransaction.TornBagCount;
            var ICUMSAValue = sugarDayTransaction.IcumsaValue;
            var MoistureValue = sugarDayTransaction.MoistureValue;
            var LineReplaceDate = sugarDayTransaction.LineReplaceDate;
            var UnitID = sugarDayTransaction.UnitId;
            DataTable data = SMS.InsertSugarDayTransaction(Id, SugarGodownID, TransactionDate, Production, ShiftingIN, Sales, ShiftingOut, TornBagCount, ICUMSAValue, MoistureValue, LineReplaceDate, UnitID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SugarDayTransaction");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SugarDayTransaction");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!...........");
                return RedirectToAction("SugarDayTransaction");
            }

        }
        [HttpPost]
        public JsonResult SugarDayTransactionData(string Unit, string SugarGodown, string TransactionDate, string TransactionDate2)
        {
            //var data = TPTServices.UnitParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SugarDayTransaction> sugarDayTransactions = new List<SugarDayTransaction>();
            sugarDayTransactions = SMS.SugarDayTransaction(Unit, SugarGodown, TransactionDate, TransactionDate2);
            int rowstotal = sugarDayTransactions.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                sugarDayTransactions = sugarDayTransactions.Where(x => x.SugarGodownId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.SugarDayTransactionId.ToString().Contains(searchvalue.ToLower()) || x.SugarGodownGodownNumber.ToLower().Contains(searchvalue.ToLower()) || x.TransactionDate.ToString().Contains(searchvalue.ToLower()) || x.Production.ToString().Contains(searchvalue.ToLower()) || x.ShiftingIn.ToString().Contains(searchvalue.ToLower()) || x.Sales.ToString().Contains(searchvalue.ToLower()) || x.ShiftingOut.ToString().Contains(searchvalue.ToLower()) || x.TornBagCount.ToString().Contains(searchvalue.ToLower()) || x.IcumsaValue.ToString().Contains(searchvalue.ToLower()) || x.MoistureValue.ToString().Contains(searchvalue.ToLower()) || x.LineReplaceDate.ToString().Contains(searchvalue.ToLower())).ToList<SugarDayTransaction>();
            }
            int totalrowsafterfiltering = sugarDayTransactions.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            sugarDayTransactions = sugarDayTransactions.Skip(start).Take(length).ToList<SugarDayTransaction>();
            return Json(new { data = sugarDayTransactions, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion SugarDayTransaction
        #region SugarWeekTransaction
        public ActionResult SugarWeekTransaction()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult SugarWeekTransactionData(string Unit, string SugarGodown)
        {
            //var data = TPTServices.UnitParameter();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<SugarWeekTransaction> sugarDayTransactions = new List<SugarWeekTransaction>();
            sugarDayTransactions = SMS.SugarWeekTransaction(Unit, SugarGodown);
            int rowstotal = sugarDayTransactions.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                sugarDayTransactions = sugarDayTransactions.Where(x => x.SugarGodownId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.SugarWeekTransactionId.ToString().Contains(searchvalue.ToLower()) || x.SugarGodownGodownNumber.ToLower().Contains(searchvalue.ToLower())   || x.IcumsaValue.ToString().Contains(searchvalue.ToLower()) || x.MoistureValue.ToString().Contains(searchvalue.ToLower())).ToList<SugarWeekTransaction>();
            }
            int totalrowsafterfiltering = sugarDayTransactions.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            sugarDayTransactions = sugarDayTransactions.Skip(start).Take(length).ToList<SugarWeekTransaction>();
            return Json(new { data = sugarDayTransactions, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddeditSugarWeekTransaction(int id = 0)
        {
            if (id == 0)
                return View(new SugarWeekTransaction());
            else
            {
                List<SugarWeekTransaction> tptPowerSeason = new List<SugarWeekTransaction>();
                //List<Centre> Centerlist = new List<Centre>();
                tptPowerSeason = SMS.SugarWeekTransaction("", "");
                return View(tptPowerSeason.Where(x => x.SugarWeekTransactionId == id).FirstOrDefault<SugarWeekTransaction>());
            }

        }
        [HttpPost]
        public ActionResult AddeditSugarWeekTransaction(SugarWeekTransaction sugarWeekTransaction)
        {
            var Id = sugarWeekTransaction.SugarWeekTransactionId;
            var SugarGodownID = sugarWeekTransaction.SugarGodownId;
            
            var ICUMSAValue = sugarWeekTransaction.IcumsaValue;
            var MoistureValue = sugarWeekTransaction.MoistureValue;
            var TransactionWeek = sugarWeekTransaction.TransactionWeek;
            var UnitID = sugarWeekTransaction.UnitId;
            DataTable data = SMS.InsertSugarWeekTransaction(Id, SugarGodownID, TransactionWeek, ICUMSAValue, MoistureValue, UnitID);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (data.Rows.Count > 0)
            {
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("SugarWeekTransaction");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("SugarWeekTransaction");
                }
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong");
                return RedirectToAction("SugarWeekTransaction");
            }

        }
           #endregion SugarWeekTransaction
    }
}