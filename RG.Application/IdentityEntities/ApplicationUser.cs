using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
       
        public int? EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string UserType { get; set; }

        public bool IsActive { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public int? SourceUserID { get; set; }
        public int ? DeviceDependencyTypeID { get; set; }


    }
}
