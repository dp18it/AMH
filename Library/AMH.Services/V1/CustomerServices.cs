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
    public class CustomerServices : AbstractCustomerServices
    {
        private AbstractCustomerDao abstractCustomerDao;

        public CustomerServices(AbstractCustomerDao abstractCustomerDao)
        {
            this.abstractCustomerDao = abstractCustomerDao;
        }
       
        public override SuccessResult<AbstractCustomer> Customer_ActInAct(long Id)
        {
            return this.abstractCustomerDao.Customer_ActInAct(Id);
        }
        public override SuccessResult<AbstractCustomer> Customer_ById(long Id)
        {
            return this.abstractCustomerDao.Customer_ById(Id);
        }
        public override SuccessResult<AbstractCustomer> Customer_Delete(long Id, long DeletedBy)
        {
            return this.abstractCustomerDao.Customer_Delete(Id, DeletedBy);
        }
        public override PagedList<AbstractCustomer> Customer_All(PageParam pageParam, string search)
        {
            return this.abstractCustomerDao.Customer_All(pageParam, search);
        }
        public override SuccessResult<AbstractCustomer> Customer_Upsert(AbstractCustomer abstractCustomer)
        {
            return this.abstractCustomerDao.Customer_Upsert(abstractCustomer);
        }
    }
    public class MasterCityServices : AbstractMasterCityServices
    {
        private AbstractMasterCityDao abstractMasterCityDao;

        public MasterCityServices(AbstractMasterCityDao abstractMasterCityDao)
        {
            this.abstractMasterCityDao = abstractMasterCityDao;
        }
        public override PagedList<AbstractMasterCity> MasterCity_All(PageParam pageParam, string search, long StateId)
        {
            return this.abstractMasterCityDao.MasterCity_All(pageParam, search,StateId);
        }
    }


    public class MasterStateServices : AbstractMasterStateServices
    {
        private AbstractMasterStateDao abstractMasterStateDao;

        public MasterStateServices(AbstractMasterStateDao abstractMasterStateDao)
        {
            this.abstractMasterStateDao = abstractMasterStateDao;
        }
        public override PagedList<AbstractMasterState> MasterState_All(PageParam pageParam, string search,long CountryId)
        {
            return this.abstractMasterStateDao.MasterState_All(pageParam, search,CountryId);
        }
    }


    public class MasterCountryServices : AbstractMasterCountryServices
    {
        private AbstractMasterCountryDao abstractMasterCountryDao;

        public MasterCountryServices(AbstractMasterCountryDao abstractMasterCountryDao)
        {
            this.abstractMasterCountryDao = abstractMasterCountryDao;
        }
        public override PagedList<AbstractMasterCountry> MasterCountry_All(PageParam pageParam, string search)
        {
            return this.abstractMasterCountryDao.MasterCountry_All(pageParam, search);
        }
    }

}