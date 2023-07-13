using KnowledgeApp_Test.Models.Account;
using KnowledgeApp_Test.Models.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace KnowledgeApp_Test.Services
{
    public class LoginServices
    {
        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        public DataTable Account(string UserName, string password)
        {
            cmd = new SqlCommand("select U.UserId,U.Username,U.DisplayName,U.Email,U.UserImage,isnull(UUM.UnitId,'')UnitId,isnull(UUM.RoleId,'')RoleId from Users U left outer Join UserRoles UR on U.UserID= UR.UserID left outer join UserUnitMapping UUM on U.UserId=UUM.USerID where Username='" + UserName + "' and Password='" + password + "' and IsActive=1", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public List<Models.Administration.RolePermisssion> USerMenuList(string Id, string Roles, string Unit)
        {
            string SqlQuery = "Exec GetMenuList '" + Id + "','" + Roles + "','" + Unit + "'";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<RolePermisssion> menulist = new List<RolePermisssion>();
            foreach (DataRow dr in dt.Rows)
            {
                menulist.Add(new RolePermisssion
                {
                    FormId = Convert.ToInt32(dr["FormID"]),
                    MenuId = Convert.ToInt32(dr["MenuID"]),
                    SubMenuId = Convert.ToInt32(dr["SubMenuID"]),
                    FormName = dr["FormNameName"].ToString(),
                    URL = dr["URL"].ToString(),
                    SerialNumber = Convert.ToInt32(dr["SrialNo"].ToString()),
                    status = Convert.ToInt32(dr["Status"]),
                    BtnAdd = Convert.ToBoolean(dr["BtnADD"]),
                    btnEdit = Convert.ToBoolean(dr["BtnUPDATE"]),
                    btnDelete = Convert.ToBoolean(dr["BtnDELETE"]),
                    btnExportExcel = Convert.ToBoolean(dr["BtnEXPORT"]),
                    btnView = Convert.ToBoolean(dr["BtnVIEW"]),
                    btnExportPdf = Convert.ToBoolean(dr["BtnPRINT"]),
                    btnSearch = Convert.ToBoolean(dr["BtnSEARCH"]),
                    BtnNotification = Convert.ToBoolean(dr["BtnNotification"]),
                    MenuName = dr["MenuName"].ToString(),
                    SubMenuName = dr["SubMenuName"].ToString()
                });

            }
            return menulist;

        }
        public List<DashBoard> DashBoard()
        {
            string SqlQuery = "Exec UnitWiseRecovery";
            cmd = new SqlCommand(SqlQuery, con2);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DashBoard> DS = new List<DashBoard>();
            foreach (DataRow dr in dt.Rows)
            {
                DS.Add(new DashBoard
                {
                    EntryDate = dr["EntryDate"].ToString(),
                    Ajbapur = dr["Ajbapur"].ToString(),
                    Rupapur = dr["Rupapur"].ToString(),
                    Hariawan = dr["Hariawan"].ToString(),
                    Loni = dr["Loni"].ToString(),
                });
                
               

            }
            return DS;
        }
    }
    }