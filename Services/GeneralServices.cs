using KnowledgeApp_Test.Models.Administration;
using KnowledgeApp_Test.Models.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace KnowledgeApp_Test.Services
{
    public class GeneralServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        public List<EntryType> EntryTypesMenu()
        {
            string sql = "select * from EntryType";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<EntryType> EntryType = new List<EntryType>();
            foreach (DataRow dr in dt.Rows)
            {
                EntryType.Add(new EntryType
                {
                    EntryTypeID = Convert.ToInt32(dr["EntryTypeID"]),
                    EntryOrder = Convert.ToInt32(dr["EntryOrder"]),
                    EntryTypeName = dr["EntryTypeName"].ToString()
                }) ;

            }
            return EntryType;

        }

        public List<RolePermisssion> ValidateForm(string FormName)
        {
            List<RolePermisssion> userlist = new List<RolePermisssion>();
            List<RolePermisssion> userlistTemp = new List<RolePermisssion>();
            
                if (HttpContext.Current.Session["Menu"] != null )
                {
                    object obdata = HttpContext.Current.Session["Menu"];
                    userlist = (List<RolePermisssion>)obdata;
                    userlistTemp = userlist.Where(w => w.FormName.ToUpper() == FormName.ToUpper().ToString()|| w.MenuName.ToUpper() == FormName.ToUpper().ToString()).ToList();
                    return userlistTemp;
                }
           
            else
            {
                return userlist;
            }
            
        }

        public DataTable DeleteDatasingleparameter(string TableName, string Id)
        {
            string sql = "Exec DeleteDataFromAnyTable '" + TableName + "'," + Id + "";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

    }
}