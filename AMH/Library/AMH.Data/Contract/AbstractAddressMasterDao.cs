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
    public abstract class AbstractAddressMasterDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractAddressMaster> AddressMaster_Upsert(AbstractAddressMaster abstractAddressMaster);
        public abstract PagedList<AbstractAddressMaster> AddressMaster_All(PageParam pageParam, string search);
        public abstract SuccessResult<AbstractAddressMaster> AddressMaster_ById(long Id);
        public abstract SuccessResult<AbstractAddressMaster> AddressMaster_ActInAct(long Id, long UpdatedBy);
        public abstract PagedList<AbstractAddressMaster> AddressMaster_ByUserId(PageParam pageParam, string search, long UserId);
        public abstract SuccessResult<AbstractAddressMaster> AddressMaster_Delete(long Id, long DeletedBy);
    }

    public abstract class AbstractCityMasterDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractCityMaster> CityMaster_ByStateMasterId(PageParam pageParam, string search, long StateMasterId);
    }

    public abstract class AbstractStateMasterDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractStateMaster> StateMaster_ByCountryMasterId(PageParam pageParam, string search, long CountryMasterId);
    }

    public abstract class AbstractCountryMasterDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractCountryMaster> CountryMaster_All(PageParam pageParam, string search);
    }
}
