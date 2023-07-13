using KnowledgeApp_Test.Models.PlantData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class PlantDataServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'PlantDataServices.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'PlantDataServices.sdr' is never used


        public List<MillParameter> MillParameter()
        {

            string sql = "Select * from Lab.MILL_PARAMETER";


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MillParameter> MillParameter = new List<MillParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                MillParameter.Add(new MillParameter
                {
                    MillParameterId = Convert.ToInt32(dr["MillParameterID"]),
                    MillParameterCode = Convert.ToInt16(dr["MillParameterCode"]),
                    MillParameterName = dr["MillParameterName"].ToString(),
                    ShortName = dr["ShortName"].ToString(),
                    IsApplicableForWil=(bool)(dr["IsApplicableForWIL"]),
                    IsTwoHourly= (bool)(dr["IsTwoHourly"]),
                    Flag = Convert.ToInt16(dr["Flag"])
                });

            }
            return MillParameter;

        }

        public List<Mill> Mill()
        {

            string sql = "select MillID,MillCode,MillName,(Case when MillType =1 then 'Texmaco' else 'WIL' end) MillType from Lab.Mill ";


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<Mill> Mill = new List<Mill>();
            foreach (DataRow dr in dt.Rows)
            {
                Mill.Add(new Mill
                {
                    MillId = Convert.ToInt32(dr["MillID"]),
                    MillCode = Convert.ToInt16(dr["MillCode"]),
                    MillName = dr["MillName"].ToString(),
                    MillTypeName = dr["MillType"].ToString(),
                  
                });

            }
            return Mill;

        }

        public List<MillLog> MillLog( string Unit)
        {

            string sql = "select LML.MillLogID,isnull(LML.UnitID,'')UnitID,Isnull(LML.DocumentNumber,'')DocumentNumber ,Isnull(LML.LogDate,'')LogDate ,Isnull(LML.LogHour,'')LogHour ,Isnull(LML.MillType,'')MillType,Isnull(LML.EntryType,'')EntryType,Cu.UnitName from Lab.MILL_LOG LML Left outer Join Common.Unit Cu on LML.UnitID=Cu.UnitId where 1=1";
            if (Unit != "" && Unit!=null && Unit!="undefined" && Unit!="null")
            {
                sql = sql + " and LML.UnitID='" + Unit + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MillLog> MillLog = new List<MillLog>();
            foreach (DataRow dr in dt.Rows)
            {
                MillLog.Add(new MillLog
                {
                    MillLogId = Convert.ToInt32(dr["MillLogID"]),
                    UnitId = Convert.ToInt16(dr["UnitID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    DocumentNumber = Convert.ToInt32(dr["DocumentNumber"]),
                    LogDate= DateTime.Parse(dr["LogDate"].ToString()),
                    LogHour = Convert.ToInt16(dr["LogHour"]),
                    MillType= Convert.ToInt32(dr["MillType"]),
                    EntryType = Convert.ToInt32(dr["EntryType"]),

                });

            }
            return MillLog;

        }
        public List<MillLogDetails> MillLogDetails(string MillLog,string MillParameter,string Mill, string DetailId)
        {
            string sql = "Select MLD.MillLogDetailID,MLD.MillLogID,MLD.SerialNumber,MLD.MillParameterID,isnull(MLD.MillID,'')MillID,isnull(MLD.LogValue,'')LogValue,LMP.MillParameterName,LM.MillName from Lab.MILL_LOG_DETAIL MLD Left outer join Lab.MILL_PARAMETER LMP on MLD.MillParameterID=LMP.MillParameterID Left Outer Join Lab.MILL LM on MLD.MillID= LM.MillID where 1=1";
            if (MillLog != "" && MillLog!="undefined" && MillLog!="null" && MillLog != null)
            {
                sql = sql + " and MLD.MillLogID=" + MillLog + "";
            }
            if (DetailId != "" && DetailId != "undefined" && DetailId != "null" && DetailId != null)
            {
                sql = sql + " and MLD.MillLogDetailID=" + DetailId + "";
            }
            if(MillParameter != "" && MillParameter != "undefined" && MillParameter != "null" && MillParameter != null)
            {
                sql = sql + "and MLD.MillParameterID=" + MillParameter + "";
            }
            if (Mill != "" && Mill != "undefined" && Mill != "null" && Mill != null)
            {
                sql = sql + "and MLD.MillID=" + Mill + "";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MillLogDetails> millLogDetails = new List<MillLogDetails>();
            foreach (DataRow dr in dt.Rows)
            {
                millLogDetails.Add(new MillLogDetails
                {
                    MillLogDetailID = Convert.ToInt32(dr["MillLogDetailID"]),
                    MillLogID = Convert.ToInt16(dr["MillLogID"]),
                    MillParameterName = dr["MillParameterName"].ToString(),
                    MillName =dr["MillName"].ToString(),
                    LogValue=Convert.ToInt32(dr["LogValue"]),
                    SerialNumber = Convert.ToInt32(dr["SerialNumber"]),
                    MillParameterId = Convert.ToInt32(dr["MillParameterID"]),
                    MillId = Convert.ToInt32(dr["MillID"]),
                });

            }
            return millLogDetails;

        }


        public List<Pan> Pan()
        {

            string sql = "select * from Lab.Pan";
           
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<Pan> Pan = new List<Pan>();
            foreach (DataRow dr in dt.Rows)
            {
                Pan.Add(new Pan
                {
                    PanId = Convert.ToInt32(dr["PanID"]),
                    PanCode = Convert.ToInt16(dr["PanCode"]),
                    PanName = dr["PanName"].ToString(),

                });

            }
            return Pan;

        }


        public List<Shift> Shift()
        {

            string sql = "select * from Lab.Shift";

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<Shift> Shift = new List<Shift>();
            foreach (DataRow dr in dt.Rows)
            {
                Shift.Add(new Shift
                {
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    ShiftCode = Convert.ToInt16(dr["ShiftCode"]),
                    ShiftName = dr["ShiftName"].ToString(),
                    ShortCode = dr["ShortCode"].ToString(),
                    FirstHour = Convert.ToInt32(dr["FirstHour"]),
                    SecondHour = Convert.ToInt32(dr["SecondHour"]),
                    ThirdHour = Convert.ToInt32(dr["ThirdHour"]),
                    FourthHour = Convert.ToInt32(dr["FourthHour"]),
                });

            }
            return Shift;

        }

        public List<ShiftEngineerLogbook> ShiftEngineerLogbook(string Unit, string Shift, string LogDate2, string LogDate3, string PlantDepartment, string PlantSubDepartment, string ShiftIncharge, string SectionHead, string DepartmentHead)
        {

            string sql = "select LSEGB.EngineerLogbookID,Isnull(LSEGB.DocumentNumber,'')DocumentNumber,Isnull(LSEGB.LogDate,'')LogDate,Isnull(LSEGB.PlantDepartmentID,'')PlantDepartmentID,Isnull(LSEGB.PlantSubDepartmentID,'')PlantSubDepartmentID,Isnull(LSEGB.ShiftID,'')ShiftID,Isnull(LSEGB.ShiftInchargeID,'')ShiftInchargeID,Isnull(LSEGB.IsChemist,'')IsChemist,Isnull(LSEGB.SectionHeadID,'')SectionHeadID,Isnull(LSEGB.DepartmentHeadID,'')DepartmentHeadID,Isnull(LSEGB.EntryUserID,'')EntryUserID,Isnull(LSEGB.EntryDate,'')EntryDate,Isnull(LSEGB.UnitID,'')UnitID,Isnull(CU.UnitName,'')UnitName,LPD.DepartmentName,LPSD.SubDepartmentName,LS.ShiftName,LSS.ShiftName as ShiftInchargeName,LE.EmployeeCode as SectionHeadCode,LEE.EmployeeCode as DepartmentHeadCode from Lab.SHIFT_ENGINEER_LOGBOOK LSEGB left outer join  Common.Unit CU on LSEGB.UnitID=CU.UnitID left outer join Lab.PlantDepartment LPD on LSEGB.PlantDepartmentID=LPD.PlantDepartmentID left outer join Lab.PlantSubDepartment LPSD on LSEGB.PlantSubDepartmentID=LPSD.PlantSubDepartmentID left outer join Lab.Shift LS on LSEGB.ShiftID=LS.ShiftID left outer join Lab.Shift LSS on LSEGB.ShiftInchargeID=LSS.ShiftID left outer join Lab.EMPLOYEE LE on LSEGB.SectionHeadID=LE.EmployeeID left outer join Lab.EMPLOYEE LEE on LSEGB.DepartmentHeadID=LEE.EmployeeID where 1=1";
            if (LogDate2.Length > 0 && LogDate2.Length == 10)
            {
                string d = LogDate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                LogDate2 = s;
            }
            if (LogDate3.Length > 0 && LogDate3.Length == 10)
            {
                string d1 = LogDate3.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                LogDate3 = s1;
            }
            if (Unit != "" && Unit!=null && Unit!="undefined" && Unit!="null") 
            {
                sql = sql + "and LSEGB.UnitID='" + Unit + "'";
            }
            if (Shift != "" && Shift != null && Shift != "undefined" && Shift != "null")
            {
                sql = sql + "and LSEGB.ShiftID='" + Shift + "'";
            }
            if (LogDate2 != "" && LogDate3==""  && LogDate2 != null && LogDate2 != "undefined" && LogDate2 != "null" || LogDate3==null || LogDate3=="undefined" || LogDate3=="null")
            {
                sql = sql + "and LSEGB.LogDate='" + LogDate2 + "'";
            }
            if (LogDate2 != "" && LogDate3 != "" && LogDate2 != null && LogDate2 != "undefined" && LogDate2 != "null" && LogDate3 != null && LogDate3 != "undefined" && LogDate3 != "null")
            {
                sql = sql + "and LSEGB.LogDate between '" + LogDate2 + "' and '"+ LogDate3 + "'";
            }
            if (PlantDepartment != "" && PlantDepartment != null && PlantDepartment != "undefined" && PlantDepartment != "null")
            {
                sql = sql + "and LSEGB.PlantDepartmentID='" + PlantDepartment + "'";
            }
            if (PlantSubDepartment != "" && PlantSubDepartment != null && PlantSubDepartment != "undefined" && PlantSubDepartment != "null")
            {
                sql = sql + "and LSEGB.PlantSubDepartmentID='" + PlantSubDepartment + "'";
            }
            if (ShiftIncharge != "" && ShiftIncharge != null && ShiftIncharge != "undefined" && ShiftIncharge != "null")
            {
                sql = sql + "and LSEGB.ShiftInchargeID='" + ShiftIncharge + "'";
            }

            if (SectionHead != "" && SectionHead != null && SectionHead != "undefined" && SectionHead != "null")
            {
                sql = sql + "and LSEGB.SectionHeadID='" + SectionHead + "'";
            }

            if (DepartmentHead != "" && DepartmentHead != null && DepartmentHead != "undefined" && DepartmentHead != "null")
            {
                sql = sql + "and LSEGB.DepartmentHead='" + ShiftIncharge + "'";
            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<ShiftEngineerLogbook> ShiftEngineerLogbook = new List<ShiftEngineerLogbook>();
            foreach (DataRow dr in dt.Rows)
            {
                ShiftEngineerLogbook.Add(new ShiftEngineerLogbook
                {
                    EngineerLogbookId = Convert.ToInt32(dr["EngineerLogbookID"]),
                    DocumentNumber = Convert.ToInt16(dr["DocumentNumber"]),
                    LogDate = DateTime.Parse(dr["LogDate"].ToString()),
                    PlantDepartmentDepartmentName = dr["DepartmentName"].ToString(),
                    PlantSubDepartmentSubDepartmentName = dr["SubDepartmentName"].ToString(),
                    ShiftShiftName = dr["ShiftName"].ToString(),
                    IsChemist=(bool)(dr["IsChemist"]),
                    SectionHeadEmployeeCode =dr["SectionHeadCode"].ToString(),
                    DepartmentHeadEmployeeCode = dr["DepartmentHeadCode"].ToString(),
                    EntryUserId = Convert.ToInt32(dr["EntryUserID"]),
                    EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    PlantDepartmentId= Convert.ToInt32(dr["PlantDepartmentID"]),
                    PlantSubDepartmentId = Convert.ToInt32(dr["PlantSubDepartmentID"]),
                    SectionHeadId = Convert.ToInt32(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt32(dr["DepartmentHeadID"]),
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    ShiftInchargeId = Convert.ToInt32(dr["ShiftInchargeID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                });

            }
            return ShiftEngineerLogbook;

        }


        public List<PlantPerformance> PlantPerformance(string Unit, string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {

            string sql = "select LPP.PlantPerformanceID,Isnull(LPP.LogDate,'')LogDate,Isnull(LPP.ShiftID,'')ShiftID,Isnull(LPP.LogHour,'')LogHour,Isnull(LPP.CaneCrushed,0)CaneCrushed,Isnull(LPP.SugarBagged,0)SugarBagged,Isnull(LPP.FBDAirTemperature,0)FBDAirTemperature,Isnull(LPP.ExhaustTemperature,0)ExhaustTemperature,Isnull(LPP.ImbitionPercent,0)ImbitionPercent,Isnull(LPP.ProcessHeadID,'')ProcessHeadID,Isnull(LPP.SectionHeadID,'')SectionHeadID,Isnull(LPP.DepartmentHeadID,'')DepartmentHeadID,Isnull(LPP.UnitID,'')UnitID,CU.UnitName,LEEE.EmployeeCode as ProcessHeadEmployeeCode ,LEE.EmployeeCode as DepartmentHeadEmployeeCode,LE.EmployeeCode as SectionHeadEmployeeCode,LS.ShiftName from Lab.PLANT_PERFORMANCE LPP left outer join  Common.Unit CU on LPP.UnitID=CU.UnitID left outer join Lab.Shift LS on LPP.ShiftID=LS.ShiftID left outer join Lab.EMPLOYEE LEEE on LPP.ProcessHeadID=LEEE.EmployeeID left outer join Lab.EMPLOYEE LE on LPP.SectionHeadID=LE.EmployeeID left outer join Lab.EMPLOYEE LEE on LPP.DepartmentHeadID=LEE.EmployeeID where 1=1";
            if (Unit != "" && Unit!=null && Unit!="null" && Unit!="undefined")
            {
                sql = sql + "and LPP.UnitID='" + Unit + "'";
            }
            if (Shift != "" && Shift != null && Shift != "null" && Shift != "undefined")
            {
                sql = sql + "and LPP.ShiftID='" + Shift + "'";
            }
         
            if (ProcessHead != "" && ProcessHead != null && ProcessHead != "null" && ProcessHead != "undefined")
            {
                sql = sql + "and LPP.ProcessHeadID='" + ProcessHead + "'";
            }
            if (SectionHead != "" && SectionHead != null && SectionHead != "null" && SectionHead != "undefined")
            {
                sql = sql + "and LPP.SectionHeadID='" + SectionHead + "'";
            }
            if (DepartmentHead != "" && DepartmentHead != null && DepartmentHead != "null" && DepartmentHead != "undefined")
            {
                sql = sql + "and LPP.DepartmentHeadID='" + DepartmentHead + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PlantPerformance> PlantPerformance = new List<PlantPerformance>();
            foreach (DataRow dr in dt.Rows)
            {
                PlantPerformance.Add(new PlantPerformance
                {
                    PlantPerformanceId = Convert.ToInt32(dr["PlantPerformanceID"]),
                    UnitUnitName =dr["UnitName"].ToString(),
                    LogDate = DateTime.Parse(dr["LogDate"].ToString()),
                    ShiftShiftName = dr["ShiftName"].ToString(),
                    LogHour = Convert.ToInt16(dr["LogHour"]),
                    CaneCrushed = Convert.ToInt32(dr["CaneCrushed"]),
                    SugarBagged = Convert.ToInt32(dr["SugarBagged"]),
                    FbdAirTemperature = Convert.ToInt32(dr["FBDAirTemperature"]),
                    ExhaustTemperature = Convert.ToInt32(dr["ExhaustTemperature"]),
                    ImbitionPercent = Convert.ToInt32(dr["ImbitionPercent"]),
                    ProcessHeadEmployeeCode = dr["ProcessHeadEmployeeCode"].ToString(),
                    SectionHeadEmployeeCode = dr["SectionHeadEmployeeCode"].ToString(),
                    DepartmentHeadEmployeeCode = dr["DepartmentHeadEmployeeCode"].ToString(),
                    ProcessHeadId = Convert.ToInt32(dr["ProcessHeadID"]),
                    SectionHeadId = Convert.ToInt32(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt32(dr["DepartmentHeadID"]),
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                });

            }
            return PlantPerformance;
        }
        public List<PlantDepartment> PlantDepartment()
        {
            string sql = "select PlantDepartmentID,isnull(OldCode,'')OldCode,DepartmentName,isnull(ShortName,'')ShortName,DepartmentCode from Lab.PlantDepartment";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PlantDepartment> PlantDepartment = new List<PlantDepartment>();
            foreach (DataRow dr in dt.Rows)
            {
                PlantDepartment.Add(new PlantDepartment
                {
                    PlantDepartmentId = Convert.ToInt32(dr["PlantDepartmentID"]),
                    OldCode = Convert.ToInt16(dr["OldCode"]),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    ShortName = dr["ShortName"].ToString(),
                    DepartmentCode=dr["DepartmentCode"].ToString()
                });

            }
            return PlantDepartment;

        }
        public List<PlantSubDepartment> PlantSubDepartment(string PlantDepartment)
        {
            string sql = "select LPSD.PlantSubDepartmentID,LPSD.PlantDepartmentID,LPSD.OldCode,LPSD.SubDepartmentName,LPSD.ShortName,LPSD.DepartmentCode,LPD.DepartmentName from Lab.PlantSubDepartment LPSD left outer Join Lab.PlantDepartment LPD on LPSD.PlantDepartmentID=LPD.PlantDepartmentID Where 1=1";
            if (PlantDepartment!="") 
            {
                sql = sql + "and LPSD.PlantDepartmentID='" + PlantDepartment + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PlantSubDepartment> PlantSubDepartment = new List<PlantSubDepartment>();
            foreach (DataRow dr in dt.Rows)
            {
                PlantSubDepartment.Add(new PlantSubDepartment
                {
                    PlantSubDepartmentId= Convert.ToInt32(dr["PlantSubDepartmentID"]),
                    PlantDepartmentId = Convert.ToInt32(dr["PlantDepartmentID"]),
                    OldCode = Convert.ToInt16(dr["OldCode"]),
                    SubDepartmentName = dr["SubDepartmentName"].ToString(),
                    ShortName = dr["ShortName"].ToString(),
                    DepartmentCode = dr["DepartmentCode"].ToString(),
                    PlantDepartmentName=dr["DepartmentName"].ToString()
                });

            }
            return PlantSubDepartment;

        }
        public List<Position> Position(string MillParameter)
        {
            string sql = "select LP.PositionID,LP.PositionCode,LP.PositionName,isnull(LP.MillParameterID,'')MillParameterID,LP.ShortName,LMP.MillParameterName from Lab.POSITION LP left outer join Lab.MILL_PARAMETER LMP on LP.MillParameterID=LMP.MillParameterID Where 1=1";
            if (MillParameter != "")
            {
                sql = sql + "and LP.MillParameterID='" + MillParameter + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Position> Position = new List<Position>();
            foreach (DataRow dr in dt.Rows)
            {
                Position.Add(new Position
                {
                    PositionId = Convert.ToInt32(dr["PositionID"]),
                    PositionCode = Convert.ToInt16(dr["PositionCode"]),
                    PositionName = dr["PositionName"].ToString(),
                    MillParameterMillParameterName = dr["MillParameterName"].ToString(),
                    ShortName = dr["ShortName"].ToString(),
                    MillParameterId = Convert.ToInt32(dr["MillParameterID"]),

                });

            }
            return Position;

        }

        public List<PanPosition> PanPosition(string Unit, string ProcessHead, string SectionHead, string DepartmentHead)
        {
            string sql = "Select LPP.PanPositionID,LPP.AnalysisDate,LPP.ShiftID,isnull(LPP.ProcessHeadID,'')ProcessHeadID,isnull(LPP.SectionHeadID,'')SectionHeadID,isnull(LPP.DepartmentHeadID,'')DepartmentHeadID,isnull(LPP.UnitID,'')UnitID,LE.EmployeeCode as ProcessHead,LEE.EmployeeCode as SectionHead,LEE.EmployeeCode as DepartmentHead,Ls.ShiftName,Cu.UnitName from Lab.PAN_POSITION LPP Left outer Join Lab.Employee LE on LPP.ProcessHeadID = LE.EmployeeID Left outer Join Lab.Employee LEE on LPP.SectionHeadID = LEE.EmployeeID Left outer Join Lab.Employee LEEE on LPP.SectionHeadID = LEEE.EmployeeID Left outer Join Lab.Shift LS on LPP.ShiftID =LS.ShiftID Left outer Join Common.Unit CU on LPP.UnitID=CU.UnitID where 1=1";
            if (Unit != "")
            {
                sql = sql + "and LPP.UnitID='" + Unit + "'";
            }
            if (ProcessHead != "")
            {
                sql = sql + "and LPP.ProcessHeadID='" + ProcessHead + "'";
            }
            if (SectionHead != "")
            {
                sql = sql + "and LPP.SectionHeadID='" + SectionHead + "'";
            }
            if (DepartmentHead != "")
            {
                sql = sql + "and LPP.DepartmentHeadID='" + DepartmentHead + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PanPosition> PanPosition = new List<PanPosition>();
            foreach (DataRow dr in dt.Rows)
            {
                PanPosition.Add(new PanPosition
                {
                    PanPositionId = Convert.ToInt32(dr["PanPositionID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    AnalysisDate = DateTime.Parse(dr["AnalysisDate"].ToString()),
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    ProcessHeadEmployeeCode = dr["ProcessHead"].ToString(),
                    SectionHeadEmployeeCode = dr["SectionHead"].ToString(),
                    DepartmentHeadEmployeeCode = dr["DepartmentHead"].ToString(),
                    ProcessHeadId = Convert.ToInt16(dr["ProcessHeadID"]),
                    SectionHeadId = Convert.ToInt16(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt16(dr["DepartmentHeadID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                   
                  
                });

            }
            return PanPosition;

        }

        public List<Location> Location(string Position)
        {
            string sql = "select LL.LocationID,isnull(LL.LocationCode,'')LocationCode,LL.LocationName,isnull(LL.PositionID,'')PositionID,LL.ShortName,LP.PositionName from Lab.LOCATION LL left outer join Lab.POSITION LP on LL.PositionID=LP.PositionID Where 1=1";
            if (Position != "")
            {
                sql = sql + "and LL.PositionID='" + Position + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Location> Location = new List<Location>();
            foreach (DataRow dr in dt.Rows)
            {
                Location.Add(new Location
                {
                    LocationId = Convert.ToInt32(dr["LocationID"]),
                    LocationCode = Convert.ToInt16(dr["LocationCode"]),
                    LocationName = dr["LocationName"].ToString(),
                    PositionPositionName = dr["PositionName"].ToString(),
                    ShortName = dr["ShortName"].ToString(),
                    PositionId = Convert.ToInt32(dr["PositionID"]),

                });

            }
            return Location;

        }

        public List<PanPositionDetail> PanPositionDetail(string Pan, string PanPostion, string DetailId)
        {
            string sql = "select PPD.PanPositionDetailID,PPD.PanPositionID,isnull(PPD.SerialNumber,'')SerialNumber,isnull(PPD.PanID,'')PanID,isnull(PPD.PanValue,0)PanValue,P.PanName from Lab.PAN_POSITION_Detail PPD left outer join Lab.Pan P on PPd.PanID=P.PanID where 1=1";
            if (PanPostion != ""&& PanPostion!="undefined"&& PanPostion!="null" && PanPostion!=null)
            {
                sql = sql + "and PPD.PanPositionID='" + PanPostion + "'";
            }
            if (Pan != "" && Pan != "undefined" && Pan != "null" && Pan != null)
            {
                sql = sql + "and PPD.PanID='" + Pan + "'";
            }
            if (DetailId != "" && DetailId != "undefined" && DetailId != "null" && DetailId != null)
            {
                sql = sql + "and PPD.PanPositionDetailID='" + DetailId + "'";
            }



            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PanPositionDetail> panPositionDetail = new List<PanPositionDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                panPositionDetail.Add(new PanPositionDetail
                {
                    SerialNumber = Convert.ToInt32(dr["SerialNumber"]),
                    PanPositionDetailID = Convert.ToInt32(dr["PanPositionDetailID"]),
                    PanPositionID = Convert.ToInt32(dr["PanPositionID"]),
                    PanValue = Convert.ToDecimal(dr["PanValue"].ToString()),
                    PanName = dr["PanName"].ToString(),
                    PanID = Convert.ToInt32(dr["PanID"]),
                });

            }
            return panPositionDetail;

        }
        public List<ShiftEngineerLogbookDetails> ShiftEngineerLogbookDetails(string logbook, string Details)
        {
            string sql = "select * from Lab.SHIFT_ENGINEER_LOGBOOK_DETAIL where 1=1";

            if (logbook != "" && logbook != "undefined" && logbook != null && logbook != "null")
            {
                sql = sql + "and EngineerLogbookID='" + logbook + "'";
            }

            if (Details != "" && Details != "undefined" && Details != null && Details != "null")
            {
                sql = sql + "and EngineerLogbookDetailID='" + Details + "'";
            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ShiftEngineerLogbookDetails> shiftEngineerLogbookDetails = new List<ShiftEngineerLogbookDetails>();
            foreach (DataRow dr in dt.Rows)
            {
                shiftEngineerLogbookDetails.Add(new ShiftEngineerLogbookDetails
                {
                    DetailsId = Convert.ToInt32(dr["EngineerLogbookDetailID"]),
                    EngineerLogbookId = Convert.ToInt16(dr["EngineerLogbookID"]),
                    SerialNo = Convert.ToInt32(dr["SerialNumber"]),
                    WorkDone = dr["WorkDone"].ToString(),
                    Observations = dr["Observations"].ToString(),
                    WorkToBeDone = dr["WorkToBeDone"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                });

            }
            return shiftEngineerLogbookDetails;
        }


        public DataTable InsertMillParameter(int Id, int Code, string Name, int Flag, bool IsApplicableForWIL, bool IsTwoHourly, string ShortName)
        {
            string SqlQujery = "Exec InsertMILLPARAMETERNew " + Id + "," + Code + ",'" + Name + "'," + Flag + "," + IsApplicableForWIL + "," + IsTwoHourly + ",'" + ShortName + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMill(int Id, int Code, string Name, int Type)
        {
            string SqlQujery = "Exec InsertMILLNew " + Id + "," + Code + ",'" + Name + "'," + Type + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMillLog(int Id, int Unit, int DocNo, DateTime LogDate, int LogHour,int type, int EntryType)
        {
            string SqlQujery = "Exec InsertMILLLOGNew " + Id + "," + Unit + "," + DocNo + ",'" + LogDate.ToString("yyyy-MM-dd") + "'," + LogHour + ","+ type + "," + EntryType + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPan(int Id, int Code, string Name)
        {
            string SqlQujery = "Exec InsertPanNew " + Id + "," + Code + ",'" + Name + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertShift(int Id, int Code, string Name, string ShortCode, int FirstHour, int SecondHour, int ThirdHour, int FourthHour)
        {
            string SqlQujery = "Exec InsertSHIFTNew " + Id + "," + Code + ",'" + Name + "','" + ShortCode + "'," + FirstHour + "," + SecondHour + "," + ThirdHour + "," + FourthHour + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMillLogDetails(int Id, int MillLogID, int SerialNumber, int MPId, int MId, int Value)
        {
            string SqlQujery = "Exec InsertMILLLOGDETAILNew " + Id + "," + MillLogID + "," + SerialNumber + "," + MPId + "," + MId + "," + Value + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertShiftEngineerLogBook(int Id, int DocNo, DateTime LogDate, int PDId, int PSDId, int SId, int SInId, bool IsChemist, int SHId, int DHId, int EntryuserId, DateTime EntryDate, int UId)
        {
            string SqlQujery = "Exec InsertSHIFTENGINEERLOGBOOKNew " + Id + "," + DocNo + ",'" + LogDate.ToString("yyyy-MM-dd") + "'," + PDId + "," + PSDId + "," + SId + "," + SInId + "," + IsChemist + "," + SHId + ","+ DHId + "," + EntryuserId + ",'" + EntryDate.ToString("yyyy-MM-dd HH:mm:ss") + "'," + UId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertShiftEngineerLogDetailsBook(int Id, int EngineerLogbookID, int SerialNumber,string  Observations, string WorkDone,string WorkToBeDone,string Remarks)
        {
            string SqlQujery = "Exec InsertSHIFTENGINEERLOGBOOKDETAILLNew " + Id + ","+ EngineerLogbookID + ","+ SerialNumber + ",'"+ Observations + "','"+ WorkDone + "','"+ WorkToBeDone + "','"+ Remarks + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPlantPerformance(int Id,  DateTime LogDate, int ShiftID, int LogHour, decimal CaneCrushed, int FBDAirTemperature, int ExhaustTemperature, decimal ImbitionPercent, int ProcessHeadID, int SectionHeadID, int DepartmentHeadID, int UnitID,int SugarBagged)
        {
            
            string SqlQujery = "Exec InsertPlantPerformanceNew " + Id + ",'" + LogDate.ToString("yyyy-MM-dd") + "'," + ShiftID + "," + LogHour + "," + CaneCrushed + ","+ SugarBagged + "," + FBDAirTemperature + "," + ExhaustTemperature + ","+ ImbitionPercent + ","+ ProcessHeadID + ","+ SectionHeadID + ","+ DepartmentHeadID + ","+ UnitID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPlantDepartment(int Id, int OldCode, string DepartmentName,string ShortName,string DepartmentCode)
        {
            string SqlQujery = "Exec InsertPlantDepartmentNew " + Id + "," + OldCode + ",'" + DepartmentName + "','"+ ShortName + "','"+ DepartmentCode + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPlantSubDepartment(int Id,int PlantDepartmentID, int OldCode, string SubDepartmentName, string ShortName, string DepartmentCode)
        {
            string SqlQujery = "Exec InsertPlantSubDepartmentNew " + Id + ","+ PlantDepartmentID + "," + OldCode + ",'" + SubDepartmentName + "','" + ShortName + "','" + DepartmentCode + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPOSITION(int Id, int PositionCode, string PositionName, int MillParameterID, string ShortName)
        {
            string SqlQujery = "Exec InsertPOSITIONNew " + Id + "," + PositionCode + ",'" + PositionName + "'," + MillParameterID + ",'" + ShortName + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPANPOSITION(int Id,DateTime AnalysisDate, int ShiftID, int ProcessHeadID, int SectionHeadID, int DepartmentHeadID,int UnitID)
        {
            string SqlQujery = "Exec InsertPANPOSITIONNew " + Id + ",'"+ AnalysisDate.ToString("yyyy-MM-dd")+ "'," + ShiftID + "," + ProcessHeadID + "," + SectionHeadID + "," + DepartmentHeadID + ","+ UnitID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertPANPOSITIONDetail(int Id,  int PanPositionID, int SerialNumber, int PanID, decimal PanValue)
        {
            string SqlQujery = "Exec InsertPANPOSITIONDetailNew " + Id + "," + PanPositionID + "," + SerialNumber + "," + PanID + "," + PanValue + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertLOCATION(int Id, int LocationCode, string LocationName, int PositionID, string ShortName)
        {
            string SqlQujery = "Exec InsertLOCATIONNew " + Id + "," + LocationCode + ",'" + LocationName + "'," + PositionID + ",'" + ShortName + "'";
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
