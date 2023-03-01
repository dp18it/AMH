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
    public class ProductDao : AbstractProductDao
    {

    
        public override SuccessResult<AbstractProduct> Product_Upsert(AbstractProduct AbstractProduct)
        {
            SuccessResult<AbstractProduct> Product = null;
            var param = new DynamicParameters();

            param.Add("@Product_Id", AbstractProduct.Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractProduct.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Description", AbstractProduct.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Price", AbstractProduct.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("@Quantity", AbstractProduct.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Image", AbstractProduct.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExtraImage1", AbstractProduct.ExtraImage1, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExtraImage2", AbstractProduct.ExtraImage2, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExtraImage3", AbstractProduct.ExtraImage3, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Subcat_Id", AbstractProduct.Subcat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractProduct.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractProduct.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Product_Upsert, param, commandType: CommandType.StoredProcedure);
                Product = task.Read<SuccessResult<AbstractProduct>>().SingleOrDefault();
                Product.Item = task.Read<Product>().SingleOrDefault();
            }

            return Product;
        }

        public override SuccessResult<AbstractProduct> Product_ById(int Product_Id,int Users_Id)
        {
            SuccessResult<AbstractProduct> Product = null;
            var param = new DynamicParameters();

            param.Add("@Product_Id",Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Users_Id", Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Product_ById, param, commandType: CommandType.StoredProcedure);
                Product = task.Read<SuccessResult<AbstractProduct>>().SingleOrDefault();
                Product.Item = task.Read<Product>().SingleOrDefault();
            }

            return Product;
        }

        public override SuccessResult<AbstractProduct> Product_Delete(int Product_Id,int Deletedby)
        {
            SuccessResult<AbstractProduct> Product = null;
            var param = new DynamicParameters();

            param.Add("@Product_Id", Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Product_Delete, param, commandType: CommandType.StoredProcedure);
                Product = task.Read<SuccessResult<AbstractProduct>>().SingleOrDefault();
                Product.Item = task.Read<Product>().SingleOrDefault();
            }

            return Product;
        }


        public override PagedList<AbstractProduct> Product_All(PageParam pageParam, string search,int IsVisibleAll, int Cat_Id,int Users_Id,int Subcat_Id,int FromPrice,int ToPrice)
        {
            PagedList<AbstractProduct> Product = new PagedList<AbstractProduct>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Cat_Id", Cat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Users_Id", Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Subcat_Id", Subcat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FromPrice", FromPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ToPrice", ToPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Product_All, param, commandType: CommandType.StoredProcedure);
                Product.Values.AddRange(task.Read<Product>());
                Product.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Product;
        }

        public override SuccessResult<AbstractProduct> Product_ActInact(int Product_Id, int Updatedby)
        {
            SuccessResult<AbstractProduct> Product = null;
            var param = new DynamicParameters();

            param.Add("@Product_Id", Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Product_ActInact, param, commandType: CommandType.StoredProcedure);
                Product = task.Read<SuccessResult<AbstractProduct>>().SingleOrDefault();
                Product.Item = task.Read<Product>().SingleOrDefault();
            }

            return Product;
        }


        
    }
}
