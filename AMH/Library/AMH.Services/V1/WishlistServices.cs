using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Data.Contract;
using AMH.Entities.Contract;
using AMH.Services.Contract;

namespace AMH.Services.V1
{
    public class WishlistServices : AbstractWishlistServices
    {
        private AbstractWishlistDao abstractWishlistDao;

        public WishlistServices(AbstractWishlistDao abstractWishlistDao)
        {
            this.abstractWishlistDao = abstractWishlistDao;
        }


        public override SuccessResult<AbstractWishlist> Wishlist_ById(int Wish_Id)
        {
            return this.abstractWishlistDao.Wishlist_ById(Wish_Id);
        }
        public override PagedList<AbstractWishlist> Wishlist_All(PageParam pageParam, string search, int Users_Id)
        {
            return this.abstractWishlistDao.Wishlist_All(pageParam, search, Users_Id);
        }
        public override SuccessResult<AbstractWishlist> Wishlist_Upsert(AbstractWishlist abstractWishlist)
        {
            return this.abstractWishlistDao.Wishlist_Upsert(abstractWishlist);
        }
        public override SuccessResult<AbstractWishlist> Wishlist_Delete(int Wish_Id, int Deletedby)
        {
            return this.abstractWishlistDao.Wishlist_Delete(Wish_Id, Deletedby);
        }

    }
}