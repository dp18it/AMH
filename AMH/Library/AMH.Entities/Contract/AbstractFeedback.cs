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
    public abstract class AbstractFeedback
    {
        public int Id { get; set; }
        public DateTime F_Date { get; set; }
        public string FeedBack { get; set; }
        public int User_Id { get; set; }
        public int Product_Id { get; set; } 
        public DateTime Updateddate { get; set; }
        public int Updatedby { get; set; }
        public DateTime Deleteddate { get; set; }
        public int Deletedby { get; set; }

        [NotMapped]
        public string F_DateStr => F_Date != null ? F_Date.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdateddateStr => Updateddate != null ? Updateddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeleteddateStr => Deleteddate != null ? Deleteddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
}

