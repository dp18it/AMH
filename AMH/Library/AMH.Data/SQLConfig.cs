//-----------------------------------------------------------------------
// <copyright file="SQLConfig.cs" company="Rushkar">
//     Copyright Rushkar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AMH.Data
{
    /// <summary>
    /// SQL configuration class which holds stored procedure name.
    /// </summary>
    internal sealed class SQLConfig
    {
        #region Wishlist
        public const string Wishlist_Upsert = "Wishlist_Upsert";
        public const string Wishlist_ById = "Wishlist_ById";
        public const string Wishlist_All = "Wishlist_All";
        public const string Wishlist_Delete = "Wishlist_Delete";
        #endregion

        #region Users
        public const string Users_Upsert = "Users_Upsert";
        public const string Users_ById = "Users_ById";
        public const string Users_All = "Users_All";
        public const string Users_ActInact = "Users_ActInact";
        public const string Users_Delete = "Users_Delete";
        public const string User_SignOut = "User_SignOut";
        public const string User_SignIn = "User_SignIn";
        public const string Users_ChangePassword = "Users_ChangePassword";
        public const string Admin_ChangePassword = "Admin_ChangePassword";
        public const string Users_ResetPassword = "Users_ResetPassword";
        public const string Admin_ResetPassword = "Admin_ResetPassword";
        #endregion

        #region SubCategory
        public const string SubCategory_Upsert = "SubCategory_Upsert";
        public const string SubCategory_ById = "SubCategory_ById";
        public const string SubCategory_All = "SubCategory_All";
        public const string SubCategory_ActInact = "SubCategory_ActInact";
        public const string SubCategory_Delete = "SubCategory_Delete";
        #endregion

        #region Product
        public const string Product_Upsert = "Product_Upsert";
        public const string Product_ById = "Product_ById";
        public const string Product_All = "Product_All";
        public const string Product_ActInact = "Product_ActInact";
        public const string Product_Delete = "Product_Delete";
        #endregion

        #region OrderAMH
        public const string OrderAMH_Upsert = "OrderAMH_Upsert";
        public const string OrderAMH_ById = "OrderAMH_ById";
        public const string OrderAMH_All = "OrderAMH_All";
        public const string OrderAMH_ActInact = "OrderAMH_ActInact";
        public const string OrderAMH_Delete = "OrderAMH_Delete";
        #endregion
    
        #region Feedback
        public const string Feedback_Upsert = "Feedback_Upsert";
        public const string Feedback_ById = "Feedback_ById";
        public const string Feedback_All = "Feedback_All";
        public const string Feedback_Delete = "Feedback_Delete";
        #endregion

        #region Cart
        public const string Cart_Upsert = "Cart_Upsert";
        public const string Cart_All = "Cart_All";
        public const string Cart_Delete = "Cart_Delete";
        #endregion
        #region Category
        public const string Category_Upsert = "Category_Upsert";
        public const string Category_ById = "Category_ById";
        public const string Category_All = "Category_All";
        public const string Category_ActInact = "Category_ActInact";
        public const string Category_Delete = "Category_Delete";
        #endregion
        #region AddressMaster
        public const string AddressMaster_Upsert = "AddressMaster_Upsert";
        public const string AddressMaster_All = "AddressMaster_All";
        public const string AddressMaster_ById = "AddressMaster_ById";
        public const string AddressMaster_ActInAct = "AddressMaster_ActInAct";
        public const string AddressMaster_Delete = "AddressMaster_Delete";
        public const string AddressMaster_ByUserId = "AddressMaster_ByUserId";
        public const string CityMaster_ByStateMasterId = "CityMaster_ByStateMasterId";
        public const string StateMaster_ByCountryMasterId = "StateMaster_ByCountryMasterId";
        // public const string Users_ById = "Users_ById  ";
        #endregion
        #region Customer
        public const string Customer_Upsert = "Customer_Upsert";
        public const string Customer_All = "Customer_All";
        public const string MasterCountry_All = "MasterCountry_All";
        public const string MasterState_All = "MasterState_All";
        public const string MasterCity_All = "MasterCity_All";
        public const string Customer_ById = "Customer_ById";
        public const string Customer_ActInAct = "Customer_ActInAct";
        public const string Customer_Delete = "Customer_Delete";
        #endregion
        
        #region Student
        public const string Student_Upsert = "Student_Upsert";
        public const string Student_All = "Student_All";
        public const string Department_All = "Department_All";
        public const string Student_ById = "Student_ById";
        public const string Student_Delete = "Student_Delete";
        #endregion

        #region Employees
        public const string Employees_Upsert = "Employees_Upsert";
        public const string Employees_All = "Employees_All";
        public const string MasterEmCountry_All = "MasterCountry_All";
        public const string MasterEmState_All = "MasterState_All";
        public const string MasterEmCity_All = "MasterCity_All";
        public const string Employees_ById = "Employees_ById";
        public const string Employees_ActInAct = "Employees_ActInAct";
        public const string Employees_Delete = "Employees_Delete";
        #endregion
        #region AdminType
        public const string AdminType_All = "AdminType_All";
        #endregion
        #region Appointment
        public const string Appointment_Upsert = "Appointment_Upsert";
        public const string Appointment_All = "Appointment_All";
        public const string Appointment_ById = "Appointment_ById";
        public const string Appointment_StatusChange = "Appointment_StatusChange";
        public const string Appointment_ChangeDate = "Appointment_ChangeDate";
        public const string Appointment_Delete = "Appointment_Delete";
        public const string MasterAppointmentStatus_All = "MasterAppointmentStatus_All";
        #endregion

        #region City
        public const string City_Upsert = "City_Upsert";
        public const string City_All = "City_All";
        public const string City_ById = "City_ById";
        public const string City_Delete = "City_Delete";
        public const string City_ActInact = "City_ActInact";
        #endregion

        #region State
        public const string State_Upsert = "State_Upsert";
        public const string State_All = "State_All";
        public const string State_ById = "State_ById";
        public const string State_Delete = "State_Delete";
        public const string State_ActInact = "State_ActInact";
        #endregion

        #region CountryMaster
        public const string CountryMaster_All = "CountryMaster_All";
        #endregion
        #region Admin
        public const string Admin_SignOut = "Admin_SignOut";
        public const string Admin_SignIn = "Admin_SignIn";
        //public const string Admin_ChangePassword = "Admin_ChangePassword";
        public const string Admin_Upsert = "Admin_Upsert";
        public const string Admin_ById = "Admin_ById";
        public const string Admin_All = "Admin_All";
        public const string Admin_Delete = "Admin_Delete";
        public const string Admin_ActInact = "Admin_ActInact";
        public const string Home_All = "Home_All";
        #endregion




    }
}
