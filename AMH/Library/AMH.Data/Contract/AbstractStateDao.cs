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
    public abstract class  AbstractStateDao: AbstractBaseDao

    {
        public abstract SuccessResult<AbstractState> State_Upsert(AbstractState abstractState);
        public abstract SuccessResult<AbstractState> State_ById(int Id);
        public abstract PagedList<AbstractState> State_All(PageParam pageParam, string Search );
        public abstract SuccessResult<AbstractState> State_Delete(int Id, int Deletedby);
        public abstract SuccessResult<AbstractState> State_ActInact(int Id, int Deletedby);
    }
}
