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
    public abstract class AbstractCustomerServices
    {
        public abstract SuccessResult<AbstractCustomer> Customer_Upsert(AbstractCustomer abstractCustomer);
        public abstract PagedList<AbstractCustomer> Customer_All(PageParam pageParam, string search);
        public abstract SuccessResult<AbstractCustomer> Customer_ById(long Id);
        public abstract SuccessResult<AbstractCustomer> Customer_ActInAct(long Id);
        public abstract SuccessResult<AbstractCustomer> Customer_Delete(long Id, long DeletedBy);
    }
    public abstract class AbstractMasterCityServices
    {
        public abstract PagedList<AbstractMasterCity> MasterCity_All(PageParam pageParam, string search,long StateId);
    }

    public abstract class AbstractMasterStateServices
    {
        public abstract PagedList<AbstractMasterState> MasterState_All(PageParam pageParam, string search,long CountryId);
    }

    public abstract class AbstractMasterCountryServices
    {
        public abstract PagedList<AbstractMasterCountry> MasterCountry_All(PageParam pageParam, string search);
    }

}
