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
    public class EmployeesServices : AbstractEmployeesServices
    {
        private AbstractEmployeesDao abstractEmployeesDao;

        public EmployeesServices(AbstractEmployeesDao abstractEmployeesDao)
        {
            this.abstractEmployeesDao = abstractEmployeesDao;
        }
       
        public override SuccessResult<AbstractEmployees> Employees_ActInAct(long Id)
        {
            return this.abstractEmployeesDao.Employees_ActInAct(Id);
        }
        public override SuccessResult<AbstractEmployees> Employees_ById(long Id)
        {
            return this.abstractEmployeesDao.Employees_ById(Id);
        }
        public override SuccessResult<AbstractEmployees> Employees_Delete(long Id, long DeletedBy)
        {
            return this.abstractEmployeesDao.Employees_Delete(Id, DeletedBy);
        }
        public override PagedList<AbstractEmployees> Employees_All(PageParam pageParam, string search)
        {
            return this.abstractEmployeesDao.Employees_All(pageParam, search);
        }
        public override SuccessResult<AbstractEmployees> Employees_Upsert(AbstractEmployees abstractEmployees)
        {
            return this.abstractEmployeesDao.Employees_Upsert(abstractEmployees);
        }
    }
    public class MasterEmCityServices : AbstractMasterEmCityServices
    {
        private AbstractMasterEmCityDao abstractMasterEmCityDao;

        public MasterEmCityServices(AbstractMasterEmCityDao abstractMasterEmCityDao)
        {
            this.abstractMasterEmCityDao = abstractMasterEmCityDao;
        }
        public override PagedList<AbstractMasterEmCity> MasterCity_All(PageParam pageParam, string search, long StateId)
        {
            return this.abstractMasterEmCityDao.MasterCity_All(pageParam, search, StateId);
        }
    }


    public class MasterEmStateServices : AbstractMasterEmStateServices
    {
        private AbstractMasterEmStateDao abstractMasterEmStateDao;

        public MasterEmStateServices(AbstractMasterEmStateDao abstractMasterEmStateDao)
        {
            this.abstractMasterEmStateDao = abstractMasterEmStateDao;
        }
        public override PagedList<AbstractMasterEmState> MasterState_All(PageParam pageParam, string search, long CountryId)
        {
            return this.abstractMasterEmStateDao.MasterState_All(pageParam, search, CountryId);
        }
    }


    public class MasterEmCountryServices : AbstractMasterEmCountryServices
    {
        private AbstractMasterEmCountryDao abstractMasterEmCountryDao;

        public MasterEmCountryServices(AbstractMasterEmCountryDao abstractMasterEmCountryDao)
        {
            this.abstractMasterEmCountryDao = abstractMasterEmCountryDao;
        }
        public override PagedList<AbstractMasterEmCountry> MasterCountry_All(PageParam pageParam, string search)
        {
            return this.abstractMasterEmCountryDao.MasterCountry_All(pageParam, search);
        }
    }

}