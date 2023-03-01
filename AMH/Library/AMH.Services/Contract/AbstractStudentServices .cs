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
    public abstract class AbstractStudentServices
    {
        public abstract SuccessResult<AbstractStudent> Student_Upsert(AbstractStudent abstractStudent);
        public abstract PagedList<AbstractStudent> Student_All(PageParam pageParam, string search,int DepartmentId);
        public abstract SuccessResult<AbstractStudent> Student_ById(int Id);
        public abstract SuccessResult<AbstractStudent> Student_Delete(int Id);
    }
    public abstract class AbstractDepartmentServices
    {
        public abstract PagedList<AbstractDepartment> Department_All(PageParam pageParam, string search);
    }
}
