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
    public abstract class  AbstractPaymentDao: AbstractBaseDao

    {
        
        //public abstract SuccessResult<AbstractPayment> Payment_Upsert(AbstractPayment abstractPayment);
        //public abstract SuccessResult<AbstractPayment> Payment_ById(int Payment_Id);
        public abstract SuccessResult<AbstractPayment> Payment_ActInact(int Payment_Id, int Updatedby);
        public abstract PagedList<AbstractPayment> Payment_All(PageParam pageParam, string Search);
        //public abstract SuccessResult<AbstractPayment> Payment_Delete(int Payment_Id, int Deletedby);
    }
}
