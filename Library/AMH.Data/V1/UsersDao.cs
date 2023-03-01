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
    public class UsersDao : AbstractUsersDao
    {

        public override bool User_SignOut()
        {
            bool result = false;
            var param = new DynamicParameters();

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.User_SignOut, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;

        }
        public override SuccessResult<AbstractUsers> User_SignIn(string Email, string Password)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.User_SignIn, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }

        public override SuccessResult<AbstractUsers> Users_Upsert(AbstractUsers AbstractUsers)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Users_Id", AbstractUsers.Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", AbstractUsers.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", AbstractUsers.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Image", AbstractUsers.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", AbstractUsers.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", AbstractUsers.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ContactNo", AbstractUsers.ContactNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@BirthDate", AbstractUsers.BirthDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("@CityId", AbstractUsers.CityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StateId", AbstractUsers.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Pincode", AbstractUsers.Pincode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Address", AbstractUsers.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Addressline2", AbstractUsers.Addressline2, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractUsers.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_Upsert, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }

        public override SuccessResult<AbstractUsers> Users_ById(int Users_Id)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Users_Id",Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ById, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }

        public override SuccessResult<AbstractUsers> Users_Delete(int Users_Id,int Deletedby)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Id", Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_Delete, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }


        public override PagedList<AbstractUsers> Users_All(PageParam pageParam, string search,int CityId,int StateId,int IsVisibleAll,string FromDate,string ToDate)
        {
            PagedList<AbstractUsers> Users = new PagedList<AbstractUsers>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CityId", CityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StateId", StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FromDate", FromDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ToDate", ToDate, dbType: DbType.String, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_All, param, commandType: CommandType.StoredProcedure);
                Users.Values.AddRange(task.Read<Users>());
                Users.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Users;
        }

        public override SuccessResult<AbstractUsers> Users_ActInact(int Users_Id, int Updatedby)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Id", Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ActInact, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }
        public override SuccessResult<AbstractUsers> Users_ChangePassword(int Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OldPassword", OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@NewPassword", NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ChangePassword, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }
        
             public override SuccessResult<AbstractUsers> Users_ForgotPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@NewPassword", NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ForgotPassword, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }
        
        public override SuccessResult<AbstractUsers> Users_ResetPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@NewPassword", NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ResetPassword, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }
        public override SuccessResult<AbstractUsers> Users_CheckEmailExists(string Email)
        {
            SuccessResult<AbstractUsers> Users = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_CheckEmailExists, param, commandType: CommandType.StoredProcedure);
                Users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                Users.Item = task.Read<Users>().SingleOrDefault();
            }

            return Users;
        }

    }
}
