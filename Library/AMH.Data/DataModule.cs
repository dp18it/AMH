//-----------------------------------------------------------------------
// <copyright file="DataModule.cs" company="Rushkar">
//     Copyright Rushkar Solutions. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AMH.Data
{
    using Autofac;
    using AMH.Data.Contract;

    //using AMH.Data.Contract;


    /// <summary>
    /// Contract Class for DataModule.
    /// </summary>
    public class DataModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<V1.WishlistDao>().As<AbstractWishlistDao>().InstancePerDependency();
            builder.RegisterType<V1.CityDao>().As<AbstractCityDao>().InstancePerDependency();
            builder.RegisterType<V1.StateDao>().As<AbstractStateDao>().InstancePerDependency();
            builder.RegisterType<V1.UsersDao>().As<AbstractUsersDao>().InstancePerDependency();
            builder.RegisterType<V1.PaymentDao>().As<AbstractPaymentDao>().InstancePerDependency();
            builder.RegisterType<V1.ProductDao>().As<AbstractProductDao>().InstancePerDependency();
            builder.RegisterType<V1.OrderAMHDao>().As<AbstractOrderAMHDao>().InstancePerDependency();
            builder.RegisterType<V1.FeedbackDao>().As<AbstractFeedbackDao>().InstancePerDependency();
            builder.RegisterType<V1.CartDao>().As<AbstractCartDao>().InstancePerDependency();
            builder.RegisterType<V1.CategoryDao>().As<AbstractCategoryDao>().InstancePerDependency();
            builder.RegisterType<V1.SubCategoryDao>().As<AbstractSubCategoryDao>().InstancePerDependency();
            builder.RegisterType<V1.AddressMasterDao>().As<AbstractAddressMasterDao>().InstancePerDependency();
           // builder.RegisterType<V1.AppointmentDao>().As<AbstractAppointmentDao>().InstancePerDependency();
            builder.RegisterType<V1.WishlistDao>().As<AbstractWishlistDao>().InstancePerDependency();
            builder.RegisterType<V1.CityMasterDao>().As<AbstractCityMasterDao>().InstancePerDependency();
            builder.RegisterType<V1.StateMasterDao>().As<AbstractStateMasterDao>().InstancePerDependency();
            builder.RegisterType<V1.CountryMasterDao>().As<AbstractCountryMasterDao>().InstancePerDependency();
            builder.RegisterType<V1.AdminDao>().As<AbstractAdminDao>().InstancePerDependency();
            builder.RegisterType<V1.CustomerDao>().As<AbstractCustomerDao>().InstancePerDependency();
            builder.RegisterType<V1.StudentDao>().As<AbstractStudentDao>().InstancePerDependency();
            builder.RegisterType<V1.EmployeesDao>().As<AbstractEmployeesDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterCityDao>().As<AbstractMasterCityDao>().InstancePerDependency();
            builder.RegisterType<V1.DepartmentDao>().As<AbstractDepartmentDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterEmCityDao>().As<AbstractMasterEmCityDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterCountryDao>().As<AbstractMasterCountryDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterEmCountryDao>().As<AbstractMasterEmCountryDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterStateDao>().As<AbstractMasterStateDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterEmStateDao>().As<AbstractMasterEmStateDao>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
