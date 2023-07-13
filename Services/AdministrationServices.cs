using KnowledgeApp_Test.Models.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace KnowledgeApp_Test.Services
{
    public class AdministrationServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserConnection"].ConnectionString);
        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        public List<Users> Users()
        {
            cmd = new SqlCommand("select Isnull(U.UserId,'')UserId,Isnull(U.Username,'')Username,Isnull(U.DisplayName,'')DisplayName,Isnull(U.Email,'')Email,Isnull(U.Source,'')Source,Isnull(U.LastDirectoryUpdate,'')LastDirectoryUpdate,Isnull(U.UserImage,'')UserImage,Isnull(U.InsertDate,'')InsertDate,Isnull(U.InsertUserId,'')InsertUserId,Isnull(U.UpdateDate,'')UpdateDate,Isnull(U.UpdateUserId,'')UpdateUserId,Isnull(U.IsActive,'')IsActive,Isnull(U.IsActive,'')IsActive,ISnull(CU.UnitName,'')UnitName,ISnull(U.UnitID,'')UnitID from users U left outer Join DsclKMS2021.Common.Unit CU on U.UnitID= Cu.UnitID where 1=1 and IsActive=1", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Users> users = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new Users
                {
                    UserId = Convert.ToInt32(dr["UserId"].ToString()),
                    Username = dr["Username"].ToString(),
                    DisplayName = dr["DisplayName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Source = dr["Source"].ToString(),
                    LastDirectoryUpdate = DateTime.Parse(dr["LastDirectoryUpdate"].ToString()),
                    UserImage = dr["UserImage"].ToString(),
                    InsertDate = DateTime.Parse(dr["InsertDate"].ToString()),
                    InsertUserId = Convert.ToInt32(dr["InsertUserId"]),
                    UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString()),
                    UpdateUserId = Convert.ToInt32(dr["UpdateUserId"]),
                    IsActive = Convert.ToInt16(dr["IsActive"]),
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                });

            }
            return users;


        }
        public DataTable UserUnitMapping(int UserId)
        {
            cmd = new SqlCommand("select UnitId from UserUnitMapping where USerID=" + UserId + "", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public List<Role> Roles()
        {
            cmd = new SqlCommand("select * from Roles", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Role> roles = new List<Role>();
            foreach (DataRow dr in dt.Rows)
            {
                roles.Add(new Role
                {
                    RoleId = Convert.ToInt32(dr["RoleId"].ToString()),
                    RoleName = dr["RoleName"].ToString(),
                });

            }
            return roles;
        }
        public DataTable InsertUsers(int Id, string Name, string DName, string Email, string Source, string Password, string salt, string UserImage, int UserId, XDocument unit)
        {
            string SqlQujery = "Exec InserUSerNew " + Id + ",'" + Name + "','" + DName + "','" + Email + "','" + Source + "','" + Password + "','" + salt + "','" + UserImage + "'," + UserId + ",'" + unit + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertRole(int Id, string Name)
        {
            string SqlQujery = "Exec InsertRoleNew " + Id + ",'" + Name + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertRoleRight(XDocument RoleDetails, int RoleId,int UnitId)
        {
            string SqlQujery = "Exec InsertRolMaster'" + RoleDetails + "'," + RoleId + ","+ UnitId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertUserPermmission(XDocument UserRight, XDocument Roles, int UserId,int Unit)
        {
            string SqlQujery = "Exec InsertUserRightsandRoles'" + UserRight + "','"+ Roles + "'," + UserId + ","+ Unit + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public List<RolePermisssion> RolePermisssions(string Role, string Menu, string SubMenu)
        {
            if (Menu == "" || Menu == null || Menu == "undefined" || Menu == "null")
            {
                Menu = "null";
            }
            if (SubMenu == "" || SubMenu == null || SubMenu == "undefined" || SubMenu == "null")
            {
                SubMenu = "null";
            }
            string SqlQuery = "exec GetRolePermisssion'" + Role + "'," + Menu + "," + SubMenu + "";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            //sda.Fill(dt);
            List<RolePermisssion> rolePermisssion = new List<RolePermisssion>();
            foreach (DataRow dr in dt.Rows)
            {
                rolePermisssion.Add(new RolePermisssion
                {
                    MenuId = Convert.ToInt32(dr["MenuID"]),
                    SubMenuId = Convert.ToInt32(dr["SubMenuID"]),
                    FormId = Convert.ToInt32(dr["FormID"]),
                    FormName = dr["FormNameName"].ToString(),
                    URL = dr["URL"].ToString(),
                    SerialNumber = Convert.ToInt32(dr["SrialNo"]),
                    status = Convert.ToInt32(dr["Status"]),
                    BtnAdd = Convert.ToBoolean(dr["BtnADD"]),
                    btnEdit = Convert.ToBoolean(dr["BtnUPDATE"]),
                    btnDelete = Convert.ToBoolean(dr["BtnDELETE"]),
                    btnView = Convert.ToBoolean(dr["BtnVIEW"]),
                    btnExportExcel = Convert.ToBoolean(dr["BtnEXPORT"]),
                    btnExportPdf = Convert.ToBoolean(dr["BtnPRINT"]),
                    btnSearch = Convert.ToBoolean(dr["BtnSEARCH"]),
                    BtnNotification = Convert.ToBoolean(dr["BtnNotification"]),
                });
            }
            return rolePermisssion;
        }
        public List<UserRoles> UserRolesList(String UserRoleId,string Unit)
        {
            string SqlQuery = "exec getUserwiseRight " + UserRoleId + ","+ Unit + "";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<UserRoles> userRoles = new List<UserRoles>();
            foreach (DataRow dr in dt.Rows)
            {
                userRoles.Add(new UserRoles
                {
                    MaippingId = Convert.ToInt32(dr["MaippingId"]),
                    UserId = Convert.ToInt32(dr["UserId"]),
                    RoleName = dr["RoleName"].ToString(),
                    RoleId = Convert.ToInt32(dr["RoleId"]),

                });

            }
            return userRoles;
        }
        public List<RolePermisssionList> RolePermisssionList(String RoleId,string Unit)
        {
            string SqlQuery = "exec GetRollWisePermissionList '" + RoleId + "',"+ Unit + "";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<RolePermisssionList> rolePermisssions = new List<RolePermisssionList>();
            foreach (DataRow dr in dt.Rows)
            {
                rolePermisssions.Add(new RolePermisssionList
                {
                    RoleID = Convert.ToInt32(dr["RoleID"]),
                    FormID = Convert.ToInt32(dr["FormID"]),
                    BtnAdd = dr["BtnADD"].ToString(),
                    btnEdit = dr["BtnUPDATE"].ToString(),
                    btnDelete=dr["BtnDELETE"].ToString(),
                    btnView= dr["BtnVIEW"].ToString(),
                    btnExportPdf = dr["BtnPRINT"].ToString(),
                    btnSearch = dr["BtnSEARCH"].ToString(),
                    BtnNotification = dr["BtnNotification"].ToString(),
                    btnExportExcel = dr["BtnEXPORT"].ToString(),
                    MenuID =Convert.ToInt32( dr["MenuID"]),
                    SubMenuID = Convert.ToInt32(dr["SubMenuID"]),
                    FormName=dr["FormNameName"].ToString(),
                });

            }
            return rolePermisssions;
        }
        public List<RolePermisssionList> UserPermisssionList(String UserId)
        {
            string SqlQuery = "exec GetRollWisePermissionList " + UserId + "";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<RolePermisssionList> rolePermisssions = new List<RolePermisssionList>();
            foreach (DataRow dr in dt.Rows)
            {
                rolePermisssions.Add(new RolePermisssionList
                {
                    RoleID = Convert.ToInt32(dr["RoleID"]),
                    FormID = Convert.ToInt32(dr["FormID"]),
                    BtnAdd = dr["BtnADD"].ToString(),
                    btnEdit = dr["BtnUPDATE"].ToString(),
                    btnDelete = dr["BtnDELETE"].ToString(),
                    btnView = dr["BtnVIEW"].ToString(),
                    btnExportPdf = dr["BtnPRINT"].ToString(),
                    btnSearch = dr["BtnSEARCH"].ToString(),
                    BtnNotification = dr["BtnNotification"].ToString(),
                    btnExportExcel = dr["BtnEXPORT"].ToString(),
                    MenuID = Convert.ToInt32(dr["MenuID"]),
                    SubMenuID = Convert.ToInt32(dr["SubMenuID"]),
                    FormName = dr["FormNameName"].ToString(),
                });

            }
            return rolePermisssions;
        }
        public List<RolePermisssion> GetAllPageforUserpermission(string UserId,string RoleId, string Unit)
        {
            if (Unit == "" || Unit == null || Unit == "undefined" || Unit == "null")
            {
                Unit = "0";
            }
            string SqlQuery = "exec AllFormavailabeforUser'" + UserId + "'," + Unit + ",'" + RoleId + "'";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            //sda.Fill(dt);
            List<RolePermisssion> rolePermisssion = new List<RolePermisssion>();
            foreach (DataRow dr in dt.Rows)
            {
                rolePermisssion.Add(new RolePermisssion
                {
                    MenuId = Convert.ToInt32(dr["MenuID"]),
                    SubMenuId = Convert.ToInt32(dr["SubMenuID"]),
                    FormId = Convert.ToInt32(dr["FormID"]),
                    FormName = dr["FormNameName"].ToString(),
                    URL = dr["URL"].ToString(),
                    SerialNumber = Convert.ToInt32(dr["SrialNo"]),
                    status = Convert.ToInt32(dr["Status"]),
                    BtnAdd = Convert.ToBoolean(dr["BtnADD"]),
                    btnEdit = Convert.ToBoolean(dr["BtnUPDATE"]),
                    btnDelete = Convert.ToBoolean(dr["BtnDELETE"]),
                    btnView = Convert.ToBoolean(dr["BtnVIEW"]),
                    btnExportExcel = Convert.ToBoolean(dr["BtnEXPORT"]),
                    btnExportPdf = Convert.ToBoolean(dr["BtnPRINT"]),
                    btnSearch = Convert.ToBoolean(dr["BtnSEARCH"]),
                    BtnNotification = Convert.ToBoolean(dr["BtnNotification"]),
                });
            }
            return rolePermisssion;
        }

    }
}