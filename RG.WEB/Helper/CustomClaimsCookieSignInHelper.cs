using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using RG.Application.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Helper
{
    /*
    public class CustomClaimsCookieSignInHelper<TUser> where TUser:ApplicationUser
    {
        private readonly SignInManager<TUser> _signInManager;
        public CustomClaimsCookieSignInHelper(SignInManager<TUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task SignInUserAsync(TUser user, bool isPersistent, IEnumerable<Claim> customClaims)
        {
            var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            
            if (customClaims != null && claimsPrincipal?.Identity is ClaimsIdentity claimsIdentity)
            {
                claimsIdentity.AddClaims(customClaims);
            }
            
            //foreach(var claim in customClaims)
            //{
            //    claimsPrincipal.Identities.First().AddClaim(claim);
            //}
            var schema = IdentityConstants.ApplicationScheme;
            await _signInManager.Context.SignInAsync(IdentityConstants.ApplicationScheme,
                claimsPrincipal,
                new AuthenticationProperties { IsPersistent = isPersistent,ExpiresUtc=DateTime.Now.AddHours(10) });
        }
    }
    */
}
