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
    public class AdminDao : AbstractAdminDao
    {
        public override bool Admin_SignOut()
        {
            bool result = false;
            var param = new DynamicParameters();

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Admin_SignOut, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;

        }
        public override SuccessResult<AbstractAdmin> Admin_SignIn(string Email, string Password)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_SignIn, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_Upsert(AbstractAdmin AbstractAdmin)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Admin_Id", AbstractAdmin.Admin_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Email", AbstractAdmin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", AbstractAdmin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ContactNo", AbstractAdmin.ContactNo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractAdmin.Createdby, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractAdmin.Updatedby, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_Upsert, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_ById(int Admin_Id)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Admin_Id", Admin_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_ById, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }
        public override PagedList<AbstractAdmin> Admin_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            PagedList<AbstractAdmin> Admin = new PagedList<AbstractAdmin>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
           

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_All, param, commandType: CommandType.StoredProcedure);
                Admin.Values.AddRange(task.Read<Admin>());
                Admin.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_ActInact(int Admin_Id, int Updatedby)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Admin_Id", Admin_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_ActInact, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_Delete(int Admin_Id, int Deletedby)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Admin_Id", Admin_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_Delete, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }
        public override SuccessResult<AbstractAdmin> Home_All()
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            //param.Add("@Admin_Id", Admin_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Home_All, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_ChangePassword(int Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            SuccessResult<AbstractAdmin> Users = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OldPassword", OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@NewPassword", NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_ChangePassword, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Users.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Users;
        }

        public override SuccessResult<AbstractAdmin> Admin_ResetPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            SuccessResult<AbstractAdmin> Users = null;
            var param = new DynamicParameters();

            param.Add("@NewPassword", NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ResetPassword, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Users.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Users;
        }

    }
}
