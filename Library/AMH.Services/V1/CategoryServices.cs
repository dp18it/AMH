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
    public class CategoryServices : AbstractCategoryServices
    {
        private AbstractCategoryDao abstractCategoryDao;

        public CategoryServices(AbstractCategoryDao abstractCategoryDao)
        {
            this.abstractCategoryDao = abstractCategoryDao;
        }

     
        public override SuccessResult<AbstractCategory> Category_ById(int Category_Id)
        {
            return this.abstractCategoryDao.Category_ById(Category_Id);
        }
        public override PagedList<AbstractCategory> Category_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractCategoryDao.Category_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractCategory> Category_Upsert(AbstractCategory abstractCategory)
        {
            return this.abstractCategoryDao.Category_Upsert(abstractCategory);
        }
        public override SuccessResult<AbstractCategory> Category_ActInact(int Category_Id, int Updatedby)
        {
            return this.abstractCategoryDao.Category_ActInact(Category_Id, Updatedby);
        }
        public override SuccessResult<AbstractCategory> Category_Delete(int Category_Id, int Deletedby)
        {
            return this.abstractCategoryDao.Category_Delete(Category_Id, Deletedby);
        }

    }
}