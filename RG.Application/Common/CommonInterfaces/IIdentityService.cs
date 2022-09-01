using RG.Application.Common.Models;
using RG.Application.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.CommonInterfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(int userID);

        Task<bool> IsInRoleAsync(int userID, string roleName);

        Task<bool> AuthorizeAsync(int userID, string policyName);
        Task<RResult> UserPasswordValidationWhenChange(int userID, string currentPassword,string newPassword);

    }
}
