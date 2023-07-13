using KnowledgeApp_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Configuration;
using KnowledgeApp_Test.Services;
using KnowledgeApp_Test.Models.Account;
using static KnowledgeApp_Test.Models.Common_Model.Alert;
using KnowledgeApp_Test.Models.Administration;
using System.Web.Helpers;
using System.Drawing;

using System.Collections;
using Newtonsoft.Json;

namespace KnowledgeApp_Test.Controllers
{
    public class LoginController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        GeneralServices GS = new GeneralServices();
        LoginServices LS = new LoginServices();
        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account account)
        {
            
            var UserName = account.UserName;
            var Password = account.Password;
            DataTable data = LS.Account(UserName, Password);
            var Roles = "0";
            var Unit = "0";
            if (data.Rows.Count > 0)
            {
                for( int i = 0; i < data.Rows.Count; i++)
                {
                    Roles =Roles+","+ data.Rows[i]["RoleId"].ToString();
                    Unit = Unit +"," + data.Rows[i]["UnitID"].ToString();
                }
                this.Session["Account"] = data;
                String sp_Status = data.Rows[0]["Username"].ToString();
                String UserId = data.Rows[0]["UserId"].ToString();
                Session["UserName"] = sp_Status;
                Session["UserId"] = UserId;
                //Session["UnitID"] = UnitID;
                List<RolePermisssion> menulist = new List<RolePermisssion>();
                menulist = LS.USerMenuList(Session["UserId"].ToString(), Roles, Unit);
                Session["Menu"] = menulist;
              
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Employee added");
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Your UserName Or Password is Incorrect");
                return View("Login");
            }
        }


        public ActionResult Logout()
        {
            this.Session["Account"]=null;
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult DashBoard()
        {
            List<DashBoard> Ds = new List<DashBoard>();
            Ds = LS.DashBoard();
            ViewBag.DataPoints = JsonConvert.SerializeObject(Ds, _jsonSetting);
            return View();
           
        }
       



        public ActionResult BarChart()
        {
            List<DashBoard> entities = new List<DashBoard>();
            entities = LS.DashBoard();
            return Json(entities, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult PartialMenuList()
        {

            return PartialView("_PartialMenuList", Session["Menu"]);
        }

        public ActionResult Access()
        {
            return View();
        }
        public ActionResult RigthsData(string FormName)
        {
            List<RolePermisssion> menulist = new List<RolePermisssion>();
            menulist = GS.ValidateForm(FormName);
            if (menulist != null && menulist.Count > 0)
            {
                return Json(new { data = menulist }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return RedirectToAction("Login");
            }
        }
        public JsonResult DeleteDatabyId(string TableName, string Id)
        {
            string msg = "";
            DataTable dt = GS.DeleteDatasingleparameter(TableName, Id);

            if (dt.Rows.Count > 0)
            {
                String sp_Status = dt.Rows[0]["Status"].ToString();
                String sp_MSg = dt.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {
                    msg = CommonServices.ShowAlert(Alerts.Success, sp_MSg);
                    return Json(new { hasError = true, message = msg }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    msg = CommonServices.ShowAlert(Alerts.Danger, sp_MSg);
                    return Json(new { hasError = false, message = msg }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                msg = CommonServices.ShowAlert(Alerts.Danger, "Something Wents Wrong!...........");
                return Json(new { hasError = false, message = msg }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}