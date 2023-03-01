using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
namespace AMH.Services.Contract
{
    public abstract class AbstractWishlistServices
    {
       
        public abstract SuccessResult<AbstractWishlist> Wishlist_ById(int Wish_Id);
        public abstract PagedList<AbstractWishlist> Wishlist_All(PageParam pageParam, string search, int Users_Id);
        public abstract SuccessResult<AbstractWishlist> Wishlist_Upsert(AbstractWishlist abstractWishlist);
        public abstract SuccessResult<AbstractWishlist> Wishlist_Delete(int Wish_Id, int Deleteby);


    }
}
