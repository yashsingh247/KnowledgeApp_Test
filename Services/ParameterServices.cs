using KnowledgeApp_Test.Models.Parameters;
using KnowledgeApp_Test.Models.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using OfficeOpenXml;
using KnowledgeApp_Test.Models.Sugar_Molasses;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace KnowledgeApp_Test.Services
{
    public class ParameterServices
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        public List<EntryType> EntryType()
        {
            cmd = new SqlCommand("select * from EntryType", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<EntryType> EntryType = new List<EntryType>();
            foreach (DataRow dr in dt.Rows)
            {
                EntryType.Add(new EntryType
                {
                    EntryTypeId = Convert.ToInt32(dr["EntryTypeID"]),
                    EntryTypeName = dr["EntryTypeName"].ToString(),
                    EntryOrder = Convert.ToInt32(dr["EntryOrder"]),

                });

            }
            return EntryType;
        }
        public List<ParameterType> ParameterType(string EntryType)
        {
            string sqlquery = "select ParameterTypeID,ParameterTypeName,IsComputed,ParameterTypeCode,isnull(IsStoppageType,0)IsStoppageType,Isnull(IsStockType,0)IsStockType,ISnull(EntryTypeName,'')EntryTypeName,Isnull(Lab.ParameterType.EntryTypeID,0)EntryTypeID from Lab.ParameterType  Left outer join EntryType on EntryType.EntryTypeID=Lab.ParameterType.EntryTypeID where 1=1";
            if (EntryType != "" && EntryType != "undefined")
            {
                sqlquery = sqlquery + " and Lab.ParameterType.EntryTypeID=" + EntryType + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ParameterType> ParameterType = new List<ParameterType>();
            foreach (DataRow dr in dt.Rows)
            {
                ParameterType.Add(new ParameterType
                {
                    EntryTypeId = Convert.ToInt32(dr["EntryTypeID"]),
                    ParameterTypeName = dr["ParameterTypeName"].ToString(),
                    IsComputed = (bool)(dr["IsComputed"]),
                    ParameterTypeCode = Convert.ToInt16(dr["ParameterTypeCode"]),
                    IsStoppageType = (bool)(dr["IsStoppageType"]),
                    EntryTypeName = dr["EntryTypeName"].ToString(),
                    IsStockType = (bool)(dr["IsStockType"]),
                    ParameterTypeId = Convert.ToInt32(dr["ParameterTypeID"]),
                });
            }
            return ParameterType;
        }
        public List<ParameterUnit> ParameterUnit()
        {
            cmd = new SqlCommand("select  ParameterUnitID,ParameterUnitCode,ParameterUnitName,isnull(DataType,0)DataType from lab.PARAMETER_UNIT", con);

            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ParameterUnit> ParameterUnit = new List<ParameterUnit>();
            foreach (DataRow dr in dt.Rows)
            {
                ParameterUnit.Add(new ParameterUnit
                {
                    ParameterUnitId = Convert.ToInt32(dr["ParameterUnitID"]),
                    ParameterUnitCode = Convert.ToInt32(dr["ParameterUnitCode"]),
                    ParameterUnitName = dr["ParameterUnitName"].ToString(),
                    DataType = Convert.ToInt16(dr["DataType"]),
                });

            }
            return ParameterUnit;
        }
        public List<Parameter> Parameter(string ParameterType)
        {
            if (ParameterType == "" || ParameterType == "undefined")
            {
                cmd = new SqlCommand("select ParameterID,ISnull(ParameterCode,0)ParameterCode,ISnull(ParameterName,'')ParameterName,Isnull(LPT.ParameterTypeID,0)ParameterTypeID,ISnull(Discontinued,0)Discontinued,ISnull(IsUserDefined,0)IsUserDefined,ISnull(IsPreviousDay,0)IsPreviousDay,ISnull(IsStoppageParameter,0)IsStoppageParameter,ISnull(PrevousDayParameterID,0)PrevousDayParameterID,ISnull(MaximumValue,0)MaximumValue,ISnull(MinimumValue,0.00)MinimumValue,ISnull(DefaultValue,0)DefaultValue,Isnull(BeforeDecimalDigit,0)BeforeDecimalDigit,ISnull(AfterDecimalDigit,0)AfterDecimalDigit,ISnull(PrintBeforeDecimalDigit,0)PrintBeforeDecimalDigit,ISnull(PrintAfterDecimalDigit,0)PrintAfterDecimalDigit,ISnull(TodateType,0)TodateType,ISnull(AverageBasisParameterID,0)AverageBasisParameterID,ISnull(Formula,'')Formula,ISnull(TodateFormula,'')TodateFormula,ISnull(DescriptiveFormula,'')DescriptiveFormula,ISnull(DescriptiveTodateFormula,'')DescriptiveTodateFormula,ISnull(CalculationLevel,'')CalculationLevel,ISnull(IsStockParameter,0)IsStockParameter,ISnull(UOM,'')UOM,ISnull(IsBrixWeightParameter,0)IsBrixWeightParameter,ISnull(IsCalculatedOnBrixWeight,0)IsCalculatedOnBrixWeight,ISnull(IsHourlyEntry,0)IsHourlyEntry,ISnull(IsAdditional_Entry,0)IsAdditional_Entry,ISnull(AverageBasisParameter,0)AverageBasisParameter,ISnull(ParameterTypeName,'')ParameterTypeName from Lab.Parameter LP Left Join Lab.ParameterType LPT on  LP.ParameterTypeID=LPT.ParameterTypeID", con);
            }
            else
            {
                var ParameterType2 = Convert.ToInt32(ParameterType).ToString();
                cmd = new SqlCommand("select ParameterID,ISnull(ParameterCode,0)ParameterCode,ISnull(ParameterName,'')ParameterName,Isnull(LPT.ParameterTypeID,0)ParameterTypeID,ISnull(Discontinued,0)Discontinued,ISnull(IsUserDefined,0)IsUserDefined,ISnull(IsPreviousDay,0)IsPreviousDay,ISnull(IsStoppageParameter,0)IsStoppageParameter,ISnull(PrevousDayParameterID,0)PrevousDayParameterID,ISnull(MaximumValue,0)MaximumValue,ISnull(MinimumValue,0.00)MinimumValue,ISnull(DefaultValue,0)DefaultValue,Isnull(BeforeDecimalDigit,0)BeforeDecimalDigit,ISnull(AfterDecimalDigit,0)AfterDecimalDigit,ISnull(PrintBeforeDecimalDigit,0)PrintBeforeDecimalDigit,ISnull(PrintAfterDecimalDigit,0)PrintAfterDecimalDigit,ISnull(TodateType,0)TodateType,ISnull(AverageBasisParameterID,0)AverageBasisParameterID,ISnull(Formula,'')Formula,ISnull(TodateFormula,'')TodateFormula,ISnull(DescriptiveFormula,'')DescriptiveFormula,ISnull(DescriptiveTodateFormula,'')DescriptiveTodateFormula,ISnull(CalculationLevel,'')CalculationLevel,ISnull(IsStockParameter,0)IsStockParameter,ISnull(UOM,'')UOM,ISnull(IsBrixWeightParameter,0)IsBrixWeightParameter,ISnull(IsCalculatedOnBrixWeight,0)IsCalculatedOnBrixWeight,ISnull(IsHourlyEntry,0)IsHourlyEntry,ISnull(IsAdditional_Entry,0)IsAdditional_Entry,ISnull(AverageBasisParameter,0)AverageBasisParameter,ISnull(ParameterTypeName,'')ParameterTypeName from Lab.Parameter LP Left Join Lab.ParameterType LPT on  LP.ParameterTypeID=LPT.ParameterTypeID  where LPT.ParameterTypeID='" + ParameterType2 + "'", con);
            }
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Parameter> Parameter = new List<Parameter>();
            foreach (DataRow dr in dt.Rows)
            {
                Parameter.Add(new Parameter
                {
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterCode = Convert.ToInt16(dr["ParameterCode"]),
                    ParameterTypeId = Convert.ToInt32(dr["ParameterTypeID"]),
                    ParameterName = dr["ParameterName"].ToString(),


                    Discontinued = (bool)(dr["Discontinued"]),
                    IsUserDefined = (bool)(dr["IsUserDefined"]),
                    IsPreviousDay = (bool)(dr["IsPreviousDay"]),
                    IsStoppageParameter = (bool)(dr["IsStoppageParameter"]),

                    PrevousDayParameterId = Convert.ToInt32(dr["PrevousDayParameterID"]),
                    MaximumValue = (decimal)(dr["MaximumValue"]),
                    MinimumValue = (decimal)(dr["MinimumValue"]),
                    DefaultValue = (decimal)(dr["DefaultValue"]),

                    BeforeDecimalDigit = Convert.ToInt16(dr["BeforeDecimalDigit"]),
                    AfterDecimalDigit = Convert.ToInt16(dr["AfterDecimalDigit"]),
                    PrintBeforeDecimalDigit = Convert.ToInt16(dr["PrintBeforeDecimalDigit"]),
                    PrintAfterDecimalDigit = Convert.ToInt16(dr["PrintAfterDecimalDigit"]),
                    CalculationLevel = Convert.ToInt16(dr["CalculationLevel"].ToString()),
                    Formula = dr["Formula"].ToString(),
                    TodateType = Convert.ToInt16(dr["TodateType"]),
                    AverageBasisParameterId = Convert.ToInt32(dr["AverageBasisParameterID"]),
                    TodateFormula = dr["TodateFormula"].ToString(),
                    DescriptiveFormula = dr["DescriptiveFormula"].ToString(),

                    DescriptiveTodateFormula = dr["DescriptiveTodateFormula"].ToString(),
                    IsStockParameter = (bool)(dr["IsStockParameter"]),
                    Uom = dr["UOM"].ToString(),
                    IsBrixWeightParameter = (bool)dr["IsBrixWeightParameter"],

                    IsCalculatedOnBrixWeight = (bool)(dr["IsCalculatedOnBrixWeight"]),
                    IsHourlyEntry = (bool)(dr["IsHourlyEntry"]),
                    IsAdditionalEntry = (bool)(dr["IsAdditional_Entry"]),
                    AverageBasisParameter = Convert.ToInt16(dr["AverageBasisParameter"]),
                    ParameterTypeParameterTypeName = dr["ParameterTypeName"].ToString(),
                }); ;

            }
            return Parameter;
        }
        public DataTable InsertEntryType(int Id, string EntryTypeName, int EntryOrder)
        {

            string SqlQujery = "Exec InsertEntryTypeNew " + Id + ",'" + EntryTypeName + "'," + EntryOrder + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertParameterUnit(int Id, string PUName, int PUCode, int DataType)
        {

            string SqlQujery = "Exec InsertParameterUnitNew " + Id + "," + PUCode + ",'" + PUName + "'," + DataType + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertParameterType(int Id, string PTName, bool ISCmp, int PTCode, bool isStpgType, bool isStkType, int EntrtyId)
        {

            string SqlQujery = "Exec InsertParameterTypeNew " + Id + ",'" + PTName + "'," + ISCmp + "," + PTCode + "," + isStpgType + "," + isStkType + "," + EntrtyId + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertParameter(int Id, int ParameterCode, string ParameterName, int ParameterTypeID, bool Discontinued, bool IsUserDefined, bool IsPreviousDay, bool IsStoppageParameter, int PrevousDayParameterID, decimal MaximumValue, decimal MinimumValue, decimal DefaultValue, int BeforeDecimalDigit, int AfterDecimalDigit, int PrintBeforeDecimalDigit, int PrintAfterDecimalDigit, int TodateType, int AverageBasisParameterID, string Formula, string TodateFormula, string DescriptiveFormula, string DescriptiveTodateFormula, int CalculationLevel, bool IsStockParameter, string UOM, bool IsBrixWeightParameter, bool IsCalculatedOnBrixWeight, bool IsHourlyEntry, bool IsAdditional_Entry, int AverageBasisParameter)
        {

            string SqlQujery = "Exec InsertParameterNew " + Id + "," + ParameterCode + ",'" + ParameterName + "'," + ParameterTypeID + "," + Discontinued + "," + IsUserDefined + "," + IsPreviousDay + "," + IsStoppageParameter + "," + PrevousDayParameterID + "," + MaximumValue + "," + MinimumValue + "," + DefaultValue + "," + BeforeDecimalDigit + "," + AfterDecimalDigit + "," + PrintBeforeDecimalDigit + "," + PrintAfterDecimalDigit + "," + TodateType + "," + AverageBasisParameterID + ",'" + Formula + "','" + TodateFormula + "','" + DescriptiveFormula + "','" + DescriptiveTodateFormula + "'," + CalculationLevel + "," + IsStockParameter + ",'" + UOM + "'," + IsBrixWeightParameter + "," + IsCalculatedOnBrixWeight + "," + IsHourlyEntry + "," + IsAdditional_Entry + "," + AverageBasisParameter + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        List<Parameter> EntryParameterType()
        {
            string sql = "exec GetAllInputParameter 1";
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

        public List<ReportTemplateReport> ReportTemplateReport(string UnitId, string TempId, string ReportDate)
        {

      
            cmd = new SqlCommand("select isnull(t.ParameterID,'')ParameterID,isnull(ParameterType,'')ParameterType,isnull(RowNumber,'')RowNumber,isnull(ColumnNumber,'')ColumnNumber,isnull(PrefixValue,0)PrefixValue,isnull(FixedValue,0)FixedValue,isnull(PostfixValue,0)PostfixValue,isnull(DayValue,0)DayValue,isnull(TodateValue,0)TodateValue,isnull(d.EntryDate,'')EntryDate from lab.DAILY d join lab.ReportTemplateDetail t on d.ParameterID = t.ParameterID  where ReportTemplateID =" + TempId + "and EntryDate = '" + ReportDate + "' and unitid = " + UnitId + " order by ParameterID", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ReportTemplateReport> ReportTemplateReopt = new List<ReportTemplateReport>();
            foreach (DataRow dr in dt.Rows)
            {
                ReportTemplateReopt.Add(new ReportTemplateReport
                {
                    ParameterID = Convert.ToInt32(dr["ParameterID"]),
                    ParameterType = Convert.ToInt32(dr["ParameterType"]),
                    RowNumber = Convert.ToInt32(dr["RowNumber"]),
                    ColumnNumber = Convert.ToInt32(dr["ColumnNumber"]),
                    PrefixValue = Convert.ToDecimal(dr["PrefixValue"]),
                    FixedValue = Convert.ToDecimal(dr["FixedValue"]),
                    PostfixValue = Convert.ToDecimal(dr["PostfixValue"]),
                    TodateValue = Convert.ToDecimal(dr["TodateValue"]),
                    EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    DayValue = Convert.ToDecimal(dr["DayValue"]),
                });

            }
            return ReportTemplateReopt;
        }

        public List<DateWisesDailyParameter> DateWiseDailyParameter(string parametertype, string Parameter, string unit, string entrydate, string entrydate2)
        {

            if (entrydate.Length > 0 && entrydate.Length == 10)
            {
                string d = entrydate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                entrydate = s;
            }
            if (entrydate2.Length > 0 && entrydate2.Length == 10)
            {
                string d1 = entrydate2.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                entrydate2 = s1;
            }

            string PTypeval = "null", Pval = "null", unitVal = "null", entrydateVal = "null", entrydate2Val = "null", sqlquery;
            //string sqlquery = "exec DateWiseDailyParameterReport ";
            if (parametertype != "" && parametertype != "undefind" && parametertype != null && parametertype != "null")
            {
                PTypeval = parametertype;
            }
            if (Parameter != "" && Parameter != "undefind" && Parameter != null)
            {
                Pval = Parameter;
            }
            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != "null" && entrydate != null)
            {
                entrydateVal = entrydate;
            }
            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {
                entrydate2Val = entrydate2;
            }
            if (entrydate == "" || entrydate == "null" || entrydate == null)
            {
                entrydateVal = DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate2 != "null")
            {
                sqlquery = "exec DateWiseDailyParameterReport '" + entrydateVal + "','" + entrydate2Val + "'," + unitVal + "," + PTypeval + "," + Pval + "";
            }
            else
            {
                sqlquery = "exec DateWiseDailyParameterReport '" + entrydateVal + "'," + entrydate2Val + "," + unitVal + "," + PTypeval + "," + Pval + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DateWisesDailyParameter> DateWiseDailyParameter = new List<DateWisesDailyParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                DateWiseDailyParameter.Add(new DateWisesDailyParameter
                {
                    ParameterTypeName = dr["ParameterTypeName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    DayValue = Convert.ToDecimal(dr["DayValue"]),
                    TodateValue = Convert.ToDecimal(dr["TodateValue"])
                });
            }
            return DateWiseDailyParameter;

        }
        public List<DateWiseStockParameter> DateWisestockParameter(string parametertype, string Parameter, string unit, string entrydate, string entrydate2)
        {

            if (entrydate.Length > 0 && entrydate.Length == 10)
            {
                string d = entrydate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                entrydate = s;
            }
            if (entrydate2.Length > 0 && entrydate2.Length == 10)
            {
                string d1 = entrydate2.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                entrydate2 = s1;
            }

            string PTypeval = "null", Pval = "null", unitVal = "null", entrydateVal = "null", entrydate2Val = "null", sqlquery;
            if (parametertype != "" && parametertype != "undefind" && parametertype != null && parametertype != "null")
            {
                PTypeval = parametertype;
            }
            if (Parameter != "" && Parameter != "undefind" && Parameter != null && Parameter != "null")
            {
                Pval = Parameter;
            }
            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != null && entrydate != "null")
            {
                entrydateVal = entrydate;
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != "null")
            {
                entrydate2Val = entrydate2;
            }
            if (entrydate == "" || entrydate == "null" || entrydate == null)
            {
                entrydateVal = DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate2 != "null")
            {
                sqlquery = "exec DateWiseStockParameterReport '" + entrydateVal + "','" + entrydate2Val + "'," + unitVal + "," + PTypeval + "," + Pval + "";
            }
            else
            {
                sqlquery = "exec DateWiseStockParameterReport '" + entrydateVal + "'," + entrydate2Val + "," + unitVal + "," + PTypeval + "," + Pval + "";
            }
            //string sqlquery = "exec DateWiseDailyParameterReport '"+ entrydateVal + "','"+ entrydate2Val + "','"+ unitVal + "','"+ Pval + "','"+ PTypeval + "'";

            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DateWiseStockParameter> dateWiseStockParameter = new List<DateWiseStockParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                dateWiseStockParameter.Add(new DateWiseStockParameter
                {
                    ParameterTypeName = dr["ParameterTypeName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    DayValue = Convert.ToDecimal(dr["DayValue"]),

                });

            }
            return dateWiseStockParameter;

        }

        #region New Update 

        public List<Models.Report.SugarWeekTransaction> NewSDTRReport(string unit, string SugarGodownID, string entrydate, string entrydate2)
        {
            string SugarGodownVal = "null", unitVal = "null", entrydateVal = "null", entrydate2Val = "null", sqlquery;

            if (SugarGodownID != "" && SugarGodownID != "undefind" && SugarGodownID != null && SugarGodownID != "null")
            {
                SugarGodownVal = SugarGodownID;
            }
            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate == "" && entrydate == "undefind" && entrydate != "null" && entrydate != null)
            {
                entrydateVal = entrydate;
            }
            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {
                entrydate2Val = entrydate2;
            }
            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {
                sqlquery = "exec SugarTransactionReportNew '" + entrydateVal + "','" + entrydate2Val + "'," + unitVal + "," + SugarGodownVal + "";
            }
            else
            {
                sqlquery = "exec SugarTransactionReportNew " + entrydateVal + "," + entrydate2Val + "," + unitVal + "," + SugarGodownVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Models.Report.SugarWeekTransaction> NewSDTRReportTransaction = new List<Models.Report.SugarWeekTransaction>();
            foreach (DataRow dr in dt.Rows)
            {
                NewSDTRReportTransaction.Add(new Models.Report.SugarWeekTransaction
                {
                    UnitId = Convert.ToInt32(dr["UnitId"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    TransactionDate = dr["TransactionDate"].ToString(),
                    Production = dr["Production"].ToString(),
                    ShiftingIN = dr["ShiftingIN"].ToString(),
                    Sales = dr["Sales"].ToString(),
                    ShiftingOut = dr["ShiftingOut"].ToString(),
                    TornBagCount = dr["TornBagCount"].ToString(),
                    ICUMSAValue = dr["ICUMSAValue"].ToString(),
                    MoistureValue = dr["MoistureValue"].ToString(),
                    LineReplaceDate = dr["LineReplaceDate"].ToString(),
                    //TransactionWeek =Convert.ToInt32(dr["TransactionWeek"]),
                    //EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    //DayValue = Convert.ToDecimal(dr["DayValue"]),
                    //TodateValue = Convert.ToDecimal(dr["TodateValue"])
                });

            }
            return NewSDTRReportTransaction;

        }

        public List<CMPStatus> NewCMPStatusReport(string unit, string entrydate, string entrydate2)
        {
            string unitVal = "null", entrydateVal = "", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != "null" && entrydate != null)
            {
                string d = entrydate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydateVal = s;
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate != "null")
            {
                string d = entrydate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate != "null")
            {
                sqlquery = "exec CMPStatusReportNew'" + entrydateVal + "','" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec CMPStatusReportNew  '" + entrydateVal + "'," + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<CMPStatus> NewCMPStatuseportTransaction = new List<CMPStatus>();
            foreach (DataRow dr in dt.Rows)
            {
                NewCMPStatuseportTransaction.Add(new CMPStatus
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    RegistrationDate = dr["RegistrationDate"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    Preamble = dr["Preamble"].ToString(),
                    ApprovalStatus = dr["ApprovalStatus"].ToString(),
                    UnitHeadApprovalState = dr["UnitHeadApprovalState"].ToString(),
                    UnitHeadApprovalDate = dr["UnitHeadApprovalDate"].ToString(),
                    UnitHeadComment = dr["UnitHeadComment"].ToString(),
                    TechnicalCoordinatorApprovalState = dr["TechnicalCoordinatorApprovalState"].ToString(),
                    TechnicalCoordinatorComment = dr["TechnicalCoordinatorComment"].ToString(),
                    CTT_EngineerApprovalState = dr["CTT_EngineerApprovalState"].ToString(),
                    TechnicalCoordinatorApprovalDate = dr["TechnicalCoordinatorApprovalDate"].ToString(),
                    CTT_EngineerApprovalDate = dr["CTT_EngineerApprovalDate"].ToString(),
                    CTT_EngineerComment = dr["CTT_EngineerComment"].ToString(),
                    CTT_ProcessApprovalState = dr["CTT_ProcessApprovalState"].ToString(),
                    CTT_ProcessApprovalDate = dr["CTT_ProcessApprovalDate"].ToString(),
                    CTT_ProcessComment = dr["CTT_ProcessComment"].ToString(),
                    FinalAuthorityApprovalState = dr["FinalAuthorityApprovalState"].ToString(),
                    FinalAuthorityApprovalDate = dr["FinalAuthorityApprovalDate"].ToString(),
                    FinalAuthorityComment = dr["FinalAuthorityComment"].ToString(),
                    DrawingDocument = dr["DrawingDocument"].ToString(),
                    ROICalculationDocument = dr["ROICalculationDocument"].ToString(),
                    EstimationDocument = dr["EstimationDocument"].ToString(),

                });

            }
            return NewCMPStatuseportTransaction;

        }

        public List<PPfReports> NewPPfReport(string unit, string entrydate2)
        {
            string unitVal = "null", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null)
            {
                entrydate2Val = entrydate2;
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null)
            {
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
                sqlquery = "exec PlantPerformanceReportNew '" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec PlantPerformanceReportNew " + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PPfReports> NewPPFReportTransaction = new List<PPfReports>();
            foreach (DataRow dr in dt.Rows)
            {
                NewPPFReportTransaction.Add(new PPfReports
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),
                    LogHour = dr["LogHour"].ToString(),
                    CaneCrushed = dr["CaneCrushed"].ToString(),
                    SugarBagged = dr["SugarBagged"].ToString(),
                    FBDAirTemperature = dr["FBDAirTemperature"].ToString(),
                    ExhaustTemperature = dr["ExhaustTemperature"].ToString(),
                    ImbitionPercent = dr["ImbitionPercent"].ToString(),

                });
            }
            return NewPPFReportTransaction;

        }

        public List<MassecuiteStock> NewMassStoctReport(string unit, string AnalysisDate)
        {
            string unitVal = "null", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
                sqlquery = "exec MassecuiteStockReportNew '" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec MassecuiteStockReportNew " + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MassecuiteStock> NewMassStockReportTransaction = new List<MassecuiteStock>();
            foreach (DataRow dr in dt.Rows)
            {
                NewMassStockReportTransaction.Add(new MassecuiteStock
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),
                    MASSECUITE = dr["MASSECUITE"].ToString(),
                    SHIFT_RCV = dr["SHIFT_RCV"].ToString(),
                    DROPP = dr["DROPP"].ToString(),
                    CURED = dr["CURED"].ToString(),
                    BALANCE = dr["BALANCE"].ToString(),
                    //ImbitionPercent = dr["ImbitionPercent"].ToString(),

                });
            }
            return NewMassStockReportTransaction;

        }


        public List<ShiftLogbook> NewShiftLogbookReport(string unit, string AnalysisDate)
        {
            string unitVal = "null", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
                sqlquery = "exec ShiftLogbookReportNew '" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec ShiftLogbookReportNew " + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ShiftLogbook> ShiftLogbookReportTransaction = new List<ShiftLogbook>();
            foreach (DataRow dr in dt.Rows)
            {
                ShiftLogbookReportTransaction.Add(new ShiftLogbook
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    Observations = dr["Observations"].ToString(),
                    WorkDone = dr["WorkDone"].ToString(),
                    WorkToBeDone = dr["WorkToBeDone"].ToString(),
                    ShiftInchargeID = Convert.ToInt32(dr["ShiftInchargeID"]),
                    Remarks = dr["Remarks"].ToString(),

                });
            }
            return ShiftLogbookReportTransaction;

        }


        public List<ChemistLogbook> NewChemistLogoBookReport(string unit, string AnalysisDate)
        {
            string unitVal = "null", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
                sqlquery = "exec ChemistLogbookReportNew '" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec ChemistLogbookReportNew " + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ChemistLogbook> ChemistLogoBookReportTransaction = new List<ChemistLogbook>();
            foreach (DataRow dr in dt.Rows)
            {
                ChemistLogoBookReportTransaction.Add(new ChemistLogbook
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    Observations = dr["Observations"].ToString(),
                    WorkDone = dr["WorkDone"].ToString(),
                    WorkToBeDone = dr["WorkToBeDone"].ToString(),
                    ShiftInchargeID = Convert.ToInt32(dr["ShiftInchargeID"]),
                    Remarks = dr["Remarks"].ToString(),

                });//ImbitionPercent = dr["ImbitionPercent"].ToString(),
            }
            return ChemistLogoBookReportTransaction;

        }
        public List<ChemicalConsumption> NewChemicalConsumptionReport(string unit, string AnalysisDate)
        {
            string unitVal = "null", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                 string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
                sqlquery = "exec ChemicalConsumptionReportNew '" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec ChemicalConsumptionReportNew " + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ChemicalConsumption> ChemicalConsumptionTransaction = new List<ChemicalConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ChemicalConsumptionTransaction.Add(new ChemicalConsumption
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    ChemicalName = dr["ChemicalName"].ToString(),
                    BalanceOfPerShift = dr["BalanceOfPerShift"].ToString(),
                    IssuedQuantity = dr["IssuedQuantity"].ToString(),
                    Total = dr["Total"].ToString(),
                    ConsumedQuantity = dr["ConsumedQuantity"].ToString(),
                    bal = dr["bal"].ToString(),

                });
            }
            return ChemicalConsumptionTransaction;

        }

        public List<ClarificationHouse> NewClarificationHouseReport(string AnalysisDate)
        {
            string entrydate2Val = "null", sqlquery;
            
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                entrydate2Val = s;
                sqlquery = "exec ClarificationHouseReport'" + entrydate2Val + "'";
            }
            else
            {
                sqlquery = "exec ClarificationHouseReport " + entrydate2Val + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ClarificationHouse> ClarificationHouse = new List<ClarificationHouse>();
            foreach (DataRow dr in dt.Rows)
            {
                ClarificationHouse.Add(new ClarificationHouse
                {
                    TransactionDate = dr["TransactionDate"].ToString(),
                    ClarificationName = dr["ClarificationName"].ToString(),
                    Shift6To2 = dr["Shift6To2"].ToString(),
                    Shift2To10 = dr["Shift2To10"].ToString(),
                    Shift10To6 = dr["Shift10To6"].ToString(),
                });
            }
            return ClarificationHouse;

        }


        public List<MassecuiteConditioningData> NewMassecuiteConditioningDataReport(string AnalysisDate)
        {
            string entrydate2Val = "null", sqlquery;

            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate != "" && AnalysisDate != "undefind" && AnalysisDate != null)
            {
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                entrydate2Val = s;
                sqlquery = "exec MassecuiteConditioningDataReport'" + entrydate2Val + "'";
            }
            else
            {
                sqlquery = "exec MassecuiteConditioningDataReport " + entrydate2Val + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MassecuiteConditioningData> MassecuiteConditioningData = new List<MassecuiteConditioningData>();
            foreach (DataRow dr in dt.Rows)
            {
                MassecuiteConditioningData.Add(new MassecuiteConditioningData
                {
                    AnalysisDate = dr["AnalysisDate"].ToString(),
                    MassecuiteConditioningName = dr["MassecuiteConditioningName"].ToString(),
                    Shift6To2 = dr["Shift6To2"].ToString(),
                    Shift2To10 = dr["Shift2To10"].ToString(),
                    Shift10To6 = dr["Shift10To6"].ToString(),
                });
            }
            return MassecuiteConditioningData;

        }


        public List<TPTReports> TPTReports(string unit, string RevisionID, string CrushingSeasonid)
        {
            string RevisionNameval = "0", unitVal = "null", ParameterNameVal = "null", sqlquery;

            if (RevisionID != "" && RevisionID != "undefind" && RevisionID != null && RevisionID != "null")
            {
                RevisionNameval = RevisionID;
            }
            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }


            if (CrushingSeasonid == "" && CrushingSeasonid == "undefind" && CrushingSeasonid != null)
            {
                ParameterNameVal = CrushingSeasonid;
            }
            if (CrushingSeasonid == "" && CrushingSeasonid == "undefind" && CrushingSeasonid != null)
            {
                sqlquery = "exec TPTReports '" + ParameterNameVal + "'," + unitVal + ",'"+null+"'," + RevisionNameval + "";
            }
            else
            {
                sqlquery = "exec TPTReports " + ParameterNameVal + "," + unitVal + ",'"+null+"'," + RevisionNameval + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TPTReports> NewTPTReports = new List<TPTReports>();
            foreach (DataRow dr in dt.Rows)
            {
                NewTPTReports.Add(new TPTReports
                {
                    UnitId = Convert.ToInt32(dr["UnitId"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    RevisionID = Convert.ToInt32(dr["RevisionID"]),
                    CrushingSeasonid = Convert.ToInt32(dr["CrushingSeasonid"]),
                    ParameterCode = dr["ParameterCode"].ToString(),
                    RevisionName = dr["RevisionName"].ToString(),
                    ParameterName = dr["ParameterName"].ToString(),
                    Target = dr["Target"].ToString(),
                    Actual = dr["Actual"].ToString(),
                    DeviationOfSubstract = dr["DeviationOfSubstract"].ToString(),
                    DeviationOfPercents = dr["DeviationOfPercents"].ToString(),
                });

            }
            return NewTPTReports;

        }

        public List<YearlyBenchMark> NewYearlyBenchMark(string AnalysisDate)
        {
            string entrydate2Val = "null", sqlquery;

            if (AnalysisDate == "" && AnalysisDate == "undefind" && AnalysisDate != null)
            {
                entrydate2Val = AnalysisDate;
            }
            if (AnalysisDate == "" && AnalysisDate == "undefind" && AnalysisDate != null)
            {
                sqlquery = "exec YearlyBenchMarkList'" + entrydate2Val + "'";
            }
            else
            {
                sqlquery = "exec YearlyBenchMarkList " + entrydate2Val + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<YearlyBenchMark> YearlyBenchMark = new List<YearlyBenchMark>();
            foreach (DataRow dr in dt.Rows)
            {
                YearlyBenchMark.Add(new YearlyBenchMark
                {
                    SerialNumber = dr["SerialNumber"].ToString(),
                    BenchMarkCode = dr["BenchMarkCode"].ToString(),
                    BenchMarkName = dr["BenchMarkName"].ToString(),
                    ApplicableYear = dr["ApplicableYear"].ToString(),
                    ApplicableValue = dr["ApplicableValue"].ToString(),
                    RowNumber = dr["RowNumber"].ToString(),
                });
            }
            return YearlyBenchMark;

        }
        public List<MillLog> NewMillLogReport(string unit, string entrydate, string entrydate2)
        {
            string unitVal = "null", entrydateVal = "", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != null && entrydate != "null")
            {
                entrydateVal = entrydate;
                string d = entrydateVal.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydateVal = s;
            }

            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate2 != "null")
            {
                entrydate2Val = entrydate2;
                string d = entrydate2Val.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate != "null")
            {
               
                sqlquery = "exec MillLogReport '" + entrydateVal + "','" + entrydate2Val + "'";
            }
            else
            {
                sqlquery = "exec MillLogReport '" + entrydateVal + "'," + entrydate2Val + ","+ unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MillLog> NewMillLog = new List<MillLog>();
            foreach (DataRow dr in dt.Rows)
            {
                NewMillLog.Add(new MillLog
                {
                    MillParameterCode = dr["MillParameterCode"].ToString(),
                    MillParameterName = dr["MillParameterName"].ToString(),
                    MillName = dr["MillName"].ToString(),
                    LogDate = dr["LogDate"].ToString(),
                    PositionShortName = dr["PositionShortName"].ToString(),
                    LocationShortName = dr["LocationShortName"].ToString(),
                    LogHour = dr["LogHour"].ToString(),
                    LogValue = dr["LogValue"].ToString(),
                });

            }
            return NewMillLog;

        }
        public List<StopPage> StoppageFrequency(string unit, string entrydate, string entrydate2)
        {
            string unitVal = "null", entrydateVal = "null", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != null && entrydate != "null")
            {

                entrydateVal = entrydate;
            }

            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {
                entrydate2Val = entrydate2;
            }
            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {
                sqlquery = "exec TPTReports '" + entrydateVal + "'," + unitVal + "," + entrydate2Val + "";
            }
            else
            {
                sqlquery = "exec TPTReports " + entrydateVal + "," + unitVal + "," + entrydate2Val + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<StopPage> NewStopPage = new List<StopPage>();
            foreach (DataRow dr in dt.Rows)
            {
                NewStopPage.Add(new StopPage
                {
                    UnitID = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    StationCode = dr["StationCode"].ToString(),
                    StationName = dr["StationName"].ToString(),
                    TotalTime = dr["TotalTime"].ToString(),
                    Frequency = dr["Frequency"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),

                });

            }
            return NewStopPage;

        }

        public List<IAADStatus> IAADStatusReport(string unit, string entrydate, string entrydate2)
        {
            string unitVal = "null", entrydateVal = "", entrydate2Val = "null", sqlquery;

            if (unit != "" && unit != "undefind" && unit != null && unit != "null")
            {
                unitVal = unit;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != null && entrydate != "null")
            {
                string d = entrydate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydateVal = s;
                
            }

            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate != "null")
            {
                string d = entrydate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
               
            }
            if (entrydate2 != "" && entrydate2 != "undefind" && entrydate2 != null && entrydate != "null")
            {
                sqlquery = "exec IAADStatusReportNew '" + entrydateVal + "','" + entrydate2Val + "'," + unitVal + "";
            }
            else
            {
                sqlquery = "exec IAADStatusReportNew '" + entrydateVal + "'," + entrydate2Val + "," + unitVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<IAADStatus> NewIAADSPage = new List<IAADStatus>();
            foreach (DataRow dr in dt.Rows)
            {
                NewIAADSPage.Add(new IAADStatus
                {
                   
                    UnitUnitName = dr["UnitUnitName"].ToString(),
                    RegistrationDate = dr["RegistrationDate"].ToString(),
                    RegistrationNumber = dr["RegistrationNumber"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    ApprovalStatus = dr["ApprovalStatus"].ToString(),
                    UnitHeadApprovalDate = dr["UnitHeadApprovalDate"].ToString(),
                    UnitHeadComment = dr["UnitHeadComment"].ToString(),
                    TechnicalCoordinatorApprovalDate = dr["TechnicalCoordinatorApprovalDate"].ToString(),
                    TechnicalCoordinatorComment = dr["TechnicalCoordinatorComment"].ToString(),
                    CTT_EngineerComment = dr["CTT_EngineerComment"].ToString(),
                    CTT_EngineerApprovalDate = dr["CTT_EngineerApprovalDate"].ToString(),
                    CTT_ProcessComment = dr["CTT_ProcessComment"].ToString(),
                    FinalAuthorityApprovalDate = dr["FinalAuthorityApprovalDate"].ToString(),
                    FinalAuthorityComment = dr["FinalAuthorityComment"].ToString(),

                });

            }
            return NewIAADSPage;

        }

        public List<Auditlog> AuditlogStatusReport(string TableName, string entrydate, string entrydate2)
        {
            string TableNameVal = "null", entrydateVal = "", entrydate2Val = "null", sqlquery;

            if (TableName != "" && TableName != "undefind" && TableName != null && TableName != "null")
            {
                TableNameVal = TableName;
            }
            if (entrydate != "" && entrydate != "undefind" && entrydate != null && entrydate != "null")
            {
                string d = entrydate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydateVal = s;
            }

            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {

                string d = entrydate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                entrydate2Val = s;
            }
            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null && entrydate != "null")
            {
                sqlquery = "exec AuditLogReport '" + entrydateVal + "','" + entrydate2Val + "'," + TableNameVal + "";
            }
            else
            {
                sqlquery = "exec AuditLogReport '" + entrydateVal + "'," + entrydate2Val + "," + TableNameVal + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Auditlog> NewAuditlogStatus = new List<Auditlog>();
            foreach (DataRow dr in dt.Rows)
            {
                NewAuditlogStatus.Add(new Auditlog
                {
                    AuditLogID = Convert.ToInt32(dr["AuditLogID"]),
                    TableNames = dr["TableNames"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    Action = dr["Action"].ToString(),
                    ChangedOn = dr["ChangedOn"].ToString(),
                    RowId = dr["RowId"].ToString(),
                    Module = dr["Module"].ToString(),
                    Page = dr["Page"].ToString(),
                    Changes = dr["Changes"].ToString(),

                });

            }
            return NewAuditlogStatus;

        }

        public List<Models.Report.MolassesDayTransaction> MolassesDayTransaction(string entrydate, string entrydate2)
        {
            string entrydateVal = "null", entrydate2Val = "null", sqlquery;


            if (entrydate != "" && entrydate != "undefind" && entrydate != null && entrydate != "null")
            {
                entrydateVal = entrydate;
            }

            if (entrydate2 == "" && entrydate2 == "undefind" && entrydate2 != null)
            {
                entrydate2Val = entrydate2;
            }
            if (entrydate2 == "" && entrydate != "")
            {
                sqlquery = "exec MolassesDayTransactionReportNew '" + entrydateVal + "'," + entrydate2Val + "";
            }
            else
            {
                sqlquery = "exec MolassesDayTransactionReportNew " + entrydateVal + "," + entrydate2Val + "";
            }
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Models.Report.MolassesDayTransaction> MolassesDayTransactionNew = new List<Models.Report.MolassesDayTransaction>();
            foreach (DataRow dr in dt.Rows)
            {
                MolassesDayTransactionNew.Add(new Models.Report.MolassesDayTransaction
                {
                    TankNumber = dr["TankNumber"].ToString(),
                    //TransactionDate = Convert.ToDateTime(dr[TransactionDate]),
                    TransactionDate = dr["TransactionDate"].ToString(),
                    Production = dr["Production"].ToString(),
                    ShiftingIN = dr["ShiftingIN"].ToString(),
                    TotalIn = dr["TotalIn"].ToString(),
                    Sales = dr["Sales"].ToString(),
                    ShiftingOut = dr["ShiftingOut"].ToString(),
                    TotalOut = dr["TotalOut"].ToString(),

                });

            }
            return MolassesDayTransactionNew;

        }



        #endregion


    }
}

