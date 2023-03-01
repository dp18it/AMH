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
    public class WishlistDao : AbstractWishlistDao
    {

    
        public override SuccessResult<AbstractWishlist> Wishlist_Upsert(AbstractWishlist AbstractWishlist)
        {
            SuccessResult<AbstractWishlist> Wishlist = null;
            var param = new DynamicParameters();

            param.Add("@Wish_Id", AbstractWishlist.Wish_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Product_Id", AbstractWishlist.Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Users_Id", AbstractWishlist.Users_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Wishlist_Upsert, param, commandType: CommandType.StoredProcedure);
                Wishlist = task.Read<SuccessResult<AbstractWishlist>>().SingleOrDefault();
                Wishlist.Item = task.Read<Wishlist>().SingleOrDefault();
            }

            return Wishlist;
        }

        public override SuccessResult<AbstractWishlist> Wishlist_ById(int Wish_Id)
        {
            SuccessResult<AbstractWishlist> Wishlist = null;
            var param = new DynamicParameters();

            param.Add("@Wish_Id",Wish_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Wishlist_ById, param, commandType: CommandType.StoredProcedure);
                Wishlist = task.Read<SuccessResult<AbstractWishlist>>().SingleOrDefault();
                Wishlist.Item = task.Read<Wishlist>().SingleOrDefault();
            }

            return Wishlist;
        }

        public override SuccessResult<AbstractWishlist> Wishlist_Delete(int Wish_Id,int Deletedby)
        {
            SuccessResult<AbstractWishlist> Wishlist = null;
            var param = new DynamicParameters();

            param.Add("@Wish_Id", Wish_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Wishlist_Delete, param, commandType: CommandType.StoredProcedure);
                Wishlist = task.Read<SuccessResult<AbstractWishlist>>().SingleOrDefault();
                Wishlist.Item = task.Read<Wishlist>().SingleOrDefault();
            }

            return Wishlist;
        }


        public override PagedList<AbstractWishlist> Wishlist_All(PageParam pageParam, string search, int Users_Id)
        {
            PagedList<AbstractWishlist> Wishlist = new PagedList<AbstractWishlist>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Users_Id", Users_Id, dbType: DbType.String, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Wishlist_All, param, commandType: CommandType.StoredProcedure);
                Wishlist.Values.AddRange(task.Read<Wishlist>());
                Wishlist.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Wishlist;
        }


        
    }
}
