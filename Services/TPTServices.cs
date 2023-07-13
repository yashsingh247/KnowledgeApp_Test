using KnowledgeApp_Test.Models.TPT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class TPTServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        public List<UnitParameter> UnitParameter()
        {
            cmd = new SqlCommand("select * from Lab.UnitParameter", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<UnitParameter> UnitParameter = new List<UnitParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                UnitParameter.Add(new UnitParameter
                {
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    UnitParameterId = Convert.ToInt16(dr["UnitParameterID"])

                });

            }
            return UnitParameter;
        }
        public List<TptParameter> TptParameter(string Parameter, string ParameterUnit, string TexParameter, string WilParameter)
        {
            string sql = "select LTP.TPTParameterID,isnull(LTP.ParameterCode,'')ParameterCode,LTP.ParameterName,isnull(LTP.IsInputParameter,'')IsInputParameter,isnull(LTP.DataType,'')DataType,isnull(LTP.ParameterUnitID,'')ParameterUnitID,isnull(LTP.Formula,'')Formula,isnull(LTP.ParameterID,'')ParameterID,isnull(LTP.HighlightPositive,'')HighlightPositive,isnull(LTP.DeviationPercent,0)DeviationPercent,isnull(LTP.DifferenceValue,0)DifferenceValue,isnull(LTP.ConsolidationType,'')ConsolidationType,isnull(LTP.ConsolidationParameterID,'')ConsolidationParameterID,isnull(LTP.CalculationLevel,'')CalculationLevel,isnull(LTP.Precision,'')Precision,isnull(LTP.ShowOnFinalTPT,'')ShowOnFinalTPT,isnull(LTP.ReportType,'')ReportType,ISNULL(LTP.DisplayOrder,'')DisplayOrder,ISNULL(LTP.TP_TPT_SERIAL,'')TP_TPT_SERIAL,ISNULL(LTP.DescriptiveFormula,'')DescriptiveFormula,ISNULL(LTP.TexParameterID,'')TexParameterID,ISNULL(LTP.WILParameterID,'')WILParameterID,ISNULL(LTP.ShowOnOutput,'')ShowOnOutput,ISNULL(LTP.OutputRowNumber,'')OutputRowNumber,ISNULL(LTP.OutputSerial,'')OutputSerial,LP.ParameterName as TexParameterName,LPU.ParameterUnitName,LPP.ParameterName AS WILParameterName,LPP.ParameterName as ParameterParameterName   from Lab.TPT_PARAMETER LTP left outer join Lab.Parameter LP on LTP.TexParameterID= LP.ParameterID left outer join Lab.PARAMETER_UNIT LPU on LTP.ParameterUnitID= LPU.ParameterUnitID left outer join Lab.Parameter LPP on LTP.WILParameterID= LPP.ParameterID left outer join Lab.Parameter LPPP on LTP.ParameterID= LPPP.ParameterID where 1=1";
            if (Parameter != "" && Parameter!=null && Parameter!="undefined" && Parameter!="null")
            {
                sql = sql + "and LTP. ParameterID='" + Parameter + "'";
            }
            if (ParameterUnit != "" && ParameterUnit != null && ParameterUnit != "undefined" && ParameterUnit != "null")
            {
                sql = sql + "and LTP. ParameterUnitID='" + ParameterUnit + "'";
            }
            if (TexParameter != "" && TexParameter != null && TexParameter != "undefined" && TexParameter != "null")
            {
                sql = sql + "and LTP. TexParameterID='" + TexParameter + "'";
            }
            if (WilParameter != "" && WilParameter != null && WilParameter != "undefined" && WilParameter != "null")
            {
                sql = sql + " and LTP. WILParameterID='" + WilParameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptParameter> TptParameter = new List<TptParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                TptParameter.Add(new TptParameter
                {
                    TptParameterId = Convert.ToInt32(dr["TPTParameterID"]),
                    ParameterCode = dr["ParameterCode"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    IsInputParameter = (bool)(dr["IsInputParameter"]),
                    DataType = Convert.ToInt16(dr["DataType"]),
                    ParameterUnitParameterUnitName = dr["ParameterUnitName"].ToString(),
                    Formula = dr["Formula"].ToString(),
                    ParameterParameterName = dr["ParameterParameterName"].ToString(),
                    HighlightPositive = (bool)(dr["HighlightPositive"]),
                    DeviationPercent = Convert.ToInt32(dr["DeviationPercent"]),
                    DifferenceValue = Convert.ToInt32(dr["DifferenceValue"]),
                    ConsolidationType = Convert.ToInt16(dr["ConsolidationType"]),
                    ConsolidationParameterId = Convert.ToInt16(dr["ConsolidationParameterID"]),
                    CalculationLevel = Convert.ToInt16(dr["CalculationLevel"]),
                    Precision = Convert.ToInt16(dr["Precision"]),
                    ShowOnFinalTpt = (bool)(dr["ShowOnFinalTPT"]),
                    ReportType = Convert.ToInt16(dr["ReportType"]),
                    DisplayOrder = Convert.ToInt16(dr["DisplayOrder"]),
                    TpTptSerial = Convert.ToInt16(dr["TP_TPT_SERIAL"]),
                    DescriptiveFormula = dr["DescriptiveFormula"].ToString(),
                    TexParameterParameterName= dr["TexParameterName"].ToString(),
                    WilParameterParameterName = dr["WILParameterName"].ToString(),
                    ShowOnOutput = (bool)(dr["ShowOnOutput"]),
                    OutputRowNumber = Convert.ToInt16(dr["OutputRowNumber"]),
                    OutputSerial = Convert.ToInt16(dr["OutputSerial"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterUnitId = Convert.ToInt32(dr["ParameterUnitID"]),
                    TexParameterId = Convert.ToInt32(dr["TexParameterID"]),
                    WilParameterId = Convert.ToInt32(dr["WILParameterID"])
                });

            }
            return TptParameter;
        }
        public List<TptPower> TptPower(string Parameter, string ParameterUnit)
        {
            string sql = "select LPT.TPTPowerParameterID,LPT.TPTPowerCode,LPT.TPTPowerName,isnull(LPT.ParameterType,'')ParameterType,LPT.Formula,isnull(LPT.ParameterUnitID,'')ParameterUnitID,LPT.DescriptiveFormula,isnull(LPT.ParameterID,'')ParameterID,LP.ParameterName,LPU.ParameterUnitName from Lab.TPT_POWER LPT left outer join Lab.Parameter LP on LPT.ParameterID=LP.ParameterID left outer join Lab.PARAMETER_UNIT LPU on LPT.ParameterUnitID=LPU.ParameterUnitID where 1=1";
            if (Parameter != "" && Parameter!="undefined" && Parameter!="null"&& Parameter!=null)
            {
                sql = sql + "and LTP. ParameterID='" + Parameter + "'";
            }
            if (ParameterUnit != "" && ParameterUnit != "undefined" && ParameterUnit != "null" && ParameterUnit != null)
            {
                sql = sql + "and LTP. ParameterUnitID='" + ParameterUnit + "'";
            }
           

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptPower> TptPower = new List<TptPower>();
            foreach (DataRow dr in dt.Rows)
            {
                TptPower.Add(new TptPower
                {
                    TptPowerParameterId = Convert.ToInt32(dr["TPTPowerParameterID"]),
                    TptPowerCode = dr["TPTPowerCode"].ToString(),
                    TptPowerName = dr["TPTPowerName"].ToString(),
                    ParameterType= Convert.ToInt16(dr["ParameterType"]),
                    Formula = dr["Formula"].ToString(),
                    ParameterUnitParameterUnitName = dr["ParameterUnitName"].ToString(),
                    DescriptiveFormula =dr["DescriptiveFormula"].ToString(),
                    ParameterParameterName =dr["ParameterName"].ToString(),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterUnitId = Convert.ToInt32(dr["ParameterUnitID"])
                    
                });

            }
            return TptPower;
        }
        public List<TptRevision> TptRevision(string Unit, string CreationDate2, string CreationDate3, string CrushingSeason)
        {
            if (CreationDate2.Length > 0 && CreationDate2.Length == 10)
            {
                string d = CreationDate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                CreationDate2 = s;
            }
            if (CreationDate3.Length > 0 && CreationDate3.Length == 10)
            {
                string d1 = CreationDate3.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                CreationDate3 = s1;
            }
            string sql = "select LTR.RevisionID,isnull(LTR.UnitID,'')UnitID,isnull(LTR.RevisionCode,'')RevisionCode,LTR.RevisionName,isnull(LTR.CreationDate,'')CreationDate,isnull(LTR.SeasonStartDate,'')SeasonStartDate,isnull(LTR.CrushingSeasonID,'')CrushingSeasonID,isnull(LTR.SeasonDays,'')SeasonDays,isnull(LTR.SeasonEndDate,'')SeasonEndDate,CU.UnitName,CS.CrushingSeasonName from Lab.TPT_REVISION LTR left outer join  Common.Unit CU on LTR.UnitID=CU.UnitID left outer join  Common.CrushingSeason CS on LTR.CrushingSeasonID=CS.CrushingSeasonID where 1=1";
            if (Unit != "" && Unit != null && Unit != "undefined" && Unit != "null" )
            {
                sql = sql + "and LTR. UnitID='" + Unit + "'";
            }
            if (CreationDate2 != "" && CreationDate3=="" && CreationDate2 != null && CreationDate2 != "undefined" && CreationDate2 != "null" || CreationDate3=="undefined"|| CreationDate3==null || CreationDate3=="null")
            {
                sql = sql + "and LTR. CreationDate='" + CreationDate2 + "'";
            }
            if (CreationDate2 != "" && CreationDate3 != "" && CreationDate2 != null && CreationDate2 != "undefined" && CreationDate2 != "null" && CreationDate3 != null && CreationDate3 != "undefined" && CreationDate3 != "null")
            {
                sql = sql + "and LTR. CreationDate Between'" + CreationDate2 + "' and '"+ CreationDate3 + "'";
            }
            if (CrushingSeason != "" && CrushingSeason != null && CrushingSeason != "undefined" && CrushingSeason != "null")
            {
                sql = sql + "and LTR. CrushingSeasonID ='"+ CrushingSeason + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptRevision> TptRevision = new List<TptRevision>();
            foreach (DataRow dr in dt.Rows)
            {
                TptRevision.Add(new TptRevision
                {
                    RevisionId = Convert.ToInt32(dr["RevisionID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    RevisionName = dr["RevisionName"].ToString(),
                    RevisionCode = Convert.ToInt16(dr["RevisionCode"]),
                    CreationDate=DateTime.Parse(dr["CreationDate"].ToString()),
                    SeasonStartDate = DateTime.Parse(dr["SeasonStartDate"].ToString()),
                    CrushingSeasonCrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    SeasonEndDate = DateTime.Parse(dr["SeasonEndDate"].ToString()),
                    SeasonDays = Convert.ToInt16(dr["SeasonDays"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])

                });

            }
            return TptRevision;
        }
        public List<TptSeason> TptSeason(string tptRevision,string tptParameter)
        {
            string sql = "select LTS.TPTSeasonID,LTS.TPTYear,isnull(LTS.RevisionID,'')RevisionID,isnull(LTS.TPTParameterID,'')TPTParameterID,isnull(LTS.Target,0)Target,isnull(LTS.Actual,0)Actual,isnull(LTS.LastYearActual,0)LastYearActual,isnull(LTS.Target_TEX,0)Target_TEX,isnull(LTS.Taget_WIL,0)Taget_WIL,isnull(LTS.Actual_TEX,0)Actual_TEX,isnull(LTS.Actual_WIL,0)Actual_WIL,LTR.RevisionName,LTP.ParameterCode from Lab.TPT_SEASON LTS left Outer Join Lab.TPT_REVISION LTR on LTS.RevisionID=LTR.RevisionID left outer join Lab.TPT_PARAMETER LTP on LTS.TPTParameterID=LTP.TPTParameterID where 1=1";
            if (tptRevision != "" && tptRevision != "undefined" && tptRevision != "null" && tptRevision != null)
            {
                sql = sql + "and LTS. RevisionID='" + tptRevision + "'";
            }
            
            if (tptParameter != "" && tptParameter != "undefined" && tptParameter != "null" && tptParameter != null)
            {
                sql = sql + "and LTS. TPTParameterID ='" + tptParameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptSeason> tptSeason = new List<TptSeason>();
            foreach (DataRow dr in dt.Rows)
            {
                tptSeason.Add(new TptSeason
                {
                    RevisionId = Convert.ToInt32(dr["RevisionID"]),
                    RevisionRevisionName = dr["RevisionName"].ToString(),
                    TptParameterParameterCode = dr["ParameterCode"].ToString(),
                    TptYear = Convert.ToInt16(dr["TPTYear"]),
                    Target = Convert.ToDecimal(dr["Target"]),
                    Actual = Convert.ToDecimal(dr["Actual"]),
                    LastYearActual = Convert.ToDecimal(dr["LastYearActual"]),
                    TargetTex = Convert.ToDecimal(dr["Target_TEX"]),
                    TagetWil = Convert.ToDecimal(dr["Taget_WIL"]),
                    ActualTex = Convert.ToDecimal(dr["Actual_TEX"]),
                    ActualWil = Convert.ToDecimal(dr["Actual_WIL"]),
                    TptParameterId = Convert.ToInt32(dr["TPTParameterID"]),
                    TptSeasonId = Convert.ToInt32(dr["TPTSeasonID"])

                });

            }
            return tptSeason;
        }
        public List<TptMonthly> TptMonthly(string tptRevision, string tptParameter)
        {
            string sql = "Select LTM.TPTMonthlyID,LTM.TPTYear,LTM.TPTMonth,LTM.RevisionID,LTM.TPTParameterID,LTM.Target,LTM.Actual,LTM.LastYearActual,LTM.Target_TEX,LTM.Taget_WIL,LTM.Actual_TEX,LTM.Actual_WIL,LTR.RevisionName,LTP.ParameterCode from Lab.TPT_MONTHLY LTM Left Outer Join Lab.TPT_REVISION LTR on LTM.RevisionID=LTR.RevisionID Left Outer Join Lab.TPT_PARAMETER LTP on LTM.TPTParameterID=LTP.TPTParameterID where 1=1";
            if (tptRevision != "" && tptRevision != "undefined" && tptRevision != "null" && tptRevision != null)
            {
                sql = sql + "and LTM. RevisionID='" + tptRevision + "'";
            }

            if (tptParameter != "" && tptParameter != "undefined" && tptParameter != "null" && tptParameter != null)
            {
                sql = sql + "and LTM. TPTParameterID ='" + tptParameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptMonthly> tptMonth = new List<TptMonthly>();
            foreach (DataRow dr in dt.Rows)
            {
                tptMonth.Add(new TptMonthly
                {
                    
                    RevisionId = Convert.ToInt32(dr["RevisionID"]),
                    RevisionRevisionName = dr["RevisionName"].ToString(),
                    TptParameterParameterCode = dr["ParameterCode"].ToString(),
                    TptYear = Convert.ToInt16(dr["TPTYear"]),
                    Target = Convert.ToDecimal(dr["Target"]),
                    Actual = Convert.ToDecimal(dr["Actual"]),
                    LastYearActual = Convert.ToDecimal(dr["LastYearActual"]),
                    TargetTex = Convert.ToDecimal(dr["Target_TEX"]),
                    TagetWil = Convert.ToDecimal(dr["Taget_WIL"]),
                    ActualTex = Convert.ToDecimal(dr["Actual_TEX"]),
                    ActualWil = Convert.ToDecimal(dr["Actual_WIL"]),
                    TptParameterId = Convert.ToInt32(dr["TPTParameterID"]),
                    TptMonthlyId = Convert.ToInt32(dr["TPTMonthlyID"]),
                    TptMonth=Convert.ToInt16(dr["TPTMonth"])

                });

            }
            return tptMonth;
        }
        public List<TptWeekly> TptWeekly(string tptRevision, string tptParameter)
        {
            string sql = "Select LTW.TPTWeeklyID,isnull(LTW.TPTYear,'')TPTYear,isnull(LTW.TPTWeek,'')TPTWeek,isnull(LTW.RevisionID,'')RevisionID,isnull(LTW.TPTParameterID,'')TPTParameterID,isnull(LTW.Target,0)Target,isnull(LTW.Actual,0)Actual,isnull(LTW.LastYearActual,0)LastYearActual,isnull(LTW.Target_TEX,0)Target_TEX,isnull(LTW.Taget_WIL,0)Taget_WIL,isnull(LTW.Actual_TEX,0)Actual_TEX,isnull(LTW.Actual_WIL,0)Actual_WIL,isnull(LTR.RevisionName,'')RevisionName,isnull(LTP.ParameterCode,'')ParameterCode from Lab.TPT_WEEKLY LTW Left Outer Join Lab.TPT_REVISION LTR on LTW.RevisionID=LTR.RevisionID Left Outer Join Lab.TPT_PARAMETER LTP on LTW.TPTParameterID=LTP.TPTParameterID where 1=1";
            if (tptRevision != "" && tptRevision != "undefined" && tptRevision != "null" && tptRevision != null)
            {
                sql = sql + "and LTW. RevisionID='" + tptRevision + "'";
            }

            if (tptParameter != "" && tptParameter != "undefined" && tptParameter != "null" && tptParameter != null)
            {
                sql = sql + "and LTW. TPTParameterID ='" + tptParameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptWeekly> tptWeek = new List<TptWeekly>();
            foreach (DataRow dr in dt.Rows)
            {
                tptWeek.Add(new TptWeekly
                {

                    RevisionId = Convert.ToInt32(dr["RevisionID"]),
                    RevisionRevisionName = dr["RevisionName"].ToString(),
                    TptParameterParameterCode = dr["ParameterCode"].ToString(),
                    TptYear = Convert.ToInt16(dr["TPTYear"]),
                    Target = Convert.ToDecimal(dr["Target"]),
                    Actual = Convert.ToDecimal(dr["Actual"]),
                    LastYearActual = Convert.ToDecimal(dr["LastYearActual"]),
                    TargetTex = Convert.ToDecimal(dr["Target_TEX"]),
                    TagetWil = Convert.ToDecimal(dr["Taget_WIL"]),
                    ActualTex = Convert.ToDecimal(dr["Actual_TEX"]),
                    ActualWil = Convert.ToDecimal(dr["Actual_WIL"]),
                    TptParameterId = Convert.ToInt32(dr["TPTParameterID"]),
                    TptWeeklyId = Convert.ToInt32(dr["TPTWeeklyID"]),
                    TptWeek = Convert.ToInt16(dr["TPTWeek"])

                });

            }
            return tptWeek;
        }
        public List<TptPowerSeason> TptPowerSeason(string tptRevision, string tptpowerParameter)
        {
            string sql = "Select LTPS.TPTPowerSeasonID,isnull(LTPS.TPTYear,'')TPTYear,isnull(LTPS.RevisionID,0)RevisionID,isnull(LTPS.TPTPowerParameterID,'')TPTPowerParameterID,isnull(LTPS.Target,0)Target,isnull(LTPS.Actual,0)Actual,isnull(LTPS.LastYearActual,0)LastYearActual,isnull(LTR.RevisionName,0)RevisionName,isnull(LTP.TPTPowerCode,0)TPTPowerCode from Lab.TPT_POWER_SEASON LTPS Left outer join Lab.TPT_REVISION LTR on LTPS.RevisionID = LTR.RevisionID left outer Join Lab.TPT_POWER LTP on LTPS.TPTPowerParameterID =LTP.TPTPowerParameterID where 1=1";
            if (tptRevision != "" && tptRevision != "undefined" && tptRevision != "null" && tptRevision != null)
            {
                sql = sql + "and LTPS. RevisionID='" + tptRevision + "'";
            }

            if (tptpowerParameter != "" && tptpowerParameter != "undefined" && tptpowerParameter != "null" && tptpowerParameter != null)
            {
                sql = sql + "and LTPS. TPTPowerParameterID ='" + tptpowerParameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptPowerSeason> tptPowerSeason = new List<TptPowerSeason>();
            foreach (DataRow dr in dt.Rows)
            {
                tptPowerSeason.Add(new TptPowerSeason
                {

                    RevisionId = Convert.ToInt32(dr["RevisionID"]),
                    RevisionRevisionName = dr["RevisionName"].ToString(),
                    TptPowerParameterTptPowerCode = dr["TPTPowerCode"].ToString(),
                    TptYear = Convert.ToInt16(dr["TPTYear"]),
                    Target = Convert.ToDecimal(dr["Target"]),
                    Actual = Convert.ToDecimal(dr["Actual"]),
                    LastYearActual = Convert.ToDecimal(dr["LastYearActual"]),
                    TptPowerSeasonId= Convert.ToInt32(dr["TPTPowerSeasonID"]),
                    TptPowerParameterId= Convert.ToInt32(dr["TPTPowerParameterID"]),
                  

                });

            }
            return tptPowerSeason;
        }
        public List<TptPowerMonthly> TptPowerMonthly(string tptRevision, string tptpowerParameter)
        {
            string sql = "select LTPM.TPTPowerMonthlyID,isnull(LTPM.TPTYear,0)TPTYear,isnull(LTPM.TPTMonth,0)TPTMonth,isnull(LTPM.RevisionID,0)RevisionID,isnull(LTPM.TPTPowerParameterID,0)TPTPowerParameterID,isnull(LTPM.Target,0)Target,isnull(LTPM.Actual,0)Actual,isnull(LTPM.LastYearActual,0)LastYearActual,isnull(LTR.RevisionName,0)RevisionName,isnull(LTP.TPTPowerCode,0)TPTPowerCode from  Lab.TPT_POWER_MONTHLY LTPM Left outer join Lab.TPT_REVISION LTR on LTPM.RevisionID = LTR.RevisionID left outer Join Lab.TPT_POWER LTP on LTPM.TPTPowerParameterID =LTP.TPTPowerParameterID where 1=1";
            if (tptRevision != "" && tptRevision != "undefined" && tptRevision != "null" && tptRevision != null)
            {
                sql = sql + "and LTPM. RevisionID='" + tptRevision + "'";
            }

            if (tptpowerParameter != "" && tptpowerParameter != "undefined" && tptpowerParameter != "null" && tptpowerParameter != null)
            {
                sql = sql + "and LTPM. TPTPowerParameterID ='" + tptpowerParameter + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptPowerMonthly> tptPowerMonth = new List<TptPowerMonthly>();
            foreach (DataRow dr in dt.Rows)
            {
                tptPowerMonth.Add(new TptPowerMonthly
                {

                    RevisionId = Convert.ToInt32(dr["RevisionID"]),
                    RevisionRevisionName = dr["RevisionName"].ToString(),
                    TptPowerParameterTptPowerCode = dr["TPTPowerCode"].ToString(),
                    TptYear = Convert.ToInt16(dr["TPTYear"]),
                    Target = Convert.ToDecimal(dr["Target"]),
                    Actual = Convert.ToDecimal(dr["Actual"]),
                    LastYearActual = Convert.ToDecimal(dr["LastYearActual"]),
                    TptPowerMonthlyId = Convert.ToInt32(dr["TPTPowerMonthlyID"]),
                    TptPowerParameterId = Convert.ToInt32(dr["TPTPowerParameterID"]),
                    TptMonth=Convert.ToInt16(dr["TPTMonth"])

                });

            }
            return tptPowerMonth;
        }
        public DataTable InsertUnitParameter(int Id, int Unit, int Parameter)
        {
            string SqlQujery = "Exec InsertUnitParameterNew " + Id + "," + Unit + "," + Parameter + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptParameter(int Id, string Code, string Name, bool IsInputParameter, int DataType, int ParameterUnitId, string Formula, int ParameterId, bool HighPositive, decimal DeviationPercent, decimal DifferenceValue, int ConsolidationType, int ConsolidationParameterId, int CalculationLevel, int Precision, bool ShowOnFinalTpt, int ReportType, int DisplayOrder, int TpTptSerial, string DescriptiveFormula, int TexParameterId, int WilParameterId, bool ShowOnOutput, int OutputRowNumber, int OutputSerial)

        {
            string SqlQujery = "Exec InsertTPTParameterNew " + Id + ",'" + Code + "','" + Name + "'," + IsInputParameter + "," + DataType + "," + ParameterUnitId + ",'" + Formula + "'," + ParameterId + "," + HighPositive + "," + DeviationPercent + "," + DifferenceValue + "," + ConsolidationType + "," + ConsolidationParameterId + "," + CalculationLevel + "," + Precision + "," + ShowOnFinalTpt + "," + ReportType + "," + DisplayOrder + "," + TpTptSerial + ",'" + DescriptiveFormula + "'," + WilParameterId + "," + TexParameterId + "," + ShowOnOutput + "," + OutputRowNumber + "," + OutputSerial + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptPower(int Id, string Code, string Name, int Type, string Formula, int ParameterUnitId, string DescretiveFormula, int Parameter)
        {
            string SqlQujery = "Exec InsertTPTPowerNNew " + Id + "," + Code + ",'" + Name + "',"+ Type + ",'"+ Formula + "',"+ ParameterUnitId + ",'"+ DescretiveFormula + "',"+ Parameter + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptRevisison(int Id, int Code, string Name, int Unit, DateTime CreationDate, DateTime SeasonStartDate, DateTime SeasonEndDate, int CrushingSeason, int SeasonDays)
        {
            string SqlQujery = "Exec InsertTPTREVISIONNNew " + Id + "," + Unit + "," + Code + ",'"+ Name + "','"+ CreationDate .ToString("yyyy-MM-dd")+ "','"+ SeasonStartDate.ToString("yyyy-MM-dd") + "',"+ CrushingSeason + ","+ SeasonDays + ",'"+ SeasonEndDate.ToString("yyyy-MM-dd") + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptSeason(int Id, int TptYear, int RevisionId, int TptParameterId, decimal Target, decimal Actual, decimal LastYearActual, decimal TargetTex, decimal TagetWil, decimal ActualTex, decimal ActualWil)
        {
            string SqlQujery = "Exec InsertTPTSeasonNNew " + Id + "," + TptYear + "," + RevisionId + ","+ TptParameterId + ","+ Target + ","+ Actual + ","+ LastYearActual + ","+ TargetTex + ","+ TagetWil + ","+ ActualTex + ","+ ActualWil + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptMonthly(int Id, int TptYear, int TptMonth, int RevisionId, int TptParameterId, decimal Target, decimal Actual, decimal LastYearActual, decimal TargetTex, decimal TagetWil, decimal ActualTex, decimal ActualWil)
        {
            string SqlQujery = "Exec InsertTPTMonthlyNNew " + Id + "," + TptYear + ","+ TptMonth + "," + RevisionId + "," + TptParameterId + "," + Target + "," + Actual + "," + LastYearActual + "," + TargetTex + "," + TagetWil + "," + ActualTex + "," + ActualWil + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptWeekly(int Id, int TptYear, int TptWeek, int RevisionId, int TptParameterId, decimal Target, decimal Actual, decimal LastYearActual, decimal TargetTex, decimal TagetWil, decimal ActualTex, decimal ActualWil)
        {
            string SqlQujery = "Exec InsertTPTWEEKLYNNew " + Id + "," + TptYear + "," + TptWeek + "," + RevisionId + "," + TptParameterId + "," + Target + "," + Actual + "," + LastYearActual + "," + TargetTex + "," + TagetWil + "," + ActualTex + "," + ActualWil + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptPowerSeason(int Id, int TptYear, int RevisionId, int TptPowerParameterId, decimal Target, decimal Actual, decimal LastYearActual)
        {
            string SqlQujery = "Exec InsertTPTPOWERSEASONNNew " + Id + "," + TptYear + "," + RevisionId + ","+ TptPowerParameterId + ","+ Target + ","+ Actual + ","+ LastYearActual + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertTptPowerMonthly(int Id, int TptYear, int TptMonth, int RevisionId, int TptPowerParameterId, decimal Target, decimal Actual, decimal LastYearActual)
        {
            string SqlQujery = "Exec InsertTPTPOWERMonthlyNNew " + Id + "," + TptYear + ","+ TptMonth + "," + RevisionId + "," + TptPowerParameterId + "," + Target + "," + Actual + "," + LastYearActual + "";
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