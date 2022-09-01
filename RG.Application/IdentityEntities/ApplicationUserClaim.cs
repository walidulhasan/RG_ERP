using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.IdentityEntities
{
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public ApplicationUserClaim()
        {

        }
        public ApplicationUserClaim(int userID, string claimType, string claimValue, int? projectID)
        {
            UserId = userID;
            ClaimType = claimType;
            ClaimValue = claimValue;
            ProjectID = projectID;
        }

        public int? ProjectID { get; set; }
    }
}
