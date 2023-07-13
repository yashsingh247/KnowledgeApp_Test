using KnowledgeApp_Test.Models.Control;
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
    public class ControlController : Controller
    {
        ControlService controlService = new ControlService();
        //CommonServices commonServices = new CommonServices();
        DropdownListSevices DropdownListSevices = new DropdownListSevices();
        // GET: Control
        #region BrixWeight
        public ActionResult BrixWeight()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditBrixWeight(int id=0) 
        {
            if (id == 0)
                return View(new BrixWeight());
            else
            {
                List<BrixWeight> Brix = new List<BrixWeight>();
                //List<Centre> Centerlist = new List<Centre>();
                Brix = controlService.GetBrixWeight();
                return View(Brix.Where(x => x.BrixWeightId == id).FirstOrDefault<BrixWeight>());

            }
        }
        public JsonResult BrixWeightData()
        {
           // var data = controlService.GetBrixWeight();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<BrixWeight> BrixWeightlist = new List<BrixWeight>();
            BrixWeightlist = controlService.GetBrixWeight();
            int rowstotal = BrixWeightlist.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                BrixWeightlist = BrixWeightlist.Where(x => x.ValueAt20.ToString().Contains(searchvalue.ToLower()) || x.ValueAt27.ToString().Contains(searchvalue.ToLower()) || x.BrixValue.ToString().Contains(searchvalue.ToLower()) || x.BrixWeightId.ToString().Contains(searchvalue.ToLower())).ToList<BrixWeight>();

            }
            int totalrowsafterfiltering = BrixWeightlist.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            BrixWeightlist = BrixWeightlist.Skip(start).Take(length).ToList<BrixWeight>();
            return Json(new { data = BrixWeightlist, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddeditBrixWeight(BrixWeight brixWeight) 
        {
           
            var Id = brixWeight.BrixWeightId;
            var BrixValue = brixWeight.BrixValue;
            var value20 = brixWeight.ValueAt20;
            var value27 = brixWeight.ValueAt27;
            if (BrixValue == 0)
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Please Enter Brix Value");
                return RedirectToAction("BrixWeight");

            }
            DataTable data = controlService.InsertBrixWeight(Id, BrixValue, value20, value27);
            String sp_Status = data.Rows[0]["Status"].ToString();
            String sp_MSg = data.Rows[0]["Msg"].ToString();
            if (sp_Status == "1")
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                return RedirectToAction("BrixWeight");
            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                return RedirectToAction("BrixWeight");
            }

        }
        #endregion BrixWeight
        #region ControlParameterGroup
        public ActionResult ControlParameterGroup()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddEditControlParameterGroup(int id=0) 
        {
            if (id == 0)
                return View(new ControlParameterGroup());
            else
            {
                List<ControlParameterGroup> controlParameterGroup = new List<ControlParameterGroup>();
                //List<Centre> Centerlist = new List<Centre>();
                controlParameterGroup = controlService.GetControlParameterGroup();
                return View(controlParameterGroup.Where(x => x.ParameterGroupId == id).FirstOrDefault<ControlParameterGroup>());

            }
        }
        [HttpPost]
        public ActionResult AddEditControlParameterGroup(ControlParameterGroup controlParameterGroup)
        {
            var Id = controlParameterGroup.ParameterGroupId;
            var CtrlPName = controlParameterGroup.ControlParameterGroupName;
            var serialorder = controlParameterGroup.SerialOrder;
            DataTable data = controlService.InsertControlParameterGroup(Id, CtrlPName, serialorder);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("ControlParameterGroup");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("ControlParameterGroup");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("ControlParameterGroup");
            }
        }
        [HttpPost]
            public JsonResult ControlParameterGroupData()
        {
           // var data = controlService.GetControlParameterGroup();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ControlParameterGroup> controlParameterGroup = new List<ControlParameterGroup>();
            controlParameterGroup = controlService.GetControlParameterGroup();
            int rowstotal = controlParameterGroup.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                controlParameterGroup = controlParameterGroup.Where(x => x.ControlParameterGroupName.ToLower().Contains(searchvalue.ToLower()) || x.SerialOrder.ToString().Contains(searchvalue.ToLower()) || x.ParameterGroupId.ToString().Contains(searchvalue.ToLower())).ToList<ControlParameterGroup>();

            }
            int totalrowsafterfiltering = controlParameterGroup.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            controlParameterGroup = controlParameterGroup.Skip(start).Take(length).ToList<ControlParameterGroup>();
            return Json(new { data = controlParameterGroup, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        #endregion ControlParameterGroup
        #region Date Configuration
        public ActionResult DateConfiguration()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpGet]
        public ActionResult AddeditDateConfiguration(int id=0) 
        {
            if (id == 0)
                return View(new DateConfiguration());
            else
            {
                List<DateConfiguration> dateConfiguration = new List<DateConfiguration>();
                //List<Centre> Centerlist = new List<Centre>();
                dateConfiguration = controlService.GetDateConfiguration("");
                return View(dateConfiguration.Where(x => x.DateConfigurationId == id).FirstOrDefault<DateConfiguration>());

            }
        }
        [HttpPost]
        public ActionResult AddeditDateConfiguration(DateConfiguration dateConfiguration) 
        {
            var Id = dateConfiguration.DateConfigurationId;
            var CngfgDate = dateConfiguration.ConfigurationDate;
            var type = dateConfiguration.ConfigurationType;
            var Unit = dateConfiguration.UnitId;
            DataTable data = controlService.InsertDateConfiguration(Id, CngfgDate,type, Unit);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("DateConfiguration");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("DateConfiguration");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("DateConfiguration");
            }
        }
        [HttpPost]
        public JsonResult DateConfigurationData(string Unit)
        {
            //var data = controlService.GetDateConfiguration(Unit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DateConfiguration> dateConfiguration = new List<DateConfiguration>();
            dateConfiguration = controlService.GetDateConfiguration(Unit);
            int rowstotal = dateConfiguration.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                dateConfiguration = dateConfiguration.Where(x => x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.ConfigurationDate.ToString().Contains(searchvalue.ToLower()) || x.DateConfigurationId.ToString().Contains(searchvalue.ToLower()) || x.ConfigurationType.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<DateConfiguration>();

            }
            int totalrowsafterfiltering = dateConfiguration.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            dateConfiguration = dateConfiguration.Skip(start).Take(length).ToList<DateConfiguration>();
            return Json(new { data = dateConfiguration, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        #endregion DateConfiguration
        #region ConterolParameter
        public ActionResult ControlParameter()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        [HttpPost]
        public JsonResult ControlParameterData(string ControlParameterGroup)
        {
            // var data = controlService.GetControlParameter(ControlParameterGroup);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ControlParameter> controlParameter = new List<ControlParameter>();
            controlParameter = controlService.GetControlParameter(ControlParameterGroup);
            int rowstotal = controlParameter.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                controlParameter = controlParameter.Where(x => x.ParameterName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterGroupName.ToLower().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.SerialOrder.ToString().Contains(searchvalue.ToLower()) || x.ParameterType.ToString().Contains(searchvalue.ToLower()) || x.ParameterWidth.ToString().Contains(searchvalue.ToLower()) || x.ParameterGroupId.ToString().Contains(searchvalue.ToLower()) || x.ParameterCode.ToLower().Contains(searchvalue.ToLower())).ToList<ControlParameter>();

            }
            int totalrowsafterfiltering = controlParameter.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            controlParameter = controlParameter.Skip(start).Take(length).ToList<ControlParameter>();
            return Json(new { data = controlParameter, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditControlParameter(int id=0) 
        {
            if (id == 0)
                return View(new ControlParameter());
            else
            {
                List<ControlParameter> controlParameter = new List<ControlParameter>();
                //List<Centre> Centerlist = new List<Centre>();
                controlParameter = controlService.GetControlParameter("");
                return View(controlParameter.Where(x => x.ParameterId == id).FirstOrDefault<ControlParameter>());

            }
        }
        [HttpPost]
        public ActionResult AddeditControlParameter(ControlParameter controlParameter)
        {
            var Id = controlParameter.ParameterId;
            var PCode = controlParameter.ParameterCode;
            var PName = controlParameter.ParameterName;
            var Desc = controlParameter.ParameterDescription;
            var PGroup = controlParameter.ParameterGroupId;
            var Serial = controlParameter.SerialOrder;
            var Ptype = controlParameter.ParameterType;
            var PWidth = controlParameter.ParameterWidth;


            DataTable data = controlService.InsertControlParameter(Id, PCode, PName, Desc, PGroup, Serial, Ptype, PWidth);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("ControlParameter");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("ControlParameter");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("ControlParameter");
            }
        }
        #endregion ConterolParameter
        #region ControlParameterValue
        public ActionResult ControlParameterValue()
        {
            ViewBag.Alert = TempData["Alert"];
            return View();
        }
        public JsonResult ControlParameterValueData(string ControlParameter, string Unit)
        {
            //var data = controlService.GetControlParameterValueData(ControlParameterGroup, Unit);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<ControlParameterValue> controlParameterValue = new List<ControlParameterValue>();
            controlParameterValue = controlService.GetControlParameterValueData(ControlParameter, Unit);
            int rowstotal = controlParameterValue.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                controlParameterValue = controlParameterValue.Where(x => x.ParameterCode.ToLower().Contains(searchvalue.ToLower()) || x.ParameterId.ToString().Contains(searchvalue.ToLower()) || x.ControlParameterValueId.ToString().Contains(searchvalue.ToLower()) || x.UnitId.ToString().Contains(searchvalue.ToLower()) || x.ParameterValue.ToString().Contains(searchvalue.ToLower())||x.UnitUnitName.ToLower().Contains(searchvalue.ToLower())||x.UnitId.ToString().Contains(searchvalue.ToLower())).ToList<ControlParameterValue>();

            }
            int totalrowsafterfiltering = controlParameterValue.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            controlParameterValue = controlParameterValue.Skip(start).Take(length).ToList<ControlParameterValue>();
            return Json(new { data = controlParameterValue, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddeditControlParameterValue(int id = 0)
        {
            if (id == 0)
                return View(new ControlParameterValue());
            else
            {
                List<ControlParameterValue> controlParameterValue = new List<ControlParameterValue>();
                //List<Centre> Centerlist = new List<Centre>();
                controlParameterValue = controlService.GetControlParameterValueData("","");
                return View(controlParameterValue.Where(x => x.ControlParameterValueId == id).FirstOrDefault<ControlParameterValue>());

            }

        }

       [HttpPost]
        public ActionResult AddeditControlParameterValue(ControlParameterValue controlParameterValue)
        {
            var Id = controlParameterValue.ControlParameterValueId;
            var PId = controlParameterValue.ParameterId;
            var Unit = controlParameterValue.UnitId;
            var PValue = controlParameterValue.ParameterValue;
            DataTable data = controlService.InsertControlParameterValue(Id,PId,Unit,PValue);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("ControlParameterValue");
                }
                else
                {
                    TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("ControlParameterValue");
                }

            }
            else
            {
                TempData["Alert"] = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("ControlParameterValue");
            }
        }
        #endregion ControlParameterValue
    }

}