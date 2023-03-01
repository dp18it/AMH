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
    public abstract class  AbstractSubCategoryDao: AbstractBaseDao

    {
        
        public abstract SuccessResult<AbstractSubCategory> SubCategory_Upsert(AbstractSubCategory abstractSubCategory);
        public abstract SuccessResult<AbstractSubCategory> SubCategory_ById(int Subcat_Id);
        public abstract SuccessResult<AbstractSubCategory> SubCategory_ActInact(int Subcat_Id, int Updatedby);
        public abstract SuccessResult<AbstractSubCategory> SubCategory_Delete(int Subcat_Id, int Deletedby);
        public abstract PagedList<AbstractSubCategory> SubCategory_All(PageParam pageParam, string Search,int IsVisibleAll);

    }
}
