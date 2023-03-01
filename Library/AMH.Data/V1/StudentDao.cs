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
    public class StudentDao : AbstractStudentDao
    {
        public override SuccessResult<AbstractStudent> Student_Upsert(AbstractStudent AbstractStudent)
        {
            SuccessResult<AbstractStudent> Address = null;
            var param = new DynamicParameters();

            param.Add("@StudentId", AbstractStudent.StudentId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractStudent.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DepartmentId", AbstractStudent.DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Gender", AbstractStudent.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Phone", AbstractStudent.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Student_Upsert, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractStudent>>().SingleOrDefault();
                Address.Item = task.Read<Student>().SingleOrDefault();
            }

            return Address;
        }


        public override PagedList<AbstractStudent> Student_All(PageParam pageParam, string search,int DepartmentId)
        {
            PagedList<AbstractStudent> Address = new PagedList<AbstractStudent>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Student_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<Student>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }


        public override SuccessResult<AbstractStudent> Student_ById(int StudentId)
        {
            SuccessResult<AbstractStudent> Address = null;
            var param = new DynamicParameters();

            param.Add("@StudentId", StudentId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Student_ById, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractStudent>>().SingleOrDefault();
                Address.Item = task.Read<Student>().SingleOrDefault();
            }

            return Address;
        }


        public override SuccessResult<AbstractStudent> Student_Delete(int StudentId)
        {
            SuccessResult<AbstractStudent> Address = null;
            var param = new DynamicParameters();

            param.Add("@StudentId", StudentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Student_Delete, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractStudent>>().SingleOrDefault();
                Address.Item = task.Read<Student>().SingleOrDefault();
            }

            return Address;
        }
    }
    public class DepartmentDao : AbstractDepartmentDao
    {
        public override PagedList<AbstractDepartment> Department_All(PageParam pageParam, string search)
        {
            PagedList<AbstractDepartment> Address = new PagedList<AbstractDepartment>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Department_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<Department>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }
}
