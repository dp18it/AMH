using AMH;
using AMH.Entities.V1;
using System;
using AMH.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMH.Entities.Contract
{
    public abstract class AbstractProduct

    {
        public int Product_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string ExtraImage1 { get; set; }
        public string ExtraImage2{ get; set; }
        public string ExtraImage3 { get; set; }
        public string Categoryname { get; set; }
        public string SubCategoryname { get; set; }
        public int Subcat_Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInCart { get; set; }
        public bool IsInWishlist { get; set; }
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
        [NotMapped]
        public string ImageUrlStr => Configurations.BaseUrl + Image; 
        [NotMapped]
        public string ExtraImage1UrlStr => Configurations.BaseUrl + ExtraImage1;
        [NotMapped]
        public string ExtraImage2UrlStr => Configurations.BaseUrl + ExtraImage2;
        [NotMapped]
        public string ExtraImage3UrlStr => Configurations.BaseUrl + ExtraImage3;
    }
}

