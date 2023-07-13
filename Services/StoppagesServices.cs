using KnowledgeApp_Test.Models.Stoppages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class StoppagesServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        public List<StoppageDepartment> StoppageDepartment(string Parameter)
        {
           
            string sql = "select LSD.DepartmentID,LSD.DepartmentCode,LSD.DepartmentName,isnull(LSD.ParameterID,'')ParameterID,LP.ParameterName from Lab.StoppageDepartment LSD Left  join Lab.Parameter LP on LSD.ParameterID=LP.ParameterID where 1=1";
            if (Parameter != "") 
            {
                sql = sql + "and LSD.ParameterID='" + Parameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<StoppageDepartment> StoppageDepartment = new List<StoppageDepartment>();
            foreach (DataRow dr in dt.Rows)
            {
                StoppageDepartment.Add(new StoppageDepartment
                {
                    DepartmentId = Convert.ToInt32(dr["DepartmentID"]),
                    DepartmentCode = dr["DepartmentCode"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterName = dr["ParameterName"].ToString()
                }); ;

            }
            return StoppageDepartment;

        }
        public List<StoppageStation> StoppageStation(string Parameter,string Department)
        {

            string sql = "select LSS.StationID,LSS.StationCode,LSS.StationName,isnull(LSS.DepartmentID,'')DepartmentID,LSS.ParameterID,LP.ParameterName,isnull(LSD.DepartmentName,'')DepartmentName from Lab.StoppageStation LSS inner join Lab.Parameter LP on LP.ParameterID =LSS.ParameterID Left join Lab.StoppageDepartment LSD on LSS.DepartmentID= LSD.DepartmentID where 1=1";
            if (Parameter != "")
            {
                sql = sql + "and LSS.ParameterID='" + Parameter + "'";
            }
            if (Department != "") 
            {
                sql = sql + "and LSS.DepartmentID='" + Department + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<StoppageStation> StoppageStation = new List<StoppageStation>();
            foreach (DataRow dr in dt.Rows)
            {
                StoppageStation.Add(new StoppageStation
                {
                    StationId = Convert.ToInt32(dr["StationID"]),
                    StationCode = dr["StationCode"].ToString(),
                    StationName = dr["StationName"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    ParameterId= Convert.ToInt32(dr["ParameterID"]),
                    DepartmentId = Convert.ToInt32(dr["DepartmentID"]),
                   
                }); ;

            }
            return StoppageStation;

        }
        public List<StoppageSparesProcess> StoppageSparesProcess(string Station)
        {

            string sql = "select LSSP.SpareProcessID,LSSP.SpareProcessCode,LSSP.SpareProcessName,isnull(LSSP.IsProcess,'')IsProcess,ISnull(LSSP.StationID,'')StationID,ISnull(LSS.StationCode,'')StationCode from Lab.StoppageSparesProcess LSSP left Join Lab.StoppageStation LSS on LSSP.StationID=LSS.StationID where 1=1";
            if (Station != "" && Station!=null && Station!="undefined" && Station!="null")
            {
                sql = sql + "and LSSP.StationID='" + Station + "'";
            }
           

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<StoppageSparesProcess> StoppageSparesProcess = new List<StoppageSparesProcess>();
            foreach (DataRow dr in dt.Rows)
            {
                StoppageSparesProcess.Add(new StoppageSparesProcess
                {
                    SpareProcessId = Convert.ToInt32(dr["SpareProcessID"]),
                    SpareProcessCode = dr["SpareProcessCode"].ToString(),
                    SpareProcessName = dr["SpareProcessName"].ToString(),
                    StationCode = dr["StationCode"].ToString(),
                    IsProcess = (bool)(dr["IsProcess"]),
                    StationId = Convert.ToInt32(dr["StationID"]),

                });

            }
            return StoppageSparesProcess;

        }
        public List<StoppageDefect> StoppageDefect(string SparesProcess)
        {

            string sql = "select LSD.DefectID,isnull(LSD.SpareProcessID,'')SpareProcessID,LSD.DefectCode,LSD.DefectName,isnull(LSP.SpareProcessCode,'')SpareProcessCode from Lab.StoppageDefect LSD Left Join Lab.StoppageSparesProcess LSP on LSD.SpareProcessID=LSP.SpareProcessID where 1=1";
            if (SparesProcess != "")
            {
                sql = sql + "and LSD.SpareProcessID ='" + SparesProcess + "'";
            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<StoppageDefect> StoppageDefect = new List<StoppageDefect>();
            foreach (DataRow dr in dt.Rows)
            {
                StoppageDefect.Add(new StoppageDefect
                {
                    DefectId = Convert.ToInt32(dr["DefectID"]),
                    SpareProcessId = Convert.ToInt32(dr["SpareProcessID"]),
                    SpareProcessCode = dr["SpareProcessCode"].ToString(),
                    DefectName = dr["DefectName"].ToString(),
                    DefectCode = dr["DefectCode"].ToString()
                }); 

            }
            return StoppageDefect;

        }
        public List<StoppageActionTaken> StoppageActionTaken(string Defect)
        {

            string sql = "select LSAT.ActionID,Isnull(LSAT.DefectID,'')DefectID,LSAT.ActionCode,LSAT.ActionName,ISnull(LSD.DefectCode,'')DefectCode from Lab.StoppageActionTaken LSAT Left Join Lab.StoppageDefect LSD on LSAT.DefectID=LSD.DefectID where 1=1";
            if (Defect != "" && Defect!=null && Defect!="undefined" && Defect!="null")
            {
                sql = sql + "and LSAT.DefectID=" + Defect + "";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<StoppageActionTaken> StoppageActionTaken = new List<StoppageActionTaken>();
            foreach (DataRow dr in dt.Rows)
            {
                StoppageActionTaken.Add(new StoppageActionTaken
                {
                    ActionId = Convert.ToInt32(dr["ActionID"]),
                    DefectCode = dr["DefectCode"].ToString(),
                    ActionCode = dr["ActionCode"].ToString(),
                    ActionName = dr["ActionName"].ToString(),
                    DefectId = Convert.ToInt16(dr["DefectID"])
                });

            }
            return StoppageActionTaken;

        }
        public List<Stoppage> Stoppage(string Unit, string CrushingSeason, string StoppageDate, string StoppageTill, string StoppageStation, string StoppageSparesProcess, string StoppageActionTaken, string StoppageDefect)
        {
            if (StoppageDate.Length > 0 && StoppageDate.Length == 10)
            {
                string d = StoppageDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                StoppageDate = s;
            }
            if (StoppageTill.Length > 0 && StoppageTill.Length == 10)
            {
                string d1 = StoppageTill.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                StoppageTill = s1;
            }


            string sql = "select  LS.StoppageID,LS.UnitID,LS.CrushingSeasonID,LS.StoppageDate,LS.DateSerial,LS.StoppageStart,LS.StoppageTill,LS.StationID,LS.Duration,isnull(LS.DurationHour,0)DurationHour,LS.Remarks,isnull(LS.StoppageType,'')StoppageType,isnull(LS.SpareProcessID,'')SpareProcessID,isnull(LS.DefectID,'')DefectID,isnull(LS.ActionID,'')ActionID,CS.CrushingSeasonName,CU.UnitName,LSS.StationName,LSSP.SpareProcessName,LSAT.ActionName,LSD.DefectName,LSSP.SpareProcessCode,LSD.DefectCode,LSAT.ActionCode,LSS.StationCode,St.StoppageTypeName from Lab.Stoppage LS left Join Common.Unit CU on LS.UnitID = Cu.UnitID left Join Common.CrushingSeason CS on LS.CrushingSeasonID = CS.CrushingSeasonID Left Join Lab.StoppageStation LSS on LS.StationID = Lss.StationID Left Join Lab.StoppageSparesProcess LSSP on LS.SpareProcessID = LSSP.SpareProcessID Left Join Lab.StoppageActionTaken LSAT on Ls.ActionID = LSAT.ActionID Left Join Lab.StoppageDefect LSD on Ls.DefectID = LSD.DefectID Left Outer Join StoppageType ST on Ls.StoppageType=St.Id where 1=1";
           
            
            if (Unit != "" && Unit!="undefined"&& Unit!=null)
            {
                sql = sql + "and LS.UnitID='" + Unit + "'";
            }

            if (CrushingSeason != "" && CrushingSeason != "undefined" && CrushingSeason != null)
            {
                sql = sql + "and LS.CrushingSeasonID='" + CrushingSeason + "'";
            }
             if (StoppageDate != "" && StoppageDate != "undefined" && StoppageDate != null)
            {
               
                sql = sql + "and LS.StoppageDate ='" + StoppageDate + "'";
            }
            if (StoppageTill != "" && StoppageTill != "" && StoppageTill != "undefined" && StoppageTill != null)
            {
               
                sql = sql + "and LS.StoppageDate between '" + StoppageDate + "' and '"+ StoppageTill + "'";
            }
            if (StoppageStation != "" && StoppageStation != "undefined" && StoppageStation != null )
            {
                sql = sql + "and LS.StationID='" + StoppageStation + "'";
            }
            if (StoppageSparesProcess != "" && StoppageSparesProcess != "undefined" && StoppageSparesProcess != null)
            {
                sql = sql + "and LS.SpareProcessID='" + StoppageSparesProcess + "'";

            }
            if (StoppageActionTaken != "" && StoppageActionTaken != "undefined" && StoppageActionTaken != null)
            {
                sql = sql + "and LS.ActionID='" + StoppageActionTaken + "'";
            }

            if (StoppageDefect != "" && StoppageDefect != "undefined" && StoppageDefect != null)
            {
                sql = sql + "and LS.DefectID='" + StoppageDefect + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Stoppage> Stoppage = new List<Stoppage>();
            foreach (DataRow dr in dt.Rows)
            {
                DropdownListSevices DS = new DropdownListSevices();
                var StoppageStart = DateTime.Parse(dr["StoppageStart"].ToString());
                var StoppageTil = DateTime.Parse(dr["StoppageTill"].ToString());
                var Timespan = DS.DateDiff(StoppageStart, StoppageTil);
                Stoppage.Add(new Stoppage
                {
                    StoppageId = Convert.ToInt32(dr["StoppageID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    StoppageDate = DateTime.Parse(dr["StoppageDate"].ToString()),
                    StoppageStart = DateTime.Parse(dr["StoppageStart"].ToString()),
                    StoppageTill = DateTime.Parse(dr["StoppageTill"].ToString()),
                    DateSerial = Convert.ToInt16(dr["DateSerial"]),
                    StationCode = dr["StationCode"].ToString(),
                    Duration = Convert.ToInt16(dr["Duration"]),
                    DurationHour = dr["DurationHour"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                    StoppageType = Convert.ToInt16(dr["StoppageType"]),
                    SpareProcessCode = dr["SpareProcessCode"].ToString(),
                    DefectCode = dr["DefectCode"].ToString(),
                    ActionCode = dr["ActionCode"].ToString(),
                    SpareProcessName = dr["SpareProcessName"].ToString(),
                    DefectDefectName = dr["DefectName"].ToString(),
                    ActionActionName = dr["ActionName"].ToString(),
                    ActionId = Convert.ToInt32(dr["ActionID"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    DefectId = Convert.ToInt32(dr["DefectID"]),
                    SpareProcessId = Convert.ToInt32(dr["SpareProcessID"]),
                    StationId = Convert.ToInt32(dr["StationID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    StoppageTypeName = dr["StoppageTypeName"].ToString(),
                    

                }); 

            }
            return Stoppage;
        }
        public DataTable InsertStoppageDepartment(int Id,string Code, string Name,int PId)
        {

            string SqlQujery = "Exec InsertStoppageDepartmentNew " + Id + ",'" + Code + "','" + Name + "'," + PId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertStoppageStation(int Id, string Code, string Name,int DId, int PId)
        {

            string SqlQujery = "Exec InsertStoppageStationNew " + Id + ",'" + Code + "','" + Name + "',"+DId+"," + PId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertStoppageSparesProcess(int Id, string Code, string Name, bool IsProcess, int SId)
        {

            string SqlQujery = "Exec InsertStoppageSparesProcessNew " + Id + ",'" + Code + "','" + Name + "'," + IsProcess + "," + SId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertStoppageDefect(int Id, string Code, string Name, int ProcessId)
        {

            string SqlQujery = "Exec InsertStoppageDefectNew " + Id + ",'" + Code + "','" + Name + "'," + ProcessId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertStoppageActionTaken(int Id, string Code, string Name, int DfctId)
        {

            string SqlQujery = "Exec InsertStoppageActionTakenNew " + Id + ",'" + Code + "','" + Name + "'," + DfctId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertStoppage(int Id, int UId, int CSId, DateTime StoppageDate, int DateSerial, DateTime StoppageStart, DateTime StoppageTil, TimeSpan StartTime, TimeSpan EndTime, int SId, int Duration, string DurationHour, string Remarks, int stoppageType, int SPId, int DefctId, int AId)
        {

            string SqlQujery = "Exec InsertStoppagenNew " + Id + "," + UId + "," + CSId + ",'" + StoppageDate.ToString("yyyy-MM-dd") + "'," + DateSerial + ",'" + StoppageStart.ToString("yyyy-MM-dd") + ' ' + StartTime.ToString() + "','" + StoppageTil.ToString("yyyy-MM-dd") + ' ' + EndTime.ToString() + "'," + SId + "," + Duration + ",'" + DurationHour + "','" + Remarks + "'," + stoppageType + "," + SPId + "," + DefctId + "," + AId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public List<StationWiseStoppageReport> StationWiseStoppageReport(string StartDate,string EndDate,string UnitId,string StationId)
        {

            string Staedt = "null", EndDt = "null", unitVal = "null", StationIdVal = "null", sqlquery;
           
            if (UnitId != "" && UnitId != "undefind" && UnitId != null && UnitId != "null")
            {
                unitVal = UnitId;
            }
            if (StationId != "" && StationId != "undefind" && StationId != null && StationId != "null")
            {
                StationIdVal = StationId;
            }
           if (StartDate != "" && StartDate != "undefind" && StartDate != null && StartDate != "null")
            {
                string d = StartDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                Staedt = s;
            }
            if (EndDate != "" && EndDate != "undefind" && EndDate != "null" && EndDate!=null)
            {
                string d = EndDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                EndDt = s;
            }
            if (StartDate != "" && StartDate != "undefind" && StartDate != "null" && StartDate != null)
            {
                sqlquery = "exec StationWiseStoppageList '" + Staedt + "'," + EndDt + "," + unitVal + "," + StationIdVal + "";
                if (StartDate != "" && StartDate != "undefind" && StartDate != "null" && StartDate != null && EndDate != "" && EndDate != "undefind" && EndDate != "null" && EndDate != null)
                {
                    sqlquery = "exec StationWiseStoppageList '" + Staedt + "','" + EndDt + "'," + unitVal + "," + StationIdVal + "";

                }

            }
            else
            {
                sqlquery = "exec StationWiseStoppageList " + Staedt + "," + EndDt + "," + unitVal + "," + StationIdVal + "";
            }

            //string sqlquery = "exec DateWiseDailyParameterReport '"+ entrydateVal + "','"+ entrydate2Val + "','"+ unitVal + "','"+ Pval + "','"+ PTypeval + "'";

            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<StationWiseStoppageReport> stationWiseStoppageReport = new List<StationWiseStoppageReport>();
            foreach (DataRow dr in dt.Rows)
            {
                stationWiseStoppageReport.Add(new StationWiseStoppageReport
                {
                    StationName = dr["StationName"].ToString(),
                    StoppageDate =DateTime.Parse(dr["StoppageDate"].ToString()),
                    StoppageStart = DateTime.Parse(dr["StoppageStart"].ToString()),
                    StoppageTill= DateTime.Parse(dr["StoppageTill"].ToString()),
                    Duration=dr["Duration"].ToString(),
                    DurationHour=dr["DurationHour"].ToString(),
                    Remarks=dr["Remarks"].ToString()
                });

            }
            return stationWiseStoppageReport;

        }
        public List<DailyStoppageReport> DailyStoppageReport(string StartDate, string UnitId)
        {

            string Staedt = "null", unitVal = "null", sqlquery;

            if (UnitId != "" && UnitId != "undefind" && UnitId != null && UnitId != "null")
            {
                unitVal = UnitId;
            }

            if (StartDate != "" && StartDate != "undefind" && StartDate != null && StartDate != "null")
            {
                 string d = StartDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
               
			    Staedt = s;
           sqlquery = "exec DailyStoppageReportNew '" + Staedt + "'," + unitVal + "";
             //sqlquery = "exec DailyStoppageReportNew '" + Staedt + "'";
            }
            else 
            {
                sqlquery = "exec DailyStoppageReportNew " + Staedt + "," + unitVal + "";
                //sqlquery = "exec DailyStoppageReportNew " + Staedt + "";
            }   

            //string sqlquery = "exec DateWiseDailyParameterReport '"+ entrydateVal + "','"+ entrydate2Val + "','"+ unitVal + "','"+ Pval + "','"+ PTypeval + "'";

            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DailyStoppageReport> dailyStoppageReport = new List<DailyStoppageReport>();
            foreach (DataRow dr in dt.Rows)
            {
                dailyStoppageReport.Add(new DailyStoppageReport
                {
                    StationName = dr["StationName"].ToString(),
                    From=dr["From"].ToString(),
                    Till = dr["Till"].ToString(),
                    Duration = dr["Duration"].ToString(),
                    StoppageTypeName = dr["StoppageTypeName"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                   
                });

            }
            return dailyStoppageReport;

        }
        public List<GroupWiseStoppageReport> GroupWiseStoppageReport(string StartDate,string EndDate, string UnitId,string StationId, string DepartmentId)
        {
            


            string Staedt = "",Enddt="null", Stationval="null",Departmentval="null", unitVal = "null", sqlquery;

            if (UnitId != "" && UnitId != "undefind" && UnitId != null && UnitId != "null")
            {
                unitVal = UnitId;
            }
            if (StationId != "" && StationId != "undefind" && StationId != null && StationId != "null")
            {
                Stationval = StationId;
            }
            if(DepartmentId != "" && DepartmentId != "undefind" && DepartmentId != null && DepartmentId != "null")
            {
                Departmentval = DepartmentId;
            }
            if(StartDate != "" && StartDate != "undefind" && StartDate != null && StartDate != "null")
            {
                
                string d = StartDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                Staedt = s;


            }

            if (EndDate != "" && EndDate != "undefind" && EndDate != null && EndDate != "null")
            {
                string d = EndDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                Enddt = s;
                //sqlquery = "exec DailyStoppageReportNew '" + Staedt + "'," + unitVal + "";
                sqlquery = "exec GroupWiseStoppageReportNew '" + Staedt + "','"+ Enddt + "',"+ unitVal + ","+ Stationval + ","+ Departmentval + "";
            }
            else
            {
                //sqlquery = "exec DailyStoppageReportNew " + Staedt + "," + unitVal + "";
                sqlquery = "exec GroupWiseStoppageReportNew '" + Staedt + "',"+Enddt+","+ unitVal + ","+ Stationval + ","+ Departmentval + "";
            }

            //string sqlquery = "exec DateWiseDailyParameterReport '"+ entrydateVal + "','"+ entrydate2Val + "','"+ unitVal + "','"+ Pval + "','"+ PTypeval + "'";

            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<GroupWiseStoppageReport> groupWiseStoppageReport = new List<GroupWiseStoppageReport>();
            foreach (DataRow dr in dt.Rows)
            {
                groupWiseStoppageReport.Add(new GroupWiseStoppageReport
                {
                    StationName = dr["StationName"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    Duration = dr["Duration"].ToString(),
                    DurationInMinutes = dr["DurationInMinut"].ToString(),
                    UnitId = dr["UnitID"].ToString(),
                    DepartmentId = dr["DepartmentID"].ToString(),
                    StationId = dr["StationID"].ToString(),
                   StoppageDate=DateTime.Parse(dr["StoppageDate"].ToString())

                }) ;

            }
            return groupWiseStoppageReport;

        }

    }
}