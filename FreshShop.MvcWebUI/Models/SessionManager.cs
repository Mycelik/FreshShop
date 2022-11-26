using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreshShop.MvcWebUI.Models
{
    public static class SessionManager
    {
        public static User ActiveUser
        {
            get
            {
                return HttpContext.Current.Session["ActiveUser"] as User;
            }
            set
            {
                HttpContext.Current.Session.Add("ActiveUser", value);
            }
        }
    }
}