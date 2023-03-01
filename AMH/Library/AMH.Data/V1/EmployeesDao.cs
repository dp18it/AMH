using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Data.Contract;
using AMH.Entities.Contract;
using AMH.Entities.V1;
using Dapper;

namespace AMH.Data.V1
{
    public class EmployeesDao : AbstractEmployeesDao
    {
        public override SuccessResult<AbstractEmployees> Employees_Upsert(AbstractEmployees AbstractEmployees)
        {
            SuccessResult<AbstractEmployees> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractEmployees.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@EmployeeName", AbstractEmployees.EmployeeName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DOB", AbstractEmployees.DOB, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", AbstractEmployees.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PhoneNumber", AbstractEmployees.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CountryId", AbstractEmployees.CountryId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@StateId", AbstractEmployees.StateId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CityId", AbstractEmployees.CityId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", AbstractEmployees.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", AbstractEmployees.UpdatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Employees_Upsert, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractEmployees>>().SingleOrDefault();
                Address.Item = task.Read<Employees>().SingleOrDefault();
            }

            return Address;
        }


        public override PagedList<AbstractEmployees> Employees_All(PageParam pageParam, string search)
        {
            PagedList<AbstractEmployees> Address = new PagedList<AbstractEmployees>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Employees_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<Employees>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }


        public override SuccessResult<AbstractEmployees> Employees_ById(long Id)
        {
            SuccessResult<AbstractEmployees> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Employees_ById, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractEmployees>>().SingleOrDefault();
                Address.Item = task.Read<Employees>().SingleOrDefault();
            }

            return Address;
        }


        public override SuccessResult<AbstractEmployees> Employees_ActInAct(long Id)
        {
            SuccessResult<AbstractEmployees> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Employees_ActInAct, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractEmployees>>().SingleOrDefault();
                Address.Item = task.Read<Employees>().SingleOrDefault();
            }

            return Address;
        }

        public override SuccessResult<AbstractEmployees> Employees_Delete(long Id, long DeletedBy)
        {
            SuccessResult<AbstractEmployees> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Employees_Delete, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractEmployees>>().SingleOrDefault();
                Address.Item = task.Read<Employees>().SingleOrDefault();
            }

            return Address;
        }
    }
    public class MasterEmCountryDao : AbstractMasterEmCountryDao
    {
        public override PagedList<AbstractMasterEmCountry> MasterCountry_All(PageParam pageParam, string search)
        {
            PagedList<AbstractMasterEmCountry> Address = new PagedList<AbstractMasterEmCountry>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterCountry_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterEmCountry>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }

    public class MasterEmStateDao : AbstractMasterEmStateDao
    {
        public override PagedList<AbstractMasterEmState> MasterState_All(PageParam pageParam, string search, long CountryId)
        {
            PagedList<AbstractMasterEmState> Address = new PagedList<AbstractMasterEmState>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CountryId", CountryId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterState_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterEmState>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }

    public class MasterEmCityDao : AbstractMasterEmCityDao
    {
        public override PagedList<AbstractMasterEmCity> MasterCity_All(PageParam pageParam, string search, long StateId)
        {
            PagedList<AbstractMasterEmCity> Address = new PagedList<AbstractMasterEmCity>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", StateId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterCity_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterEmCity>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }



}
