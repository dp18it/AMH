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
    public class CityDao : AbstractCityDao
    {
       

        public override SuccessResult<AbstractCity> City_Upsert(AbstractCity AbstractCity)
        {
            SuccessResult<AbstractCity> City = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractCity.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractCity.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@State", AbstractCity.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractCity.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractCity.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.City_Upsert, param, commandType: CommandType.StoredProcedure);
                City = task.Read<SuccessResult<AbstractCity>>().SingleOrDefault();
                City.Item = task.Read<City>().SingleOrDefault();
            }

            return City;
        }

        public override SuccessResult<AbstractCity> City_ById(int Id)
        {
            SuccessResult<AbstractCity> City = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.City_ById, param, commandType: CommandType.StoredProcedure);
                City = task.Read<SuccessResult<AbstractCity>>().SingleOrDefault();
                City.Item = task.Read<City>().SingleOrDefault();
            }

            return City;
        }
        public override PagedList<AbstractCity> City_All(PageParam pageParam, string search, int StateId)
        {
            PagedList<AbstractCity> City = new PagedList<AbstractCity>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
           

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.City_All, param, commandType: CommandType.StoredProcedure);
                City.Values.AddRange(task.Read<City>());
                City.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return City;
        }

      

        public override SuccessResult<AbstractCity> City_Delete(int Id, int Deletedby)
        {
            SuccessResult<AbstractCity> City = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.City_Delete, param, commandType: CommandType.StoredProcedure);
                City = task.Read<SuccessResult<AbstractCity>>().SingleOrDefault();
                City.Item = task.Read<City>().SingleOrDefault();
            }

            return City;
        }
        public override SuccessResult<AbstractCity> City_ActInact(int Id, int Updatedby)
        {
            SuccessResult<AbstractCity> City = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.City_ActInact, param, commandType: CommandType.StoredProcedure);
                City = task.Read<SuccessResult<AbstractCity>>().SingleOrDefault();
                City.Item = task.Read<City>().SingleOrDefault();
            }

            return City;
        }
    }
}
