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
    public class AddressMasterServices : AbstractAddressMasterServices
    {
        private AbstractAddressMasterDao abstractAddressMasterDao;

        public AddressMasterServices(AbstractAddressMasterDao abstractAddressMasterDao)
        {
            this.abstractAddressMasterDao = abstractAddressMasterDao;
        }
        public override PagedList<AbstractAddressMaster> AddressMaster_ByUserId(PageParam pageParam, string search, long UserId)
        {
            return this.abstractAddressMasterDao.AddressMaster_ByUserId(pageParam, search, UserId);
        }
        public override SuccessResult<AbstractAddressMaster> AddressMaster_ActInAct(long Id, long UpdatedBy)
        {
            return this.abstractAddressMasterDao.AddressMaster_ActInAct(Id, UpdatedBy);
        }
        public override SuccessResult<AbstractAddressMaster> AddressMaster_ById(long Id)
        {
            return this.abstractAddressMasterDao.AddressMaster_ById(Id);
        }
        public override SuccessResult<AbstractAddressMaster> AddressMaster_Delete(long Id, long DeletedBy)
        {
            return this.abstractAddressMasterDao.AddressMaster_Delete(Id, DeletedBy);
        }
        public override PagedList<AbstractAddressMaster> AddressMaster_All(PageParam pageParam, string search)
        {
            return this.abstractAddressMasterDao.AddressMaster_All(pageParam, search);
        }
        public override SuccessResult<AbstractAddressMaster> AddressMaster_Upsert(AbstractAddressMaster abstractAddressMaster)
        {
            return this.abstractAddressMasterDao.AddressMaster_Upsert(abstractAddressMaster);
        }
    }

    public class CityMasterServices : AbstractCityMasterServices
    {
        private AbstractCityMasterDao abstractCityMasterDao;

        public CityMasterServices(AbstractCityMasterDao abstractCityMasterDao)
        {
            this.abstractCityMasterDao = abstractCityMasterDao;
        }
        public override PagedList<AbstractCityMaster> CityMaster_ByStateMasterId(PageParam pageParam, string search, long StateMasterId)
        {
            return this.abstractCityMasterDao.CityMaster_ByStateMasterId(pageParam, search, StateMasterId);
        }
    }


    public class StateMasterServices : AbstractStateMasterServices
    {
        private AbstractStateMasterDao abstractStateMasterDao;

        public StateMasterServices(AbstractStateMasterDao abstractStateMasterDao)
        {
            this.abstractStateMasterDao = abstractStateMasterDao;
        }
        public override PagedList<AbstractStateMaster> StateMaster_ByCountryMasterId(PageParam pageParam, string search, long CountryMasterId)
        {
            return this.abstractStateMasterDao.StateMaster_ByCountryMasterId(pageParam, search, CountryMasterId);
        }
    }


    public class CountryMasterServices : AbstractCountryMasterServices
    {
        private AbstractCountryMasterDao abstractCountryMasterDao;

        public CountryMasterServices(AbstractCountryMasterDao abstractCountryMasterDao)
        {
            this.abstractCountryMasterDao = abstractCountryMasterDao;
        }
        public override PagedList<AbstractCountryMaster> CountryMaster_All(PageParam pageParam, string search)
        {
            return this.abstractCountryMasterDao.CountryMaster_All(pageParam, search);
        }
    }
}