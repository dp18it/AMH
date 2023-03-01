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
    public class CategoryDao : AbstractCategoryDao
    {

    
        public override SuccessResult<AbstractCategory> Category_Upsert(AbstractCategory AbstractCategory)
        {
            SuccessResult<AbstractCategory> Category = null;
            var param = new DynamicParameters();

            param.Add("@Category_Id", AbstractCategory.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractCategory.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Description", AbstractCategory.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractCategory.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractCategory.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Category_Upsert, param, commandType: CommandType.StoredProcedure);
                Category = task.Read<SuccessResult<AbstractCategory>>().SingleOrDefault();
                Category.Item = task.Read<Category>().SingleOrDefault();
            }

            return Category;
        }

        public override SuccessResult<AbstractCategory> Category_ById(int Category_Id)
        {
            SuccessResult<AbstractCategory> Category = null;
            var param = new DynamicParameters();

            param.Add("@Category_Id",Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Category_ById, param, commandType: CommandType.StoredProcedure);
                Category = task.Read<SuccessResult<AbstractCategory>>().SingleOrDefault();
                Category.Item = task.Read<Category>().SingleOrDefault();
            }

            return Category;
        }

        public override SuccessResult<AbstractCategory> Category_Delete(int Category_Id,int Deletedby)
        {
            SuccessResult<AbstractCategory> Category = null;
            var param = new DynamicParameters();

            param.Add("@Category_Id", Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Category_Delete, param, commandType: CommandType.StoredProcedure);
                Category = task.Read<SuccessResult<AbstractCategory>>().SingleOrDefault();
                Category.Item = task.Read<Category>().SingleOrDefault();
            }

            return Category;
        }


        public override PagedList<AbstractCategory> Category_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            PagedList<AbstractCategory> Category = new PagedList<AbstractCategory>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Category_All, param, commandType: CommandType.StoredProcedure);
                Category.Values.AddRange(task.Read<Category>());
                Category.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Category;
        }

        public override SuccessResult<AbstractCategory> Category_ActInact(int Category_Id, int Updatedby)
        {
            SuccessResult<AbstractCategory> Category = null;
            var param = new DynamicParameters();

            param.Add("@Category_Id", Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Category_ActInact, param, commandType: CommandType.StoredProcedure);
                Category = task.Read<SuccessResult<AbstractCategory>>().SingleOrDefault();
                Category.Item = task.Read<Category>().SingleOrDefault();
            }

            return Category;
        }


        
    }
}
