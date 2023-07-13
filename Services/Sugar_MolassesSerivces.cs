using KnowledgeApp_Test.Models.Sugar_Molasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class Sugar_MolassesSerivces
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
     
        public List<MolassesTank>MolassesTank(string Crushingseason)
        {
            string Query = "select LMT.MolassesTankID,LMT.TankNumber,isnull(LMT.CrushingSeasonID,'')CrushingSeasonID,LMT.Grade,LMT.Opening,LMT.Discontinued,isnull(CS.CrushingSeasonName,'')CrushingSeasonName from Lab.MolassesTank LMT Left outer Join Common.CrushingSeason CS on LMT.CrushingSeasonID=CS.CrushingSeasonID where 1=1";
           if (Crushingseason != "" && Crushingseason != "undefined" && Crushingseason != null && Crushingseason != "null")
            {
                Query = Query + " and LMT.CrushingSeasonID=" + Crushingseason + "";
            
            } 
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MolassesTank> molassesTank = new List<MolassesTank>();
            foreach (DataRow dr in dt.Rows)
            {
                molassesTank.Add(new MolassesTank
                {
                    MolassesTankId=Convert.ToInt32(dr["MolassesTankID"]),
                    TankNumber=dr["TankNumber"].ToString(),
                    CrushingSeasonId= Convert.ToInt32(dr["CrushingSeasonID"]),
                    Grade= dr["Grade"].ToString(),
                    Opening= Convert.ToDecimal(dr["MolassesTankID"]),
                    Discontinued=(bool)(dr["Discontinued"]),
                    CrushingSeasonCrushingSeasonName=dr["CrushingSeasonName"].ToString(),
                });

            }
            return molassesTank;
        }
        public List<MolassesDayTransaction> MolassesDayTransaction(string Unit,string tank,string TransactionDate,string TransactionDate2)
        {
            string Query = "select  MolassesDayTransactionID,isnull(LMDT.MolassesTankID,'') MolassesTankID,isnull(LMDT.TransactionDate,'')TransactionDate,isnull(LMDT.Production,0)Production,isnull(LMDT.ShiftingIN,0)ShiftingIN,isnull(LMDT.Sales,0)Sales,isnull(LMDT.ShiftingOut,0) ShiftingOut,isnull(LMDT.InTemperature1,0)InTemperature1,isnull(LMDT.InTemperature2,0)InTemperature2,isnull(LMDT.InTemperature3,0)InTemperature3,isnull(LMDT.InTemperature4,0)InTemperature4,isnull(LMDT.InTemperature5,0)InTemperature5,isnull(LMDT.OutTemperature1,0)OutTemperature1,isnull(LMDT.OutTemperature2,0)OutTemperature2,isnull(LMDT.OutTemperature3,0)OutTemperature3,isnull(LMDT.OutTemperature4,0)OutTemperature4,isnull(LMDT.OutTemperature5,0) OutTemperature5,isnull(LMDT.WaterIn1,0)WaterIn1,isnull(LMDT.WaterIn2,0)WaterIn2,isnull(LMDT.WaterIn3,0)WaterIn3,isnull(LMDT.WaterIn4,0)WaterIn4,isnull(LMDT.WaterIn5,0)WaterIn5,isnull(LMDT.WaterOut1,0)WaterOut1,isnull(LMDT.WaterOut2,0)WaterOut2,isnull(LMDT.WaterOut3,0)WaterOut3,isnull(LMDT.WaterOut4,0)WaterOut4,isnull(LMDT.WaterOut5,0)WaterOut5,isnull(LMDT.MolassesTemperature1,0)MolassesTemperature1,isnull(LMDT.MolassesTemperature2,0)MolassesTemperature2,isnull(LMDT.MolassesTemperature3,0)MolassesTemperature3,isnull(LMDT.MolassesTemperature4,0)MolassesTemperature4,isnull(LMDT.MolassesTemperature5,0)MolassesTemperature5,isnull(LMDT.Brix,0)Brix,isnull(LMDT.TRS,0)TRS,isnull(LMDT.ProductionTemperature1,0)ProductionTemperature1,isnull(LMDT.ProductionTemperature2,0)ProductionTemperature2,isnull(LMDT.ProductionTemperature3,0)ProductionTemperature3,isnull(LMDT.ProductionTemperature4,0)ProductionTemperature4,isnull(LMDT.ProductionTemperature5,0)ProductionTemperature5,isnull(LMDT.RecirculationHours,'')RecirculationHours,isnull(LMDT.WaterSpayHours,'')WaterSpayHours,isnull(LMDT.UnitID,'')UnitID,ISNULL(CU.UnitName,'')UnitName,ISNULL(LMT.TankNumber,'')TankNumber from Lab.MOLASSES_DAY_TRANSACTION LMDT Left Outer Join Common.UNit CU on LMDT.UnitID=CU.UnitID Left Outer Join Lab.MolassesTank LMT on LMDT.MolassesTankID=LMT.MolassesTankID where 1=1";
           if (Unit != "" && Unit != "undefined" && Unit != null && Unit != "null")
            {
                Query = Query + " and LMDT.UnitID=" + Unit + "";

            }
            if (tank != "" && tank != "undefined" && tank != null && tank != "null")
            {
                Query = Query + " and LMDT.MolassesTankID=" + tank + "";

            }
            if (TransactionDate != "" && TransactionDate != "undefined" && TransactionDate != null && TransactionDate != "null" && TransactionDate2 == "" && TransactionDate2 == "undefined" && TransactionDate2 == null && TransactionDate2 == "null")
            {
                Query = Query + " and LMDT.TransactionDate='" + TransactionDate + "'";

            }
            if (TransactionDate != "" && TransactionDate != "undefined" && TransactionDate != null && TransactionDate != "null" && TransactionDate2 != "" && TransactionDate2 != "undefined" && TransactionDate2 != null && TransactionDate2 != "null")
            {
                Query = Query + " and LMDT.TransactionDate Between'" + TransactionDate + "' and '"+ TransactionDate2 + "' ";

            }


            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MolassesDayTransaction> molassesDayTransaction = new List<MolassesDayTransaction>();
            foreach (DataRow dr in dt.Rows)
            {
                molassesDayTransaction.Add(new MolassesDayTransaction
                {
                    MolassesDayTransactionId= Convert.ToInt32(dr["MolassesDayTransactionID"]),
                    UnitId= Convert.ToInt32(dr["MolassesDayTransactionID"]),
                    UnitUnitName= dr["UnitName"].ToString(),
                    MolassesTankId= Convert.ToInt32(dr["MolassesTankID"]),
                    MolassesTankTankNumber=dr["TankNumber"].ToString(),
                    TransactionDate=DateTime.Parse(dr["TransactionDate"].ToString()),
                    Production=Convert.ToInt32(dr["Production"]),
                    ShiftingIn=Convert.ToInt32(dr["ShiftingIN"]),
                    Sales=Convert.ToInt32(dr["Sales"]),
                    ShiftingOut=Convert.ToInt32(dr["MolassesDayTransactionID"]),
                    InTemperature1=Convert.ToDecimal(dr["InTemperature1"]),
                    InTemperature2=Convert.ToDecimal(dr["InTemperature2"]),
                    InTemperature3=Convert.ToDecimal(dr["InTemperature3"]),
                    InTemperature4=Convert.ToDecimal(dr["InTemperature4"]),
                    InTemperature5=Convert.ToDecimal(dr["InTemperature5"]),
                    OutTemperature1=Convert.ToDecimal(dr["OutTemperature1"]),
                    OutTemperature2=Convert.ToDecimal(dr["OutTemperature2"]),
                    OutTemperature3=Convert.ToDecimal(dr["OutTemperature3"]),
                    OutTemperature4=Convert.ToDecimal(dr["OutTemperature4"]),
                    OutTemperature5=Convert.ToDecimal(dr["OutTemperature5"]),
                    WaterIn1=Convert.ToDecimal(dr["WaterIn1"]),
                    WaterIn2=Convert.ToDecimal(dr["WaterIn2"]),
                    WaterIn3=Convert.ToDecimal(dr["WaterIn3"]),
                    WaterIn4=Convert.ToDecimal(dr["WaterIn4"]),
                    WaterIn5=Convert.ToDecimal(dr["WaterIn5"]),
                    WaterOut1=Convert.ToDecimal(dr["WaterOut1"]),
                    WaterOut2=Convert.ToDecimal(dr["WaterOut2"]),
                    WaterOut3=Convert.ToDecimal(dr["WaterOut3"]),
                    WaterOut4=Convert.ToDecimal(dr["WaterOut4"]),
                    WaterOut5=Convert.ToDecimal(dr["WaterOut5"]),
                    MolassesTemperature1=Convert.ToDecimal(dr["MolassesTemperature1"]),
                    MolassesTemperature2=Convert.ToDecimal(dr["MolassesTemperature2"]),
                    MolassesTemperature3=Convert.ToDecimal(dr["MolassesTemperature3"]),
                    MolassesTemperature4=Convert.ToDecimal(dr["MolassesTemperature4"]),
                    MolassesTemperature5=Convert.ToDecimal(dr["MolassesTemperature5"]),
                    Brix=Convert.ToDecimal(dr["Brix"]),
                    Trs=Convert.ToDecimal(dr["TRS"]),
                    ProductionTemperature1=Convert.ToDecimal(dr["ProductionTemperature1"]),
                    ProductionTemperature2=Convert.ToDecimal(dr["ProductionTemperature2"]),
                    ProductionTemperature3=Convert.ToDecimal(dr["ProductionTemperature3"]),
                    ProductionTemperature4=Convert.ToDecimal(dr["ProductionTemperature4"]),
                    ProductionTemperature5=Convert.ToDecimal(dr["ProductionTemperature5"]),
                    RecirculationHours=Convert.ToInt16(dr["RecirculationHours"]),
                    WaterSpayHours=Convert.ToInt16(dr["WaterSpayHours"]),
                });  

            }
            return molassesDayTransaction;
        }
        public List<SugarGodown> SugarGodown(string Crushingseason)
        {
            string Query = "select IsNull(LSG.SugarGodownID,'')SugarGodownID,IsNull(LSG.GodownNumber,'')GodownNumber,IsNull(LSG.LotNumber,'')LotNumber,IsNull(LSG.CrushingSeasonID,'')CrushingSeasonID,IsNull(LSG.Grade,'')Grade,IsNull(LSG.PackSize,'')PackSize,IsNull(LSG.PackType,'')PackType,IsNull(LSG.Opening,0)Opening,IsNull(LSG.Discontinued,'')Discontinued,ISnull(CS.CrushingSeasonName,'')CrushingSeasonName from Lab.Sugar_Godown LSG left Outer Join Common.CrushingSeason CS on LSG.CrushingSeasonID=CS.CrushingSeasonID   where 1=1";
           if (Crushingseason != "" && Crushingseason != "undefined" && Crushingseason != null && Crushingseason != "null")
            {
                Query = Query + " and LSG.CrushingSeasonID=" + Crushingseason + "";

            }
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SugarGodown> sugarGodowns = new List<SugarGodown>();
            foreach (DataRow dr in dt.Rows)
            {
                sugarGodowns.Add(new SugarGodown
                {
                    SugarGodownId = Convert.ToInt32(dr["SugarGodownID"]),
                    GodownNumber = dr["GodownNumber"].ToString(),
                    LotNumber=dr["LotNumber"].ToString(),
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    Grade = dr["Grade"].ToString(),
                    PackSize = Convert.ToInt16(dr["PackSize"]),
                    PackType = Convert.ToInt16(dr["PackType"]),
                    Opening = Convert.ToDecimal(dr["Opening"]),
                    Discontinued = (bool)(dr["Discontinued"]),
                    CrushingSeasonCrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                });

            }
            return sugarGodowns;
        }
        public List<SugarDayTransaction> SugarDayTransaction(string Unit, string SugarGodown, string TransactionDate, string TransactionDate2)
        {
            string Query = "select  IsNull(LSDT.SugarDayTransactionID,'')SugarDayTransactionID,IsNull(LSDT.SugarGodownID,'')SugarGodownID,IsNull(LSDT.TransactionDate,'')TransactionDate,IsNull(LSDT.Production,0)Production,IsNull(LSDT.ShiftingIN	,0)ShiftingIN,IsNull(LSDT.Sales,0)Sales,IsNull(LSDT.ShiftingOut,0)ShiftingOut,IsNull(LSDT.TornBagCount,0)TornBagCount,IsNull(LSDT.ICUMSAValue,0)ICUMSAValue,IsNull(LSDT.MoistureValue,0)MoistureValue,IsNull(LSDT.LineReplaceDate,'')LineReplaceDate,IsNull(LSDT.UnitID,'')UnitID,IsNull(LSG.GodownNumber,'')GodownNumber,ISNULL(CU.UnitName,'')UnitName from Lab.SUGAR_DAY_TRANSACTION LSDT Left Outer Join Common.Unit CU on LSDT.UnitID=CU.UnitID Left outer Join Lab.Sugar_Godown LSG on LSDT.SugarGodownID=LSG.SugarGodownID where 1=1";
           if (Unit != "" && Unit != "undefined" && Unit != null && Unit != "null")
            {
                Query = Query + " and LSDT.UnitID=" + Unit + "";

            }
            if (SugarGodown != "" && SugarGodown != "undefined" && SugarGodown != null && SugarGodown != "null")
            {
                Query = Query + " and LSDT.SugarGodownID=" + SugarGodown + "";

            }
            if (TransactionDate != "" && TransactionDate != "undefined" && TransactionDate != null && TransactionDate != "null" && TransactionDate2 == "" && TransactionDate2 == "undefined" && TransactionDate2 == null && TransactionDate2 == "null")
            {
                Query = Query + " and Convert(varchar, LSDT.TransactionDate, 105)='" + TransactionDate + "'";

            }
            if (TransactionDate != "" && TransactionDate != "undefined" && TransactionDate != null && TransactionDate != "null" && TransactionDate2 != "" && TransactionDate2 != "undefined" && TransactionDate2 != null && TransactionDate2 != "null")
            {
                Query = Query + " and Convert(varchar, LSDT.TransactionDate, 105) Between'" + TransactionDate + "' and '" + TransactionDate2 + "' ";

            }
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SugarDayTransaction> sugarDayTransactions = new List<SugarDayTransaction>();
            foreach (DataRow dr in dt.Rows)
            {
                sugarDayTransactions.Add(new SugarDayTransaction
                {
                    SugarDayTransactionId = Convert.ToInt32(dr["SugarDayTransactionID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    SugarGodownId= Convert.ToInt32(dr["SugarGodownID"]),
                    SugarGodownGodownNumber = dr["SugarGodownID"].ToString(),
                    TransactionDate=DateTime.Parse(dr["TransactionDate"].ToString()),
                    Production=Convert.ToDecimal(dr["Production"]),
                    ShiftingIn = Convert.ToDecimal(dr["ShiftingIN"]),
                    Sales = Convert.ToDecimal(dr["Sales"]),
                    ShiftingOut = Convert.ToDecimal(dr["ShiftingOut"]),
                    TornBagCount = Convert.ToDecimal(dr["TornBagCount"]),
                    IcumsaValue = Convert.ToDecimal(dr["ICUMSAValue"]),
                    MoistureValue = Convert.ToDecimal(dr["MoistureValue"]),
                    LineReplaceDate = DateTime.Parse(dr["LineReplaceDate"].ToString()),
                }); 

            }
            return sugarDayTransactions;
        }
        public List<SugarWeekTransaction> SugarWeekTransaction(string Unit, string SugarGodown)
        {
            string Query = "select LSWT.SugarWeekTransactionID,ISNull(LSWT.SugarGodownID,'')SugarGodownID,ISNull(LSWT.TransactionWeek,'')TransactionWeek,ISNull(LSWT.ICUMSAValue,0)ICUMSAValue,ISNull(LSWT.MoistureValue,0)MoistureValue,ISNull(LSWT.UnitID,'')UnitID,IsNull(LSG.GodownNumber,'')GodownNumber,ISNULL(CU.UnitName,'')UnitName from Lab.SUGAR_WEEK_TRANSACTION LSWT Left outer Join Lab.Sugar_Godown LSG on LSWT.SugarGodownID=LSG.SugarGodownID Left Outer Join Common.Unit CU on LSWT.UnitID=CU.UnitID where 1=1";
           if (Unit != "" && Unit != "undefined" && Unit != null && Unit != "null")
            {
                Query = Query + " and LSWT.UnitID=" + Unit + "";

            }
            if (SugarGodown != "" && SugarGodown != "undefined" && SugarGodown != null && SugarGodown != "null")
            {
                Query = Query + " and LSWT.SugarGodownID=" + SugarGodown + "";

            }
           
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SugarWeekTransaction> sugarWeekTransaction = new List<SugarWeekTransaction>();
            foreach (DataRow dr in dt.Rows)
            {
                sugarWeekTransaction.Add(new SugarWeekTransaction
                {
                    SugarWeekTransactionId = Convert.ToInt32(dr["SugarWeekTransactionID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    SugarGodownId = Convert.ToInt32(dr["SugarGodownID"]),
                    SugarGodownGodownNumber = dr["SugarGodownID"].ToString(),
                    TransactionWeek=Convert.ToInt32(dr["TransactionWeek"]),
                    MoistureValue = Convert.ToDecimal(dr["MoistureValue"]),
                   
                   
                });

            }
            return sugarWeekTransaction;
        }
        public DataTable InsertMolassesTank(int id, string TankNumber, int CrushingSeasonID, string Grade,decimal Opening,bool Discontinued)
        {
            string SqlQujery = "Exec InsertMolassesTankNew " + id + ",'" + TankNumber + "',"+ CrushingSeasonID + ",'" + Grade + "'," + Opening + ","+ Discontinued + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMolassesDayTransaction(int id, int MolassesTankID, DateTime TransactionDate, decimal Production,  decimal ShiftingIN, decimal Sales , decimal ShiftingOut, decimal InTemperature1, decimal InTemperature2, decimal InTemperature3, decimal InTemperature4, decimal InTemperature5, decimal OutTemperature1, decimal OutTemperature2, decimal OutTemperature3, decimal OutTemperature4, decimal OutTemperature5, decimal WaterIn1, decimal WaterIn2, decimal WaterIn3, decimal WaterIn4, decimal WaterIn5, decimal WaterOut1, decimal WaterOut2, decimal WaterOut3, decimal WaterOut4, decimal WaterOut5, decimal MolassesTemperature1, decimal MolassesTemperature2, decimal MolassesTemperature3, decimal MolassesTemperature4, decimal MolassesTemperature5, decimal Brix, decimal TRS, decimal ProductionTemperature1, decimal ProductionTemperature2, decimal ProductionTemperature3, decimal ProductionTemperature4, decimal ProductionTemperature5, decimal RecirculationHours, decimal WaterSpayHours, int UnitID)
        {
            string SqlQujery = "Exec InsertMolassesDAYTRANSACTIONNew " + id + "," + MolassesTankID + ",'" + TransactionDate.ToString("yyyy-MM-dd") + "'," + Production + "," + ShiftingIN + "," + Sales + ","+ ShiftingOut + ","+ InTemperature1 + ","+ InTemperature2 + ","+ InTemperature3+ ","+ InTemperature4 + ","+ InTemperature5 + ","+ OutTemperature1 + ","+ OutTemperature2 + ","+ OutTemperature3 + ","+ OutTemperature4 + ","+ OutTemperature5 + ","+ WaterIn1 + ","+ WaterIn2 + ","+ WaterIn3 + ","+ WaterIn4 + ","+ WaterIn5 + ","+ WaterOut1 + ","+ WaterOut2 + ","+ WaterOut3 + ","+ WaterOut4 + ","+ WaterOut5 + ","+ MolassesTemperature1 + ","+ MolassesTemperature2 + ","+ MolassesTemperature3 + ","+ MolassesTemperature4 + ","+ MolassesTemperature5 + ","+ Brix + ","+ TRS + ","+ ProductionTemperature1 + ","+ ProductionTemperature2 + ","+ ProductionTemperature3 + ","+ ProductionTemperature4 + ","+ ProductionTemperature5 + ","+ RecirculationHours + ","+ WaterSpayHours + ","+ UnitID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertSugarGodown(int id,string GodownNumber,string LotNumber,int CrushingSeasonID,string Grade,int PackSize,int PackType,decimal Opening,bool Discontinued)
        {
            string SqlQujery = "Exec InsertSugarGodownNew " + id + ",'"+ GodownNumber + "','"+ LotNumber + "',"+ CrushingSeasonID + ",'"+ Grade + "',"+ PackSize + ","+ PackType + ","+ Opening + ","+ Discontinued + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertSugarDayTransaction(int id, int SugarGodownID, DateTime TransactionDate, decimal Production, decimal ShiftingIN, decimal Sales, decimal ShiftingOut, decimal TornBagCount, decimal ICUMSAValue,decimal MoistureValue,DateTime LineReplaceDate,int UnitID)
        {
            string SqlQujery = "Exec InsertSUGARDAYTRANSACTIONNew " + id + "," + SugarGodownID + ",'" + TransactionDate.ToString("yyyy-MM-dd") + "'," + Production + "," + ShiftingIN + "," + Sales + "," + ShiftingOut + "," + TornBagCount + "," + ICUMSAValue + ","+ MoistureValue + ",'"+ LineReplaceDate .ToString("yyyy-MM-dd") + "',"+ UnitID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertSugarWeekTransaction(int id, int SugarGodownID, int TransactionWeek, decimal ICUMSAValue, decimal MoistureValue,  int UnitID)
        {
            string SqlQujery = "Exec InsertSUGARWEEkTRANSACTIONNew " + id + "," + SugarGodownID + "," + TransactionWeek + "," + ICUMSAValue + "," + MoistureValue + "," + UnitID + "";
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