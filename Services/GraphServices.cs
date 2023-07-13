using KnowledgeApp_Test.Models.Graph;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class GraphServices
    {
        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        public List<StoppageGraph> StoppageGraph()
        {
            string SqlQuery = "Exec DepartmentWiseStoppageGraph";
            cmd = new SqlCommand(SqlQuery, con2);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<StoppageGraph> DS = new List<StoppageGraph>();
            foreach (DataRow dr in dt.Rows)
            {
                DS.Add(new StoppageGraph
                {
                    ParameterName = dr["ParameterName"].ToString(),
                    DayValue = Convert.ToDouble(dr["DayValue"]),
                }); ;



            }
            return DS;
        }
    }
}