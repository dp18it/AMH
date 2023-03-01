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
    public abstract class AbstractCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Createddate { get; set; }
        public int Createdby { get; set; }
        public DateTime Updateddate { get; set; }
        public int Updatedby { get; set; }
        public DateTime Deleteddate { get; set; }
        public int Deletedby { get; set; }

        [NotMapped]
        public string CreateddateStr => Createddate != null ? Createddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdateddateStr => Updateddate != null ? Updateddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeleteddateStr => Deleteddate != null ? Deleteddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";

    }
}

