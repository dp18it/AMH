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
    public class CityServices : AbstractCityServices
    {
        private AbstractCityDao abstractCityDao;
        public CityServices(AbstractCityDao abstractCityDao)
        {
            this.abstractCityDao = abstractCityDao;
        }

      
        public override SuccessResult<AbstractCity> City_ById(int Id)
        {
            return this.abstractCityDao.City_ById(Id);
        }
        public override PagedList<AbstractCity> City_All(PageParam pageParam, string search, int StateId)
        {
            return this.abstractCityDao.City_All(pageParam, search, StateId);
        }
        public override SuccessResult<AbstractCity> City_Upsert(AbstractCity abstractCity)
        {
            return this.abstractCityDao.City_Upsert(abstractCity);
        }
   
        public override SuccessResult<AbstractCity> City_Delete(int Id, int Deletedby)
        {
            return this.abstractCityDao.City_Delete(Id, Deletedby);
        }
        public override SuccessResult<AbstractCity> City_ActInact(int Id, int Updatedby)
        {
            return this.abstractCityDao.City_ActInact(Id, Updatedby);
        }

    }
}