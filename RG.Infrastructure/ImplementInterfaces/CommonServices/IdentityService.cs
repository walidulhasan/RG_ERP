using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.IdentityEntities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RG.Application.Common.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace RG.Infrastructure.ImplementInterfaces.CommonServices
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly IWebHostEnvironment _env;
        public IdentityService(
             UserManager<ApplicationUser> userManager,
             IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
             IAuthorizationService authorizationService, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _env = env;
        }
        public  async Task<bool> AuthorizeAsync(int userID, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userID);

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<string> GetUserNameAsync(int userID)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userID);

            return user.UserName;
        }

        public async Task<bool> IsInRoleAsync(int userID, string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userID);

            return await _userManager.IsInRoleAsync(user, roleName);
        }



        public async Task<RResult> UserPasswordValidationWhenChange(int userID, string currentPassword, string newPassword)
        {
            RResult result = new RResult();
            result.result = 0;
            var userinfo = await _userManager.Users.FirstAsync(b => b.Id == userID && b.IsActive == true && b.IsRemoved == false);
            if (userinfo != null)
            {
                var verifyPassword = _userManager.PasswordHasher.VerifyHashedPassword(userinfo, userinfo.PasswordHash, currentPassword);
                if(verifyPassword == PasswordVerificationResult.Success)
                {
                    string authenticationURL = "";
                    if (_env.IsDevelopment())
                    {
                        authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                    }
                    else
                    {
                        authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                    }

                    using (var httpClient = new HttpClient())
                    {
                        var apiUrl = $"{authenticationURL}UserInfoForOther/ChangePassword?secret={userinfo.SecurityStamp}&id={userinfo.Id}&password={newPassword}";//currentUserService.RoleID
                        using var response = await httpClient.GetAsync(apiUrl);
                        if (response != null)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                              result = JsonConvert.DeserializeObject<RResult>(apiResponse);
                            return result;
                        }
                        result.message = "Network problem.";
                    }

                }
                else
                {
                    result.message = "your current password is not correct.";
                }
            }
            else
            {
                result.message = "your are trying wrong way.";
            }

            return result;
        }
    }
}
