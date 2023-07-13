using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace KnowledgeApp_Test.App_Start
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter  // ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (HttpContext.Current.Session["UserName"] == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(
        //               new RouteValueDictionary{{ "controller", "Login" },
        //                              { "action", "Login" }

        //                                 });
        //    }


        //    base.OnActionExecuting(filterContext);
        //}

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller  
                return;
            }

            // Check for authorization  
            if (HttpContext.Current.Session["UserName"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }
        }
    }
}