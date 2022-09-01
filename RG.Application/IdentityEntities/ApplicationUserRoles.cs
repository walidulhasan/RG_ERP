using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.IdentityEntities
{
    public class ApplicationUserRoles : IdentityUserRole<int>
    {
        [Key, Column(Order = 2)]
        public int ProjectID { get; set; }

        [Key, Column(Order = 3)]
        public int CompanyID { get; set; }
    }
}
