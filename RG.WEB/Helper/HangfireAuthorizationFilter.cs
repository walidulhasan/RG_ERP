using Hangfire.Annotations;
using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Helper
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public HangfireAuthorizationFilter()
        {

        }
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var role = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            if(role != null && role.Value.ToString()== "Super Admin")
            {
                return true;
            }
            return false;
        }
    }
}
