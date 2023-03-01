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
    public class SubCategoryDao : AbstractSubCategoryDao
    {

    
        public override SuccessResult<AbstractSubCategory> SubCategory_Upsert(AbstractSubCategory AbstractSubCategory)
        {
            SuccessResult<AbstractSubCategory> SubCategory = null;
            var param = new DynamicParameters();

            param.Add("@Subcat_Id", AbstractSubCategory.Subcat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractSubCategory.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Description", AbstractSubCategory.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Category_Id", AbstractSubCategory.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractSubCategory.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractSubCategory.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubCategory_Upsert, param, commandType: CommandType.StoredProcedure);
                SubCategory = task.Read<SuccessResult<AbstractSubCategory>>().SingleOrDefault();
                SubCategory.Item = task.Read<SubCategory>().SingleOrDefault();
            }

            return SubCategory;
        }

        public override SuccessResult<AbstractSubCategory> SubCategory_ById(int Subcat_Id)
        {
            SuccessResult<AbstractSubCategory> SubCategory = null;
            var param = new DynamicParameters();

            param.Add("@Subcat_Id",Subcat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubCategory_ById, param, commandType: CommandType.StoredProcedure);
                SubCategory = task.Read<SuccessResult<AbstractSubCategory>>().SingleOrDefault();
                SubCategory.Item = task.Read<SubCategory>().SingleOrDefault();
            }

            return SubCategory;
        }

        public override SuccessResult<AbstractSubCategory> SubCategory_Delete(int Subcat_Id,int Deletedby)
        {
            SuccessResult<AbstractSubCategory> SubCategory = null;
            var param = new DynamicParameters();

            param.Add("@Subcat_Id", Subcat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubCategory_Delete, param, commandType: CommandType.StoredProcedure);
                SubCategory = task.Read<SuccessResult<AbstractSubCategory>>().SingleOrDefault();
                SubCategory.Item = task.Read<SubCategory>().SingleOrDefault();
            }

            return SubCategory;
        }


        public override PagedList<AbstractSubCategory> SubCategory_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            PagedList<AbstractSubCategory> SubCategory = new PagedList<AbstractSubCategory>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubCategory_All, param, commandType: CommandType.StoredProcedure);
                SubCategory.Values.AddRange(task.Read<SubCategory>());
                SubCategory.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return SubCategory;
        }

        public override SuccessResult<AbstractSubCategory> SubCategory_ActInact(int Subcat_Id, int Updatedby)
        {
            SuccessResult<AbstractSubCategory> SubCategory = null;
            var param = new DynamicParameters();

            param.Add("@Subcat_Id", Subcat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubCategory_ActInact, param, commandType: CommandType.StoredProcedure);
                SubCategory = task.Read<SuccessResult<AbstractSubCategory>>().SingleOrDefault();
                SubCategory.Item = task.Read<SubCategory>().SingleOrDefault();
            }

            return SubCategory;
        }


        
    }
}
