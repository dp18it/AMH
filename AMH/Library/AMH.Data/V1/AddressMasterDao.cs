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
    public class AddressMasterDao : AbstractAddressMasterDao
    {
        public override SuccessResult<AbstractAddressMaster> AddressMaster_Upsert(AbstractAddressMaster AbstractAddressMaster)
        {
            SuccessResult<AbstractAddressMaster> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractAddressMaster.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@LocationName", AbstractAddressMaster.LocationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AddressLine1", AbstractAddressMaster.AddressLine1, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AddressLine2", AbstractAddressMaster.AddressLine2, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PinCode", AbstractAddressMaster.PinCode, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CityMasterId", AbstractAddressMaster.CityMasterId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@StateMasterId", AbstractAddressMaster.StateMasterId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CountryMasterId", AbstractAddressMaster.CountryMasterId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UserId", AbstractAddressMaster.UserId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@AdminId", AbstractAddressMaster.AdminId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Latitude", AbstractAddressMaster.Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Longitute", AbstractAddressMaster.Longitute, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AddressMaster_Upsert, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAddressMaster>>().SingleOrDefault();
                Address.Item = task.Read<AddressMaster>().SingleOrDefault();
            }

            return Address;
        }

        public override PagedList<AbstractAddressMaster> AddressMaster_ByUserId(PageParam pageParam, string search, long UserId)
        {
            PagedList<AbstractAddressMaster> Address = new PagedList<AbstractAddressMaster>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@UserId", UserId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AddressMaster_ByUserId, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<AddressMaster>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
        public override PagedList<AbstractAddressMaster> AddressMaster_All(PageParam pageParam, string search)
        {
            PagedList<AbstractAddressMaster> Address = new PagedList<AbstractAddressMaster>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AddressMaster_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<AddressMaster>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }


        public override SuccessResult<AbstractAddressMaster> AddressMaster_ById(long Id)
        {
            SuccessResult<AbstractAddressMaster> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AddressMaster_ById, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAddressMaster>>().SingleOrDefault();
                Address.Item = task.Read<AddressMaster>().SingleOrDefault();
            }

            return Address;
        }


        public override SuccessResult<AbstractAddressMaster> AddressMaster_ActInAct(long Id, long UpdatedBy)
        {
            SuccessResult<AbstractAddressMaster> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", UpdatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AddressMaster_ActInAct, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAddressMaster>>().SingleOrDefault();
                Address.Item = task.Read<AddressMaster>().SingleOrDefault();
            }

            return Address;
        }

        public override SuccessResult<AbstractAddressMaster> AddressMaster_Delete(long Id, long DeletedBy)
        {
            SuccessResult<AbstractAddressMaster> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AddressMaster_Delete, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAddressMaster>>().SingleOrDefault();
                Address.Item = task.Read<AddressMaster>().SingleOrDefault();
            }

            return Address;
        }
    }

    public class CityMasterDao : AbstractCityMasterDao
    {
        public override PagedList<AbstractCityMaster> CityMaster_ByStateMasterId(PageParam pageParam, string search, long StateMasterId)
        {
            PagedList<AbstractCityMaster> Address = new PagedList<AbstractCityMaster>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateMasterId", StateMasterId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CityMaster_ByStateMasterId, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<CityMaster>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }

    public class StateMasterDao : AbstractStateMasterDao
    {
        public override PagedList<AbstractStateMaster> StateMaster_ByCountryMasterId(PageParam pageParam, string search, long CountryMasterId)
        {
            PagedList<AbstractStateMaster> Address = new PagedList<AbstractStateMaster>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CountryMasterId", CountryMasterId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StateMaster_ByCountryMasterId, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<StateMaster>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }

    public class CountryMasterDao : AbstractCountryMasterDao
    {
        public override PagedList<AbstractCountryMaster> CountryMaster_All(PageParam pageParam, string search)
        {
            PagedList<AbstractCountryMaster> Address = new PagedList<AbstractCountryMaster>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CountryMaster_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<CountryMaster>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }
}
