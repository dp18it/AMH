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
    public abstract class AbstractStudent
    {
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string DepartmentName { get; set; }
       
        public DateTime CreatedDate { get; set; }
       
        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
       
    }
    public abstract class AbstractDepartment
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }

}

