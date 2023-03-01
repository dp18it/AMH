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
    public abstract class AbstractOrderAMHServices
    {
       
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_ById(int Order_Id);
        public abstract PagedList<AbstractOrderAMH> OrderAMH_All(PageParam pageParam, string search,int IsVisibleAll);
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_Upsert(AbstractOrderAMH abstractOrderAMH);
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_ActInact(int Order_Id, int Updatedby);
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_Delete(int Order_Id, int Deleteby);


    }
}
