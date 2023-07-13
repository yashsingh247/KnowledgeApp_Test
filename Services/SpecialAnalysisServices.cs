using KnowledgeApp_Test.Models.SpecialAnalysis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace KnowledgeApp_Test.Services
{
    public class SpecialAnalysisServices
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        public List<SpecialAnalysisType> SpecialAnalysisType()
        {

            string sql = "select SpecialAnalysisTypeID,SpecialAnalysisTypeCode,SpecialAnalysisTypeName,IsPeriodic,isnull(StartRowNumber,0)StartRowNumber,ExcelTemplateName,isnull(DateRow,0)DateRow,isnull(DateColumn,0)DateColumn from Lab.Special_Analysis_Type";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SpecialAnalysisType> SpecialAnalysisType = new List<SpecialAnalysisType>();
            foreach (DataRow dr in dt.Rows)
            {
                SpecialAnalysisType.Add(new SpecialAnalysisType
                {
                    SpecialAnalysisTypeId = Convert.ToInt32(dr["SpecialAnalysisTypeID"]),
                    SpecialAnalysisTypeCode = Convert.ToInt16(dr["SpecialAnalysisTypeCode"]),
                    SpecialAnalysisTypeName = dr["SpecialAnalysisTypeName"].ToString(),
                    IsPeriodic = (bool)(dr["IsPeriodic"]),
                    ExcelTemplateName = dr["ExcelTemplateName"].ToString(),
                    StartRowNumber = Convert.ToInt32(dr["StartRowNumber"]),
                    DateRow = Convert.ToInt32(dr["DateRow"]),
                    DateColumn = Convert.ToInt32(dr["DateColumn"])
                });

            }
            return SpecialAnalysisType;

        }

        public List<SpecialAnalysisParameter> SpecialAnalysisParameter(string SpecialAnalysisType)
        {

            string sql = "select LSAP.SpecialAnalysisParameterID,LSAP.SpecialAnalysisParameterCode,LSAP.SpecialAnalysisParameterName,LSAP.SpecialAnalysisTypeID,LSAP.IsInput,Isnull(LSAP.Formula,'')Formula,ISnull(LSAP.CalculationLevel,0)CalculationLevel,LSAP.DataType,Isnull(LSAP.ShortName,'')ShortName,ISnull(LSAP.DescriptiveFormula,'')DescriptiveFormula,isnull(LSAP.RowNumber,0)RowNumber,ISnull(LSAP.ColumnNumber,0)ColumnNumber,LSAT.SpecialAnalysisTypeName from [Lab].[Special_Analysis_Parameter] LSAP INNER jOIN Lab.Special_Analysis_Type LSAT ON LSAP.SpecialAnalysisTypeID=LSAT.SpecialAnalysisTypeID where 1=1";
            if (SpecialAnalysisType != "") 
            {
                sql = sql + " and LSAP.SpecialAnalysisTypeID='" + SpecialAnalysisType + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SpecialAnalysisParameter> SpecialAnalysisParameter = new List<SpecialAnalysisParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                SpecialAnalysisParameter.Add(new SpecialAnalysisParameter
                {
                    SpecialAnalysisTypeId = Convert.ToInt32(dr["SpecialAnalysisTypeID"]),
                    SpecialAnalysisParameterCode = dr["SpecialAnalysisParameterCode"].ToString(),
                    SpecialAnalysisParameterName = dr["SpecialAnalysisParameterName"].ToString(),
                    IsInput = (bool)(dr["IsInput"]),
                    Formula = dr["Formula"].ToString(),
                    DataType = Convert.ToInt16(dr["DataType"]),
                    ShortName = dr["ShortName"].ToString(),
                    DescriptiveFormula = dr["DescriptiveFormula"].ToString(),
                    RowNumber = Convert.ToInt32(dr["RowNumber"]),
                    ColumnNumber = Convert.ToInt32(dr["ColumnNumber"]),
                    CalculationLevel = Convert.ToInt32(dr["CalculationLevel"]),
                    SpecialAnalysisParameterId = Convert.ToInt32(dr["SpecialAnalysisParameterID"]),
                    SpecialAnalysisTypeSpecialAnalysisTypeName=dr["SpecialAnalysisParameterName"].ToString(),
                });

            }
            return SpecialAnalysisParameter;

        }
        public List<SpecialAnalysis> SpecialAnalysis(string SpecialAnalysisType)
        {

            string sql = "select LSA.SpecialAnalysisID,Convert(date,LSA.AnalysisDate)AnalysisDate,LSA.SpecialAnalysisTypeID,Isnull(LSA.EntryUserID,'')EntryUserID,Convert(Date ,ISnull(LSA.EntryDate,''))EntryDate,LSAT.SpecialAnalysisTypeName from Lab.Special_Analysis LSA inner join LAb.Special_Analysis_Type LSAT on LSA.SpecialAnalysisTypeID = LSAT.SpecialAnalysisTypeID where 1=1";
            if (SpecialAnalysisType != "" && SpecialAnalysisType !="undefined" && SpecialAnalysisType !=null && SpecialAnalysisType !="null" )
            {
                sql = sql + " and LSA.SpecialAnalysisTypeID='" + SpecialAnalysisType + "'";
            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SpecialAnalysis> SpecialAnalysis = new List<SpecialAnalysis>();
            foreach (DataRow dr in dt.Rows)
            {
                SpecialAnalysis.Add(new SpecialAnalysis
                {
                    SpecialAnalysisId = Convert.ToInt32(dr["SpecialAnalysisID"]),
                    AnalysisDate = DateTime.Parse(dr["AnalysisDate"].ToString()),
                    SpecialAnalysisTypeName = dr["SpecialAnalysisTypeName"].ToString(),
                    EntryUserId = Convert.ToInt32(dr["EntryUserID"]),
                    EntryDate = DateTime.Parse(dr["EntryDate"].ToString()),
                    SpecialAnalysisTypeId = Convert.ToInt16(dr["SpecialAnalysisTypeID"])
                });

            }
            return SpecialAnalysis;

        }
        public List<SpecialAnalysisDetails> SpecialAnalysisDetails(string SpecialAnalysis,string analysisParameter)
        {

            string sql = "select LSAD.SpecialAnalysisDetailID,LSAD.SpecialAnalysisID,isnull(LSAD.SerialNumber,'')SerialNumber,isnull(LSAD.SpecialAnalysisParameterID,'')SpecialAnalysisParameterID,isnull(LSAD.AnalysisValue,0)AnalysisValue,LSAP.SpecialAnalysisParameterName from Lab.Special_Analysis_Detail LSAD left outer join Lab.Special_Analysis_Parameter LSAP on LSAD.SpecialAnalysisParameterID = LSAP.SpecialAnalysisParameterID where 1=1";
            if (SpecialAnalysis != "" && SpecialAnalysis != null && SpecialAnalysis != "undefined" && SpecialAnalysis != "null")
            {
                sql = sql + " and LSAD.SpecialAnalysisID='" + SpecialAnalysis + "'";
            }
            if (analysisParameter != "" && analysisParameter != null && analysisParameter != "undefined" && analysisParameter != "null")
            {
                sql = sql + " and LSAD.SpecialAnalysisParameterID='" + analysisParameter + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<SpecialAnalysisDetails> specialAnalysisDetails = new List<SpecialAnalysisDetails>();
            foreach (DataRow dr in dt.Rows)
            {
                specialAnalysisDetails.Add(new SpecialAnalysisDetails
                {
                    SpecialAnalysisDetilsId = Convert.ToInt32(dr["SpecialAnalysisDetailID"]),
                    SpecialAnalysisId = Convert.ToInt32(dr["SpecialAnalysisID"]),
                    SerialNumber = Convert.ToInt16(dr["SerialNumber"]),
                    SpecialAnalysisParameterID = Convert.ToInt32(dr["SpecialAnalysisParameterID"]),
                    SpecialAnalysisParameterName = dr["SpecialAnalysisParameterName"].ToString(),
                    AnalysisValue = dr["AnalysisValue"].ToString()
                });

            }
            return specialAnalysisDetails;

        }



        public DataTable InsertSpecialAnalysisType(int Id, int Code, string Name, bool Isperiodic,int Startrow,string ExcelTemplateName,int DateRow,int DateColumn)
        {
            string SqlQujery = "Exec InsertSpecialAnalysisNew " + Id + ","+ Code + ",'" + Name + "'," + Isperiodic + ","+ Startrow + ",'" + ExcelTemplateName + "',"+ DateRow + ","+ DateColumn + "";
           // cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);

        }
        public DataTable InsertSpecialAnalysisTypeParameter(int Id, string Code, string Name, bool IsInput,int SATId, string Formula, int DataType, string ShortName,string DescriptiveFormula,int RowNumber,int ColumnNumber ,int CalculationLevel)
        {
            string SqlQujery = "Exec InsertSpecialAnalysisTypeParameterNew " + Id + ",'" + Code + "','" + Name + "'," + SATId + "," + IsInput + ",'" + Formula + "'," + DataType + ",'" + ShortName + "','"+ DescriptiveFormula + "',"+ RowNumber + ","+ ColumnNumber + ","+ CalculationLevel + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);

        }

        public DataTable InsertAddeditSpecialAnalysis(int id, DateTime analysisDate, int specialAnalysisTypeId, int entryUserId, DateTime entryDate)
        {
            //suresh_11102022
            string SqlQujery = "Exec Special_Analysis " + id + ",'" + analysisDate.ToString("yyyy-MM-dd HH:mm:ss.000") + "'," + specialAnalysisTypeId + "," + entryUserId + ",'" + entryDate.ToString("yyyy-MM-dd HH:mm:ss.000") + "'";
            //cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertAddeditSpecialAnalysisDetails(int specialAnalysisId, int specialAnalysisDetilsId, short serialNumber, int specialAnalysisParameterID, string analysisValue)
        {
            //suresh_11102022
            string SqlQujery = "Exec Special_Analysis_Detail " + specialAnalysisId + ","+ specialAnalysisDetilsId + "," + serialNumber + "," + specialAnalysisParameterID + ",'" + analysisValue + "'";
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