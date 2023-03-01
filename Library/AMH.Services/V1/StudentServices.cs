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
    public class StudentServices : AbstractStudentServices
    {
        private AbstractStudentDao abstractStudentDao;

        public StudentServices(AbstractStudentDao abstractStudentDao)
        {
            this.abstractStudentDao = abstractStudentDao;
        }
       
        public override SuccessResult<AbstractStudent> Student_ById(int Id)
        {
            return this.abstractStudentDao.Student_ById(Id);
        }
        public override SuccessResult<AbstractStudent> Student_Delete(int Id)
        {
            return this.abstractStudentDao.Student_Delete(Id);
        }
        public override PagedList<AbstractStudent> Student_All(PageParam pageParam, string search,int DepartmentId)
        {
            return this.abstractStudentDao.Student_All(pageParam, search, DepartmentId);
        }
        public override SuccessResult<AbstractStudent> Student_Upsert(AbstractStudent abstractStudent)
        {
            return this.abstractStudentDao.Student_Upsert(abstractStudent);
        }
    }
    public class DepartmentServices : AbstractDepartmentServices
    {
        private AbstractDepartmentDao abstractDepartmentDao;

        public DepartmentServices(AbstractDepartmentDao abstractDepartmentDao)
        {
            this.abstractDepartmentDao = abstractDepartmentDao;
        }
        public override PagedList<AbstractDepartment> Department_All(PageParam pageParam, string search)
        {
            return this.abstractDepartmentDao.Department_All(pageParam, search);
        }
    }
}