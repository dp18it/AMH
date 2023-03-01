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
    public class CustomerDao : AbstractCustomerDao
    {
        public override SuccessResult<AbstractCustomer> Customer_Upsert(AbstractCustomer AbstractCustomer)
        {
            SuccessResult<AbstractCustomer> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractCustomer.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CustomerName", AbstractCustomer.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DOB", AbstractCustomer.DOB, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", AbstractCustomer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PhoneNumber", AbstractCustomer.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CountryId", AbstractCustomer.CountryId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@StateId", AbstractCustomer.StateId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CityId", AbstractCustomer.CityId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", AbstractCustomer.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", AbstractCustomer.UpdatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Customer_Upsert, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                Address.Item = task.Read<Customer>().SingleOrDefault();
            }

            return Address;
        }


        public override PagedList<AbstractCustomer> Customer_All(PageParam pageParam, string search)
        {
            PagedList<AbstractCustomer> Address = new PagedList<AbstractCustomer>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Customer_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<Customer>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }


        public override SuccessResult<AbstractCustomer> Customer_ById(long Id)
        {
            SuccessResult<AbstractCustomer> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Customer_ById, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                Address.Item = task.Read<Customer>().SingleOrDefault();
            }

            return Address;
        }


        public override SuccessResult<AbstractCustomer> Customer_ActInAct(long Id)
        {
            SuccessResult<AbstractCustomer> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Customer_ActInAct, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                Address.Item = task.Read<Customer>().SingleOrDefault();
            }

            return Address;
        }

        public override SuccessResult<AbstractCustomer> Customer_Delete(long Id, long DeletedBy)
        {
            SuccessResult<AbstractCustomer> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Customer_Delete, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                Address.Item = task.Read<Customer>().SingleOrDefault();
            }

            return Address;
        }
    }
    public class MasterCountryDao : AbstractMasterCountryDao
    {
        public override PagedList<AbstractMasterCountry> MasterCountry_All(PageParam pageParam, string search)
        {
            PagedList<AbstractMasterCountry> Address = new PagedList<AbstractMasterCountry>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterCountry_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterCountry>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }

    public class MasterStateDao : AbstractMasterStateDao
    {
        public override PagedList<AbstractMasterState> MasterState_All(PageParam pageParam, string search,long CountryId)
        {
            PagedList<AbstractMasterState> Address = new PagedList<AbstractMasterState>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CountryId", CountryId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterState_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterState>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }

    public class MasterCityDao : AbstractMasterCityDao
    {
        public override PagedList<AbstractMasterCity> MasterCity_All(PageParam pageParam, string search,long StateId)
        {
            PagedList<AbstractMasterCity> Address = new PagedList<AbstractMasterCity>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", StateId, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterCity_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterCity>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }



}
