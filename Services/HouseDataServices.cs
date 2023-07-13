using KnowledgeApp_Test.Models.HouseData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Services
{
    public class HouseDataServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'HouseDataServices.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'HouseDataServices.sdr' is never used


        public List<ClarificationType> ClarificationType()
        {

            string sql = "select * from Lab.CLARIFICATION_TYPE";


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<ClarificationType> ClarificationType = new List<ClarificationType>();
            foreach (DataRow dr in dt.Rows)
            {
                ClarificationType.Add(new ClarificationType
                {
                    ClarificationTypeId = Convert.ToInt32(dr["ClarificationTypeID"]),
                    ClarificationTypeCode = Convert.ToInt16(dr["ClarificationTypeCode"]),
                    ClarificationName = dr["ClarificationName"].ToString(),
                    ClarificationNature = Convert.ToInt16(dr["ClarificationNature"])
                });

            }
            return ClarificationType;

        }
        public List<Clarification> Clarification(string Clarification)
        {

            string sql = "select LC.ClarificationID,LC.ClarificationTypeID,LC.ClarificationCode,LC.ClarificationName,LCT.ClarificationName as ClarificationTypeName from Lab.CLARIFICATION LC left join Lab.CLARIFICATION_TYPE LCT on LC.ClarificationTypeID=LCT.ClarificationTypeID where 1=1";
            if (Clarification != "")
            {
                sql = sql + "and Lc.ClarificationTypeID='" + Clarification + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<Clarification> clarification = new List<Clarification>();
            foreach (DataRow dr in dt.Rows)
            {
                clarification.Add(new Clarification
                {
                    ClarificationId = Convert.ToInt32(dr["ClarificationID"]),
                    ClarificationTypeId = Convert.ToInt32(dr["ClarificationTypeID"]),
                    ClarificationCode = Convert.ToInt16(dr["ClarificationCode"]),
                    ClarificationName = dr["ClarificationName"].ToString(),
                    ClarificationTypeName = dr["ClarificationTypeName"].ToString()
                });

            }
            return clarification;

        }
        public List<ClarificationHouse> ClarificationHouse(string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {

            string sql = "select LCH.ClarificationHouseID,LCH.TransactionDate,isnull(LCH.ShiftID,'')ShiftID,isnull(LCH.ProcessHeadID,'')ProcessHeadID,LCH.IsChemist,isnull(LCH.SectionHeadID,'')SectionHeadID,isnull(LCH.DepartmentHeadID,'')DepartmentHeadID,LE.EmployeeName as ProcessHead ,LEE.EmployeeName as SectionHead, LEEE.EmployeeName as DepartmentHead,LS.ShiftName" +
                " from Lab.Clarification_House LCH Left Outer Join Lab.Employee LE on LCH.ProcessHeadID = LE.EmployeeID Left Outer Join Lab.Employee LEE on LCH.SectionHeadID =LEE.EmployeeID Left Outer Join Lab.Employee LEEE on LCH.DepartmentHeadID =LEEE.EmployeeID Left Outer Join  Lab.Shift LS on LCH.ShiftID=LS.ShiftID where 1=1";
            if (Shift != "")
            {
                sql = sql + "and LCH.ShiftID='" + Shift + "'";
            }
            if (ProcessHead != "")
            {
                sql = sql + "and LCH.ProcessHeadID='" + ProcessHead + "'";
            }
            if (SectionHead != "")
            {
                sql = sql + "and LCH.SectionHeadID='" + SectionHead + "'";
            }
            if (DepartmentHead != "")
            {
                sql = sql + "and LCH.DepartmentHeadID='" + DepartmentHead + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<ClarificationHouse> ClarificationHouse = new List<ClarificationHouse>();
            foreach (DataRow dr in dt.Rows)
            {
                ClarificationHouse.Add(new ClarificationHouse
                {
                    ClarificationHouseId = Convert.ToInt32(dr["ClarificationHouseID"]),
                    TransactionDate = DateTime.Parse(dr["TransactionDate"].ToString()),
                    ShiftShiftName = dr["ShiftName"].ToString(),
                    ProcessHeadEmployeeName = dr["ProcessHead"].ToString(),
                    IsChemist = (bool)(dr["IsChemist"]),
                    SectionHeadEmployeeName = dr["SectionHead"].ToString(),
                    DepartmentHeadEmployeeName = dr["DepartmentHead"].ToString(),
                    ProcessHeadId = Convert.ToInt32(dr["ProcessHeadID"]),
                    SectionHeadId = Convert.ToInt16(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt16(dr["DepartmentHeadID"]),
                    ShiftId = Convert.ToInt32(dr["ShiftID"])
                });

            }
            return ClarificationHouse;

        }
        public List<ClarificationHouseDetail> ClarificationHouseDetail(string Clarification,string ClarificationHouseId)
        {

            string sql = "Select CHD.ClarificationHouseDetailID,CHD.ClarificationHouseID,isnull(CHD.SerialNumber,'')SerialNumber,isnull(CHD.ClarificationID,'')ClarificationID,isnull(CHD.ClarificationValue,0)ClarificationValue,C.ClarificationName from [Lab].Clarification_House_Detail CHD left outer Join Lab.CLARIFICATION C on CHd.ClarificationID=C.ClarificationID where 1=1";
            if (Clarification != "" && Clarification != "undefined" && Clarification != null && Clarification!="null")
            {
                sql = sql + "and CHD.ClarificationID='" + Clarification + "'";
            }
            if (ClarificationHouseId != "" && ClarificationHouseId != "undefined" && ClarificationHouseId != null && ClarificationHouseId != "null")
            {
                sql = sql + "and CHD.ClarificationHouseID='" + ClarificationHouseId + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<ClarificationHouseDetail> clarificationHouseDetail = new List<ClarificationHouseDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                clarificationHouseDetail.Add(new ClarificationHouseDetail
                {
                    ClarificationHouseId = Convert.ToInt32(dr["ClarificationHouseID"]),
                    ClarificationName = dr["ClarificationName"].ToString(),
                    ClarificationHouseDetailID = Convert.ToInt32(dr["ClarificationHouseDetailID"]),
                    ClarificationID = Convert.ToInt16(dr["ClarificationID"]),
                    SerialNo = Convert.ToInt16(dr["SerialNumber"]),
                    ClarificationValue=Convert.ToDecimal(dr["ClarificationValue"])
                    
                });

            }
            return clarificationHouseDetail;

        }
        public List<MassecuiteConditioning> MassecuiteConditioning()
        {

            string sql = "select * from Lab.MASSECUITE_CONDITIONING";

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MassecuiteConditioning> MassecuiteConditioning = new List<MassecuiteConditioning>();
            foreach (DataRow dr in dt.Rows)
            {
                MassecuiteConditioning.Add(new MassecuiteConditioning
                {
                    MassecuiteConditioningId = Convert.ToInt32(dr["MassecuiteConditioningID"]),
                    MassecuiteConditioningCode = Convert.ToInt16(dr["MassecuiteConditioningCode"]),
                    MassecuiteConditioningName = dr["MassecuiteConditioningName"].ToString()
                    
                });

            }
            return MassecuiteConditioning;

        }
        public List<MassecuiteConditioningData> MassecuiteConditioningData(string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {

            string sql = "select LMC.MassecuiteConditioningDataID,LMC.AnalysisDate,isnull(LMC.ShiftID,'')ShiftID,isnull(LMC.ProcessHeadID,'')ProcessHeadID,isnull(LMC.SectionHeadID,'')SectionHeadID,isnull(LMC.DepartmentHeadID,'')DepartmentHeadID,LE.EmployeeName as ProcessHead ,LEE.EmployeeName as SectionHead, LEEE.EmployeeName as DepartmentHead,LS.ShiftName from Lab.MASSECUITE_CONDITIONING_DATA LMC Left Outer Join Lab.Employee LE on LMC.ProcessHeadID = LE.EmployeeID Left Outer Join Lab.Employee LEE on LMC.SectionHeadID =LEE.EmployeeID Left Outer Join Lab.Employee LEEE on LMC.DepartmentHeadID =LEEE.EmployeeID Left Outer Join  Lab.Shift LS on LMC.ShiftID=LS.ShiftID where 1=1";
            if (Shift != "" && Shift!=null && Shift != "undefined" && Shift != "null")
            {
                sql = sql + "and LMC.ShiftID='" + Shift + "'";
            }
            if (ProcessHead != "" && ProcessHead != null && ProcessHead != "undefined" && ProcessHead != "null")
            {
                sql = sql + "and LMC.ProcessHeadID='" + ProcessHead + "'";
            }
            if (SectionHead != "" && SectionHead != null && SectionHead != "undefined" && SectionHead != "null")
            {
                sql = sql + "and LMC.SectionHeadID='" + SectionHead + "'";
            }
            if (DepartmentHead != "" && DepartmentHead != null && DepartmentHead != "undefined" && DepartmentHead != "null")
            {
                sql = sql + "and LMC.DepartmentHeadID='" + DepartmentHead + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MassecuiteConditioningData> MassecuiteConditioningData = new List<MassecuiteConditioningData>();
            foreach (DataRow dr in dt.Rows)
            {
                MassecuiteConditioningData.Add(new MassecuiteConditioningData
                {
                    MassecuiteConditioningDataId = Convert.ToInt32(dr["MassecuiteConditioningDataID"]),
                    AnalysisDate = DateTime.Parse(dr["AnalysisDate"].ToString()),
                    ShiftShiftName = dr["ShiftName"].ToString(),
                    ProcessHeadEmployeeName = dr["ProcessHead"].ToString(),
                    SectionHeadEmployeeName = dr["SectionHead"].ToString(),
                    DepartmentHeadEmployeeName = dr["DepartmentHead"].ToString(),
                    ProcessHeadId = Convert.ToInt32(dr["ProcessHeadID"]),
                    SectionHeadId = Convert.ToInt16(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt16(dr["DepartmentHeadID"]),
                    ShiftId = Convert.ToInt32(dr["ShiftID"])
                });

            }
            return MassecuiteConditioningData;

        }
        public List<MassecuiteConditioningDataDetails> MassecuiteConditioningDataDetails(string conditinung,string DataId)
        {

            string sql = "select LMCDD.MassecuiteConditioningDetailDataID,LMCDD.MassecuiteConditioningDataID,isnull(LMCDD.SerialNumber,'')SerialNumber,isnull(LMCDD.MassecuiteConditioningID,'')MassecuiteConditioningID,isnull(LMCDD.AnalysisValue,0)AnalysisValue,LMc.MassecuiteConditioningName from Lab.MASSECUITE_CONDITIONING_DETAIL_DATA LMCDD left outer join Lab.MASSECUITE_CONDITIONING_DATA LMCD on LMCDD.MassecuiteConditioningDataID=LMCD.MassecuiteConditioningDataID left outer join Lab.MASSECUITE_CONDITIONING LMC on LMCDD.MassecuiteConditioningID=LMC.MassecuiteConditioningID where 1 = 1";
            if (conditinung != "" && conditinung != "undefined" && conditinung != null && conditinung != "null")
            {
                sql = sql + "and LMCDD.MassecuiteConditioningID= '" + conditinung + "'";
            }
            if (DataId != "" && DataId != "undefined" && DataId != null && DataId != "null")
            {
                sql = sql + "and LMCDD.MassecuiteConditioningDataID= '" + DataId + "'";
            }


            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MassecuiteConditioningDataDetails> MassecuiteConditioningDataDetails = new List<MassecuiteConditioningDataDetails>();
            foreach (DataRow dr in dt.Rows)
            {
                MassecuiteConditioningDataDetails.Add(new MassecuiteConditioningDataDetails
                {
                    MassecuiteConditioningDataDetailsId = Convert.ToInt32(dr["MassecuiteConditioningDetailDataID"]),
                    MassecuiteConditioningDataId = Convert.ToInt32(dr["MassecuiteConditioningDataID"]),
                    SerialNo = Convert.ToInt16(dr["SerialNumber"]),
                    AnalysisValue = Convert.ToDecimal(dr["AnalysisValue"]),
                    MassecuiteConditioningID = Convert.ToInt32(dr["MassecuiteConditioningID"]),
                    MassecuiteConditioningName = dr["MassecuiteConditioningName"].ToString()

                }) ;

            }
            return MassecuiteConditioningDataDetails;

        }

        public List<MassecuiteStock> MassecuiteStock(string Unit, string Shift, string AnalysisDate2, string AnalysisDate3, string ProcessHeadId, string SectionHeadId, string DepartmentHeadId)
        {

            string sql = "select LMS.AnalysisDate,LMS.ShiftID,ISNull(LMS.SHIFT_RCV_A,0)SHIFT_RCV_A,Isnull(LMS.MassecuiteStockID,0)MassecuiteStockID,Isnull(LMS.DROPP_A,0)DROPP_A,Isnull(LMS.CURED_A,0)CURED_A,Isnull(LMS.BAL_A,0)BAL_A,Isnull(LMS.SHIFT_RCV_A1,0)SHIFT_RCV_A1,ISnull(LMS.DROPP_A1,0)DROPP_A1,Isnull(LMS.CURED_A1,0)CURED_A1,Isnull(LMS.BAL_A1,0)BAL_A1,Isnull(LMS.SHIFT_RCV_B,0)SHIFT_RCV_B,Isnull(LMS.DROPP_B,0)DROPP_B,Isnull(LMS.CURED_B,0)CURED_B,Isnull(LMS.BAL_B,0)BAL_B,Isnull(LMS.SHIFT_RCV_C1,0)SHIFT_RCV_C1,Isnull(LMS.DROPP_C1,0)DROPP_C1,Isnull(LMS.CURED_C1,0)CURED_C1,Isnull(LMS.BAL_C1,0)BAL_C1,Isnull(LMS.SHIFT_RCV_C,0)SHIFT_RCV_C,Isnull(LMS.DROPP_C,0)DROPP_C,Isnull(LMS.CURED_C,0)CURED_C,Isnull(LMS.BAL_C,0)BAL_C,isnull(LMS.ProcessHeadID,'')ProcessHeadID,isnull(LMS.SectionHeadID,'')SectionHeadID,isnull(LMS.DepartmentHeadID,'')DepartmentHeadID,isnull(LMS.UnitID,'')UnitID, LE.EmployeeName as ProcessHead ,LEE.EmployeeName as SectionHead, LEEE.EmployeeName as DepartmentHead,LS.ShiftName,Cu.UnitName,LMS.UnitID from [Lab].[MASSECUITE_STOCK] LMS Left Outer Join Lab.Employee LE on LMS.ProcessHeadID = LE.EmployeeID Left Outer Join Lab.Employee LEE on LMS.SectionHeadID =LEE.EmployeeID Left Outer Join Lab.Employee LEEE on LMS.DepartmentHeadID =LEEE.EmployeeID Left Outer Join  Lab.Shift LS on LMS.ShiftID=LS.ShiftID Left Outer Join Common.Unit CU on LMS.UnitID=CU.UnitID where 1=1";

            if (AnalysisDate2.Length > 0 && AnalysisDate2.Length == 10)
            {
                string d = AnalysisDate2.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                AnalysisDate2 = s;
            }
            if (AnalysisDate3.Length > 0 && AnalysisDate3.Length == 10)
            {
                string d1 = AnalysisDate3.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                AnalysisDate3 = s1;
            }
            if (Shift != "" && Shift != null && Shift != "undefined" && Shift != "null")
            {
                sql = sql + "and LMS.ShiftID='" + Shift + "'";
            }
            if (Unit != "" && Unit != null && Unit != "undefined" && Unit != "null")
            {
                sql = sql + "and LMS.UnitID='" + Unit + "'";
            }
            if (AnalysisDate2 != "" && AnalysisDate2 != null && AnalysisDate2 != "undefined" && AnalysisDate2 != "null")
            {
                sql = sql + "and LMS.AnalysisDate='" + AnalysisDate2+ "'";
            }
            if (AnalysisDate3 != "" && AnalysisDate3 != "" && AnalysisDate3 != null && AnalysisDate3 != "undefined" && AnalysisDate3 != "null")
            {
                sql = sql + "and LMS.AnalysisDate between'" + AnalysisDate2 + "' and '" + AnalysisDate3 + "'";
            }

            if (ProcessHeadId != "" && ProcessHeadId != null && ProcessHeadId != "undefined" && ProcessHeadId != "null")
            {
                sql = sql + "and LMS.ProcessHeadID='" + ProcessHeadId + "'";
            }
            if (SectionHeadId != "" && SectionHeadId != null && SectionHeadId != "undefined" && SectionHeadId != "null")
            {
                sql = sql + "and LMS.SectionHeadID='" + SectionHeadId + "'";

            }
            if (DepartmentHeadId != "" && DepartmentHeadId != null && DepartmentHeadId != "undefined" && DepartmentHeadId != "null")
            {
                sql = sql + "and LMS.DepartmentHeadID='" + DepartmentHeadId + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<MassecuiteStock> MassecuiteStock = new List<MassecuiteStock>();
            foreach (DataRow dr in dt.Rows)
            {
                MassecuiteStock.Add(new MassecuiteStock
                {
                    MassecuiteStockId = Convert.ToInt32(dr["MassecuiteStockID"]),
                    UnitName = dr["UnitName"].ToString(),
                    AnalysisDate = DateTime.Parse(dr["AnalysisDate"].ToString()),
                    ShiftRcvA = Convert.ToInt32(dr["SHIFT_RCV_A"]),
                    DroppA = Convert.ToInt32(dr["DROPP_A"]),
                    CuredA = Convert.ToInt32(dr["CURED_A"]),
                    BalA = Convert.ToInt32(dr["BAL_A"]),
                    ShiftRcvA1 = Convert.ToInt32(dr["SHIFT_RCV_A1"]),
                    DroppA1 = Convert.ToInt32(dr["DROPP_A1"]),
                    CuredA1 = Convert.ToInt32(dr["CURED_A1"]),
                    BalA1 = Convert.ToInt32(dr["BAL_A1"]),
                    ShiftRcvB = Convert.ToInt32(dr["SHIFT_RCV_B"]),
                    DroppB = Convert.ToInt32(dr["DROPP_B"]),
                    CuredB = Convert.ToInt32(dr["CURED_B"]),
                    BalB = Convert.ToInt32(dr["BAL_B"]),
                    ShiftRcvC1 = Convert.ToInt32(dr["SHIFT_RCV_C1"]),
                    DroppC1 = Convert.ToInt32(dr["DROPP_C1"]),
                    CuredC1 = Convert.ToInt32(dr["CURED_C1"]),
                    BalC1 = Convert.ToInt32(dr["BAL_C1"]),
                    ShiftRcvC = Convert.ToInt32(dr["SHIFT_RCV_C"]),
                    DroppC = Convert.ToInt32(dr["DROPP_C"]),
                    CuredC = Convert.ToInt32(dr["CURED_C"]),
                    BalC = Convert.ToInt32(dr["BAL_C"]),
                    ProcessHeadId = Convert.ToInt32(dr["ProcessHeadID"]),
                    SectionHeadId = Convert.ToInt32(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt32(dr["DepartmentHeadID"]),
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"]),

                });

            }
            return MassecuiteStock;

        }

        public List<Chemical> Chemical()
        {

            string sql = "select * from Lab.Chemical";

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<Chemical> Chemical = new List<Chemical>();
            foreach (DataRow dr in dt.Rows)
            {
                Chemical.Add(new Chemical
                {
                    ChemicalId = Convert.ToInt32(dr["ChemicalID"]),
                    ChemicalCode = Convert.ToInt16(dr["ChemicalCode"]),
                    ChemicalName = dr["ChemicalName"].ToString()

                });

            }
            return Chemical;

        }


        public List<ChemicalConsumption> ChemicalConsumption(string Unit, string Shift, string ProcessHead, string SectionHead, string DepartmentHead)
        {

            string sql = "select LCC.ChemicalConsumptionID,Isnull(LCC.ConsumptionDate,'')ConsumptionDate,Isnull(LCC.ShiftID,'')ShiftID,Isnull(LCC.ProcessHeadID,'')ProcessHeadID,Isnull(LCC.SectionHeadID,'')SectionHeadID,Isnull(LCC.DepartmentHeadID,'')DepartmentHeadID,Isnull(LCC.UnitID,'')UnitID,LE.EmployeeCode as ProcessHeadCode,LEE.EmployeeCode as SectionHeadCode,LEEE.EmployeeCode as DepartmentHeadCode,LS.ShiftName,CU.UnitName from Lab.CHEMICAL_CONSUMPTION LCC left outer join Lab.Employee LE on LCC.ProcessHeadID=LE.EmployeeID left outer join Lab.Employee LEE on LCC.SectionHeadID=LEE.EmployeeID left outer join Lab.Employee LEEE on LCC.DepartmentHeadID=LEE.EmployeeID left outer join Lab.Shift Ls on LCC.ShiftID =Ls.ShiftID left Outer Join Common.Unit CU on LCC.UnitID=Cu.UnitID where 1=1";

            if (Unit != "" && Unit != null)
            {

                sql = sql + "and LCC.UnitID=" + Unit + "";
            }
            if (Shift != "" && Shift != null)
            {
                sql = sql + "and LCC.ShiftID=" + Shift + "";
            }
            if (ProcessHead != "" && ProcessHead != null)
            {
                sql = sql + "and LCC.ProcessHeadID=" + ProcessHead + "";
            }
            if (SectionHead != "" && SectionHead != null)
            {
                sql = sql + "and LCC.SectionHeadID=" + SectionHead + "";
            }
            if (DepartmentHead != "" && DepartmentHead != null)
            {
                sql = sql + "and LCC.DepartmentHeadID=" + DepartmentHead + "";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<ChemicalConsumption> ChemicalConsumption = new List<ChemicalConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ChemicalConsumption.Add(new ChemicalConsumption
                {
                    ChemicalConsumptionId = Convert.ToInt32(dr["ChemicalConsumptionId"]),
                    UnitUnitName = dr["UnitName"].ToString(),
                    ConsumptionDate = DateTime.Parse(dr["ConsumptionDate"].ToString()),
                    ShiftShiftName = dr["ShiftName"].ToString(),
                    ProcessHeadEmployeeCode = dr["ProcessHeadCode"].ToString(),
                    SectionHeadEmployeeCode = dr["SectionHeadCode"].ToString(),
                    DepartmentHeadEmployeeCode = dr["DepartmentHeadCode"].ToString(),
                    ProcessHeadId = Convert.ToInt32(dr["ProcessHeadID"]),
                    SectionHeadId = Convert.ToInt16(dr["SectionHeadID"]),
                    DepartmentHeadId = Convert.ToInt16(dr["DepartmentHeadID"]),
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    UnitId = Convert.ToInt32(dr["UnitID"])
                });

            }
            return ChemicalConsumption;

        }
        public List<ChemicalConsumptionDetails> ChemicalConsumptionDetails(string Chemical,string CunsumptionId)
        {

            string sql = "select LCCD.ChemicalConsumptionDetailID,LCCD.ChemicalConsumptionID,LCCD.SerialNumber,isnull(LCCD.ChemicalID,'')ChemicalID,isnull(LCCD.IssuedQuantity,0)IssuedQuantity,isnull(LCCD.ConsumedQuantity,0)ConsumedQuantity,LC.ChemicalName from Lab.CHEMICAL_CONSUMPTION_DETAIL LCCD left outer Join Lab.CHEMICAL LC On LCCD.ChemicalID=LC.ChemicalID where 1=1";

            if (Chemical != "" && Chemical != null && Chemical!="undefined"&& Chemical!="null")
            {

                sql = sql + "and LCCD.ChemicalID=" + Chemical + "";
            }
            if (CunsumptionId != "" && CunsumptionId != null && CunsumptionId != "undefined" && CunsumptionId != "null")
            {

                sql = sql + "and LCCD.ChemicalConsumptionID=" + CunsumptionId + "";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            List<ChemicalConsumptionDetails> chemicalConsumptionDetails = new List<ChemicalConsumptionDetails>();
            foreach (DataRow dr in dt.Rows)
            {
                chemicalConsumptionDetails.Add(new ChemicalConsumptionDetails
                {
                    ChemicalConsumptionDetailID = Convert.ToInt32(dr["ChemicalConsumptionDetailID"]),
                    ChemicalConsumptionID = Convert.ToInt32(dr["ChemicalConsumptionID"]),
                    ChemicalName = dr["ChemicalName"].ToString(),
                    IssuedQuantity = Convert.ToDecimal(dr["IssuedQuantity"]),
                    ConsumedQuantity = Convert.ToDecimal(dr["ConsumedQuantity"]),
                    ChemicalID=Convert.ToInt32(dr["ChemicalID"]),
                    SerialNumber=Convert.ToInt32(dr["SerialNumber"])
                });

            }
            return chemicalConsumptionDetails;

        }



        public DataTable InsertCLARIFICATIONType(int Id, int ClarificationTypeCode, string ClarificationName, int ClarificationNature)
        {
            string SqlQujery = "Exec InsertCLARIFICATIONTypeNew " + Id + "," + ClarificationTypeCode + ",'" + ClarificationName + "'," + ClarificationNature + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertCLARIFICATIONNew(int Id, int ClarificationTypeID, int ClarificationCode, string ClarificationName)
        {
            string SqlQujery = "Exec InsertCLARIFICATIONNew " + Id + "," + ClarificationTypeID + "," + ClarificationCode + ",'" + ClarificationName + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertClarificationHouseNew(int Id, DateTime TransactionDate, int ShiftID, int ProcessHeadID, bool IsChemist, int SectionHeadID, int DepartmentHeadID)
        {
            string SqlQujery = "Exec InsertClarificationHouseNew " + Id + ",'" + TransactionDate.ToString("yyyy-MM-dd") + "'," + ShiftID + "," + ProcessHeadID + "," + IsChemist + "," + SectionHeadID + "," + DepartmentHeadID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertClarificationHouseDetailNew(int Id, int ClarificationHouseID, int SerialNumber, int ClarificationID, Decimal ClarificationValue)
        {
            string SqlQujery = "Exec InsertClarificationHouseDetailNew " + Id + ",'" + ClarificationHouseID + "'," + SerialNumber + "," + ClarificationID + "," + ClarificationValue + "" ;
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMASSECUITECONDITIONINGNew(int Id, int Code, string Name)
        {
            string SqlQujery = "Exec InsertMASSECUITECONDITIONINGNew " + Id + "," + Code + ",'" + Name + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMASSECUITECONDITIONINGDataNew(int Id, DateTime AnalysisDate, int ShiftID, int ProcessHeadID, int SectionHeadID, int DepartmentHeadID)
        {
            string SqlQujery = "Exec InsertMASSECUITECONDITIONINGDataNew " + Id + ",'" + AnalysisDate + "'," + ShiftID + "," + ProcessHeadID + "," + SectionHeadID + "," + DepartmentHeadID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMASSECUITECONDITIONINGDETAILDATANew(int Id, int MassecuiteConditioningDataID, int SerialNumber, int MassecuiteConditioningID, Decimal AnalysisValue)
        {
            string SqlQujery = "Exec InsertMASSECUITECONDITIONINGDETAILDATANew " + Id + "," + MassecuiteConditioningDataID + ",'" + SerialNumber + "'," + MassecuiteConditioningID + ",'" + AnalysisValue + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertMASSECUITESTOCK(int Id, DateTime AnalysisDate, int ShiftID, Decimal SHIFT_RCV_A, Decimal DROPP_A, Decimal CURED_A, Decimal BAL_A, Decimal SHIFT_RCV_A1, Decimal DROPP_A1, Decimal CURED_A1, Decimal BAL_A1, Decimal SHIFT_RCV_B, Decimal DROPP_B, Decimal CURED_B, Decimal BAL_B, Decimal SHIFT_RCV_C1, Decimal DROPP_C1, Decimal CURED_C1, Decimal BAL_C1, Decimal SHIFT_RCV_C, Decimal DROPP_C, Decimal CURED_C,Decimal BAL_C,int ProcessHeadID,int SectionHeadID,int DepartmentHeadID, int UnitID)
        {
            string SqlQujery = "Exec InsertMASSECUITESTOCKNew " + Id + ",'" + AnalysisDate.ToString("yyyy-MM-dd") + "'," + ShiftID + "," + SHIFT_RCV_A + "," + DROPP_A + "," + CURED_A + "," + BAL_A + "," + SHIFT_RCV_A1 + "," + DROPP_A1 + "," + CURED_A1 + "," + BAL_A1 + "," + SHIFT_RCV_B + "," + DROPP_B + "," + CURED_B + "," + BAL_B + "," + SHIFT_RCV_C1 + "," + DROPP_C1 + "," + CURED_C1 + "," + BAL_C1 + "," + SHIFT_RCV_C + "," + DROPP_C + "," + CURED_C + ","+ BAL_C + ","+ ProcessHeadID + ","+ SectionHeadID + ","+ DepartmentHeadID + ","+ UnitID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertCHEMICALNew(int Id, int Code, String Name)
        {
            string SqlQujery = "Exec InsertCHEMICALNew " + Id + "," + Code + ",'" + Name + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertCHEMICALCONSUMPTIONNew(int Id, DateTime ConsumptionDate, int ShiftID, int ProcessHeadID, int SectionHeadID, int DepartmentHeadID, int UnitID)
        {
            string SqlQujery = "Exec InsertCHEMICALCONSUMPTIONNew " + Id + ",'" + ConsumptionDate.ToString("yyyy-MM-dd") + "'," + ShiftID + "," + ProcessHeadID + "," + SectionHeadID + "," + DepartmentHeadID + "," + UnitID + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        
        public DataTable InsertCHEMICALCONSUMPTIONDetailNew(int Id, int ChemicalConsumptionID, int SerialNumber, int ChemicalID, Decimal IssuedQuantity, Decimal ConsumedQuantity)
        {
            string SqlQujery = "Exec InsertCHEMICALCONSUMPTIONDetailNew " + Id + "," + ChemicalConsumptionID + "," + SerialNumber + "," + ChemicalID + "," + IssuedQuantity + "," + ConsumedQuantity + "";
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