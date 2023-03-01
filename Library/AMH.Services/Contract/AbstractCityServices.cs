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
    public abstract class AbstractCityServices
    {
        public abstract SuccessResult<AbstractCity> City_ById(int Id);
        public abstract PagedList<AbstractCity> City_All(PageParam pageParam, string search, int StateId);
        public abstract SuccessResult<AbstractCity> City_Upsert(AbstractCity abstractCity);
        public abstract SuccessResult<AbstractCity> City_Delete(int Id, int Deletedby);
        public abstract SuccessResult<AbstractCity> City_ActInact(int Id, int Updatedby);



    }
}
