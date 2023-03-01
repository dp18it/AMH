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
    public abstract class AbstractSubCategoryServices
    {
       
        public abstract SuccessResult<AbstractSubCategory> SubCategory_ById(int Subcat_Id);
        public abstract PagedList<AbstractSubCategory> SubCategory_All(PageParam pageParam, string search,int IsVisibleAll);
        public abstract SuccessResult<AbstractSubCategory> SubCategory_Upsert(AbstractSubCategory abstractSubCategory);
        public abstract SuccessResult<AbstractSubCategory> SubCategory_ActInact(int Subcat_Id, int Updatedby);
        public abstract SuccessResult<AbstractSubCategory> SubCategory_Delete(int Subcat_Id, int Deleteby);


    }
}
