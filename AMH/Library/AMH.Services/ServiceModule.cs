//-----------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AMH.Services
{
    using Autofac;
    using Data;
    using AMH.Services.Contract;
    using AMH.Services.V1;
    
    /// <summary>
    /// The Service module for dependency injection.
    /// </summary>
    public class ServiceModule : Module
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
            builder.RegisterModule<DataModule>();
            //builder.RegisterType<Wish>().As<AbstractAdminServices>().InstancePerDependency();
            builder.RegisterType<CityServices>().As<AbstractCityServices>().InstancePerDependency();
            builder.RegisterType<StateServices>().As<AbstractStateServices>().InstancePerDependency();
            builder.RegisterType<WishlistServices>().As<AbstractWishlistServices>().InstancePerDependency();
            builder.RegisterType<UsersServices>().As<AbstractUsersServices>().InstancePerDependency();
            builder.RegisterType<ProductServices>().As<AbstractProductServices>().InstancePerDependency();
            builder.RegisterType<OrderAMHServices>().As<AbstractOrderAMHServices>().InstancePerDependency();
            builder.RegisterType<FeedbackServices>().As<AbstractFeedbackServices>().InstancePerDependency();
            builder.RegisterType<CartServices>().As<AbstractCartServices>().InstancePerDependency();
            builder.RegisterType<CategoryServices>().As<AbstractCategoryServices>().InstancePerDependency();
            builder.RegisterType<SubCategoryServices>().As<AbstractSubCategoryServices>().InstancePerDependency();
            builder.RegisterType<AdminServices>().As<AbstractAdminServices>().InstancePerDependency();
         
            base.Load(builder);
        }
    }
}
