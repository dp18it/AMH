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
            param.Add("@User_Id", AbstractOrderAMH.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TotalAmout", AbstractOrderAMH.TotalAmout, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PaymentStatus", AbstractOrderAMH.PaymentStatus, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            param.Add("@ProIds", AbstractOrderAMH.ProIds, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Quantities", AbstractOrderAMH.Quantities, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Prices", AbstractOrderAMH.Prices, dbType: DbType.String, direction: ParameterDirection.Input);
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

        


        public override PagedList<AbstractOrderAMH> OrderAMH_All(PageParam pageParam, string search,int IsVisibleAll,int Users_Id, string FromDate, string ToDate)
        {
            PagedList<AbstractOrderAMH> OrderAMH = new PagedList<AbstractOrderAMH>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Users_Id", Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FromDate", FromDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ToDate", ToDate, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderAMH_All, param, commandType: CommandType.StoredProcedure);
                OrderAMH.Values.AddRange(task.Read<OrderAMH>());
                OrderAMH.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return OrderAMH;
        }
        
        public override PagedList<AbstractOrderAMH> Product_Allbyorder(PageParam pageParam, string search, string prices, string qunts, string ProductIds)
        {
            PagedList<AbstractOrderAMH> OrderAMH = new PagedList<AbstractOrderAMH>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@prices", prices, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@qunts", qunts, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ProductIds", ProductIds, dbType: DbType.String, direction: ParameterDirection.Input);


            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Product_Allbyorder, param, commandType: CommandType.StoredProcedure);
                OrderAMH.Values.AddRange(task.Read<OrderAMH>());
                OrderAMH.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return OrderAMH;
        }

        public override SuccessResult<AbstractOrderAMH> MasterOrderStatus_Update(int Order_Id, int Status_Id)
        {
            SuccessResult<AbstractOrderAMH> OrderAMH = null;
            var param = new DynamicParameters();

            param.Add("@Order_Id", Order_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Status_Id", Status_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterOrderStatus_Update, param, commandType: CommandType.StoredProcedure);
                OrderAMH = task.Read<SuccessResult<AbstractOrderAMH>>().SingleOrDefault();
                OrderAMH.Item = task.Read<OrderAMH>().SingleOrDefault();
            }

            return OrderAMH;
        }


        
    }
}
