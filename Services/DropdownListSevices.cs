using KnowledgeApp_Test.Models;
using KnowledgeApp_Test.Models.Administration;
using KnowledgeApp_Test.Models.BenchMarking;
using KnowledgeApp_Test.Models.Common;
using KnowledgeApp_Test.Models.Control;
using KnowledgeApp_Test.Models.General;
using KnowledgeApp_Test.Models.HouseData;
using KnowledgeApp_Test.Models.Parameters;
using KnowledgeApp_Test.Models.PlantData;
using KnowledgeApp_Test.Models.ProjectDocs;
using KnowledgeApp_Test.Models.SpecialAnalysis;
using KnowledgeApp_Test.Models.Stoppages;
using KnowledgeApp_Test.Models.Sugar_Molasses;
using KnowledgeApp_Test.Models.Targets;
using KnowledgeApp_Test.Models.Template;
using KnowledgeApp_Test.Models.TPT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static KnowledgeApp_Test.Models.Common_Model.Alert;

namespace KnowledgeApp_Test.Services
{
    public class DropdownListSevices
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlConnection user = new SqlConnection(ConfigurationManager.ConnectionStrings["UserConnection"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        public List<Enterprise> GetEntrpriseddl()
        {
            cmd = new SqlCommand("select EnterpriseId,EnterpriseName from common.Enterprise", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Enterprise> enterprise = new List<Enterprise>();
            foreach (DataRow dr in dt.Rows)
            {
                enterprise.Add(new Enterprise
                {
                    EnterpriseId = Convert.ToInt32(dr["EnterpriseId"]),
                    EnterpriseName = dr["EnterpriseName"].ToString(),

                });

            }
            return enterprise;
        }
        public List<Unit> GetUnitddl()
        {
            cmd = new SqlCommand("select * from Common.Unit where UnitName<>'test45' and UnitName<>'test26'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Unit> Unit = new List<Unit>();
             foreach (DataRow dr in dt.Rows)
            {
                Unit.Add(new Unit
                {
                    UnitId = Convert.ToInt32(dr["UnitId"]),
                    UnitName = dr["UnitName"].ToString(),

                });

            }
            return Unit;
        }
        public List<Village> GetVillageddl()
        {
            cmd = new SqlCommand("select V_ID,V_NAME from Village", con);
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

                });

            }
            return Village;
        }
        public List<Centre> GetCentreddl()
        {
            cmd = new SqlCommand("Select C_ID,C_NAME from Centre", con);
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
                    CName = dr["C_NAME"].ToString(),
                });

            }
            return Centre;
        }
        public List<Company> GetCompanyddl()
        {
            cmd = new SqlCommand("select CompanyID,CompanyName from common.Company", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Company> Company = new List<Company>();
            foreach (DataRow dr in dt.Rows)
            {
                Company.Add(new Company
                {
                    CompanyId = Convert.ToInt32(dr["CompanyId"]),
                    CompanyName = dr["CompanyName"].ToString(),

                });

            }
            return Company;
        }
        public List<CrushingSeason> GetCrushingSeasonddl()
        {
            cmd = new SqlCommand("select CrushingSeasonID,CrushingSeasonName from common.CrushingSeason", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<CrushingSeason> CrushingSeason = new List<CrushingSeason>();
            foreach (DataRow dr in dt.Rows)
            {
                CrushingSeason.Add(new CrushingSeason
                {
                    CrushingSeasonId = Convert.ToInt32(dr["CrushingSeasonId"]),
                    CrushingSeasonName = dr["CrushingSeasonName"].ToString(),

                });

            }
            return CrushingSeason;
        }
        public List<ControlParameterGroup> GetParameterGroupddl()
        {
            cmd = new SqlCommand("select ControlParameterGroupID,ControlParameterGroupName from Lab.ControlParameterGroup", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ControlParameterGroup> ControlParameterGroup = new List<ControlParameterGroup>();
            foreach (DataRow dr in dt.Rows)
            {
                ControlParameterGroup.Add(new ControlParameterGroup
                {
                    ParameterGroupId = Convert.ToInt32(dr["ControlParameterGroupID"]),
                    ControlParameterGroupName = dr["ControlParameterGroupName"].ToString(),

                });

            }
            return ControlParameterGroup;
        }
        public List<ControlParameter> GetControlParameterddl()
        {
            cmd = new SqlCommand("select ParameterID,isnull(ParameterName,'') ParameterName from Lab.ControlParameter", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ControlParameter> ControlParameter = new List<ControlParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                ControlParameter.Add(new ControlParameter
                {
                    ParameterId = Convert.ToInt32(dr["ParameterID"]),
                    ParameterName = dr["ParameterName"].ToString(),

                });

            }
            return ControlParameter;
        }
        public List<Models.Parameters.EntryType> GetEntryTypeddl()
        {
            cmd = new SqlCommand("select EntryTypeID,EntryTypeName from EntryType", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Models.Parameters.EntryType> EntryType = new List<Models.Parameters.EntryType>();
            foreach (DataRow dr in dt.Rows)
            {
                EntryType.Add(new Models.Parameters.EntryType
                {
                    EntryTypeId = Convert.ToInt32(dr["EntryTypeID"]),
                    EntryTypeName = dr["EntryTypeName"].ToString(),
                });

            }
            return EntryType;
        }
        public List<ParameterType> GetParemeterTypeddl()
        {
            cmd = new SqlCommand("select ParameterTypeID,ParameterTypeName from Lab.ParameterType order by ParameterTypeName", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ParameterType> ParameterType = new List<ParameterType>();
            foreach (DataRow dr in dt.Rows)
            {
                ParameterType.Add(new ParameterType
                {
                    ParameterTypeId = Convert.ToInt32(dr["ParameterTypeID"]),
                    ParameterTypeName = dr["ParameterTypeName"].ToString(),
                });

            }
            return ParameterType;
        }
        public List<Parameter> GetParemeterddl()
        {
            cmd = new SqlCommand("select ParameterID,ParameterName from Lab.Parameter order By ParameterName", con);
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
                    ParameterName = dr["ParameterName"].ToString(),
                });

            }
            return Parameter;
        }
        public List<ParameterUnit> GetParameterUnitddl()
        {
            cmd = new SqlCommand("select ParameterUnitID,ParameterUnitName from Lab.PARAMETER_UNIT order by ParameterUnitName", con);
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
                    ParameterUnitName = dr["ParameterUnitName"].ToString(),

                });

            }
            return ParameterUnit;
        }
        public List<BenchMarkParameter> GetBenchMarkParameterddl()
        {
            cmd = new SqlCommand("select BenchMarkParameterID,BenchMarkName from Lab.BENCH_MARK_PARAMETER ", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<BenchMarkParameter> BenchMarkParameter = new List<BenchMarkParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                BenchMarkParameter.Add(new BenchMarkParameter
                {
                    BenchMarkParameterId = Convert.ToInt32(dr["BenchMarkParameterID"]),
                    BenchMarkName = dr["BenchMarkName"].ToString(),

                });

            }
            return BenchMarkParameter;
        }
        public List<SeasonWeek> GetSeasonWeekddl()
        {
            cmd = new SqlCommand("select WeekID,WeekName from Lab.SEASON_WEEK", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SeasonWeek> SeasonWeek = new List<SeasonWeek>();
            foreach (DataRow dr in dt.Rows)
            {
                SeasonWeek.Add(new SeasonWeek
                {
                    WeekId = Convert.ToInt32(dr["WeekID"]),
                    WeekName = dr["WeekName"].ToString(),

                });

            }
            return SeasonWeek;
        }
        public List<SeasonMonth> GetSeasonMonthddl()
        {
            cmd = new SqlCommand("select MonthID,isnull(MonthName,'')MonthName from Lab.SEASON_MONTH order by MonthName desc ", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SeasonMonth> SeasonMonth = new List<SeasonMonth>();
            foreach (DataRow dr in dt.Rows)
            {
                SeasonMonth.Add(new SeasonMonth
                {
                    MonthId = Convert.ToInt32(dr["MonthID"]),
                    MonthName = dr["MonthName"].ToString(),

                });

            }
            return SeasonMonth;
        }
        public List<SpecialAnalysisType> GetSpecialAnalysisTypeddl()
        {
            cmd = new SqlCommand("select SpecialAnalysisTypeID,SpecialAnalysisTypeName from Lab.Special_Analysis_Type", con);
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
                    SpecialAnalysisTypeName = dr["SpecialAnalysisTypeName"].ToString(),

                });

            }
            return SpecialAnalysisType;
        }
        public List<SpecialAnalysisParameter> GetSpecialAnalysisParameterddl()
        {
            cmd = new SqlCommand("select SpecialAnalysisParameterID,SpecialAnalysisParameterName from Lab.Special_Analysis_Parameter", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SpecialAnalysisParameter> SpecialAnalysisParameter = new List<SpecialAnalysisParameter>();
            foreach (DataRow dr in dt.Rows)
            {
                SpecialAnalysisParameter.Add(new SpecialAnalysisParameter
                {
                    SpecialAnalysisParameterId = Convert.ToInt32(dr["SpecialAnalysisParameterID"]),
                    SpecialAnalysisParameterName = dr["SpecialAnalysisParameterName"].ToString(),

                });

            }
            return SpecialAnalysisParameter;
        }
        public List<StoppageDepartment> GetStoppageDepartmentddl()
        {
            cmd = new SqlCommand("select DepartmentID,DepartmentName From Lab.StoppageDepartment", con);
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
                    DepartmentName = dr["DepartmentName"].ToString(),

                });

            }
            return StoppageDepartment;
        }
        public List<StoppageStation> GetStoppageStationddl()
        {
            cmd = new SqlCommand("select StationID, StationName from Lab.StoppageStation", con);
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
                    StationName = dr["StationName"].ToString(),

                });

            }
            return StoppageStation;
        }
        public List<StoppageSparesProcess> GetStoppageSparesProcessddl()
        {
            cmd = new SqlCommand("select SpareProcessID,SpareProcessName from lab.StoppageSparesProcess", con);
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
                    SpareProcessName = dr["SpareProcessName"].ToString(),

                });

            }
            return StoppageSparesProcess;
        }
        public List<StoppageDefect> StoppageDefectddl()
        {
            cmd = new SqlCommand("select DefectID, DefectName from Lab.StoppageDefect", con);
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
                    DefectName = dr["DefectName"].ToString(),

                });

            }
            return StoppageDefect;
        }
        public List<StoppageType> StoppageTypeddl()
        {
            cmd = new SqlCommand("select * from StoppageType", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<StoppageType> stoppageType = new List<StoppageType>();
            foreach (DataRow dr in dt.Rows)
            {
                stoppageType.Add(new StoppageType
                {
                    StoppageTypeId = Convert.ToInt32(dr["Id"]),
                    StoppageTypeName = dr["StoppageTypeName"].ToString(),

                });

            }
            return stoppageType;
        }
        public List<StoppageActionTaken> StoppageActionTakenddl()
        {
            cmd = new SqlCommand("select ActionID,ActionName from Lab.StoppageActionTaken", con);
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
                    ActionName = dr["ActionName"].ToString(),

                });

            }
            return StoppageActionTaken;
        }
        public List<ClarificationType> ClarificationTypeddl()
        {
            cmd = new SqlCommand("select ClarificationTypeID,ClarificationName from Lab.CLARIFICATION_TYPE", con);
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
                    ClarificationName = dr["ClarificationName"].ToString(),

                });

            }
            return ClarificationType;
        }
        public List<Employee> Employeeddl()
        {
            cmd = new SqlCommand("Select EmployeeID,EmployeeName from Lab.Employee", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Employee> employee = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                employee.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeID"]),
                    EmployeeName = dr["EmployeeName"].ToString(),

                });

            }
            return employee;
        }
        public List<Shift> Shiftddl()
        {
            cmd = new SqlCommand("select ShiftID,ShiftName from Lab.Shift", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Shift> shift = new List<Shift>();
            foreach (DataRow dr in dt.Rows)
            {
                shift.Add(new Shift
                {
                    ShiftId = Convert.ToInt32(dr["ShiftID"]),
                    ShiftName = dr["ShiftName"].ToString(),

                });

            }
            return shift;
        }
        public List<Clarification> Clarificationddl()
        {
            cmd = new SqlCommand("select ClarificationID,ClarificationName from  Lab.CLARIFICATION", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Clarification> Clarification = new List<Clarification>();
            foreach (DataRow dr in dt.Rows)
            {
                Clarification.Add(new Clarification
                {
                    ClarificationId = Convert.ToInt32(dr["ClarificationID"]),
                    ClarificationName = dr["ClarificationName"].ToString(),

                });

            }
            return Clarification;
        }
        public List<MassecuiteConditioning> MassecuiteConditioningddl()
        {
            cmd = new SqlCommand("select MassecuiteConditioningID,MassecuiteConditioningName from Lab.MASSECUITE_CONDITIONING", con);
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
                    MassecuiteConditioningName = dr["MassecuiteConditioningName"].ToString(),

                });

            }
            return MassecuiteConditioning;
        }
        public List<Chemical> Chemicalddl()
        {
            cmd = new SqlCommand("select ChemicalID,ChemicalName from Lab.Chemical", con);
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
                    ChemicalName = dr["ChemicalName"].ToString(),

                });

            }
            return Chemical;
        }
        public List<MillParameter> MillParameterddl()
        {
            cmd = new SqlCommand("select MillParameterID,MillParameterName from Lab.MILL_PARAMETER", con);
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
                    MillParameterName = dr["MillParameterName"].ToString(),

                });

            }
            return MillParameter;
        }
        public List<Mill> Millddl()
        {
            cmd = new SqlCommand("select MillID,MillName from Lab.Mill", con);
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
                    MillName = dr["MillName"].ToString(),

                });

            }
            return Mill;
        }
        public List<PlantDepartment> PlantDepartmentddl()
        {
            cmd = new SqlCommand("select PlantDepartmentID,DepartmentName from Lab.PlantDepartment", con);
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
                    DepartmentName = dr["DepartmentName"].ToString(),

                });

            }
            return PlantDepartment;
        }
        public List<PlantSubDepartment> PlantSubDepartmentddl()
        {
            cmd = new SqlCommand("select PlantSubDepartmentID,SubDepartmentName from Lab.PlantSubDepartment", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<PlantSubDepartment> PlantSubDepartment = new List<PlantSubDepartment>();
            foreach (DataRow dr in dt.Rows)
            {
                PlantSubDepartment.Add(new PlantSubDepartment
                {
                    PlantSubDepartmentId = Convert.ToInt32(dr["PlantSubDepartmentId"]),
                    SubDepartmentName = dr["SubDepartmentName"].ToString(),

                });

            }
            return PlantSubDepartment;
        }
        public List<Pan> Panddl()
        {
            cmd = new SqlCommand("select PanID,PanName from Lab.PAN", con);
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
                    PanName = dr["PanName"].ToString(),

                });

            }
            return Pan;
        }
        public List<Position> Positionddl()
        {
            cmd = new SqlCommand("select PositionID,PositionName from Lab.POSITION", con);
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
                    PositionName = dr["PositionName"].ToString(),

                });

            }
            return Position;
        }
        public List<ParameterType> ParameterTypeTypeddl()
        {
            cmd = new SqlCommand("select ParameterTypeID,ParameterTypeName from ParameterType where ParameterType='Parameter'", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ParameterType> ParameterType = new List<ParameterType>();
            foreach (DataRow dr in dt.Rows)
            {
                ParameterType.Add(new ParameterType
                {
                    ParameterTypeId = Convert.ToInt32(dr["ParameterTypeID"]),
                    ParameterTypeName = dr["ParameterTypeName"].ToString(),

                });

            }
            return ParameterType;
        }
        public List<ChartType> ChartTypeddl()
        {
            cmd = new SqlCommand("select ParameterTypeID,ParameterTypeName from ChartType", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ChartType> ChartType = new List<ChartType>();
            foreach (DataRow dr in dt.Rows)
            {
                ChartType.Add(new ChartType
                {
                    ChartTypeId = Convert.ToInt32(dr["ParameterTypeID"]),
                    ChartTypeName = dr["ParameterTypeName"].ToString(),

                });

            }
            return ChartType;
        }
        public List<ChartTemplate> ChartTemplateddl()
        {
            cmd = new SqlCommand("select ChartTemplateID,ISnull(ChartTemplateName,'')ChartTemplateName from Lab.ChartTemplate", con);
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

                });

            }
            return ChartTemplate;
        }
        public List<ReportTemplate> ReportTemplateddl()
        {
            cmd = new SqlCommand("select ReportTemplateID,ReportTemplateName from Lab.ReportTemplate", con);
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

                });

            }
            return ReportTemplate;
        }
        public List<ReportType> ReportTypeddl()
        {
            cmd = new SqlCommand("select * from ReportType", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ReportType> ReportType = new List<ReportType>();
            foreach (DataRow dr in dt.Rows)
            {
                ReportType.Add(new ReportType
                {
                    ReportTypeId = Convert.ToInt32(dr["ReportTypeID"]),
                    ReportTypeName = dr["ReportTypeName"].ToString(),

                });

            }
            return ReportType;
        }
       public List<DocumentClass> DocumentClassddl()
        {
            cmd = new SqlCommand("select DocumentClassID,ClassName from Lab.DocumentClass", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentClass> DocumentClass = new List<DocumentClass>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentClass.Add(new DocumentClass
                {
                    DocumentClassId = Convert.ToInt32(dr["DocumentClassID"]),
                    ClassName = dr["ClassName"].ToString(),

                });

            }
            return DocumentClass;
        }
        public List<DocumentSubClass> DocumentSubClassddl()
        {
            cmd = new SqlCommand("select DocumentSubClassID,SubClassName from Lab.DocumentSubClass", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<DocumentSubClass> DocumentSubClass = new List<DocumentSubClass>();
            foreach (DataRow dr in dt.Rows)
            {
                DocumentSubClass.Add(new DocumentSubClass
                {
                    DocumentSubClassId = Convert.ToInt32(dr["DocumentSubClassID"]),
                    SubClassName = dr["SubClassName"].ToString(),

                });

            }
            return DocumentSubClass;
        }
        public List<ApprovalStatus> ApprovalStatusddl()
        {
            cmd = new SqlCommand("select * from ApprovalStatus", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ApprovalStatus> ApprovalStatus = new List<ApprovalStatus>();
            foreach (DataRow dr in dt.Rows)
            {
                ApprovalStatus.Add(new ApprovalStatus
                {
                    ApprovalStatusID = Convert.ToInt32(dr["ApprovalStatusID"]),
                    ApprovalStatusName = dr["ApprovalStatusName"].ToString(),

                });

            }
            return ApprovalStatus;
        }
        public List<TptRevision> TptRevisionddl()
        {
            cmd = new SqlCommand("select RevisionID,RevisionName from Lab.TPT_REVISION", con);
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
                    RevisionName = dr["RevisionName"].ToString(),

                });

            }
            return TptRevision;
        }
        public List<TptParameter> TptParameterddl()
            {
                cmd = new SqlCommand("select TPTParameterID,ParameterName from LAb.TPT_PARAMETER", con);
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
                        ParameterName = dr["ParameterName"].ToString(),

                    });

                }
                return TptParameter;
            }
        public List<SugarGodown> SugarGodownddl()
        {
            cmd = new SqlCommand("Select SugarGodownID,GodownNumber from Lab.Sugar_Godown", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SugarGodown> sugarGodown = new List<SugarGodown>();
            foreach (DataRow dr in dt.Rows)
            {
                sugarGodown.Add(new SugarGodown
                {
                    SugarGodownId = Convert.ToInt32(dr["SugarGodownID"]),
                    GodownNumber = dr["GodownNumber"].ToString(),

                });

            }
            return sugarGodown;
        }
        public List<ApprovalStatus> RejectStatus()
        {
            cmd = new SqlCommand("select * from ApprovalStatus where ApprovalStatusName like '%Rejected%' ", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<ApprovalStatus> ApprovalStatus = new List<ApprovalStatus>();
            foreach (DataRow dr in dt.Rows)
            {
                ApprovalStatus.Add(new ApprovalStatus
                {
                    ApprovalStatusID = Convert.ToInt32(dr["ApprovalStatusID"]),
                    ApprovalStatusName = dr["ApprovalStatusName"].ToString(),

                });

            }
            return ApprovalStatus;
        }
        public List<TableMaster> TableMaster() 
        {
            cmd = new SqlCommand("select * from TableName", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TableMaster> tableMaster = new List<TableMaster>();
            foreach (DataRow dr in dt.Rows)
            {
                tableMaster.Add(new TableMaster
                {
                    TableId = Convert.ToInt32(dr["TableId"]),
                    TableName = dr["TableName"].ToString(),

                });

            }
            return tableMaster;
        }
        public List<MolassesTank> MolassesTankddl()
        {
            cmd = new SqlCommand("select MolassesTankID,TankNumber from Lab.MolassesTank", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MolassesTank> molassesTanks = new List<MolassesTank>();
            foreach (DataRow dr in dt.Rows)
            {
                molassesTanks.Add(new MolassesTank
                {
                    MolassesTankId = Convert.ToInt32(dr["MolassesTankID"]),
                    TankNumber = dr["TankNumber"].ToString(),

                });

            }
            return molassesTanks;
        }
      public  List<MenuMaster> MenuMasterddl()
        {

            cmd = new SqlCommand("select ID,MenuName from MenuMaster", user);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<MenuMaster> menuMaster = new List<MenuMaster>();
            foreach (DataRow dr in dt.Rows)
            {
                menuMaster.Add(new MenuMaster
                {
                    MenuID = Convert.ToInt32(dr["ID"]),
                    MenuName = dr["MenuName"].ToString(),

                });

            }
            return menuMaster;
        }
        public List<Role> Roleddl()
        {
            cmd = new SqlCommand("select RoleId,RoleName from Roles", user);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Role> role = new List<Role>();
            foreach (DataRow dr in dt.Rows)
            {
                role.Add(new Role
                {
                    RoleId = Convert.ToInt32(dr["RoleId"]),
                    RoleName = dr["RoleName"].ToString(),

                });

            }
            return role;

        }


        public List<SubMenuMaster> SubMenuMasterddl(string MenuId)
        {

            cmd = new SqlCommand("select SubMenuID,SubMenuName from SubMenuMaster where MenuID=" + MenuId + "", user);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<SubMenuMaster> subMenuMaster = new List<SubMenuMaster>();
            foreach (DataRow dr in dt.Rows)
            {
                subMenuMaster.Add(new SubMenuMaster
                {
                    SubMenuID = Convert.ToInt32(dr["SubMenuID"]),
                    SubMenuName = dr["SubMenuName"].ToString(),

                });

            }
            return subMenuMaster;

        }
        public List<TptPower> TptPowerddl()
        {
            cmd = new SqlCommand("select TPTPowerParameterID,TPTPowerName from Lab.TPT_POWER", con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<TptPower> tptPower = new List<TptPower>();
            foreach (DataRow dr in dt.Rows)
            {
                tptPower.Add(new TptPower
                {
                    TptPowerParameterId = Convert.ToInt32(dr["TPTPowerParameterID"]),
                    TptPowerName = dr["TPTPowerName"].ToString(),

                });

            }
            return tptPower;
        }
       public List<UserRoles> Usersddl(int  unitId)
        {
            if (unitId != 0)
            {
                cmd = new SqlCommand(" Select U.USerID,isnull(U.UnitId,'')UnitId,UR.RoleId,R.RoleName,U.Username+'('+isnull(R.RoleName,'')+')' as USerName from UserUnitMapping UR left outer Join Users U on UR.UserID =U.USerId left Outer Join Roles R on UR.RoleId=R.RoleId where IsActive=1  and UR.UnitId=" + unitId + "", user);

            }

            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            {
                List<UserRoles> user = new List<UserRoles>();
                foreach (DataRow dr in dt.Rows)
                {
                    user.Add(new UserRoles
                    {
                       // UserRoleId = Convert.ToInt32(dr["UserRoleId"]),
                        UserId = Convert.ToInt32(dr["USerID"]),
                        USerName = dr["Username"].ToString(),
                        RoleId = Convert.ToInt32(dr["RoleId"]),
                        RoleName = dr["RoleName"].ToString(),
                        UnitId = Convert.ToInt32(dr["UnitId"])
                    });


                }

                return user;
            }
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
        public TimeSpan DateDiff(DateTime StartDate, DateTime EndDate)
        {
            var startdate = StartDate;
            var Tilldate = EndDate;
            var diffofdate = Tilldate - startdate;
            var Days = diffofdate.Days;
            var Hours = diffofdate.Hours; ;
            var Minuts = diffofdate.Minutes;
            return diffofdate;
        }




    }
}