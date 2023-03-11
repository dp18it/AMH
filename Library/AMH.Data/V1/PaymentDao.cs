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
    public class PaymentDao : AbstractPaymentDao
    {
        //public override SuccessResult<AbstractPayment> Payment_ById(int Payment_Id)
        //{
        //    SuccessResult<AbstractPayment> Payment = null;
        //    var param = new DynamicParameters();

        //    param.Add("@Payment_Id", Payment_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.Payment_ById, param, commandType: CommandType.StoredProcedure);
        //        Payment = task.Read<SuccessResult<AbstractPayment>>().SingleOrDefault();
        //        Payment.Item = task.Read<Payment>().SingleOrDefault();
        //    }

        //    return Payment;
        //}
        public override PagedList<AbstractPayment> Payment_All(PageParam pageParam, string search,int User_Id, string FromDate, string ToDate)
        {
            PagedList<AbstractPayment> Payment = new PagedList<AbstractPayment>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@User_Id", User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FromDate", FromDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ToDate", ToDate, dbType: DbType.String, direction: ParameterDirection.Input);


            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Payment_All, param, commandType: CommandType.StoredProcedure);
                Payment.Values.AddRange(task.Read<Payment>());
                Payment.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Payment;
        }

        public override SuccessResult<AbstractPayment> Payment_ActInact(int Payment_Id, int Updatedby)
        {
            SuccessResult<AbstractPayment> Payment = null;
            var param = new DynamicParameters();

            param.Add("@Payment_Id", Payment_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Payment_ActInact, param, commandType: CommandType.StoredProcedure);
                Payment = task.Read<SuccessResult<AbstractPayment>>().SingleOrDefault();
                Payment.Item = task.Read<Payment>().SingleOrDefault();
            }

            return Payment;
        }

        //public override SuccessResult<AbstractPayment> Payment_Delete(int Payment_Id, int Deletedby)
        //{
        //    SuccessResult<AbstractPayment> Payment = null;
        //    var param = new DynamicParameters();

        //    param.Add("@Payment_Id", Payment_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.Payment_Delete, param, commandType: CommandType.StoredProcedure);
        //        Payment = task.Read<SuccessResult<AbstractPayment>>().SingleOrDefault();
        //        Payment.Item = task.Read<Payment>().SingleOrDefault();
        //    }

        //    return Payment;
        //}

    }
}
