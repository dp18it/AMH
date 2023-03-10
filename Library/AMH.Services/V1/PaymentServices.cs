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
    public class PaymentServices : AbstractPaymentServices
    {
        private AbstractPaymentDao abstractPaymentDao;
        public PaymentServices(AbstractPaymentDao abstractPaymentDao)
        {
            this.abstractPaymentDao = abstractPaymentDao;
        }
        //public override SuccessResult<AbstractPayment> Payment_ById(int Payment_Id)
        //{
        //    return this.abstractPaymentDao.Payment_ById(Payment_Id);
        //}
        public override PagedList<AbstractPayment> Payment_All(PageParam pageParam, string search, int User_Id, string FromDate, string ToDate)
        {
            return this.abstractPaymentDao.Payment_All(pageParam, search,User_Id, FromDate, ToDate);
        }
        //public override SuccessResult<AbstractPayment> Payment_Upsert(AbstractPayment abstractPayment)
        //{
        //    return this.abstractPaymentDao.Payment_Upsert(abstractPayment);
        //}
        public override SuccessResult<AbstractPayment> Payment_ActInact(int Payment_Id, int Updatedby)
        {
            return this.abstractPaymentDao.Payment_ActInact(Payment_Id, Updatedby);
        }

        //public override SuccessResult<AbstractPayment> Payment_Delete(int Payment_Id, int Deletedby)
        //{
        //    return this.abstractPaymentDao.Payment_Delete(Payment_Id, Deletedby);
        //}
    }
}