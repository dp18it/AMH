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
    public abstract class AbstractProductServices
    {
       
        public abstract SuccessResult<AbstractProduct> Product_ById(int Product_Id,int Users_Id);
        public abstract PagedList<AbstractProduct> Product_All(PageParam pageParam, string search,int IsVisibleAll, int Cat_Id,int Users_Id);
        public abstract SuccessResult<AbstractProduct> Product_Upsert(AbstractProduct abstractProduct);
        public abstract SuccessResult<AbstractProduct> Product_ActInact(int Product_Id, int Updatedby);
        public abstract SuccessResult<AbstractProduct> Product_Delete(int Product_Id, int Deleteby);


    }
}
