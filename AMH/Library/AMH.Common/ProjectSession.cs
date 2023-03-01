using System.Web;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace AMH.Common
{
    public class ProjectSession
    {
        public static long AdminId
        {
            get
            {
                if (HttpContext.Current.Session["AdminId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AdminId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminId"] = value;
            }
        }
        public static long Users_Id
        {
            get
            {
                if (HttpContext.Current.Session["Users_Id"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["Users_Id"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Users_Id"] = value;
            }
        }
        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session["Email"] == null)
                {
                    return "-"; 
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Email"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }
        public static string UserType
        {
            get
            {
                if (HttpContext.Current.Session["UserType"] == "")
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["UserType"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserType"] = value;
            }
        }

        public static string AdminName
        {
            get
            {
                if (HttpContext.Current.Session["AdminName"] == "")
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AdminName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminName"] = value;
            }
        }

        public static string LoginAdminEmail
        {
            get
            {
                if (HttpContext.Current.Session["LoginAdminEmail"] == "")
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["LoginAdminEmail"]);
                }
            }

            set
            {
                HttpContext.Current.Session["LoginAdminEmail"] = value;
            }
        }

    }
}