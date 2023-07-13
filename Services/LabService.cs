using KnowledgeApp_Test.Models.Lab;
using KnowledgeApp_Test.Models.Parameters;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace KnowledgeApp_Test.Services
{
    public class LabService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        public List<SampleSlip> SampleSlip(string Unit, string SampleSlipDate2)
        {
            if (SampleSlipDate2.Length > 0 && SampleSlipDate2.Length == 10)
            {
                string d = SampleSlipDate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                SampleSlipDate2 = s;
            }
            string sqlQuery = "SELECT[SampleSlipID],isnull(LSS.[UnitID],'')UnitID,[SampleSlipNUMBER],[SampleSlipDate],[GrowerID],[VarietyID],[SlipTyple],[BRIX],[POL],[JAVARatio],[LOSSES],LU.UnitName,LSS.VillageID FROM[DsclKMS2021].[Lab].[SampleSlip] LSS Left join Common.Unit LU on LSS.UnitID = LU.UnitID where 1 = 1";
            if (Unit != "" && Unit != "undefined" && Unit != null)
            {
                sqlQuery = sqlQuery + "and LSS.UnitID=" + Unit + "";
            }
            if (SampleSlipDate2 != "" && SampleSlipDate2 != "undefined" && SampleSlipDate2 != null)
            {
                sqlQuery = sqlQuery + " and LSS.SampleSlipDate='" + SampleSlipDate2 + "'";
            }
           

            cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SampleSlip> SampleSlip = new List<SampleSlip>();
            foreach (DataRow dr in dt.Rows)
            {
                SampleSlip.Add(new SampleSlip
                {
                    SampleSlipId = Convert.ToInt32(dr["SampleSlipID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    SampleSlipNumber = Convert.ToInt32(dr["SampleSlipNUMBER"]),
                    SampleSlipDate = DateTime.Parse(dr["SampleSlipDate"].ToString()),
                    GrowerId = Convert.ToInt32(dr["GrowerID"]),
                    VarietyId = Convert.ToInt32(dr["VarietyID"]),
                    SlipTyple = Convert.ToInt16(dr["SlipTyple"]),
                    Brix = Convert.ToInt32(dr["Brix"]),
                    Pol = Convert.ToInt32(dr["POL"]),
                    JavaRatio = Convert.ToInt16(dr["JAVARatio"]),
                    Losses = Convert.ToInt32(dr["LOSSES"]),
                    VillageId = Convert.ToInt32(dr["VillageID"])
                    //UnitId = Convert.ToInt32(dr["LOSSES"])

                });

            }
            return SampleSlip;
        }
        public List<Stock> Stock(string Unit, string Parameter, string CrushingSeason)
        {
            string sql = "select LS.StockID,isnull(LS.EntryDate,'')EntryDate,isnull(LS.UnitID,'')UnitID,isnull(LS.ParameterID,'')ParameterID,isnull(LS.CrushingSeasonID,'')CrushingSeasonID,isnull(LS.DayValue,0)DayValue,CU.UnitName,LP.ParameterName,CSC.CrushingSeasonName from Lab.Stock LS Left outer join Common.Unit CU on Ls.UnitID=CU.UnitID Left outer Join Lab.Parameter LP on LS.ParameterID = LP.ParameterID  Left outer join Common.CrushingSeason CSC on LS.CrushingSeasonID = CSC.CrushingSeasonID where 1=1";

            if (Unit != "undefined"&& Unit!="" && Unit!="null"&& Unit!=null)
            {
                sql = sql + " and  Ls.UnitID= '" + Unit + "'";
            }


            if (Parameter != "undefined" && Parameter != "" && Parameter != "null" && Parameter != null)
            {
                sql = sql + " and  Ls.ParameterID= '" + Parameter + "'";
            }

            if (CrushingSeason != "undefined" && CrushingSeason != "" && CrushingSeason != "null" && CrushingSeason != null)
            {
                sql = sql + " and Ls.CrushingSeasonID= '" + CrushingSeason + "'";
            }


            cmd = new SqlCommand(sql, con);
            //cmd = new SqlCommand("exec GetSampleSlip '" + Unit + "','" + SampleSlipDate2 + "','" + SampleSlipDate3 + "'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Stock> Stock = new List<Stock>();
            foreach (DataRow dr in dt.Rows)
            {
                Stock.Add(new Stock
                {
                    StockId = Convert.ToInt32(dr["StockID"]),
                    EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    UnitName = dr["UnitName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    DayValue = Convert.ToInt32(dr["DayValue"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                });

            }
            return Stock;
        }

        public List<Daily> Daily(string EntryDate, string EntryDate2, string Unit, string Parameter, string CrushingSeason)
        {
            if (EntryDate.Length > 0 && EntryDate.Length == 10)
            {
                string d = EntryDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                EntryDate = s;
            }
            if (EntryDate2.Length > 0 && EntryDate2.Length == 10)
            {
                string d1 = EntryDate2.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                EntryDate2 = s1;
            }
            string sql = "select LD.DailyID,LD.EntryDate,isnull(LD.UnitID,'')UnitID,isnull(LD.ParameterID,'')ParameterID,isnull(LD.CrushingSeasonID,'')CrushingSeasonID,ISnull(LD.DayValue,0) as DayValue,ISnull(LD.TodateValue,0)as TodateValue,ISnull(LD.PrevDayValue,0)as PrevDayValue,isnull(LD.PrevTodateValue,0) as PrevTodateValue,CU.UnitName,LP.ParameterName,CS.CrushingSeasonName from Lab.Daily LD Left outer join Common.Unit CU on LD.UnitID = Cu.UnitID Left outer join Lab.Parameter LP on LD.ParameterID = LP.ParameterID Left outer join Common.CrushingSeason CS on LD.CrushingSeasonID = CS.CrushingSeasonID where 1 =1";
            if (Unit != "" && Unit != null && Unit != "undefined" && Unit != "null")
            {
                sql = sql + " and  LD.UnitID= " + Unit + "";
            }
            if (Parameter != "" && Parameter != null && Parameter != "undefined" && Parameter != "null")
            {
                sql = sql + " and  LD.ParameterID= " + Parameter + "";
            }
            if (CrushingSeason != "" && CrushingSeason != null && CrushingSeason != "undefined" && CrushingSeason != "null")
            {
                sql = sql + " and LD.CrushingSeasonID= " + CrushingSeason + "";
            }
            if (EntryDate != "" && EntryDate2 == "" && EntryDate != null && EntryDate != "null" && EntryDate != "undefined" && EntryDate2 == null && EntryDate2 == "undefined" && EntryDate2 == "null")
            {
                sql = sql + "and LD.EntryDate='" + EntryDate + "'";
            }
            if (EntryDate != "" && EntryDate2 != "" && EntryDate != null  && EntryDate2 != null && EntryDate != "undefined" && EntryDate2 != "undefined" && EntryDate2 != "null" && EntryDate != "null")
            {
                
                sql = sql + "and convert(varchar, LD.EntryDate, 3) between '" + EntryDate + "'and '" + EntryDate2 + "'";
            }
            cmd = new SqlCommand(sql, con);
            //cmd = new SqlCommand("exec GetSampleSlip '" + Unit + "','" + SampleSlipDate2 + "','" + SampleSlipDate3 + "'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Daily> Daily = new List<Daily>();
            foreach (DataRow dr in dt.Rows)
            {
                Daily.Add(new Daily
                {
                    DailyId = Convert.ToInt32(dr["DailyID"]),
                    EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    UnitName = dr["UnitName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    DayValue = Convert.ToInt32(dr["DayValue"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    TodateValue = Convert.ToDecimal(dr["TodateValue"]),
                    PrevDayValue = Convert.ToDecimal(dr["PrevDayValue"]),
                    PrevTodateValue = Convert.ToDecimal(dr["PrevTodateValue"]),
                });

            }
            return Daily;
        }
        public List<FormulaEntry> Formula(int FormulaType, int ParameterId)
        {
            string sql = " exec GetParameterFormula " + FormulaType + "," + ParameterId + "";

            cmd = new SqlCommand(sql, con);
            //cmd = new SqlCommand("exec GetSampleSlip '" + Unit + "','" + SampleSlipDate2 + "','" + SampleSlipDate3 + "'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<FormulaEntry> FormulaEntry = new List<FormulaEntry>();
            foreach (DataRow dr in dt.Rows)
            {
                FormulaEntry.Add(new FormulaEntry
                {
                    Formula = dr["Formula"].ToString()
                });

            }
            return FormulaEntry;
        }

        public List<Hourly> Hour(string EntryDate, string EntryDate2, string Unit, string Parameter, string CrushingSeason)
        {
            if (EntryDate.Length > 0 && EntryDate.Length == 10)
            {
                string d = EntryDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                EntryDate = s;
            }
            if (EntryDate2.Length > 0 && EntryDate2.Length == 10)
            {
                string d1 = EntryDate2.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                EntryDate2 = s1;
            }

            string sql = "select LH.HourlyID,LH.EntryDate,LH.EntryHour,LH.UnitID,LH.ParameterID,LH.CrushingSeasonID,LH.HourValue,ISNULL(LH.DayValue,0)DayValue,ISNULL(LH.PrevHourValue,0)PrevHourValue,ISNULL(LH.PrevDayValue,0)PrevDayValue,CU.UnitName,LP.ParameterName,CS.CrushingSeasonName from Lab.HOURLY LH inner join Common.Unit CU on CU.UnitID = LH.UnitID Inner Join Lab.Parameter LP on LP.ParameterID = LH.ParameterID Inner Join Common.CrushingSeason CS on CS.CrushingSeasonID = LH.CrushingSeasonID where 1 =1";

            if (Unit != "" && Unit != null && Unit != "undefined")
            {
                sql = sql + " and  LH.UnitID= '" + Unit + "'";
            }
            if (Parameter != "" && Parameter != null && Parameter != "undefined")
            {
                sql = sql + " and  LH.ParameterID= '" + Parameter + "'";
            }

            if (CrushingSeason != "" && CrushingSeason != null && CrushingSeason != "undefined")
            {
                sql = sql + " and LH.CrushingSeasonID= '" + CrushingSeason + "'";
            }
            if (EntryDate != "" && EntryDate2 == "" && EntryDate != null && EntryDate != "undefined" )
            {
               
                sql = sql + "and LH.EntryDate='" + EntryDate + "'";
            }
            if (EntryDate != "" && EntryDate2 != "" && EntryDate != null && EntryDate2 != null && EntryDate != "undefined" && EntryDate2 != "undefined")
            {
                sql = sql + "and LH.EntryDate between '" + EntryDate + "'and '" + EntryDate2 + "'";
            }

            cmd = new SqlCommand(sql, con);
            //cmd = new SqlCommand("exec GetSampleSlip '" + Unit + "','" + SampleSlipDate2 + "','" + SampleSlipDate3 + "'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Hourly> Hourly = new List<Hourly>();
            foreach (DataRow dr in dt.Rows)
            {
                Hourly.Add(new Hourly
                {
                    HourlyId = Convert.ToInt32(dr["HourlyID"]),
                    EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    UnitName = dr["UnitName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    DayValue = Convert.ToInt32(dr["DayValue"]),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    HourValue = (decimal)dr["HourValue"],
                    PrevDayValue = (decimal)dr["PrevDayValue"],
                    PrevHourValue = (decimal)dr["PrevHourValue"],
                });

            }
            return Hourly;
        }
        public DataTable InsertSampleSlip(int Id, int UnitId, int SampleSlipNo, DateTime sampleslipdate, int GrowerID, int VarietyID, int SlipTyple, Decimal BRIX, Decimal POL, Decimal JAVARatio, Decimal LOSSES, int VillageID)
        {

            string SqlQujery = "Exec InsertSampleslipNew " + Id + "," + UnitId + "," + SampleSlipNo + ",'" + sampleslipdate.ToString("yyyy-MM-dd") + "'," + GrowerID + "," + VarietyID + "," + SlipTyple + "," + BRIX + "," + POL + "," + JAVARatio + "," + LOSSES + "," + VillageID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertDaily(int Id, DateTime EntryDate, int UnitID, int ParameterID, int CrushingSeasonID, decimal DayValue, decimal TodateValue, decimal PrevDayValue, decimal PrevTodateValue)
        {

            string SqlQujery = "Exec InsertDAILYNew " + Id + ",'" + EntryDate.ToString("yyyy-MM-dd") + "'," + UnitID + "," + ParameterID + "," + CrushingSeasonID + "," + DayValue + "," + TodateValue + "," + PrevDayValue + "," + PrevTodateValue + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertHourly(int Id, DateTime EntryDate, int EntryHour, int UnitID, int ParameterID, int CrushingSeasonID, decimal HourValue, decimal DayValue, decimal PrevHourValue, decimal PrevDayValue)
        {

            string SqlQujery = "Exec InsertHourlyNew " + Id + ",'" + EntryDate.ToString("yyyy-MM-dd") + "'," + EntryHour + "," + UnitID + "," + ParameterID + "," + CrushingSeasonID + "," + HourValue + "," + DayValue + "," + PrevHourValue + "," + PrevDayValue + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertFormula(int FormulaType, int ParameterID, string Formula)
        {
            string SqlQujery = "Exec InsertParameterFormulaNew " + FormulaType + "," + ParameterID + ",'" + Formula + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public string Entryname(int EntryTypeId)
        {
            string sql = "select EntryTypeName from EntryType where EntryTypeID=" + EntryTypeId + "";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            string Val = dt.Rows[0]["EntryTypeName"].ToString();
            return Val;
        }
        public List<Parameter> EntryParameterType(int EntryType,int Type)
        {
            string sql = "";
            if (Type == 1)
            {
                 sql = "exec GetAllInputParameter " + EntryType + "";
            }
            else {
                 sql = "exec  GetAllStoppageInputParameter  " + EntryType + "";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Parameter> parameter = new List<Parameter>();
            foreach (DataRow dr in dt.Rows)
            {
                parameter.Add(new Parameter
                {
                    ParameterTypeId = Convert.ToInt32(dr["ParameterTypeID"]),
                    ParameterTypeParameterTypeName = dr["ParameterTypeName"].ToString(),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterName = dr["ParameterName"].ToString(),
                    MinimumValue = Convert.ToDecimal(dr["MinimumValue"]),
                    MaximumValue = Convert.ToDecimal(dr["MaximumValue"]),
                    ParameterCode = Convert.ToInt16(dr["ParameterCode"]),
                    EntryTypeID = Convert.ToInt32(dr["EntryTypeID"]),
                    EntryName = dr["EntryTypeName"].ToString(),
                    EntryOrder = Convert.ToInt32(dr["EntryOrder"]),
                    ParameterTypeCode = Convert.ToInt16(dr["ParameterTypeCode"])

                });

            }
            return parameter;
        }

        public List<Hourly> GetEntryHour(DateTime EntryDate, int EntryHour, int UnitId)
        {
            string sql = "exec GetParameterHourlyValue '" + EntryDate.ToString("yyyy-MM-dd") + "'," + EntryHour + "," + UnitId + "";
            cmd = new SqlCommand(sql, con);
            //cmd = new SqlCommand("exec GetSampleSlip '" + Unit + "','" + SampleSlipDate2 + "','" + SampleSlipDate3 + "'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Hourly> Hourly = new List<Hourly>();
            foreach (DataRow dr in dt.Rows)
            {
                Hourly.Add(new Hourly
                {
                    HourValue = Convert.ToInt32(dr["HourValue"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),

                });

            }
            return Hourly;
        }
        public List<Daily> GetDailyParameter(DateTime EntryDate, int UnitId)
        {
            string sql = "exec GetParameterValue '" + EntryDate.ToString("yyyy-MM-dd") + "'," + UnitId + "";
            cmd = new SqlCommand(sql, con);
            //cmd = new SqlCommand("exec GetSampleSlip '" + Unit + "','" + SampleSlipDate2 + "','" + SampleSlipDate3 + "'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Daily> Daily = new List<Daily>();
            foreach (DataRow dr in dt.Rows)
            {
                Daily.Add(new Daily
                {
                    DayValue = Convert.ToInt32(dr["DayValue"]),
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),

                });

            }
            return Daily;

        }
        public DataTable InsertHourlyEntryParameter(DateTime EntryDate,int EntryHour,int Unit,int ParameterID,float HourValue)
        {
             string SqlQujery = "Exec InsertParameterHourlyValuesNew '"+ EntryDate.ToString("yyyy-MM-dd") + "',"+ EntryHour + ","+ Unit + ","+ ParameterID + ","+ HourValue + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertDailyEntryParameter(DateTime EntryDate, int Unit, int ParameterID, float DayValue)
        {
            string SqlQujery = "Exec InsertParameterValuesNew '" + EntryDate.ToString("yyyy-MM-dd") + "'," + Unit + "," + ParameterID + "," + DayValue + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertStck(int Id,DateTime EntryDate, int Unit, int ParameterID, int CrushingId, decimal DayValue)
        {
            string SqlQujery = "Exec InserStockNew "+ Id + ",'" + EntryDate.ToString("yyyy-MM-dd") + "'," + Unit + ","+ ParameterID + "," + CrushingId + "," + DayValue + "";
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

