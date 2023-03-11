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
    public abstract class AbstractPaymentServices
    {
        //public abstract SuccessResult<AbstractPayment> Payment_ById(int Payment_Id);
        public abstract PagedList<AbstractPayment> Payment_All(PageParam pageParam, string search, int User_Id, string FromDate, string ToDate);
        //public abstract SuccessResult<AbstractPayment> Payment_Upsert(AbstractPayment abstractPayment);
        public abstract SuccessResult<AbstractPayment> Payment_ActInact(int Payment_Id, int Updatedby);
        //public abstract SuccessResult<AbstractPayment> Payment_Delete(int Payment_Id, int Deletedby);
    }
}
