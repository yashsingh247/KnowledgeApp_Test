using KnowledgeApp_Test.Models.Control;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class ControlService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'ControlService.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'ControlService.sdr' is never used
        public List<BrixWeight> GetBrixWeight()
        {
            cmd = new SqlCommand("select * from Lab.BrixWeight", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<BrixWeight> BrixWeight = new List<BrixWeight>();
            foreach (DataRow dr in dt.Rows)
            {
                BrixWeight.Add(new BrixWeight
                {
                    BrixWeightId = Convert.ToInt32(dr["BrixWeightID"]),
                    BrixValue =Convert.ToDecimal(dr["BrixValue"]),
                    ValueAt20 = Convert.ToDecimal(dr["ValueAt20"]),
                    ValueAt27 = Convert.ToDecimal(dr["ValueAt27"]),
                });

            }
            return BrixWeight;
        }
        public List<ControlParameterGroup> GetControlParameterGroup()
        {
            cmd = new SqlCommand("select ControlParameterGroupID as ControlParameterGroupID,ControlParameterGroupName,Isnull(SerialOrder,0)as SerialOrder from Lab.ControlParameterGroup", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ControlParameterGroup> ControlParameterGroup = new List<ControlParameterGroup>();
            foreach (DataRow dr in dt.Rows)
            {
                ControlParameterGroup.Add(new ControlParameterGroup
                {
                    ParameterGroupId = Convert.ToInt32(dr["ControlParameterGroupID"]),
                    ControlParameterGroupName = dr["ControlParameterGroupName"].ToString(),
                    SerialOrder = Convert.ToInt16(dr["SerialOrder"]),
                   
                });

            }
            return ControlParameterGroup;
        }
        public List<DateConfiguration> GetDateConfiguration(string Unit)

        {
            string sqlquery = "select DateConfigurationID,ConfigurationDate,ConfigurationType,isnull(UnitName,'')as UnitName,Isnull(LD.UnitID,0) as UnitID from Lab.DateConfiguration LD left join Common.Unit CU on Ld.UnitID=CU.UnitID where 1=1 ";
            if (Unit != "" && Unit != "undefined"&& Unit != null)
            {
                sqlquery = sqlquery + "and LD.UnitID =" + Unit + "";
            }
            cmd = new SqlCommand(sqlquery, con);
             cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DateConfiguration> DateConfiguration = new List<DateConfiguration>();
            foreach (DataRow dr in dt.Rows)
            {
                DateConfiguration.Add(new DateConfiguration
                {
                    DateConfigurationId = Convert.ToInt32(dr["DateConfigurationID"]),
                    ConfigurationDate = DateTime.Parse(dr["ConfigurationDate"].ToString()),
                    ConfigurationType = Convert.ToInt32(dr["ConfigurationType"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    UnitId = Convert.ToInt32(dr["UnitID"]),

                }); ;

            }
            return DateConfiguration;
        }


        public List<ControlParameter> GetControlParameter(string ControlParameterGroup)
        {
            string sqlQuery = "select ParameterID,ParameterCode,ISnull(ParameterName,'') as ParameterName ,ISnull(ParameterDescription,'')as ParameterDescription ,ParameterGroupID,LCPG.ControlParameterGroupName,LCP.SerialOrder,ParameterType,Isnull(ParameterWidth,0) As ParameterWidth from Lab.ControlParameter LCP inner join Lab.ControlParameterGroup LCPG on LCP.ParameterGroupID=LCPG.ControlParameterGroupID where 1=1 ";
            if (ControlParameterGroup != "" && ControlParameterGroup != "undefined" && ControlParameterGroup!=null)
            {
                sqlQuery = sqlQuery + "and LCP.ParameterGroupID=" + ControlParameterGroup + "";
            }
           
             cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ControlParameter> controlParameter = new List<ControlParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                controlParameter.Add(new ControlParameter
                {
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterCode = dr["ParameterCode"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    ParameterDescription = dr["ParameterDescription"].ToString(),
                    ParameterGroupId = Convert.ToInt32(dr["ParameterGroupID"]),
                    ParameterGroupName = dr["ControlParameterGroupName"].ToString(),
                    SerialOrder= Convert.ToInt16(dr["SerialOrder"]),
                    ParameterType= dr["ParameterType"].ToString(),
                    ParameterWidth= Convert.ToInt16(dr["ParameterWidth"]),
                }); ;

            }
            return controlParameter;
        }
        public List<ControlParameterValue> GetControlParameterValueData(string ControlParameter, string Unit)

        {
            string sqlquery = "select LCPV.ControlParameterValueID,LCPV.ParameterID,LCPV.UnitID,ParameterValue,CU.UnitName,LCP.ParameterName,LCP.ParameterCode from Lab.ControlParameterValue LCPV left join Lab.ControlParameter LCP on LCPV.ParameterID=LCP.ParameterID left join Common.Unit CU on  CU.UnitID=LCPV.UnitID where 1=1";
            if (ControlParameter != "" && ControlParameter != "undefined" && ControlParameter != null) 
            {
                sqlquery = sqlquery + "and LCPV.ParameterID=" + ControlParameter + "";
            }
            if (Unit != "" && Unit != "undefined" && Unit != null) 
            {
                sqlquery = sqlquery + "and LCPV.UnitID=" + Unit + "";
            }

            
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ControlParameterValue> ControlParameterValue = new List<ControlParameterValue>();
            foreach (DataRow dr in dt.Rows)
            {
                ControlParameterValue.Add(new ControlParameterValue
                {
                    ControlParameterValueId = Convert.ToInt32(dr["ControlParameterValueID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterCode = dr["ParameterCode"].ToString(),
                    UnitUnitName = dr["UnitName"].ToString(),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    ParameterValue= dr["ParameterValue"].ToString()
                }); 

            }
            return ControlParameterValue;
        }

        public DataTable InsertBrixWeight(int Id,decimal BrixValue, decimal value20, decimal value27) 
        {

            string SqlQujery = "Exec InsertBrixWeightNew "+ Id + ","+ BrixValue + ","+ value20 + ","+ value27 + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertControlParameterGroup(int Id, string CtrlPName, int SerialOrder)
        {

            string SqlQujery = "Exec InsertControlParameterGroupNew " + Id + ",'" + CtrlPName + "'," + SerialOrder + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertDateConfiguration(int Id,DateTime CngfgDate,int type,int Unit)
        {

            string SqlQujery = "Exec InsertDateConfigurationNew "+ Id + ",'"+ CngfgDate.ToString("yyyy-MM-dd") + "',"+ type + ","+ Unit + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertControlParameter(int Id,string PCode,string PName,string Desc,int PGroup, int Serial, string Ptype, int PWidth)
        {
            string SqlQujery = "Exec InsertControlParameterNew " + Id + ",'" + PCode + "','" + PName + "','" + Desc + "',"+ PGroup + ","+ Serial + ","+ Ptype + ","+ PWidth + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);

        }
        public DataTable InsertControlParameterValue(int Id,int PId,int Unit,string PValue)
        {
            string SqlQujery = "Exec InsertControlParameterValueNew " + Id + "," + PId + "," + Unit + ",'" + PValue + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);

        }

    }
}