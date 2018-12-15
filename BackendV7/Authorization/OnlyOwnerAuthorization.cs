using BackendV7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BackendV7.Authorization
{
    public class OnlyOwnerAuthorization : AuthorizeAttribute
    {

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authorized = base.IsAuthorized(actionContext);
            if (!authorized)
            {
                return false;
            }

            var context = actionContext.RequestContext;
            var user = context.Principal.Identity.IsAuthenticated ? context.Principal.Identity.Name : string.Empty;
            var action = actionContext.ActionDescriptor.ActionName;
            var controller = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            

            /*var rd = actionContext.

            var id = rd.Values["id"];
            action
            var userName = httpContext.User.Identity.Name;

            Submission submission = unit.SubmissionRepository.GetByID(id);
            User user = unit.UserRepository.GetByUsername(userName);*/

            return true;
        }



    }


}
