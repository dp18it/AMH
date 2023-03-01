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
    public class FeedbackDao : AbstractFeedbackDao
    {

    
        public override SuccessResult<AbstractFeedback> Feedback_Upsert(AbstractFeedback AbstractFeedback)
        {
            SuccessResult<AbstractFeedback> Feedback = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractFeedback.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FeedBack", AbstractFeedback.FeedBack, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@User_Id", AbstractFeedback.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Product_Id", AbstractFeedback.Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractFeedback.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Feedback_Upsert, param, commandType: CommandType.StoredProcedure);
                Feedback = task.Read<SuccessResult<AbstractFeedback>>().SingleOrDefault();
                Feedback.Item = task.Read<Feedback>().SingleOrDefault();
            }

            return Feedback;
        }

        public override SuccessResult<AbstractFeedback> Feedback_ById(int Id)
        {
            SuccessResult<AbstractFeedback> Feedback = null;
            var param = new DynamicParameters();

            param.Add("@Id",Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Feedback_ById, param, commandType: CommandType.StoredProcedure);
                Feedback = task.Read<SuccessResult<AbstractFeedback>>().SingleOrDefault();
                Feedback.Item = task.Read<Feedback>().SingleOrDefault();
            }

            return Feedback;
        }

        public override SuccessResult<AbstractFeedback> Feedback_Delete(int Id,int Deletedby)
        {
            SuccessResult<AbstractFeedback> Feedback = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Feedback_Delete, param, commandType: CommandType.StoredProcedure);
                Feedback = task.Read<SuccessResult<AbstractFeedback>>().SingleOrDefault();
                Feedback.Item = task.Read<Feedback>().SingleOrDefault();
            }

            return Feedback;
        }


        public override PagedList<AbstractFeedback> Feedback_All(PageParam pageParam, string search, int user_id, int product_id, string FromDate, string ToDate)
        {
            PagedList<AbstractFeedback> Feedback = new PagedList<AbstractFeedback>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@userid", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ProductId", product_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FromDate", FromDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ToDate", ToDate, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Feedback_All, param, commandType: CommandType.StoredProcedure);
                Feedback.Values.AddRange(task.Read<Feedback>());
                Feedback.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Feedback;
        }

        
    }
}
