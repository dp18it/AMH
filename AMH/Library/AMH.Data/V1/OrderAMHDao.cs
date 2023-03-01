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
    public class OrderAMHDao : AbstractOrderAMHDao
    {

    
        public override SuccessResult<AbstractOrderAMH> OrderAMH_Upsert(AbstractOrderAMH AbstractOrderAMH)
        {
            SuccessResult<AbstractOrderAMH> OrderAMH = null;
            var param = new DynamicParameters();

            param.Add("@Order_Id", AbstractOrderAMH.Order_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Order_Date", AbstractOrderAMH.Order_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("@TotalAmount", AbstractOrderAMH.TotalAmount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OrderStatus", AbstractOrderAMH.OrderStatus, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            param.Add("@PaymentStatus", AbstractOrderAMH.PaymentStatus, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            param.Add("@Cart_Id", AbstractOrderAMH.Cart_Id, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractOrderAMH.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractOrderAMH.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderAMH_Upsert, param, commandType: CommandType.StoredProcedure);
                OrderAMH = task.Read<SuccessResult<AbstractOrderAMH>>().SingleOrDefault();
                OrderAMH.Item = task.Read<OrderAMH>().SingleOrDefault();
            }

            return OrderAMH;
        }

        public override SuccessResult<AbstractOrderAMH> OrderAMH_ById(int Order_Id)
        {
            SuccessResult<AbstractOrderAMH> OrderAMH = null;
            var param = new DynamicParameters();

            param.Add("@Order_Id",Order_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderAMH_ById, param, commandType: CommandType.StoredProcedure);
                OrderAMH = task.Read<SuccessResult<AbstractOrderAMH>>().SingleOrDefault();
                OrderAMH.Item = task.Read<OrderAMH>().SingleOrDefault();
            }

            return OrderAMH;
        }

        public override SuccessResult<AbstractOrderAMH> OrderAMH_Delete(int Order_Id,int Deletedby)
        {
            SuccessResult<AbstractOrderAMH> OrderAMH = null;
            var param = new DynamicParameters();

            param.Add("@Order_Id", Order_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderAMH_Delete, param, commandType: CommandType.StoredProcedure);
                OrderAMH = task.Read<SuccessResult<AbstractOrderAMH>>().SingleOrDefault();
                OrderAMH.Item = task.Read<OrderAMH>().SingleOrDefault();
            }

            return OrderAMH;
        }


        public override PagedList<AbstractOrderAMH> OrderAMH_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            PagedList<AbstractOrderAMH> OrderAMH = new PagedList<AbstractOrderAMH>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderAMH_All, param, commandType: CommandType.StoredProcedure);
                OrderAMH.Values.AddRange(task.Read<OrderAMH>());
                OrderAMH.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return OrderAMH;
        }

        public override SuccessResult<AbstractOrderAMH> OrderAMH_ActInact(int Order_Id, int Updatedby)
        {
            SuccessResult<AbstractOrderAMH> OrderAMH = null;
            var param = new DynamicParameters();

            param.Add("@Order_Id", Order_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderAMH_ActInact, param, commandType: CommandType.StoredProcedure);
                OrderAMH = task.Read<SuccessResult<AbstractOrderAMH>>().SingleOrDefault();
                OrderAMH.Item = task.Read<OrderAMH>().SingleOrDefault();
            }

            return OrderAMH;
        }


        
    }
}
