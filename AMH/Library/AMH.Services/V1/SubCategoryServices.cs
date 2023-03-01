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
    public class SubCategoryServices : AbstractSubCategoryServices
    {
        private AbstractSubCategoryDao abstractSubCategoryDao;

        public SubCategoryServices(AbstractSubCategoryDao abstractSubCategoryDao)
        {
            this.abstractSubCategoryDao = abstractSubCategoryDao;
        }

     
        public override SuccessResult<AbstractSubCategory> SubCategory_ById(int Subcat_Id)
        {
            return this.abstractSubCategoryDao.SubCategory_ById(Subcat_Id);
        }
        public override PagedList<AbstractSubCategory> SubCategory_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractSubCategoryDao.SubCategory_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractSubCategory> SubCategory_Upsert(AbstractSubCategory abstractSubCategory)
        {
            return this.abstractSubCategoryDao.SubCategory_Upsert(abstractSubCategory);
        }
        public override SuccessResult<AbstractSubCategory> SubCategory_ActInact(int Subcat_Id, int Updatedby)
        {
            return this.abstractSubCategoryDao.SubCategory_ActInact(Subcat_Id, Updatedby);
        }
        public override SuccessResult<AbstractSubCategory> SubCategory_Delete(int Subcat_Id, int Deletedby)
        {
            return this.abstractSubCategoryDao.SubCategory_Delete(Subcat_Id, Deletedby);
        }

    }
}