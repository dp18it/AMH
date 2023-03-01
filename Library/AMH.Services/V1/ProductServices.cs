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
    public class ProductServices : AbstractProductServices
    {
        private AbstractProductDao abstractProductDao;

        public ProductServices(AbstractProductDao abstractProductDao)
        {
            this.abstractProductDao = abstractProductDao;
        }

     
        public override SuccessResult<AbstractProduct> Product_ById(int Product_Id,int Users_Id)
        {
            return this.abstractProductDao.Product_ById(Product_Id, Users_Id);
        }
        public override PagedList<AbstractProduct> Product_All(PageParam pageParam, string search,int IsVisibleAll, int Cat_Id,int Users_Id,int Subcat_Id,int FromPrice,int ToPrice)
        {
            return this.abstractProductDao.Product_All(pageParam, search, IsVisibleAll, Cat_Id, Users_Id, Subcat_Id, FromPrice, ToPrice);
        }
        public override SuccessResult<AbstractProduct> Product_Upsert(AbstractProduct abstractProduct)
        {
            return this.abstractProductDao.Product_Upsert(abstractProduct);
        }
        public override SuccessResult<AbstractProduct> Product_ActInact(int Product_Id, int Updatedby)
        {
            return this.abstractProductDao.Product_ActInact(Product_Id, Updatedby);
        }
        public override SuccessResult<AbstractProduct> Product_Delete(int Product_Id, int Deletedby)
        {
            return this.abstractProductDao.Product_Delete(Product_Id, Deletedby);
        }

    }
}