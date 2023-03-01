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
    public abstract class AbstractAdmin
    {
        public int Admin_Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ContactNo { get; set; }
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

        public int Feedback { get; set; }
        public int PendingPayment { get; set; }
        public int ReceivedPayment { get; set; }
        public int PlasedOrder { get; set; }
        public int ActiveOrder { get; set; }
        public int NewProduct { get; set; }
        public int NewUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalUsers { get; set; }

    }
}

