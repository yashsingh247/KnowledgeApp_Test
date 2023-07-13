using KnowledgeApp_Test.Models.BenchMarking;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class BenchMarkingServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        public List<BenchMarkParameter> BenchMarkParameter(string Parameter, string ParameterUnit)
        {

            string sql = "SELECT BMP.[BenchMarkParameterID],BMP.[BenchMarkName],BMP.BenchMarkCode,BMP.[ParameterID],BMP.[ParameterUnitID],BMP.[BenchMarkType],BMP.[RowNumber],LP.ParameterName,PU.ParameterUnitName FROM[DsclKMS2021].[Lab].[BENCH_MARK_PARAMETER] BMP inner join Lab.Parameter LP on BMP.ParameterID = LP.ParameterID Inner join Lab.PARAMETER_UNIT PU on BMP.ParameterUnitID = PU.ParameterUnitID where 1=1";

            if (Parameter != ""&& Parameter!= "undefined" && Parameter!= "null")
            {
                sql = sql + " and  BMP.ParameterID= '" + Parameter + "'";
            }
            if (ParameterUnit != "" && ParameterUnit != "undefined" && ParameterUnit != "null")
            {
                sql = sql + " and  BMP.ParameterUnitID= '" + ParameterUnit + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<BenchMarkParameter> BenchMarkParameter = new List<BenchMarkParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                BenchMarkParameter.Add(new BenchMarkParameter
                {
                    BenchMarkParameterId = Convert.ToInt32(dr["BenchMarkParameterID"]),
                    BenchMarkCode = dr["BenchMarkCode"].ToString(),
                    BenchMarkName = dr["BenchMarkName"].ToString(),
                    BenchMarkType = Convert.ToInt16(dr["BenchMarkType"]),
                    ParameterName = dr["ParameterName"].ToString(),
                    ParameterUnitName = dr["ParameterUnitName"].ToString(),
                    ParameterUnitId = Convert.ToInt32(dr["ParameterUnitID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    RowNumber = Convert.ToInt16(dr["RowNumber"]),
                });
            }
            return BenchMarkParameter;
        }


        public List<YearlyBenchMark> YearlyBenchMark(string BenchMarkCode)
        {

            string sql = "Select y.YearlyBenchMarkID,BenchMarkCode,BenchMarkName,ApplicableYear,ApplicableValue,RowNumber,y.BenchMarkParameterID From Lab.YEARLY_BENCH_MARK y left outer join Lab.BENCH_MARK_PARAMETER p on y.BenchMarkParameterID  = p.BenchMarkParameterID  where 1=1";

            if (BenchMarkCode != "" && BenchMarkCode!= "undefined" && BenchMarkCode!="null"&& BenchMarkCode!=null)
            {
                sql = sql + " and y.BenchMarkParameterID= '" + BenchMarkCode + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<YearlyBenchMark> YearlyBenchMark = new List<YearlyBenchMark>();
            foreach (DataRow dr in dt.Rows)
            {
                YearlyBenchMark.Add(new YearlyBenchMark
                {
                    YearlyBenchMarkId= Convert.ToInt32(dr["YearlyBenchMarkID"]),
                    BenchMarkParameterId = Convert.ToInt32(dr["BenchMarkParameterID"]),
                    BenchMarkCode = dr["BenchMarkCode"].ToString(),
                    BenchMarkParameterName = dr["BenchMarkName"].ToString(),
                   
                    ApplicableYear= Convert.ToInt16(dr["ApplicableYear"]),
                    ApplicableValue= Convert.ToInt32(dr["ApplicableValue"]),
                    RowNumber = Convert.ToInt32(dr["RowNumber"]),

                });

            }
            return YearlyBenchMark;
        }
        public DataTable BenchMarkParameter(int Id, string BenchMarkName, string BenchMarkCode, int PId,int PuId,int BMType,int RowNo)
        {
            string SqlQujery = "Exec InsertBENCHMARKPARAMETERNew " + Id + ",'" + BenchMarkName + "','" + BenchMarkCode + "'," + PId + "," + PuId + "," + BMType + "," + RowNo + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertYearlyBenchMarkParameter(int Id, int BMPId, int YearSerial, int APPYear, decimal AppValue)
        {
            string SqlQujery = "Exec InserYearlyBenchMarkParameterNew " + Id + "," + BMPId + "," + YearSerial + "," + APPYear + "," + AppValue + "";
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