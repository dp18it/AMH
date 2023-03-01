using AMH;
using AMH.Common;
using AMH.Entities.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMH.Entities.Contract
{
    public abstract class AbstractOrderAMH
    {
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int TotalAmout { get; set; }
        public int OrderStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public string ProIds { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quntity { get; set; }
        public int Product_Price { get; set; }
        public string Product_Image { get; set; }
        public string OrderStatus_Name { get; set; }
        public int Product_Id { get; set; }
        public string UserName { get; set; }
        public string Prices { get; set; }
        public string Quantities { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Createddate { get; set; }
        public int Createdby { get; set; }
        public DateTime Updateddate { get; set; }
        public int Updatedby { get; set; }
        public DateTime Deleteddate { get; set; }
        public int Deletedby { get; set; }
        [NotMapped]
        public string Product_ImageUrlStr => Configurations.BaseUrl + Product_Image;
        [NotMapped]
        public string Order_DateStr => Order_Date != null ? Order_Date.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string CreateddateStr => Createddate != null ? Createddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdateddateStr => Updateddate != null ? Updateddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeleteddateStr => Deleteddate != null ? Deleteddate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
}

