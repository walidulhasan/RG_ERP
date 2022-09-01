using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.IdentityEntities
{
    public class ApplicationRoleClaims : IdentityRoleClaim<int>
    {
        public ApplicationRoleClaims()
        {

        }
        public ApplicationRoleClaims(int roleID, string claimType, string claimValue, int? projectID)
        {
            RoleId = roleID;
            ClaimType = claimType;
            ClaimValue = claimValue;
            ProjectID = projectID;
        }

        public int? ProjectID { get; set; }
    }
}
