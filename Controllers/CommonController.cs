using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using KnowledgeApp_Test.Models;
using KnowledgeApp_Test.Services;
//using System.Linq.Dynamic;
using static KnowledgeApp_Test.Models.Common_Model.Alert;
using KnowledgeApp_Test.Models.Common;
using System.Globalization;
using KnowledgeApp_Test.Models.Administration;
//using System.Web.SessionState;

namespace KnowledgeApp_Test.Controllers
{

    public class CommonController : Controller
    {
        CommonServices commonServices = new CommonServices();
        DropdownListSevices dropdownListSevices = new DropdownListSevices();
        
        #region Enterprise   
        [HttpGet]
        public ActionResult EnterpriseList()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }

        [HttpPost]
        public JsonResult EnterpriseData()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Enterprise> entrepriselist = new List<Enterprise>();
            entrepriselist = commonServices.GetEnterprises();
            int rowstotal = entrepriselist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                entrepriselist = entrepriselist.Where(x => x.EnterpriseName.ToLower().Contains(searchvalue.ToLower()) || x.AddressLine1.ToLower().Contains(searchvalue.ToLower()) || x.AddressLine2.ToLower().Contains(searchvalue.ToLower()) || x.EnterpriseId.ToString().Contains(searchvalue.ToLower())).ToList<Enterprise>();

            }
            int totalrowsafterfiltering = entrepriselist.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            entrepriselist = entrepriselist.Skip(start).Take(length).ToList<Enterprise>();
            return Json(new { data = entrepriselist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEditEnterprise(int id = 0)
        {
            //var entrpriseId = Convert.ToInt32(entrprise);
            if (id == 0)
                return View(new Enterprise());
            else
            {
                List<Enterprise> enterprise = new List<Enterprise>();
                //List<Centre> Centerlist = new List<Centre>();
                enterprise = commonServices.GetEnterprises();
                return View(enterprise.Where(x => x.EnterpriseId == id).FirstOrDefault<Enterprise>());

            }
        }

        [HttpPost]
        public ActionResult AddEditEnterprise(Enterprise enterprise)
        {
            var Id = enterprise.EnterpriseId;
            var Name = enterprise.EnterpriseName;
            var Address1 = enterprise.AddressLine1;
            var Address2 = enterprise.AddressLine2;
            DataTable data = commonServices.InsertEnterPrise(Id, Name, Address1, Address2);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {


               TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("EnterpriseList");
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("EnterpriseList");
            }

        }
        #endregion Enterprises
        #region Company 
        [HttpGet]
        public ActionResult AddEditCompany(int id = 0)
        {
            if (id == 0)
                return View(new Company());
            else
            {
                List<Company> company = new List<Company>();
                //List<Centre> Centerlist = new List<Centre>();
                company = commonServices.GetCompany("");
                return View(company.Where(x => x.CompanyId == id).FirstOrDefault<Company>());

            }

        }
        [HttpGet]
        public ActionResult Company()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public ActionResult AddEditCompany(Company company)
        {
            int id = company.CompanyId;
            int Entrprise = company.EnterpriseId;
            var Name = company.CompanyName;
            var Address1 = company.AddressLine1;
            var Address2 = company.AddressLine2;
            DataTable data = commonServices.InsertCompany(id, Entrprise, Name, Address1, Address2);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Company");
                }
                else
                {
                    TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Company");
                }

            }
            else
            {

                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Some thing Wents Wrong");
                return RedirectToAction("Company");
            }

        }
        [HttpPost]
        public JsonResult CompanyData(string Enterprise)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Company> companylist = new List<Company>();
            companylist = commonServices.GetCompany(Enterprise);
            int rowstotal = companylist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                companylist = companylist.Where(x => x.CompanyName.ToLower().Contains(searchvalue.ToLower()) || x.AddressLine1.ToLower().Contains(searchvalue.ToLower()) || x.AddressLine2.ToLower().Contains(searchvalue.ToLower()) || x.CompanyId.ToString().Contains(searchvalue.ToLower())).ToList<Company>();
            }
            int totalrowsafterfiltering = companylist.Count;
            companylist = companylist.Skip(start).Take(length).ToList<Company>();
            return Json(new { data = companylist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion Company
        #region Crushing Season

        [HttpGet]
        public ActionResult CrushingSeason()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult CrushingSeasonData()
        {
            //var data = commonServices.GetCrushingSeasonData();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<CrushingSeason> crushingSeason = new List<CrushingSeason>();
            crushingSeason = commonServices.GetCrushingSeasonData();
            int rowstotal = crushingSeason.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                crushingSeason = crushingSeason.Where(x => x.CrushingSeasonName.ToLower().Contains(searchvalue.ToLower()) || x.CrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.SeasonYear.ToString().Contains(searchvalue.ToLower())).ToList<CrushingSeason>();

            }
            int totalrowsafterfiltering = crushingSeason.Count;
            crushingSeason = crushingSeason.Skip(start).Take(length).ToList<CrushingSeason>();
            return Json(new { data = crushingSeason, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddeditCrushingSeason(int id = 0)
        {
            if (id == 0)
                return View(new CrushingSeason());
            else
            {
                List<CrushingSeason> crushingSeason = new List<CrushingSeason>();
                //List<Centre> Centerlist = new List<Centre>();
                crushingSeason = commonServices.GetCrushingSeasonData();
                return View(crushingSeason.Where(x => x.CrushingSeasonId == id).FirstOrDefault<CrushingSeason>());

            }

        }
        [HttpPost]
        public ActionResult AddeditCrushingSeason(CrushingSeason crushingSeason)
        {
            var Id = crushingSeason.CrushingSeasonId;
            var SeasonName = crushingSeason.CrushingSeasonName;
            var seasonYear = crushingSeason.SeasonYear;

            DataTable data = commonServices.InsertCrushingSeason(Id, SeasonName, seasonYear);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {


                 TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("CrushingSeason");
            }
            else
            {
                 TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("CrushingSeason");
            }

        }


        #endregion Crushing Season
        #region UnitCrushingSeason 
        public ActionResult UnitCrushingSeason()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditUnitCrushingSeason(int id = 0)
        {
            if (id == 0)
                return View(new UnitCrushingSeason());
            else
            {
                List<UnitCrushingSeason> unitCrushingSeason = new List<UnitCrushingSeason>();
                //List<Centre> Centerlist = new List<Centre>();
                unitCrushingSeason = commonServices.GetUnitCrushingSeasonData("", "", "", "");
                return View(unitCrushingSeason.Where(x => x.UnitCrushingSeasonId == id).FirstOrDefault<UnitCrushingSeason>());
            }

        }

        [HttpPost]
        public JsonResult UnitCrushingSeasonData(string CrushingSeason, string Unit, string CrushingStartDate, string CrushingEndDate)
        {
            //var data = commonServices.GetUnitCrushingSeasonData(CrushingSeason, Unit, CrushingStartDate,CrushingEndDate);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<UnitCrushingSeason> UnitcrushingSeason = new List<UnitCrushingSeason>();
            UnitcrushingSeason = commonServices.GetUnitCrushingSeasonData(CrushingSeason, Unit, CrushingStartDate, CrushingEndDate);
            int rowstotal = UnitcrushingSeason.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                UnitcrushingSeason = UnitcrushingSeason.Where(x => x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.UnitCrushingSeasonId.ToString().Contains(searchvalue.ToLower()) || x.CrushingStartDate.ToString().Contains(searchvalue.ToLower()) || x.CrushingEndDate.ToString().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.MinutesDelayedStart.ToString().Contains(searchvalue.ToLower()) || x.MinutesEarlyEnd.ToString().Contains(searchvalue.ToLower())).ToList<UnitCrushingSeason>();

            }
            int totalrowsafterfiltering = UnitcrushingSeason.Count;
            UnitcrushingSeason = UnitcrushingSeason.Skip(start).Take(length).ToList<UnitCrushingSeason>();
            return Json(new { data = UnitcrushingSeason, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddeditUnitCrushingSeason(UnitCrushingSeason unitCrushingSeason)
        {
            var Id = unitCrushingSeason.UnitCrushingSeasonId;
            var CrushingSeasonId = unitCrushingSeason.CrushingSeasonId;
            var UnitId = unitCrushingSeason.UnitId;
            var Startdate = unitCrushingSeason.CrushingStartDate;
            var Enddate = unitCrushingSeason.CrushingEndDate;
            var DelayedStart = unitCrushingSeason.MinutesDelayedStart;
            var EarlyEnd = unitCrushingSeason.MinutesEarlyEnd;
           DataTable data = commonServices.InsetUnitCrushingSeason(Id, CrushingSeasonId, UnitId, Startdate, Enddate, DelayedStart, EarlyEnd);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("UnitCrushingSeason");
            }
            else
            {
                TempData["Alert"] = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("UnitCrushingSeason");
            }

        }




        #endregion UnitCrushingSeason
        #region Centre
        [HttpPost]
        public JsonResult CentreData()
        {
            //var data = commonServices.GetCentreData();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Centre> Centerlist = new List<Centre>();
            Centerlist = commonServices.GetCentreData();
            int rowstotal = Centerlist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                Centerlist = Centerlist.Where(x => x.CName.ToLower().Contains(searchvalue.ToLower()) || x.CHname.ToLower().Contains(searchvalue.ToLower()) || x.CCreatedBy.ToLower().Contains(searchvalue.ToLower()) || x.CEditedBy.ToLower().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.CId.ToString().Contains(searchvalue.ToLower())).ToList<Centre>();
            }
            int totalrowsafterfiltering = Centerlist.Count;
            Centerlist = Centerlist.Skip(start).Take(length).ToList<Centre>();
            return Json(new { data = Centerlist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Centre()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public ActionResult AddEditCentre(Centre centre)
        {
            var Id = centre.CId;
            var ccode = centre.CCode;
            var CName = centre.CName;
            var CHname = centre.CHname;
            var CCreatedby = centre.CCreatedBy;
            var CEditedby = centre.CEditedBy;
            var Unit = centre.UnitID;
            DataTable data = commonServices.InsertCentre(Id, ccode, CName, CHname, CCreatedby, CEditedby, Unit);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Centre");
                }
                else
                {
                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Centre");
                }

            }
            else
            {
                TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Centre");
            }
        }

        [HttpGet]
        public ActionResult AddEditCentre(int id = 0)
        {
            if (id == 0)
                return View(new Centre());
            else
            {
                List<Centre> centre = new List<Centre>();
                //List<Centre> Centerlist = new List<Centre>();
                centre = commonServices.GetCentreData();
                return View(centre.Where(x => x.CId == id).FirstOrDefault<Centre>());
            }
        }
        #endregion Centre
        #region Village
        [HttpGet]
        public ActionResult Village()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditVillage(int id = 0)
        {
            if (id == 0)
                return View(new Village());
            else
            {
                List<Village> village = new List<Village>();
                //List<Centre> Centerlist = new List<Centre>();
                village = commonServices.GetVillageData();
                return View(village.Where(x => x.VId == id).FirstOrDefault<Village>());
            }
        }
        [HttpPost]
        public ActionResult AddeditVillage(Village village)
        {
            var Id = village.VId;
            var Vcode = village.VCode;
            var VName = village.VName;
            var VHname = village.VHname;
            var Centre = village.Centreid;
            var VCreatedby = village.VCreatedBy;
            var VEditedby = village.VEditedBy;
            var Unit = village.UnitId;
            DataTable data = commonServices.InsertVillage(Id, Vcode, VName, VHname, Centre, VCreatedby, VEditedby, Unit);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Village");
                }
                else
                {
                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Village");
                }

            }
            else
            {
                TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Village");
            }
        }


        [HttpPost]
        public JsonResult VillageData()
        {
            //var data = commonServices.GetVillageData();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Village> Villagelist = new List<Village>();
            Villagelist = commonServices.GetVillageData();
            int rowstotal = Villagelist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                Villagelist = Villagelist.Where(x => x.VName.ToLower().Contains(searchvalue.ToLower()) || x.VHname.ToLower().Contains(searchvalue.ToLower()) || x.VCreatedBy.ToLower().Contains(searchvalue.ToLower()) || x.VEditedBy.ToLower().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.VId.ToString().Contains(searchvalue.ToLower()) || x.VCode.ToString().Contains(searchvalue.ToLower()) || x.VCentreCName.ToLower().Contains(searchvalue.ToLower())).ToList<Village>();
            }
            int totalrowsafterfiltering = Villagelist.Count;
            Villagelist = Villagelist.Skip(start).Take(length).ToList<Village>();
            return Json(new { data = Villagelist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        #endregion Village
        #region Variety
        public ActionResult Variety()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult VarietyData()
        {
            // var data = commonServices.GetVarietyData();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Variety> Varietylist = new List<Variety>();
            Varietylist = commonServices.GetVarietyData();
            int rowstotal = Varietylist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                Varietylist = Varietylist.Where(x => x.VrName.ToLower().Contains(searchvalue.ToLower()) || x.VrMatPeriod.ToString().Contains(searchvalue.ToLower()) || x.VrCreatedBy.ToLower().Contains(searchvalue.ToLower()) || x.VrEditedBy.ToLower().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.VrId.ToString().Contains(searchvalue.ToLower()) || x.VrCode.ToString().Contains(searchvalue.ToLower()) || x.VrAvgLoss.ToString().Contains(searchvalue.ToLower()) || x.VrMaxdt.ToString().Contains(searchvalue.ToLower()) || x.VrMaxRec.ToString().Contains(searchvalue.ToLower()) || x.VrCode.ToString().Contains(searchvalue.ToLower())).ToList<Variety>();
            }
            int totalrowsafterfiltering = Varietylist.Count;
            Varietylist = Varietylist.Skip(start).Take(length).ToList<Variety>();
            return Json(new { data = Varietylist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddeditVariety(int id = 0)
        {
            if (id == 0)
                return View(new Variety());
            else
            {
                List<Variety> variety = new List<Variety>();
                //List<Centre> Centerlist = new List<Centre>();
                variety = commonServices.GetVarietyData();
                return View(variety.Where(x => x.VrId == id).FirstOrDefault<Variety>());
            }

        }

        [HttpPost]
        public ActionResult AddeditVariety(Variety variety)
        {
            var Id = variety.VrId;
            var Vrcode = variety.VrCode;
            var VrName = variety.VrName;
            var VrMaxRec = variety.VrMaxRec;
            var VrMaxdt = variety.VrMaxdt;
            var VrMatPeriod = variety.VrMatPeriod;
            var VrAvgLoss = variety.VrAvgLoss;
            var VrCreatedby = variety.VrCreatedBy;
            var VrEditedby = variety.VrEditedBy;
            var Unit = variety.UnitId;
           DataTable data = commonServices.InsertVariety(Id, Vrcode, VrName, VrMaxRec, VrMaxdt, VrMatPeriod, VrAvgLoss, VrCreatedby, VrEditedby, Unit);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Variety");
                }
                else
                {
                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Variety");
                }

            }
            else
            {
                TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Variety");
            }
        }

        #endregion Variety
        #region Grower
        public ActionResult Grower()
        {
           
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        public JsonResult GrowerData()
        {
           // var data = commonServices.GetGrowerData();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Grower> Growerlist = new List<Grower>();
            Growerlist = commonServices.GetGrowerData();
            int rowstotal = Growerlist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                Growerlist = Growerlist.Where(x => x.GName.ToLower().Contains(searchvalue.ToLower()) || x.GVillVName.ToLower().Contains(searchvalue.ToLower()) || x.GHname.ToLower().Contains(searchvalue.ToLower()) || x.GHfather.ToLower().Contains(searchvalue.ToLower()) || x.GFather.ToLower().Contains(searchvalue.ToLower()) || x.GCreatedBy.ToLower().Contains(searchvalue.ToLower()) || x.GEditedBy.ToLower().Contains(searchvalue.ToLower()) || x.UnitName.ToLower().Contains(searchvalue.ToLower()) || x.GId.ToString().Contains(searchvalue.ToLower()) || x.GCode.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.GVill.ToString().Contains(searchvalue.ToLower())).ToList<Grower>();
            }
            int totalrowsafterfiltering = Growerlist.Count;
            Growerlist = Growerlist.Skip(start).Take(length).ToList<Grower>();
            return Json(new { data = Growerlist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditGrower(int id = 0)
        {

            if (id == 0)
                return View(new Grower());
            else
            {
                List<Grower> grower = new List<Grower>();
                //List<Centre> Centerlist = new List<Centre>();
                grower = commonServices.GetGrowerData();
                return View(grower.Where(x => x.GId == id).FirstOrDefault<Grower>());
            }
        }
        [HttpPost]
        public ActionResult AddeditGrower( Grower grower)
        {
            var Id = grower.GId;
            var GVill = grower.GVill;
            var GCode = grower.GCode;
            var GName = grower.GName;
            var GFather = grower.GFather;
            var GHname = grower.GHname;
            var GHfather = grower.GHfather;
            var GCreatedby = grower.GCreatedBy;
            var GEditedby = grower.GEditedBy;
            var Unit = grower.UnitId;
            DataTable data = commonServices.InsertGrower(Id, GVill, GCode, GName, GFather, GHname, GHfather, GCreatedby, GEditedby, Unit);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Grower");
                }
                else
                {
                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Grower");
                }

            }
            else
            {
                TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Grower");
            }
        }
        #endregion Groewr
        #region Unit
        [HttpGet]
        public ActionResult Unit()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditUnit(int id = 0) 
        {
            if (id == 0)
                return View(new Unit());
            else
            {
                List<Unit> unit = new List<Unit>();
               
                unit = commonServices.GetUnit("");
                return View(unit.Where(x => x.UnitId == id).FirstOrDefault<Unit>());

            }
        }
        [HttpPost]



        public ActionResult AddeditUnit(Unit unit)
        {
            var Id = unit.UnitId;
                int CountryId = unit.CompanyId;
                var Name = unit.UnitName;
                var Address1 = unit.AddressLine1;
                var Address2 = unit.AddressLine2;
                DataTable data = commonServices.InsertUnit(Id,CountryId, Name, Address1, Address2);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Unit");
                }
                else
                {
                    TempData["Alert"]= CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Unit");
                }
            }

            else
            {
                 TempData["Alert"]= CommonServices.ShowAlert(Alerts.Success, "Something Wents Wrong .......");
                return RedirectToAction("Unit");
            }

        }
       
        public JsonResult UnitData(string Company)
        {
            //var data = commonServices.GetUnit();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Unit> UnitList = new List<Unit>();
            UnitList = commonServices.GetUnit(Company);
            int rowstotal = UnitList.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                UnitList = UnitList.Where(x => x.CompanyName.ToLower().Contains(searchvalue.ToLower()) || x.AddressLine1.ToLower().Contains(searchvalue.ToLower()) || x.AddressLine2.ToLower().Contains(searchvalue.ToLower()) || x.CompanyId.ToString().Contains(searchvalue.ToLower())).ToList<Unit>();
            }
            int totalrowsafterfiltering = UnitList.Count;
            UnitList = UnitList.Skip(start).Take(length).ToList<Unit>();
            return Json(new { data = UnitList, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion Unit
    }
}