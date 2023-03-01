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
    public abstract class AbstractEmployeesServices
    {
        public abstract SuccessResult<AbstractEmployees> Employees_Upsert(AbstractEmployees abstractEmployees);
        public abstract PagedList<AbstractEmployees> Employees_All(PageParam pageParam, string search);
        public abstract SuccessResult<AbstractEmployees> Employees_ById(long Id);
        public abstract SuccessResult<AbstractEmployees> Employees_ActInAct(long Id);
        public abstract SuccessResult<AbstractEmployees> Employees_Delete(long Id, long DeletedBy);
    }
    public abstract class AbstractMasterEmCityServices
    {
        public abstract PagedList<AbstractMasterEmCity> MasterCity_All(PageParam pageParam, string search,long StateId);
    }

    public abstract class AbstractMasterEmStateServices
    {
        public abstract PagedList<AbstractMasterEmState> MasterState_All(PageParam pageParam, string search,long CountryId);
    }

    public abstract class AbstractMasterEmCountryServices
    {
        public abstract PagedList<AbstractMasterEmCountry> MasterCountry_All(PageParam pageParam, string search);
    }

}
