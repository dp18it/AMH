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
    public class AdminServices : AbstractAdminServices
    {
        private AbstractAdminDao abstractAdminDao;
        public AdminServices(AbstractAdminDao abstractAdminDao)
        {
            this.abstractAdminDao = abstractAdminDao;
        }

        public override bool Admin_SignOut()
        {
            return this.abstractAdminDao.Admin_SignOut();
        }
        public override SuccessResult<AbstractAdmin> Admin_SignIn(string Email, string Password)
        {
            return this.abstractAdminDao.Admin_SignIn(Email, Password);
        }
        //public override SuccessResult<AbstractAdmin> Admin_ChangePassword(long Id, string OldPassword, string NewPassword, string ConfirmPassword)
        //{
        //    return this.abstractAdminDao.Admin_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);
        //}

        public override SuccessResult<AbstractAdmin> Admin_ById(int Admin_Id)
        {
            return this.abstractAdminDao.Admin_ById(Admin_Id);
        }
        public override PagedList<AbstractAdmin> Admin_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractAdminDao.Admin_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractAdmin> Admin_Upsert(AbstractAdmin abstractAdmin)
        {
            return this.abstractAdminDao.Admin_Upsert(abstractAdmin);
        }
        public override SuccessResult<AbstractAdmin> Admin_ActInact(int Admin_Id, int Updatedby)
        {
            return this.abstractAdminDao.Admin_ActInact(Admin_Id, Updatedby);
        }

        public override SuccessResult<AbstractAdmin> Admin_Delete(int Admin_Id, int Deletedby)
        {
            return this.abstractAdminDao.Admin_Delete(Admin_Id, Deletedby);
        }
        public override SuccessResult<AbstractAdmin>Home_All( )
        {
            return this.abstractAdminDao.Home_All();
        }
        public override SuccessResult<AbstractAdmin> Admin_ChangePassword(int Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            return this.abstractAdminDao.Admin_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);
        }
        public override SuccessResult<AbstractAdmin> Admin_ForgotPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            return this.abstractAdminDao.Admin_ForgotPassword(NewPassword, ConfirmPassword, Email);
        }
        public override SuccessResult<AbstractAdmin> Admin_ResetPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            return this.abstractAdminDao.Admin_ResetPassword(NewPassword, ConfirmPassword, Email);
        }
        public override SuccessResult<AbstractAdmin> Admin_CheckEmailExists(string Email)
        {
            return this.abstractAdminDao.Admin_CheckEmailExists(Email);
        }
    }
}