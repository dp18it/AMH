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
    public abstract class  AbstractCategoryDao: AbstractBaseDao

    {
        
        public abstract SuccessResult<AbstractCategory> Category_Upsert(AbstractCategory abstractCategory);
        public abstract SuccessResult<AbstractCategory> Category_ById(int Category_Id);
        public abstract SuccessResult<AbstractCategory> Category_ActInact(int Category_Id, int Updatedby);
        public abstract SuccessResult<AbstractCategory> Category_Delete(int Category_Id, int Deletedby);
        public abstract PagedList<AbstractCategory> Category_All(PageParam pageParam, string Search,int IsVisibleAll);

    }
}
