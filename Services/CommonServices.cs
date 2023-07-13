using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using KnowledgeApp_Test.Models;
using KnowledgeApp_Test.Models.Common;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Services
{
    public class CommonServices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'CommonServices.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'CommonServices.sdr' is never used
        public List<Enterprise> GetEnterprises()
        {
            string sqlquery = "select * from common.Enterprise where 1=1";
           
            cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Enterprise> enterprises = new List<Enterprise>();
            foreach (DataRow dr in dt.Rows)
            {
                enterprises.Add(new Enterprise
                {
                    EnterpriseId = Convert.ToInt32(dr["EnterpriseId"]),
                    EnterpriseName = dr["EnterpriseName"].ToString(),
                    AddressLine1 = dr["AddressLine1"].ToString(),
                    AddressLine2 = dr["AddressLine2"].ToString(),
                });

            }
            return enterprises;
        }



        public List<Company> GetCompany(string Enterprise)
        {
            string sql = "select C.CompanyId,C.CompanyName,C.EnterpriseID,E.EnterpriseName,C.AddressLine1,C.AddressLine2  from common.Company C inner join  common.Enterprise E on c.EnterpriseId=E.EnterpriseID  where 1=1";
            if (Enterprise != "undefined" && Enterprise != null && Enterprise.Length > 0) 
            {
                var EnterpriseId = Convert.ToInt32(Enterprise);
                sql = sql + "and C.EnterpriseID='"+ EnterpriseId + "'";
            }
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Company> companies = new List<Company>();
            foreach (DataRow dr in dt.Rows)
            {
                companies.Add(new Company
                {
                    CompanyId = Convert.ToInt32(dr["CompanyId"]),
                    CompanyName = dr["CompanyName"].ToString(),
                    EnterpriseId = Convert.ToInt32(dr["EnterpriseID"]),
                    EnterpriseName= dr["EnterpriseName"].ToString(),
                    AddressLine1 = dr["AddressLine1"].ToString(),
                    AddressLine2 = dr["AddressLine2"].ToString(),
                });

            }
            return companies;
        }


       
       
        public List<Unit> GetUnit(String Company)
        {
            string sql = "select U.UnitID,C.Companyname,U.CompanyID,U.UnitName,U.AddressLine1,U.AddressLine2 from Common.Unit U Left outer  join Common.Company C on U.CompanyID = C.CompanyID where 1=1";
            if (Company!= "undefined" && Company != null && Company.Length>0 && Company!="")
            {
                sql = sql + "and U.CompanyID='" + Company + "'";
            }

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Unit> Unit = new List<Unit>();
            foreach (DataRow dr in dt.Rows)
            {
                Unit.Add(new Unit
                {
                    UnitId = Convert.ToInt32(dr["UnitID"]),
                    UnitName = dr["UnitName"].ToString(),
                    CompanyName = dr["Companyname"].ToString(),
                    CompanyId = Convert.ToInt32(dr["CompanyID"]),
                    AddressLine1 = dr["AddressLine1"].ToString(),
                    AddressLine2 = dr["AddressLine2"].ToString(),
                   
                });

            }
            return Unit;
        }

       

        public List<CrushingSeason> GetCrushingSeasonData()
        {
            cmd = new SqlCommand("select * from common.CrushingSeason", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<CrushingSeason> CrushingSeason = new List<CrushingSeason>();
            foreach (DataRow dr in dt.Rows)
            {
                CrushingSeason.Add(new CrushingSeason
                {
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonID"]),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    SeasonYear = Convert.ToInt32( dr["SeasonYear"]),

                });

            }
            return CrushingSeason;
        }
        public List<Centre> GetCentreData()
        {
            cmd = new SqlCommand("select C.C_ID,C.C_CODE,C.C_NAME,C.C_HNAME,C.C_CREATED_BY,C.C_EDITED_BY,CU.UnitName,C.UnitID from Centre C inner join  common.Unit CU on CU.UnitID=C.UnitID", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Centre> Centre = new List<Centre>();
            foreach (DataRow dr in dt.Rows)
            {
                Centre.Add(new Centre
                {
                    CId = Convert.ToInt32(dr["C_ID"]),
                    CCode = Convert.ToInt32(dr["C_CODE"]),
                    CName = dr["C_NAME"].ToString(),
                    CHname = dr["C_HNAME"].ToString(),
                    CCreatedBy = dr["C_CREATED_BY"].ToString(),
                    CEditedBy = dr["C_EDITED_BY"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    UnitID=Convert.ToInt32(dr["UnitID"])
                });

            }
            return Centre;
        }
        public List<UnitCrushingSeason> GetUnitCrushingSeasonData(string CrushingSeason, string Unit, string CrushingStartDate, string CrushingEndDate)
        {

            if (CrushingStartDate.Length > 0 && CrushingStartDate.Length == 10 )
            {
                string d = CrushingStartDate.Replace("-", "/");
                string s = DateTime.ParseExact(d, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                CrushingStartDate = s;
            }
            if (CrushingEndDate.Length > 0 && CrushingEndDate.Length == 10)
            {
                string d1 = CrushingEndDate.Replace("-", "/");
                string s1 = DateTime.ParseExact(d1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                CrushingEndDate = s1;
            }
            
            string sql = "select CUS.UnitCrushingSeasonID,CS.CrushingSeasonName as CrushingSeasonName,CU.UnitName,CUS.CrushingStartDate,CUS.CrushingEndDate,Isnull(CUS.MinutesDelayedStart,'')MinutesDelayedStart,Isnull(CUS.MinutesEarlyEnd,'')MinutesEarlyEnd,CUS.UnitID,CUS.CrushingSeasonID from Common.UnitCrushingSeason CUS Left outer join Common.CrushingSeason CS on CUS.CrushingSeasonID = CS.CrushingSeasonID Left Outer join Common.Unit CU on CU.UnitID = CUS.UnitID where 1 = 1";
            if (CrushingSeason != "" && CrushingSeason != "undefined" && CrushingSeason != null && CrushingSeason != "null")
            {
                sql = sql + "and CUS.CrushingSeasonID='" + CrushingSeason + "'";
            }
            if (Unit != "" && Unit != "undefined" && Unit != null && Unit!="null")
            {
                sql = sql + "and CUS.UnitID='" + Unit + "'";
            }
           
            if (CrushingStartDate != "undefined" && CrushingStartDate != "null" && CrushingEndDate == "null" )
            {
                sql = sql + "and CUS.CrushingStartDate '" + CrushingStartDate + "'";
            }
            if (CrushingEndDate != "null" && CrushingStartDate != "" && CrushingStartDate != "undefined" && CrushingStartDate != "null" && CrushingStartDate != null && Unit =="" && CrushingSeason=="")
            {
                sql = sql + "and CUS.CrushingEndDate  between '" + CrushingStartDate + "' and '" + CrushingEndDate + "'";
            }


            cmd = new SqlCommand(sql+"order by CU.UnitName", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<UnitCrushingSeason> UnitCrushingSeason = new List<UnitCrushingSeason>();
            foreach (DataRow dr in dt.Rows)
            {
                UnitCrushingSeason.Add(new UnitCrushingSeason
                {
                    UnitCrushingSeasonId = Convert.ToInt32(dr["UnitCrushingSeasonID"]),
                    UnitName=dr["UnitName"].ToString(),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),
                    CrushingStartDate = DateTime.Parse(dr["CrushingStartDate"].ToString()),
                    CrushingEndDate = DateTime.Parse(dr["CrushingEndDate"].ToString()),
                    MinutesDelayedStart = Convert.ToInt32(dr["MinutesDelayedStart"]),
                    MinutesEarlyEnd = Convert.ToInt32(dr["MinutesEarlyEnd"]),
                    UnitId=Convert.ToInt32(dr["UnitID"]),
                    CrushingSeasonId=Convert.ToInt32(dr["CrushingSeasonID"])

                });

            }
            return UnitCrushingSeason;
        }

        public List<Village> GetVillageData()
        {
            cmd = new SqlCommand("select V_ID,V_CODE,V_NAME,V_HNAME,V_CENTRE,V_CREATED_BY,V_EDITED_BY,UnitName,V.UnitID from Village V inner join Common.Unit CU on V.UnitID=CU.UnitID", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Village> Village = new List<Village>();
            foreach (DataRow dr in dt.Rows)
            {
                Village.Add(new Village
                {
                    VId = Convert.ToInt32(dr["V_ID"]),
                    VName = dr["V_NAME"].ToString(),
                    VCode = Convert.ToInt16(dr["V_CODE"]),
                    VHname = dr["V_HNAME"].ToString(),
                    VCentreCName = dr["V_CENTRE"].ToString(),
                    VCreatedBy = dr["V_CREATED_BY"].ToString(),
                    VEditedBy = dr["V_EDITED_BY"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    UnitId= Convert.ToInt32(dr["UnitID"])
                });

            }
            return Village;
        }


        public List<Variety> GetVarietyData()
        {
            cmd = new SqlCommand("select VR_ID,VR_CODE,VR_NAME,ISnull(VR_MAX_REC,0.00)as VR_MAX_REC,Convert(varchar,(isnull(VR_MAXDT,'1900-01-01')),105)as VR_MAXDT ,Isnull(VR_MAT_PERIOD,0.00)as VR_MAT_PERIOD,VR_AVG_LOSS,VR_CREATED_BY,VR_EDITED_BY,UnitName,variety.UnitID from variety inner join Common.Unit on variety.UnitID=Common.Unit.UnitID", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Variety> Variety = new List<Variety>();

            foreach (DataRow dr in dt.Rows)
            {


                Variety.Add(new Variety
                {
                    VrId = Convert.ToInt32(dr["VR_ID"]),
                    VrCode = Convert.ToInt16(dr["VR_CODE"]),
                    VrName = dr["VR_NAME"].ToString(),
                    VrMaxRec = Convert.ToDecimal(dr["VR_MAX_REC"]),
                    VrMaxdt = DateTime.Parse(dr["VR_MAXDT"].ToString()),
                    VrAvgLoss = Convert.ToDecimal(dr["VR_AVG_LOSS"]),
                    VrMatPeriod = Convert.ToInt16(dr["VR_MAT_PERIOD"]),
                    VrCreatedBy = dr["VR_CREATED_BY"].ToString(),
                    VrEditedBy = dr["VR_EDITED_BY"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    UnitId = Convert.ToInt32(dr["UnitID"])
                }); ;

            }
            return Variety;
        }


        public List<Grower> GetGrowerData()
        {
            cmd = new SqlCommand("select G_ID,G_VILL,G_CODE,G_NAME,G_FATHER,G_HNAME,G_HFATHER,G_CREATED_BY,G_EDITED_BY,UnitName,V_NAME,G.UnitID from Grower G inner join Common.Unit CU on G.UnitID=CU.UnitID inner join Village V on V.V_ID=G_VILL", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Grower> Grower = new List<Grower>();

            foreach (DataRow dr in dt.Rows)
            {


                Grower.Add(new Grower
                {
                    GId = Convert.ToInt32(dr["G_ID"]),
                    GVill=Convert.ToInt32(dr["G_VILL"]),
                    GCode = Convert.ToInt16(dr["G_CODE"]),
                    GVillVName = dr["V_NAME"].ToString(),
                    GName = dr["G_NAME"].ToString(),
                    GFather = dr["G_FATHER"].ToString(),
                    GHname = dr["G_HNAME"].ToString(),
                    GHfather = dr["G_HFATHER"].ToString(),
                    GCreatedBy = dr["G_CREATED_BY"].ToString(),
                    GEditedBy = dr["G_EDITED_BY"].ToString(),
                    UnitName = dr["UnitName"].ToString(),
                    UnitId= Convert.ToInt32(dr["UnitID"])
                });

            }
            return Grower;
        }

        public DataTable InsertEnterPrise(int id,string Name, string Address1, string Address2)
        {
            string SqlQujery = "Exec InsertEnterPrise "+ id + ",'"+ Name + "','"+ Address1 + "','"+ Address2 + "'";
            cmd = new SqlCommand(SqlQujery);

            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertCompany(int id,int Entrprise, string Name, string Address1, string Address2)
        {
            string SqlQujery = "Exec InsertCompany "+id+", "+ Entrprise + ",'" + Name + "','" + Address1 + "','" + Address2 + "'";
            //string SqlQujery = "select 'Yash' as Msg ,1 as Status ";
            cmd = new SqlCommand(SqlQujery);

            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertUnit(int Id,int CountryId, string Name, string Address1, string Address2)
        {
            string SqlQujery = "Exec InsertUnit "+ Id + ",'" + CountryId + "','" + Name + "','" + Address1 + "','" + Address2 + "'";
           // string SqlQujery = "select 'Yash' as Msg ,1 as Status ";
            cmd = new SqlCommand(SqlQujery);

            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertCentre(int Id,int ccode, string CName, string CHname, string CCreatedby, string CEditedby,int Unit)
        {
            string SqlQujery = "Exec InsertCentreNew "+ Id + "," + ccode + ",'" + CName + "','" + CHname + "','" + CCreatedby + "','" + CEditedby + "'," + Unit + "";
           cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
           sda = new SqlDataAdapter(cmd);
           dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsertCrushingSeason(int Id, string SeasonName, int seasonYear)
        {
            string SqlQujery = "Exec InsertCrushingSeason " + Id + "," + seasonYear + ",'" + SeasonName + "'";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }

        public DataTable InsetUnitCrushingSeason(int Id, int CrushingSeasonId, int UnitId,DateTime Startdate, DateTime Enddate, int DelayedStart, int EarlyEnd)
        {
            string SqlQujery = "Exec InsertUnitCrushingSeason " + Id + "," + CrushingSeasonId + "," + UnitId + ",'"+ Startdate.ToString("yyyy-MM-dd") + "','"+ Enddate.ToString("yyyy-MM-dd") + "',"+ DelayedStart + ","+ EarlyEnd + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertVillage(int Id, int Vcode, string VName, string VHname,int Centre, string VCreatedby, string VEditedby, int Unit)
        {
            string SqlQujery = "Exec InsertVillageNew " + Id + "," + Vcode + ",'" + VName + "','" + VHname + "',"+ Centre + ",'" + VCreatedby + "','" + VEditedby + "'," + Unit + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public static string ShowAlert(Alerts obj, string message)
        {
            string alertDiv = null;
            switch (obj)
            {
                case Alerts.Success:
                    alertDiv = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";
                    break;
                case Alerts.Danger:
                    alertDiv = "<div class='alert alert-danger alert-dismissible' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Error!</ strong > " + message + "</a>.</div>";
                    break;
                case Alerts.Info:
                    alertDiv = "<div class='alert alert-info alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Info!</ strong > " + message + "</a>.</div>";
                    break;
                case Alerts.Warning:
                    alertDiv = "<div class='alert alert-warning alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Warning!</strong> " + message + "</a>.</div>";
                    break;
            }
            return alertDiv;
        }
        public DataTable InsertVariety(int Id, int Vrcode, string VrName, decimal VrMaxRec, DateTime VrMaxdt, int VrMatPeriod, decimal VrAvgLoss, string VrCreatedby, string VrEditedby, int Unit)
        {
            string SqlQujery = "Exec InsertVarietyNew " + Id + "," + Vrcode + ",'" + VrName + "'," + VrMaxRec + ",'" + VrMaxdt.ToString("yyyy-MM-dd HH:MM:ss.000") + "'," + VrMatPeriod + "," + VrAvgLoss + ",'"+ VrCreatedby + "','"+ VrEditedby + "'," + Unit + "";
            cmd = new SqlCommand(SqlQujery);
            cmd = new SqlCommand(SqlQujery, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return (dt);
        }
        public DataTable InsertGrower(int Id,int GVill,int GCode,string GName,string GFather,string GHname,string GHfather,string GCreatedby,string GEditedby,int Unit)
        {
            string SqlQujery = "Exec InsertGrowerNew " + Id + ","+ GVill + "," + GCode + ",'" + GName + "','" + GFather + "','" + GHname + "','" + GHfather + "','" + GCreatedby + "','" + GEditedby + "'," + Unit + "";
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
