using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminWebApp.Utilities
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var adminID = context.HttpContext.Session.GetInt32("admin");
            if (!adminID.HasValue)
                context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
