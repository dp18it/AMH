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
    public abstract class  AbstractProductDao: AbstractBaseDao

    {
        
        public abstract SuccessResult<AbstractProduct> Product_Upsert(AbstractProduct abstractProduct);
        public abstract SuccessResult<AbstractProduct> Product_ById(int Product_Id,int Users_Id);
        public abstract SuccessResult<AbstractProduct> Product_ActInact(int Product_Id, int Updatedby);
        public abstract SuccessResult<AbstractProduct> Product_Delete(int Product_Id, int Deletedby);
        public abstract PagedList<AbstractProduct> Product_All(PageParam pageParam, string Search,int IsVisibleAll,int Cat_Id,int Users_Id,int Subcat_Id, int FromPrice ,int ToPrice);

    }
}
