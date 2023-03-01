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
    public abstract class  AbstractFeedbackDao: AbstractBaseDao

    {
        
        public abstract SuccessResult<AbstractFeedback> Feedback_Upsert(AbstractFeedback abstractFeedback);
        public abstract SuccessResult<AbstractFeedback> Feedback_ById(int Feedback_Id);
        public abstract SuccessResult<AbstractFeedback> Feedback_Delete(int Feedback_Id, int Deletedby);
        public abstract PagedList<AbstractFeedback> Feedback_All(PageParam pageParam, string Search,int user_id,int product_id);

    }
}
