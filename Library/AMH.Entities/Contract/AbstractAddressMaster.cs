using AMH;
using AMH.Entities.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMH.Entities.Contract

// CC, UU, DD and IsActive field AbstractBase inherit thashe 
{
    public abstract class AbstractAddressMaster 
    {
        public long Id { get; set; }
        public string LocationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public long PinCode { get; set; }
        public long CityMasterId { get; set; }
        public string CityName { get; set; }
        public long StateMasterId { get; set; }
        public string StateName { get; set; }
        public long CountryMasterId { get; set; }
        public string CountryName { get; set; }
        public long UserId { get; set; }
        public long AdminId { get; set; }
        public string Latitude { get; set; }
        public string Longitute { get; set; }
        public bool IsActive { get; set; }

    }

    public abstract class AbstractCityMaster
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StateMasterId { get; set; }
        public string StateMasterName { get; set; }
    }

    public abstract class AbstractStateMaster
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CountryMasterId { get; set; }
        public string CountryMasterName { get; set; }
    }

    public abstract class AbstractCountryMaster
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

