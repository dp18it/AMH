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
    public abstract class AbstractFeedbackServices
    {
       
        public abstract SuccessResult<AbstractFeedback> Feedback_ById(int Id);
        public abstract PagedList<AbstractFeedback> Feedback_All(PageParam pageParam, string search, int user_id, int product_id);
        public abstract SuccessResult<AbstractFeedback> Feedback_Upsert(AbstractFeedback abstractFeedback);
        public abstract SuccessResult<AbstractFeedback> Feedback_Delete(int Id, int Deleteby);


    }
}
