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
    public class CartServices : AbstractCartServices
    {
        private AbstractCartDao abstractCartDao;

        public CartServices(AbstractCartDao abstractCartDao)
        {
            this.abstractCartDao = abstractCartDao;
        }

        public override PagedList<AbstractCart> Cart_All(PageParam pageParam, string search, int Users_Id)
        {
            return this.abstractCartDao.Cart_All(pageParam,search,Users_Id);
        }
        public override SuccessResult<AbstractCart> Cart_Upsert(AbstractCart abstractCart)
        {
            return this.abstractCartDao.Cart_Upsert(abstractCart);
        }
        public override SuccessResult<AbstractCart> Cart_Delete(int Cart_Id, int Deletedby)
        {
            return this.abstractCartDao.Cart_Delete(Cart_Id, Deletedby);
        }

    }
}