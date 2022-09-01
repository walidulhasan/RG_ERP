using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.IdentityEntities
{
    public class ApplicationRole : IdentityRole<int>
    {
        
        public bool IsSuperAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
