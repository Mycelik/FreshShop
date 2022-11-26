using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FreshShop.MvcWebUI.Models.Filters
{
    public class RoleFilter: FilterAttribute,IActionFilter
    {
        private List<int> AllowedRoles { get; set; }
        public RoleFilter(params int[] allowedRoleIds)
        {
            AllowedRoles = allowedRoleIds.ToList();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            User activeUser = SessionManager.ActiveUser;

            if(!AllowedRoles.Contains(activeUser.RoleId.Value))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));

                //filterContext.Result = new ViewResult()
                //{
                //    ViewName ="~/Areas/Yonetim/Views/Shared/NotAllowed.cshtml"
                //};
            }

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}