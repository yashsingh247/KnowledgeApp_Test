using KnowledgeApp_Test.Models.Targets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class TargetServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'TargetServices.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'TargetServices.sdr' is never used

        public List<SeasonTarget> SeasonTarget(string CrushingSeason, string Unit, string Parameter)
        {

            string sql = "select LST.SeasonTargetID,LST.CrushingSeasonID,LST.UnitID,LST.ParameterID,LST.TargetValue,LST.ActualValue,LP.ParameterName,CU.UnitName,CS.CrushingSeasonName from Lab.SeasonTarget LST  inner join Common.CrushingSeason CS on LST.CrushingSeasonID=CS.CrushingSeasonID inner Join Lab.Parameter LP on LP.ParameterID =LST.ParameterID inner Join Common.Unit CU on CU.UnitID=LST.UnitID where 1=1";

            if (CrushingSeason != "" && CrushingSeason !="undefined" && CrushingSeason !=null && CrushingSeason !="null")
            {
                sql = sql + " and  LSt.CrushingSeasonID= '" + CrushingSeason + "'";
            }


            if (Unit != "" && Unit != "undefined" && Unit != null && Unit != "null")
            {
                sql = sql + " and  LST.UnitID= '" + Unit + "'";
            }
            if (Parameter != "" && Parameter != "undefined" && Parameter != null && Parameter != "null")
            {
                sql = sql + " and  LST.ParameterID= '" + Parameter + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SeasonTarget> SeasonTarget = new List<SeasonTarget>();
            foreach (DataRow dr in dt.Rows)
            {
                SeasonTarget.Add(new SeasonTarget
                {
                    SeasonTargetId = Convert.ToInt32(dr["SeasonTargetID"]),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    ActualValue = Convert.ToInt32(dr["ActualValue"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    TargetValue = Convert.ToInt32(dr["TargetValue"]),


                });

            }
            return SeasonTarget;

        }



        public List<SeasonMonth> SeasonMonth(string CrushingSeason, string Unit)
        {
           
            string sql = "select LSM.MonthID,LSM.CrushingSeasonID,LSM.UnitID,LSM.YearNumber,LSM.MonthNumber,LSM.StartDate,LSM.EndDate,LSM.Days,isnull(LSM.TargetDays,0)TargetDays,ISnull(LSM.MonthName,'')MonthName,ISNULL(LSM.MonthSerial,0)MonthSerial,CU.UnitName,CS.CrushingSeasonName from Lab.SEASON_MONTH LSM inner join Common.CrushingSeason CS on LSM.CrushingSeasonID=CS.CrushingSeasonID inner Join Common.Unit CU on CU.UnitID=LSM.UnitID where 1=1 ";

            if (CrushingSeason != "")
            {
                sql = sql + " and  LSM.CrushingSeasonID= '" + CrushingSeason + "'";
            } 


            if (Unit != "")
            {
                sql = sql + " and  LSM.UnitID= '" + Unit + "'";
            }
          
            cmd=new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SeasonMonth> SeasonMonth = new List<SeasonMonth>();
            foreach (DataRow dr in dt.Rows)
            {
                SeasonMonth.Add(new SeasonMonth
                {
                    MonthId = Convert.ToInt32(dr["MonthID"]),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    YearNumber = Convert.ToInt16(dr["YearNumber"]),
                    MonthNumber = Convert.ToInt16(dr["MonthNumber"]),
                    StartDate = DateTime.Parse(dr["StartDate"].ToString()),
                    EndDate = DateTime.Parse(dr["EndDate"].ToString()),
                    Days = Convert.ToInt16(dr["Days"]),
                    TargetDays = Convert.ToInt16(dr["TargetDays"]),
                    MonthName = dr["MonthName"].ToString(),
                    MonthSerial = Convert.ToInt16(dr["MonthSerial"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])
                });

            }
            return SeasonMonth;
        }


        public List<SeasonWeek> SeasonWeek(string CrushingSeason, string Unit, string StartDate, string StartDate2)
        {
            if(StartDate.Length>0 && StartDate.Length==10)
            {
                string d = StartDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                StartDate = s;
            }
            if (StartDate2.Length > 0 && StartDate2.Length == 10)
            {
                string d1 = StartDate2.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                StartDate2 = s1;
            }
            
            string sql = "select LSW.WeekID,LSW.CrushingSeasonID,LSW.UnitID,LSW.YearNumber,LSW.MonthNumber,LSW.WeekNumber,LSW.StartDate,LSW.EndDate,LSW.Days,LSW.TargetDays,LSW.WeekName,LSW.WeekSerial,CU.UnitName,CS.CrushingSeasonName from Lab.SEASON_WEEK LSW inner join Common.CrushingSeason CS on LSW.CrushingSeasonID=CS.CrushingSeasonID  inner Join Common.Unit CU on CU.UnitID=LSW.UnitID where 1=1";

            if (CrushingSeason != "" && CrushingSeason!=null && CrushingSeason!="undefined"&& CrushingSeason!="null")
            {
                sql = sql + " and  LSM.CrushingSeasonID= '" + CrushingSeason + "'";
            }


            if (Unit != "" && Unit != null && Unit != "undefined" && Unit != "null")
            {
                sql = sql + " and  LSW.UnitID= '" + Unit + "'";
            }
            if (StartDate != ""  && StartDate != null && StartDate != "undefined" && StartDate != "null" && StartDate2 == "" || StartDate2==null || StartDate2=="undefined"|| StartDate2=="null")
            {
                sql = sql + " and  LSW.StartDate= '" + StartDate + "'";
            }
            if ( StartDate2 !="" && StartDate2 != null && StartDate2 != "undefined" && StartDate2 != "null" && StartDate != "" && StartDate != null && StartDate != "undefined" && StartDate != "null")
            {
                sql = sql + " and  LSW.StartDate between '" + StartDate + "' and '"+ StartDate2 + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SeasonWeek> SeasonWeek = new List<SeasonWeek>();
            foreach (DataRow dr in dt.Rows)
            {
                SeasonWeek.Add(new SeasonWeek
                {
                    WeekId = Convert.ToInt32(dr["WeekID"]),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    YearNumber = Convert.ToInt16(dr["YearNumber"]),
                    MonthNumber = Convert.ToInt16(dr["MonthNumber"]),
                    WeekNumber = Convert.ToInt16(dr["WeekNumber"]),
                    StartDate = DateTime.Parse(dr["StartDate"].ToString()),
                    EndDate = DateTime.Parse(dr["EndDate"].ToString()),
                    Days = Convert.ToInt16(dr["Days"]),
                    TargetDays = Convert.ToInt16(dr["TargetDays"]),
                    WeekName = dr["WeekName"].ToString(),
                    WeekSerial = Convert.ToInt16(dr["WeekSerial"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])
                });

            }
            return SeasonWeek;
        }


        public List<WeekTarget> WeekTarget(string Week, string Parameter)
        {

            string sql = "select LWT.WeekTargetID,LWT.WeekID,LWT.ParameterID,LWT.TargetValue,LWT.ActualValue,LSW.WeekName,LP.ParameterName from Lab.WeekTarget LWT inner join Lab.SEASON_WEEK LSW on LWT.WeekID=LSW.WeekID inner join Lab.Parameter LP on LWT.ParameterID=LP.ParameterID where 1=1";

            if (Week != "")
            {
                sql = sql + " and  LWT.WeekID= '" + Week + "'";
            }


            if (Parameter != "")
            {
                sql = sql + " and  LWT.ParameterID= '" + Parameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<WeekTarget> WeekTarget = new List<WeekTarget>();
            foreach (DataRow dr in dt.Rows)
            {
                WeekTarget.Add(new WeekTarget
                {
                    WeekTargetId = Convert.ToInt32(dr["WeekTargetID"]),
                    WeekName = dr["WeekName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    TargetValue = Convert.ToInt16(dr["TargetValue"]),
                    ActualValue = Convert.ToInt16(dr["ActualValue"]),
                    WeekId = Convert.ToInt16(dr["WeekID"]),
                    ParameterId = Convert.ToInt16(dr["ParameterID"])
                 
                });

            }
            return WeekTarget;
        }






        public List<MonthTarget> MonthTarget(string SeasonMonth, string Parameter, string CrushingSeason, string Unit)
        {

            string sql = "select LMT.MonthTargetID,LMT.CrushingSeasonID,LMT.UnitID,LMT.MonthID,LMT.ParameterID,LMT.TargetValue,LMT.ActualValue,CS.CrushingSeasonName,CU.UnitName,LSm.MonthName,LP.ParameterName from Lab.MonthTarget LMT inner join Common.CrushingSeason CS on LMT.CrushingSeasonID=CS.CrushingSeasonID inner Join Common.Unit CU on CU.UnitID=LMT.UnitID Inner join Lab.SEASON_MONTH LSM on LMT.MonthID=LSM.MonthID Inner Join  Lab.Parameter LP on LP.ParameterID=LMT.ParameterID where 1=1";

            if (SeasonMonth != "" && SeasonMonth != "undefined" && SeasonMonth!=null)
            {
                sql = sql + " and  LMT.MonthID= '" + SeasonMonth + "'";
            }

            if (Parameter != "" && Parameter != "undefined" && Parameter != null)
            {
                sql = sql + " and  LMT.ParameterID= '" + Parameter + "'";
            }
            if (CrushingSeason != "" && CrushingSeason != "undefined" && CrushingSeason != null)
            {
                sql = sql + " and  LMT.CrushingSeasonID= '" + CrushingSeason + "'";
            }
            if (Unit != "" && CrushingSeason != "undefined" && CrushingSeason != null)
            {
                sql = sql + " and  LMT.UnitID= '" + Unit + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MonthTarget> MonthTarget = new List<MonthTarget>();
            foreach (DataRow dr in dt.Rows)
            {
                MonthTarget.Add(new MonthTarget
                {
                    MonthTargetId = Convert.ToInt32(dr["MonthTargetID"]),
                    CrushingSeasonName= dr["CrushingSeasonName"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    MonthName =dr["MonthName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    TargetValue= Convert.ToInt16(dr["TargetValue"]),
                    ActualValue = Convert.ToInt16(dr["ActualValue"]),
                    CrushingSeasonId = Convert.ToInt16(dr["CrushingSeasonID"]),
                    MonthId = Convert.ToInt32(dr["MonthID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])

                });

            }
            return MonthTarget;
        }

        public DataTable InsertSeasonTarget(int Id,int CSId,int PId,int UId,decimal TargetVal,decimal ActualVal )
        {
            string SqlQujery = "Exec InsertSeasonTarget "+Id+","+ CSId + ","+ PId + ","+ UId + ","+ TargetVal + ","+ ActualVal + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertSeasonMonth(int Id, int CSId, int UId, int YearNumber ,int MonthNumber,DateTime StartDate,DateTime EndDate,int Days,int TargetDays,string MonthName,int MonthSerial )
        {
            string SqlQujery = "Exec InsertSeasonMonth "+ Id + ", "+ CSId + ", "+ UId + ", "+ YearNumber + ", "+ MonthNumber + ", '"+ StartDate.ToString("yyyy-MM-dd") + "', '"+ EndDate.ToString("yyyy-MM-dd") + "', "+ Days + ", "+ TargetDays + ", '"+ MonthName + "','"+ MonthSerial + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertSeasonWeek(int Id, int CSId, int UId, int YearNumber, int MonthNumber,int WeekNumber, DateTime StartDate, DateTime EndDate, int Days, int TargetDays, string WeekName, int WeekSerial)
        {
            string SqlQujery = "Exec InsertSeasonWeek " + Id + ", " + CSId + ", " + UId + ", " + YearNumber + ", " + MonthNumber + ","+ WeekNumber + ",'" + StartDate.ToString("yyyy-MM-dd") + "', '" + EndDate.ToString("yyyy-MM-dd") + "', " + Days + ", " + TargetDays + ", '" + WeekName + "','" + WeekSerial + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InserWeekTarget(int Id, int SWeek, int PId,decimal TargetVal, decimal ActualVal)
        {
            string SqlQujery = "Exec InsertWeekTargetNew " + Id + "," + SWeek + "," + PId + "," + TargetVal + "," + ActualVal + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InserMonthTarget(int Id, int CSId,int UId, int PId,int MId, decimal TargetVal, decimal ActualVal)
        {
            string SqlQujery = "Exec InsertMonthTargetNew " + Id + "," + CSId + ","+ UId + "," + PId + ","+ MId + "," + TargetVal + "," + ActualVal + "";
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