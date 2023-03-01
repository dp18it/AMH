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
    public class StateDao : AbstractStateDao
    {
       

        public override SuccessResult<AbstractState> State_Upsert(AbstractState AbstractState)
        {
            SuccessResult<AbstractState> State = null;
            var param = new DynamicParameters();

            param.Add("@Name", AbstractState.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractState.Createdby, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractState.Updatedby, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.State_Upsert, param, commandType: CommandType.StoredProcedure);
                State = task.Read<SuccessResult<AbstractState>>().SingleOrDefault();
                State.Item = task.Read<State>().SingleOrDefault();
            }

            return State;
        }

        public override SuccessResult<AbstractState> State_ById(int Id)
        {
            SuccessResult<AbstractState> State = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.State_ById, param, commandType: CommandType.StoredProcedure);
                State = task.Read<SuccessResult<AbstractState>>().SingleOrDefault();
                State.Item = task.Read<State>().SingleOrDefault();
            }

            return State;
        }
        public override PagedList<AbstractState> State_All(PageParam pageParam, string search )
        {
            PagedList<AbstractState> State = new PagedList<AbstractState>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
           

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.State_All, param, commandType: CommandType.StoredProcedure);
                State.Values.AddRange(task.Read<State>());
                State.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return State;
        }

      

        public override SuccessResult<AbstractState> State_Delete(int Id, int Deletedby)
        {
            SuccessResult<AbstractState> State = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.State_Delete, param, commandType: CommandType.StoredProcedure);
                State = task.Read<SuccessResult<AbstractState>>().SingleOrDefault();
                State.Item = task.Read<State>().SingleOrDefault();
            }

            return State;
        }
        public override SuccessResult<AbstractState> State_ActInact(int Id, int Updatedby)
        {
            SuccessResult<AbstractState> State = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.State_ActInact, param, commandType: CommandType.StoredProcedure);
                State = task.Read<SuccessResult<AbstractState>>().SingleOrDefault();
                State.Item = task.Read<State>().SingleOrDefault();
            }

            return State;
        }

    }
}
