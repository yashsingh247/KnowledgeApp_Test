using KnowledgeApp_Test.Models.Template;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{

    public class TemplateServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'TemplateServices.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'TemplateServices.sdr' is never used

        public List<ChartTemplate> GetChartTemplate()
        {
            cmd = new SqlCommand("select LCT.ChartTemplateID,LCT.ChartTemplateName,Isnull(LCT.ChartType,'')ChartType,LCT.TemplateFileName,Ct.ParameterTypeName as ChartTypeName from Lab.ChartTemplate LCT left outer join ChartType CT on LCT.ChartType=CT.ParameterTypeID", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ChartTemplate> ChartTemplate = new List<ChartTemplate>();
            foreach (DataRow dr in dt.Rows)
            {
                ChartTemplate.Add(new ChartTemplate
                {
                    ChartTemplateId = Convert.ToInt32(dr["ChartTemplateID"]),
                    ChartTemplateName = dr["ChartTemplateName"].ToString(),
                    ChartType = Convert.ToInt16(dr["ChartType"]),
                    ChartTypeName= dr["ChartTypeName"].ToString(),
                    TemplateFileName = dr["TemplateFileName"].ToString(),

                });

            }
            return ChartTemplate;
        }
        public List<ReportTemplate> GetReportTemplate(String Id)
        {
            string SqlQuery = "select ReportTemplateID,ReportTemplateName,isnull(PrintStoppageDetail,0)PrintStoppageDetail,iSNULL(SeasonRow,0)SeasonRow,iSNULL(SeasonColumn,0)SeasonColumn,Isnull(CropDayColumn,0)CropDayColumn,isnull(CropDayRow,0)CropDayRow,isnull(CropDayColumn,0)CropDayColumn,isnull(ReportType,0)ReportType,isnull(ColumnCount,0)ColumnCount,isnull(TemplateFileName,0)TemplateFileName from Lab.ReportTemplate where 1=1";
            if (Id != "" && Id != null && Id != "undefined" && Id != "null") 
            {
                SqlQuery = SqlQuery + "And ReportTemplateID=" + Id + "";
            }
            SqlQuery = SqlQuery + "order by ReportTemplateName";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ReportTemplate> ReportTemplate = new List<ReportTemplate>();
            foreach (DataRow dr in dt.Rows)
            {
               
                ReportTemplate.Add(new ReportTemplate
                {
                    ReportTemplateId = Convert.ToInt32(dr["ReportTemplateID"]),
                    ReportTemplateName = dr["ReportTemplateName"].ToString(),
                    PrintStoppageDetail = (bool)dr["PrintStoppageDetail"],
                    ReportType = Convert.ToInt16(dr["ReportType"]),
                    ColumnCount = Convert.ToInt16(dr["ColumnCount"]),
                    SeasonRow = Convert.ToInt16(dr["SeasonRow"]),
                    SeasonColumn = Convert.ToInt16(dr["SeasonColumn"]),
                    CropDayRow = Convert.ToInt16(dr["CropDayRow"]),
                    CropDayColumn=Convert.ToInt16(dr["CropDayColumn"]),
                    TemplateFileName = dr["TemplateFileName"].ToString(),
                    ParameterType= Convert.ToInt16(dr["ReportType"]),

                });

            }
            return ReportTemplate;
        }
        public List<ReportTemplateDetails> GetReportTemplateDetails(string ReportTemplateId,string Parameter)
        {
            string sqlquery= "select LRTD.ReportTemplateDetailID,isnull(LRTD.ReportTemplateID,'')ReportTemplateID,isnull(LRTD.RowNumber,'')RowNumber,isnull(LRTD.ColumnNumber,'')ColumnNumber,isnull(LRTD.ParameterID,'')ParameterID,isnull(LRTD.ParameterType,'')ParameterType,isnull(LRTD.FixedValue,0)FixedValue,isnull(LRTD.PrefixValue,0)PrefixValue,isnull(LRTD.PostfixValue,0)PostfixValue,LP.ParameterName,LRT.ReportTemplateName,RT.ReportTypeName from lab.ReportTemplateDetail LRTD left outer join Lab.ReportTemplate LRT on LRTD.ReportTemplateID = LRT.ReportTemplateID left outer Join Lab.Parameter LP on LRTD.ParameterID = LP.ParameterID Left outer join ReportType RT on LRTD.ParameterType = RT.ReportTypeID where 1=1";
            if (ReportTemplateId != "" && ReportTemplateId != null && ReportTemplateId != "undefined" && ReportTemplateId != "null")
            {
                sqlquery = sqlquery + " and LRTD.ReportTemplateID=" + ReportTemplateId + "";
            }
            if (Parameter != "" && Parameter != null && Parameter != "undefined" && Parameter != "null")
            {
                sqlquery = sqlquery + " and LRTD.ParameterID=" + Parameter + "";
            }
            cmd = new SqlCommand(sqlquery+"order by ReportTemplateName ", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ReportTemplateDetails> reportTemplateDetails = new List<ReportTemplateDetails>();
            foreach (DataRow dr in dt.Rows)
            {

                reportTemplateDetails.Add(new ReportTemplateDetails
                {
                    ReportTemplateDetailID = Convert.ToInt32(dr["ReportTemplateDetailID"]),
                    ReportTemplateName = dr["ReportTemplateName"].ToString(), 
                    RowNumber= Convert.ToInt16(dr["RowNumber"]),
                    ColumnNumber= Convert.ToInt16(dr["RowNumber"]),
                    ParameterName= dr["ParameterName"].ToString(),
                    ReportTypeName = dr["ReportTypeName"].ToString(),
                    //ParameterTypeName= dr["ReportTemplateName"].ToString(),
                    FixedValue = dr["FixedValue"].ToString(),
                    PrefixValue= dr["PrefixValue"].ToString(),
                    PostfixValue =dr["PostfixValue"].ToString(),
                    ReportTemplateID = Convert.ToInt32(dr["ReportTemplateID"]),
                    ParameterID = Convert.ToInt32(dr["ParameterID"]),
                });

            }
            return reportTemplateDetails;
        }

        public List<ChartTemplateDetails> GetChartTemplateDetails(string ChartTemplate,string Parameter)
        {

            string sqlQuery = "select LCTD.ChartTemplateDetailID,isnull(LCTD.ChartTemplateID,'')ChartTemplateID,LCTD.SerialNumber,isnull(LCTD.ParameterID,'')ParameterID,isnull(LCTD.ParameterType,'')ParameterType,LCT.ChartTemplateName,LP.ParameterName,LPT.ParameterTypeName from Lab.ChartTemplateDetail LCTD  Left Outer join Lab.ChartTemplate LCT on LCTD.ChartTemplateID=LCT.ChartTemplateID Left Outer join Lab.Parameter LP on LCTD.ParameterID= LP.ParameterID Left Outer join Lab.ParameterType LPT on LCTD.ParameterType= LP.ParameterTypeID where 1=1";
            if (ChartTemplate != "" && ChartTemplate != null && ChartTemplate != "undefined" && ChartTemplate != "null")
            {
                sqlQuery = sqlQuery + " and LCTD.ChartTemplateID=" + ChartTemplate + "";
            }
            if (Parameter != "" && Parameter != null && Parameter != "undefined" && Parameter != "null")
            {
                sqlQuery = sqlQuery + " and LCTD.ParameterID=" + Parameter + "";
            }


            cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ChartTemplateDetails> ChartTemplateDetails = new List<ChartTemplateDetails>();
            foreach (DataRow dr in dt.Rows)
            {

                ChartTemplateDetails.Add(new ChartTemplateDetails
                {
                    ChartTemplateDetailID = Convert.ToInt32(dr["ChartTemplateDetailID"]),
                    ChartTemplateID = Convert.ToInt32(dr["ChartTemplateID"]),
                    SerialNumber = Convert.ToInt16(dr["SerialNumber"]),
                    ParameterID = Convert.ToInt32(dr["ParameterID"]),
                    ChartTemplateName = dr["ChartTemplateName"].ToString(),
                    ParameterName= dr["ParameterName"].ToString(),
                    ParameterType=Convert.ToInt32(dr["ParameterType"]),
                    ParameterTypeName= dr["ParameterTypeName"].ToString(),

                }) ;

            }
            return ChartTemplateDetails;
        }
        public DataTable InsertChartTemplate(int Id,string TemplateName,int ChartType,string FileName)
        {

            string SqlQujery = "Exec InsertChartTemplateNew " + Id + ",'" + TemplateName + "'," + ChartType + ",'"+ FileName + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertChartTemplateDetails(int Id, int Template, int Serial, int Parameter,int PType)
        {

            string SqlQujery = "Exec InsertChartTemplateDetailsNew " + Id + "," + Template + "," + Serial + "," + Parameter + ","+ PType + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertReportTemplate(int Id, string TemplateName, bool PrintStoppage,int SeasonRow,int SeasonColumn,int CropDayRow,int CropDayColumn,int ReportType,int ColumnCount,string File,int code )
        {

            string SqlQujery = "Exec InsertReportTemplateNew " + Id + ",'" + TemplateName + "'," + PrintStoppage + "," + SeasonRow + ","+ SeasonColumn + ","+ CropDayRow + ","+ CropDayColumn + ","+ ReportType + ","+ ColumnCount + ",'"+ File + "',"+ code + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertReportTemplateDetails(int Id,int TempId,int RowNo,int Colno,int PId,int Ptype,String fixedValue,String Prefixvalue,String Postfixvalue)
        {

            string SqlQujery = "Exec InsertReportTemplateDetailNew " + Id + "," + TempId + ","+ Ptype + "," + RowNo + "," + Colno + "," + PId + ",'" + fixedValue + "','" + Prefixvalue + "','" + Postfixvalue + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable GetReportTemplateQuery(int unitId)
        {
            string SqlQujery = "select UnitName from common.unit where unitid='" + unitId + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable Query12(int unitId, string reportDate)
        {

            string SqlQujery = "select DayValue  from lab.daily where parameterid=2 and UnitID='" + unitId + "'and EntryDate='" + reportDate + "'";
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