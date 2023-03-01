using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;

namespace AMH.Data.Contract
{
    public abstract class  AbstractOrderAMHDao: AbstractBaseDao

    {
        
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_Upsert(AbstractOrderAMH abstractOrderAMH);
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_ById(int Order_Id);
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_ActInact(int Order_Id, int Updatedby);
        public abstract SuccessResult<AbstractOrderAMH> OrderAMH_Delete(int Order_Id, int Deletedby);
        public abstract PagedList<AbstractOrderAMH> OrderAMH_All(PageParam pageParam, string Search,int IsVisibleAll);

    }
}
