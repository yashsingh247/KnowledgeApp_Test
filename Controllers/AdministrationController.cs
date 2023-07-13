using KnowledgeApp_Test.Models.Administration;
using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Services;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Controllers
{
    public class AdministrationController : Controller
    {
        AdministrationServices As = new AdministrationServices();
        DropdownListSevices DS = new DropdownListSevices();
        // GET: Administration
        public ActionResult Role()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RoleData()
        {
            //var data = TPTServices.TptParameter(Parameter, ParameterUnit, TexParameter, WilParameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Role> role = new List<Role>();
            role = As.Roles();
            int rowstotal = role.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                role = role.Where(x => x.RoleName.ToLower().Contains(searchvalue.ToLower()) || x.RoleName.ToLower().Contains(searchvalue.ToLower())).ToList<Role>();

            }
            int totalrowsafterfiltering = role.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            role = role.Skip(start).Take(length).ToList<Role>();
            return Json(new { data = role, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Sergen()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UserData()
        {
            //var data = TPTServices.TptParameter(Parameter, ParameterUnit, TexParameter, WilParameter);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Users> users = new List<Users>();
            users = As.Users();
            int rowstotal = users.Count;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                users = users.Where(x => x.Username.ToLower().Contains(searchvalue.ToLower()) || x.DisplayName.ToLower().Contains(searchvalue.ToLower()) || x.UserId.ToString().Contains(searchvalue.ToLower()) || x.UnitUnitName.ToLower().Contains(searchvalue.ToLower()) || x.Email.ToLower().Contains(searchvalue.ToLower()) || x.Source.ToLower().Contains(searchvalue.ToLower()) || x.LastDirectoryUpdate.ToString().Contains(searchvalue.ToLower()) || x.InsertDate.ToString().Contains(searchvalue.ToLower()) || x.InsertUserId.ToString().Contains(searchvalue.ToLower()) || x.UpdateDate.ToString().Contains(searchvalue.ToLower()) || x.UpdateUserId.ToString().Contains(searchvalue.ToLower()) || x.IsActive.ToString().Contains(searchvalue.ToLower())).ToList<Users>();
            }
            int totalrowsafterfiltering = users.Count;
            //entrepriselist = entrepriselist.OrderBy(sortColumnName + "" + sortDirection).ToList<Enterprise>();
            users = users.Skip(start).Take(length).ToList<Users>();
            return Json(new { data = users, draw = Request["draw"], recordsTotal = rowstotal, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddeditUsers(int id = 0)
        {
            if (id == 0)
                return View(new Users());
            else
            {
                Users u = new Users();
                List<Users> users = new List<Users>();
                //List<Centre> Centerlist = new List<Centre>();
                users = As.Users();
                var A = As.UserUnitMapping(id);
              
                ViewBag.UnitId = As.UserUnitMapping(id);
                return View(users.Where(x => x.UserId == id).FirstOrDefault<Users>());
            }

        }
        [HttpPost]
        public ActionResult AddeditUsers(Users users)
        {
            var Id = users.UserId;
            var DName = users.DisplayName;
            var Name = users.Username;
            var Email = users.Email;
            var Source = users.Source;
            var Password = users.PassWord;
            var salt = users.PasswordSalt;
            var UserImage = users.UserImage;
            var UserId = users.InsertUserId;
            var units = users.units;
            var Unitid = users.UnitID;
            XDocument unit = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("UnitDetails",
           from un in units
           select new XElement("UnitDetails",
           new XElement("UnitId", un))));
            //var U = unit;
            DataTable data = As.InsertUsers(Id, Name, DName, Email, Source, Password, salt, UserImage, UserId, unit);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    ViewBag.Alert = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Users");
                }
                else
                {
                    ViewBag.Alert = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Users");
                }

            }
            else
            {
                ViewBag.Alert = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Users");
            }
        }
        [HttpGet]
        public ActionResult AddeditRole(int id = 0)
        {
            if (id == 0)
                return View(new Role());
            else
            {
                List<Role> users = new List<Role>();

                users = As.Roles();
                return View(users.Where(x => x.RoleId == id).FirstOrDefault<Role>());
            }

        }




        [HttpPost]
        public ActionResult AddeditRole(Role role)
        {
            var Id = role.RoleId;
            var Name = role.RoleName;
            var units= role.Units;
            XDocument unit = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
             new XElement("UnitDetails",
            from un in units
            select new XElement("UnitDetails",
            new XElement("UnitId", un) )));
            var U = unit;
            DataTable data = As.InsertRole(Id, Name);
            if (data.Rows.Count > 0)
            {
                String sp_Status = data.Rows[0]["Status"].ToString();
                String sp_MSg = data.Rows[0]["Msg"].ToString();
                if (sp_Status == "1")
                {

                    ViewBag.Alert = DropdownListSevices.ShowAlert(Alerts.Success, sp_MSg);
                    return RedirectToAction("Role");
                }
                else
                {
                    ViewBag.Alert = DropdownListSevices.ShowAlert(Alerts.Danger, sp_MSg);
                    return RedirectToAction("Role");
                }

            }
            else
            {
                ViewBag.Alert = DropdownListSevices.ShowAlert(Alerts.Danger, "Something Wents Wrong.....");
                return RedirectToAction("Role");
            }
        }
            [HttpGet]
        public ActionResult AddeditRoleRight()
        {

            return View();
        }
        public JsonResult GetUnit()
        {
            
           var unit = DS.GetUnitddl();
            return Json(new { data = unit }, JsonRequestBehavior.AllowGet);
        }
            [HttpPost]
        public ActionResult AddeditRoleRight(List<RolePermisssion> formMaster, RolePermisssion rolePermisssion)
        {

            var RoleiD = formMaster.Where(x => x.IsSelected == true);
            var UnitId = rolePermisssion.UnitID;
            var RoleId = rolePermisssion.RoleId;
            XDocument RoleDetails = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
             new XElement("RoleWiseRights",
            from form in RoleiD
            select new XElement("RoleWiseRights",
            new XElement("FormID",form.FormId),
            new XElement("Menu",form.MenuId),
            new XElement("SubMenuId",form.SubMenuId),
            new XElement("SerialNo",form.SerialNumber),
            new XElement("Btnadd",form.BtnAdd),
            new XElement("BtnEdit",form.btnEdit),
            new XElement("Delete",form.btnDelete),
            new XElement("View",form.btnView),
            new XElement("Search",form.btnSearch),
            new XElement("Notification",form.BtnNotification),
            new XElement("Excel",form.btnExportExcel),
            new XElement("Pdf", form.btnExportPdf)
            )));
            DataTable dt = As.InsertRoleRight(RoleDetails, RoleId,UnitId);
            return View();
        }
        public ActionResult SubmenuDropdown(string menu)
        {

            List<SubMenuMaster> subMenuMaster = new List<SubMenuMaster>();
            if (menu != "")
            {
                subMenuMaster = DS.SubMenuMasterddl(menu);
            }
            else 
            {
                subMenuMaster = new List<SubMenuMaster>();
            }
            
            return Json(subMenuMaster, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserName(int UnitId)
        {

            List<UserRoles> users = new List<UserRoles>();
            if (UnitId != 0)
            {
                users = DS.Usersddl(UnitId);
            }
            else
            {
                users = new List<UserRoles>();
            }

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult RoleWiseRight(string Role, string Menu, string SubMenu)
        {
            TempData["Menu"] = Menu;
            // ViewBag.Menu = Menu;
            List<RolePermisssion> msApp = new List<RolePermisssion>();
            if (Menu == "0" && SubMenu == "0")
            {
                msApp = new List<RolePermisssion>();
            }
            else
            {

                msApp = As.RolePermisssions(Role, Menu, SubMenu);
            }

            return PartialView("_AddeditRole", msApp);
        }
        [HttpGet]
        public ActionResult AddeditUserRight()
        {

            return View();
        }
        public PartialViewResult RoleList(string UserRoleId,string Unit)
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            userRoles = As.UserRolesList(UserRoleId, Unit);
            return PartialView("_Rolelist", userRoles);
        }
        public PartialViewResult GetRollWisePermissionList(string RoleId ,string Unit)
        {
            List<RolePermisssionList> rolePermisssion = new List<RolePermisssionList>();
            rolePermisssion = As.RolePermisssionList(RoleId, Unit);
            return PartialView("_GetRollWisePermissionList", rolePermisssion);
        }
        public PartialViewResult GetAllPageforUserpermission(string UserId,string Role,string Unit)
        {
            List<RolePermisssion> rolePermisssion = new List<RolePermisssion>();
            rolePermisssion = As.GetAllPageforUserpermission(UserId, Role, Unit);
            return PartialView("_AddeditRole", rolePermisssion);
        }
        [HttpPost]
        public ActionResult AddeditUserRight(List<RolePermisssion> forms, List<UserRoles> roles, UserPermisssion userPermisssion)
        {

            var FormMaster = forms.Where(x => x.IsSelected == true);
            var rolename = roles.Where(y => y.IsSelect == true);
            var UserId = userPermisssion.UserId;
            var UnitId = userPermisssion.UnitId;
            XDocument fromDetails = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("UserWiseRights",
            from form in FormMaster
            select new XElement("UserWiseRights",
            new XElement("FormID", form.FormId),
            new XElement("Menu", form.MenuId),
            new XElement("SubMenuId", form.SubMenuId),
            new XElement("SerialNo", form.SerialNumber),
            new XElement("Btnadd", form.BtnAdd),
            new XElement("BtnEdit", form.btnEdit),
            new XElement("Delete", form.btnDelete),
            new XElement("View", form.btnView),
            new XElement("Search", form.btnSearch),
            new XElement("Notification", form.BtnNotification),
            new XElement("Excel", form.btnExportExcel),
            new XElement("Pdf", form.btnExportPdf)
            )));

            XDocument roledetails = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("RolesName",
           from Role in rolename
           select new XElement("RolesName",
           new XElement("RoleId", Role.RoleId)
           )));
            DataTable dt = As.InsertUserPermmission(fromDetails, roledetails, UserId,UnitId);
            return View();
        }


    }
}