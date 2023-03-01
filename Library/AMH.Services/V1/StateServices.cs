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
    public class StateServices : AbstractStateServices
    {
        private AbstractStateDao abstractStateDao;
        public StateServices(AbstractStateDao abstractStateDao)
        {
            this.abstractStateDao = abstractStateDao;
        }

      
        public override SuccessResult<AbstractState> State_ById(int Id)
        {
            return this.abstractStateDao.State_ById(Id);
        }
        public override PagedList<AbstractState> State_All(PageParam pageParam, string search)
        {
            return this.abstractStateDao.State_All(pageParam, search);
        }
        public override SuccessResult<AbstractState> State_Upsert(AbstractState abstractState)
        {
            return this.abstractStateDao.State_Upsert(abstractState);
        }
   
        public override SuccessResult<AbstractState> State_Delete(int Id, int Deletedby)
        {
            return this.abstractStateDao.State_Delete(Id, Deletedby);
        }
        public override SuccessResult<AbstractState> State_ActInact(int Id, int Updatedby)
        {
            return this.abstractStateDao.State_ActInact(Id, Updatedby);
        }
    }
}