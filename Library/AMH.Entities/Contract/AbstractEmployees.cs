using AMH;
using AMH.Entities.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMH.Entities.Contract
{
    public abstract class AbstractEmployees
    {
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName{ get; set; }
        public string CountryName{ get; set; }
        public string StateName{ get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public long CityId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public long DeletedBy { get; set; }
        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeletedDateStr => DeletedDate != null ? DeletedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
    public abstract class AbstractMasterEmCity : MasterCity
    {
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public long StateId { get; set; }
    }

    public abstract class AbstractMasterEmState : MasterState
    {
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public long CountryId { get; set; }
    }

    public abstract class AbstractMasterEmCountry : MasterCountry
    {
        //public long Id { get; set; }
        //public string Name { get; set; }
    }

}

