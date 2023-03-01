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
    public class OrderAMHServices : AbstractOrderAMHServices
    {
        private AbstractOrderAMHDao abstractOrderAMHDao;

        public OrderAMHServices(AbstractOrderAMHDao abstractOrderAMHDao)
        {
            this.abstractOrderAMHDao = abstractOrderAMHDao;
        }

     
        public override SuccessResult<AbstractOrderAMH> OrderAMH_ById(int Order_Id)
        {
            return this.abstractOrderAMHDao.OrderAMH_ById(Order_Id);
        }
        public override PagedList<AbstractOrderAMH> OrderAMH_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractOrderAMHDao.OrderAMH_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractOrderAMH> OrderAMH_Upsert(AbstractOrderAMH abstractOrderAMH)
        {
            return this.abstractOrderAMHDao.OrderAMH_Upsert(abstractOrderAMH);
        }
        public override SuccessResult<AbstractOrderAMH> OrderAMH_ActInact(int Order_Id, int Updatedby)
        {
            return this.abstractOrderAMHDao.OrderAMH_ActInact(Order_Id, Updatedby);
        }
        public override SuccessResult<AbstractOrderAMH> OrderAMH_Delete(int Order_Id, int Deletedby)
        {
            return this.abstractOrderAMHDao.OrderAMH_Delete(Order_Id, Deletedby);
        }

    }
}