using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RG.Application.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Services
{
    //IIS in-process hosting. 
    //public class ClaimsTransformer : IClaimsTransformation
    //{
    //    private readonly IHttpContextAccessor _httpContextAccessor;

    //    public ClaimsTransformer(IHttpContextAccessor httpContextAccessor)
    //    {
    //        _httpContextAccessor = httpContextAccessor;

    //    }
    //    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    //    {
    //        var companyID = _httpContextAccessor.HttpContext.Request.Cookies[SessionKey.COMPANY_ID];
    //        var businessid = _httpContextAccessor.HttpContext.Request.Cookies[SessionKey.BusinessID];

    //       ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("now", DateTime.Now.ToString()));
    //        return Task.FromResult(principal);
    //    }
    //}
}
